﻿using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Helps;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmPropinasConfigAdd : XtraUserControl
    {
        IPropinasConfig DataRepository;

        bool IsValidate = false;

        public frmPropinasConfigAdd(PropinasConfig usuarios = null)
        {
            InitializeComponent();

            DataRepository = new PropinasConfigRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };


            txtAno.EditValueChanged += TxtAno_EditValueChanged;
            txtMeses.EditValueChanged += TxtMeses_EditValueChanged;
                  
            txtExcedente.EditValueChanged += delegate { ChangeValudations(txtExcedente); };
            txtValor.EditValueChanged += delegate { ChangeValudations(txtValor); };
            
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtMeses.EditValue = usuarios.Meses;
                txtInicio.EditValue = usuarios.Inicia;
                txtTermina.EditValue = usuarios.Termina;
                txtExcedente.EditValue = usuarios.Excedente;
                txtValor.EditValue = usuarios.Valor;
                txtAno.EditValue = usuarios.Ano;

                txtCodigo.EditValue = usuarios.Inicia;
                txtMeses.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmPropinasConfigAdd_Load;

            txtMeses.Properties.NullText = mes;
            txtAno.Properties.NullText = anos;

            txtInicio.Value = DateTime.Now.StartOfMonth().Day;
            txtTermina.Value = DateTime.Now.EndOfMonth().Day;
        }

        private void TxtAno_EditValueChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(txtMeses.Text) || txtMeses.Text == mes))
                GetMes((Meses)txtMeses.EditValue, (Anos)txtAno.EditValue);

            ChangeValudations(txtAno);
        }

        private void TxtMeses_EditValueChanged(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(txtAno.Text) || txtAno.Text == anos))
                GetMes((Meses)txtMeses.EditValue, (Anos)txtAno.EditValue);

            ChangeValudations(txtMeses);
        }

        private void GetMes(Meses Mes, Anos Anos)
        {
            var data = new DateTime(AnosBuscar.GetAno(Anos), MesesBuscar.Get(Mes), 1);

            txtInicio.Value = data.StartOfMonth().Day;
            txtTermina.Value = data.EndOfMonth().Day;
        }

        private void FrmPropinasConfigAdd_Load(object sender, EventArgs e)
        {
            txtMeses.Properties.DataSource = Enum.GetValues(typeof(Meses));
            txtAno.Properties.DataSource = Enum.GetValues(typeof(Anos));
        }

        private void WindowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            if (e == null)
                Guardar();
            else
            {
                var dataResult = Convert.ToInt32(e.Button.Properties.Tag);
                switch (dataResult)
                {
                    case 0:
                        Limpar();
                        break;

                    case 1:
                        Guardar();
                        break;
                    default:
                        Apagar();
                        break;
                }
            }
        }

        private async void Apagar()
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                var msg = Mensagens.Display("Apagar Permanentemente", 
                                            "Queres apagar de forma permanente esta informação?", MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    var data = int.Parse(txtCodigo.Text);
                    var apagar = await DataRepository.Excluir(x => x.PropinasConfigID == data);

                    if (apagar)
                    {
                        Mensagens.Display("Apagar Dados",
                                          "Dados apagados com exito",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);

                        Limpar();
                    }
                }
            }     
        }

        private async void Guardar()
        {
            if (!await ValidationDatabase())
            {

                var ID = string.IsNullOrWhiteSpace(txtCodigo.Text)  ? 0 : (int) txtCodigo.EditValue;

                // save Data
                var data = new PropinasConfig
                {
                    PropinasConfigID = ID,
                    Inicia = Convert.ToInt32(txtInicio.Value),
                    Termina = Convert.ToInt32(txtTermina.Value),
                    Meses = (Meses) txtMeses.EditValue,
                    Excedente = Convert.ToInt32(txtExcedente.Value),
                    Valor = (decimal) txtValor.EditValue,
                    Ano = (Anos) txtAno.EditValue,
                };

                if (ID != 0)
                    IsValidate = await DataRepository.Guardar(data, X => X.PropinasConfigID == ID) > 0;
                else
                    IsValidate = await DataRepository.Guardar(data, true);                            

                if (IsValidate)
                {
                    Mensagens.Display("Guardar Dados", "Dados Guardados com muito Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpar();
                }
                else
                    Mensagens.Display("Impossivel Guardar Dados", "Não foi possivel guardar a informação requerida",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
            }      
        }

        private async Task<bool> ValidationDatabase()
        {
            var dataResult = await DataRepository.Get(x => x.Meses == (Meses) txtMeses.EditValue &&
                                                           x.Ano == (Anos) txtAno.EditValue &&
                                                           x.Valor == txtValor.Value, null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.PropinasConfigID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtMeses.SelectAll();
                        txtMeses.Focus();

                        return true;
                    } 
                }
                else
                {
                    Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                    txtMeses.SelectAll();
                    txtMeses.ShowPopup();

                    return true;
                }
            }
            return false;
        }

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtCodigo.Text = string.Empty;
            txtInicio.EditValue = string.Empty;
            txtTermina.EditValue = string.Empty;
            txtExcedente.EditValue = string.Empty;
            txtValor.EditValue = string.Empty;
            txtAno.EditValue = string.Empty;
            txtTitulo.Text = "[Novo]";
            txtMeses.Focus();
        }

        private void ChangeValidationCodigo()
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                windowsUIButtonPanel1.Buttons[1].Properties.Caption = "Atualizar";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = true;
            }
            else {
                windowsUIButtonPanel1.Buttons[1].Properties.Caption = "Guardar";
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }
        }
        private string mes = "[Selecione o Mês por favor]";
        private string anos = "[Selecione o ano por favor]";
        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Mes
                if (control.Name.Equals(txtMeses.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtMeses.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtValor.Text) || txtValor.Value == 0) &&
                            !(string.IsNullOrWhiteSpace(txtAno.Text) || txtAno.Text == anos))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Mes
                else if (control.Name.Equals(txtValor.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtValor.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtMeses.Text) || txtMeses.Text == mes) &&
                            !(string.IsNullOrWhiteSpace(txtAno.Text) || txtAno.Text == anos))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                else
                {
                    if (!(string.IsNullOrWhiteSpace(txtMeses.Text) || txtMeses.Text == mes) &&
                        (string.IsNullOrWhiteSpace(txtAno.Text) || txtAno.Text == anos) &&
                        !(string.IsNullOrWhiteSpace(txtValor.Text) || txtValor.Value == 0))
                    {
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                    }
                    else
                    {
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                }
            }
            else
            {
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            }
        }
       
        #region Teclas
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                // btnClose.DialogResult = DialogResult.OK;
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F1)
            {
                Limpar();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F2)
            {
                if (windowsUIButtonPanel1.Buttons[1].Properties.Enabled )
                    WindowsUIButtonPanel1_ButtonClick(null, null);
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion
    }
}