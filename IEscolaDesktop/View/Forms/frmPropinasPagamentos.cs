﻿using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmPropinasPagamentos : XtraUserControl
    {
        IPropinasPagamentos DataRepository;

        List<PropinasPagamentos>  DataOriginalList;

        AlertControl alert = null;

        public frmPropinasPagamentos()
        {
            InitializeComponent();
            DataRepository = new PropinasPagamentosRepository();
            DataOriginalList = new List<PropinasPagamentos>();

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
            #endregion

            alert = new AlertControl();
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
                   new frmPropinasPagamentosAdd(null));

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                LeituraInicial();
        }

        private void GridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                var result = propinasPagamentosBindingSource.Current as PropinasPagamentos;

                var forms = OpenFormsDialog.ShowForm(null,
                    new frmPropinasPagamentosAdd(result ?? null));

                if (forms == DialogResult.None || forms == DialogResult.Cancel)
                    LeituraInicial();
            }
        }

        private void LeituraFilter()
        {
            var data = DataOriginalList.FindAll(x => x.Descricao.ToUpper().Contains(txtPesquisar.Text.ToUpper()) ||
                                                         x.PropinasConfig.Meses.ToString().Contains(txtPesquisar.Text.ToUpper()));
            propinasPagamentosBindingSource.DataSource = data;
        }

        private async void LeituraInicial()
        {
            DataOriginalList = await DataRepository.GetAll();
            propinasPagamentosBindingSource.DataSource = DataOriginalList;

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
                    var result = propinasPagamentosBindingSource.Current as PropinasPagamentos;
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
