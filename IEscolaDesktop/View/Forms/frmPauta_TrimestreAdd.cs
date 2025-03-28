using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmPauta_TrimestreAdd : XtraUserControl
    {
        ITrimestre DataRepository;

        bool IsValidate = false;

        public frmPauta_TrimestreAdd(Pautas_Trimestres usuarios = null)
        {
            InitializeComponent();

            DataRepository = new TrimestreRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };
            txtDescricao.EditValueChanged += delegate { ChangeValudations(txtDescricao); };
            txtPeriodoFim.EditValueChanged += delegate { ChangeValudations(txtPeriodoFim); };
            txtPeriodoInicio.EditValueChanged += delegate { ChangeValudations(txtPeriodoInicio); };
            txtTolerancia.EditValueChanged += delegate { ChangeValudations(txtTolerancia); };
            
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            txtPeriodoFim.DateTime = DateTime.Now;
            txtPeriodoInicio.DateTime = DateTime.Now;

            if (usuarios != null) {
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtDescricao.EditValue = usuarios.Descricao;
                txtCodigo.EditValue = usuarios.TrimestreID;

                txtPeriodoInicio.DateTime = usuarios.PeriodoInicio;
                txtPeriodoFim.DateTime = usuarios.PeriodoFim;

                txtTolerancia.Value = usuarios.Tolerancia;

                txtDescricao.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }
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
                    var apagar = await DataRepository.Excluir(x => x.TrimestreID == data);

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

                var ID = string.IsNullOrWhiteSpace(txtCodigo.Text) == true ? 0 : (int)txtCodigo.EditValue;

                // save Data
                var data = new Pautas_Trimestres
                {
                    TrimestreID = ID,
                    Descricao = txtDescricao.Text.Trim(),
                    PeriodoInicio = (DateTime) txtPeriodoInicio.DateTime,
                    PeriodoFim = (DateTime) txtPeriodoFim.DateTime,
                    Tolerancia = Convert.ToInt32(txtTolerancia.Value), 
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.TrimestreID == ID) > 0 :
                                        await DataRepository.Guardar(data, true);

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
            var dataResult = await DataRepository.Get(x => x.Descricao == txtDescricao.Text, null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.TrimestreID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtDescricao.SelectAll();
                        txtDescricao.Focus();

                        return true;
                    } 
                }
            }
            return false;
        }

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtTolerancia.Text = string.Empty;
            txtTitulo.Text = "[Novo]";
            txtDescricao.Focus();
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

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Descricao
                if (control.Name.Equals(txtDescricao.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                        !string.IsNullOrWhiteSpace(txtPeriodoInicio.Text) &&
                        !string.IsNullOrWhiteSpace(txtPeriodoFim.Text))
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                    else 
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                          !string.IsNullOrWhiteSpace(txtPeriodoInicio.Text) &&
                          !string.IsNullOrWhiteSpace(txtPeriodoFim.Text) &&
                          !string.IsNullOrWhiteSpace(txtTolerancia.Text))
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
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
                if (windowsUIButtonPanel1.Enabled == true)
                    WindowsUIButtonPanel1_ButtonClick(null, null);
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
        #endregion
    }
}