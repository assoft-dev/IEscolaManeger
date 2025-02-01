using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaDesktop.View.ReportForms;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmUsuariosLogs : XtraUserControl
    {
        IUsuariosLogs DataRepository;

        List<UsuariosLogs>  DataOriginalList;

        AlertControl alert = null;

        public frmUsuariosLogs()
        {
            InitializeComponent();
            DataRepository = new LogsRepository();
            DataOriginalList = new List<UsuariosLogs>();

            LeituraInicial();

            txtPesquisar.EditValueChanged += delegate { LeituraFilter(); };
            txtPesquisar.ButtonClick += delegate { LeituraInicial(); };

            // Menu de Contexto
            #region Menu Populat
            MenuPrinciapl.Opening += ContextMenuStrip1_Opening;
            gridControl1.ContextMenuStrip = MenuPrinciapl;

            btnRelatorios.Click += delegate { gridControl1.ShowRibbonPrintPreview(); };
            btnReportdatabase.Click += BaseDeDados_Click;
            #endregion

            btnPDF.Click += delegate { BtnPDF_Click("PDF"); };
            btnXLS.Click += delegate { BtnPDF_Click("XLS"); };

            alert = new AlertControl();
        }

        private void BtnPDF_Click(string Extension)
        {
            var data = GlobalArquivos.GetLocalData(LocalFolder.REPORT, DateTime.Now.ToString("dd-MM-yyyy"));

            //Imprimir Documento em PDF
            string Caminho = string.Format(data + "\\{0}.{1}", DateTime.Now.Ticks, Extension);
            using (ReportDisposed rep = new ReportDisposed())
            {
                //Busca dos valores
                var buscas = usuariosLogsBindingSource.DataSource as List<UsuariosLogs>;
                if (buscas.Count != 0)
                {
                    rep.GetReport(new rptUsuarioLogs(buscas), "." + Extension, Caminho);

                    var form = Application.OpenForms;
                    foreach (Form item in form)
                    {
                        if (item.Name != typeof(frmMenu).Name)
                        {
                            alert.Show(item, "Impressão de Documentos!",
                                             "Seu documento esta pronto e foi gerado com sucesso! Queira por favor conferir");

                            alert.AlertClick += delegate
                            {
                                new Process { StartInfo = new ProcessStartInfo(Caminho) { UseShellExecute = true } }.Start();
                            };
                            return;
                        }
                    }
                   
                }
                else {
                    Mensagens.Display("Falta de informação na Tabela",
                                      "Infelimente não temos informação para Imprimir em PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((gridView1.SelectedRowsCount > 0) || (gridView1.FocusedRowHandle > 0))
            {
                btnRelatorios.Enabled = true;
                btnReportdatabase.Enabled = true;
            }
            else
            {
                btnRelatorios.Enabled = false;
                btnReportdatabase.Enabled = false;
            }
        }

        private void LeituraFilter()
        {
            var data = DataOriginalList.FindAll(x => x.Descricao.ToUpper().Contains(txtPesquisar.Text.ToUpper()) ||
                                                     x.Local.ToUpper().Contains(txtPesquisar.Text.ToUpper()));
            usuariosLogsBindingSource.DataSource = data;
        }

        private async void LeituraInicial()
        {
            DataOriginalList = await DataRepository.GetAll();
            usuariosLogsBindingSource.DataSource = DataOriginalList;

            if (DataOriginalList.Count > 0)
            {
                btnPDF.Enabled = true;
                btnXLS.Enabled = true;
            }
            else {           
                btnPDF.Enabled = false;
                btnXLS.Enabled = false;
            }
        }

        #region Contexto Menu
        private void BaseDeDados_Click(object sender, EventArgs e)
        {
            var user = usuariosLogsBindingSource.DataSource as List<UsuariosLogs>;
            if (user != null)
                GlobalReport.GetReport(new rptUsuarioLogs(user), false);
        }

        private async void Apagar_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var msg = Mensagens.Display("Apagar",  
                                           "Apagar uma informação implica perda de informação!\nPretendes mesmo continuar?!...",
                                           MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (msg == DialogResult.OK)
                {
                    var result = usuariosLogsBindingSource.Current as UsuariosLogs;
                    try
                    {
                        if (result != null)
                        {
                            var resultDelete = await DataRepository.Excluir(result);
                            if (resultDelete)
                            {
                                Mensagens.Display("Apagar Informação", "Informação selecionada Pagada com Exito!...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LeituraInicial();
                            }
                            else
                                Mensagens.Display("Tentativa Falhada", "Não foi possivel apagar a Informação selecionada!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception exe)
                    {
                        XtraMessageBox.Show("Não foi possivel apagar a Informação selecionada!...\n Verifique o as informações Adicionais: Talvez seja o facto de haver informções que dependem desta que estas a tentar apagar, e apagar este informação implica perder toda a informção delecionada comprimetendo assim a estabilidade do sistema {" + exe.Message + "}", "Tentativa Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                XtraMessageBox.Show("Por favor selecione alguma informação na tela!...");
        }
      
        #endregion
    }
}
