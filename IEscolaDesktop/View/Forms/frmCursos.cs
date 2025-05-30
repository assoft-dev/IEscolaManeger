﻿using DevExpress.XtraBars.Alerter;
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
    public partial class frmCursos : XtraUserControl
    {
        ICursos DataRepository;

        List<Cursos>  DataOriginalList;

        AlertControl alert = null;

        public frmCursos()
        {
            InitializeComponent();
            DataRepository = new CursosRepository();
            DataOriginalList = new List<Cursos>();

            LeituraInicial();

            txtPesquisar.EditValueChanged += delegate { LeituraFilter(); };
            txtPesquisar.ButtonClick += delegate { LeituraInicial(); };

            btnNovo.Click += BtnNovo_Click;
            gridControl1.DoubleClick += GridControl1_DoubleClick;

            // Menu de Contexto
            #region Menu Populat
            MenuPrinciapl.Opening += ContextMenuStrip1_Opening;
            gridControl1.ContextMenuStrip = MenuPrinciapl;

            btnApagar.Click += Apagar_Click;
            btnAtualizar.Click += Atualizar_Click;
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
                var buscas = cursosBindingSource.DataSource as List<Cursos>;
                if (buscas.Count != 0)
                {
                    rep.GetReport(new rptCursos(buscas), "." + Extension, Caminho);

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
                btnApagar.Enabled = true;
                btnAtualizar.Enabled = true;
                btnRelatorios.Enabled = true;
                btnReportdatabase.Enabled = true;
            }
            else
            {
                btnApagar.Enabled = false;
                btnAtualizar.Enabled = false;
                btnRelatorios.Enabled = false;
                btnReportdatabase.Enabled = false;
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            var forms = OpenFormsDialog.ShowForm(null,
                   new frmCursosAdd(null));

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                LeituraInicial();
        }

        private void GridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                var result = cursosBindingSource.Current as Cursos;

                var forms = OpenFormsDialog.ShowForm(null,
                    new frmCursosAdd(result ?? null));

                if (forms == DialogResult.None || forms == DialogResult.Cancel)
                    LeituraInicial();
            }
        }

        private void LeituraFilter()
        {
            var data = DataOriginalList.FindAll(x => x.Descricao.ToUpper().Contains(txtPesquisar.Text.ToUpper()) ||
                                                         x.Sigla.ToUpper().Contains(txtPesquisar.Text.ToUpper()));
            cursosBindingSource.DataSource = data;
        }

        private async void LeituraInicial()
        {
            DataOriginalList = await DataRepository.GetAll();
            cursosBindingSource.DataSource = DataOriginalList;

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
            var user = cursosBindingSource.DataSource as List<Cursos>;
            if (user != null)
                GlobalReport.GetReport(new rptCursos(user), false);
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
                GridControl1_DoubleClick(null, null);
            else
            {
                Mensagens.Display("Atualização!", 
                                  "Por favor selecione alguma informação na tela!...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                    var result = cursosBindingSource.Current as Cursos;
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
