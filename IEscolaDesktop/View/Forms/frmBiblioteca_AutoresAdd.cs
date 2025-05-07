using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Controllers.Repository.Biblioteca;
using IEscolaEntity.Models.Biblioteca;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmBiblioteca_AutoresAdd : XtraUserControl
    {
        IAutores DataRepository;
        IPais paisRepository;
        bool IsValidate = false;

        public frmBiblioteca_AutoresAdd(Autores usuarios = null)
        {
            InitializeComponent();

            DataRepository = new AutoresRepository();
            paisRepository = new PaisRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };
            txtFIrstName.EditValueChanged += delegate { ChangeValudations(txtFIrstName); };
            txtLastName.EditValueChanged += delegate { ChangeValudations(txtLastName); };
            txtData.EditValueChanged += delegate { ChangeValudations(txtData); };
            txtPais.EditValueChanged += delegate { ChangeValudations(txtPais); };

            btnBuscarGrupos.Click += BtnBuscarGrupos_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";
                txtFIrstName.EditValue = usuarios.FirstName;
                txtLastName.EditValue = usuarios.LastName;
                txtData.EditValue = usuarios.DataNascimento.Date;
                txtPais.EditValue = usuarios.PaisID;
                txtCodigo.EditValue = usuarios.AutoresID;

                txtFIrstName.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmBiblioteca_PaisAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult = await paisRepository.GetAll();
            paisBindingSource.DataSource = dataResult;
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
                    var apagar = await DataRepository.Excluir(x => x.AutoresID == data);

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
                var ID = string.IsNullOrWhiteSpace(txtCodigo.Text)  ? 0 : (int)txtCodigo.EditValue;

                // save Data
                var data = new Autores
                { 
                    AutoresID = ID,
                    FirstName = txtFIrstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    PaisID = (int) txtPais.EditValue,
                    DataNascimento = txtData.DateTime
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.AutoresID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => (x.FirstName.ToUpper() == txtFIrstName.Text.ToUpper() &&
                                                            x.LastName.ToUpper() == txtLastName.Text.ToUpper()), null);


            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.AutoresID != Convert.ToInt32(txtCodigo.Text))
                        return ResultValuesExiste();
                }
                else
                    return ResultValuesExiste();
            }
            return false;
        }

        private bool ResultValuesExiste()
        {
            Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Error);
            txtFIrstName.SelectAll();
            txtFIrstName.Focus();
            return true;
        }

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtCodigo.Text = string.Empty;
            txtFIrstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtData.DateTime = DateTime.Now;
            txtTitulo.Text = "[Novo]";
            txtFIrstName.Focus();
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
                #region FirstName
                if (control.Name.Equals(txtFIrstName.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtFIrstName.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtLastName.Text) &&
                            !(string.IsNullOrWhiteSpace(txtPais.Text) || txtPais.Text == "[Selecione a o pais por favor]"))
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

                #region Grupos
                if (control.Name.Equals(txtPais.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtPais.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtFIrstName.Text))
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