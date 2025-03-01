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
    public partial class frmPropinasPagamentosAdd : XtraUserControl
    {
        IPropinasPagamentos DataRepository;
        IPropinasConfig propinasConfigRepository;
        IEstudantes EstudantesRepository;
        bool IsValidate = false;

        public frmPropinasPagamentosAdd(PropinasPagamentos usuarios = null)
        {
            InitializeComponent();

            DataRepository = new PropinasPagamentosRepository();
            propinasConfigRepository = new PropinasConfigRepository();
            EstudantesRepository = new EstudantesRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };
            txtDescricao.EditValueChanged += delegate { ChangeValudations(txtDescricao); };
            txtEstudante.EditValueChanged += delegate { ChangeValudations(txtEstudante); };

            btnPropinasConfig.Click += BtnBuscar1Grupos_Click;
            btnEstudantes.Click += BtnBuscar2Grupos_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtDescricao.EditValue = usuarios.Descricao;
                txtPropinasConfig.EditValue = usuarios.PropinasConfigID;
                txtEstudante.EditValue = usuarios.EstudanteID;
                txtCodigo.EditValue = usuarios.PropinasPagamentosID;

                txtDescricao.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;
            txtEstudante.Properties.NullText = estudanteLabel;
            txtPropinasConfig.Properties.NullText = propinasconfigLabel;
        }

        private void BtnBuscar1Grupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmPropinasConfigAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        } 
        
        private void BtnBuscar2Grupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmEstudantesAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult = await propinasConfigRepository.GetAll();
            propinasConfigBindingSource.DataSource = dataResult;
            
            
            var dataResult1 = await EstudantesRepository.GetAll();
            estudantesBindingSource.DataSource = dataResult1;
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
                    var apagar = await DataRepository.Excluir(x => x.PropinasPagamentosID == data);

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
                var data = new PropinasPagamentos
                {
                    PropinasPagamentosID = ID,
                    Descricao = (string) txtDescricao.Text.Trim(),
                    PropinasConfigID = (int) txtPropinasConfig.EditValue,
                    EstudanteID = (int) txtEstudante.EditValue,
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.PropinasPagamentosID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => (x.Descricao == txtDescricao.Text &&
                                                            x.PropinasConfigID == 1), null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.PropinasPagamentosID != Convert.ToInt32(txtCodigo.Text))
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

        private string estudanteLabel = "[Selecione a configuração por favor]";
        private string propinasconfigLabel = "[Selecione a configuração por favor]";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Descricao
                if (control.Name.Equals(txtDescricao.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtEstudante.Text) || txtEstudante.Text == estudanteLabel) &&
                            !(string.IsNullOrWhiteSpace(txtPropinasConfig.Text) || txtPropinasConfig.Text == propinasconfigLabel))
                        { 
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        }
                        else {
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                        }
                    }
                    else {
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                }
                #endregion

                #region Estudantes
                else if (control.Name.Equals(txtEstudante.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtEstudante.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                            !(string.IsNullOrWhiteSpace(txtPropinasConfig.Text) || txtPropinasConfig.Text == propinasconfigLabel))
                        {
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        }
                        else
                        {
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                        }
                    }
                    else
                    {
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                }
                #endregion

                #region Propinas Config
                else if (control.Name.Equals(txtPropinasConfig.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtPropinasConfig.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                            !(string.IsNullOrWhiteSpace(txtEstudante.Text) || txtEstudante.Text == estudanteLabel))
                        {
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        }
                        else
                        {
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                        }
                    }
                    else
                    {
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                }
                #endregion

                else
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                          !(string.IsNullOrWhiteSpace(txtEstudante.Text) || txtEstudante.Text == estudanteLabel) &&
                          !(string.IsNullOrWhiteSpace(txtPropinasConfig.Text) || txtPropinasConfig.Text == propinasconfigLabel))
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