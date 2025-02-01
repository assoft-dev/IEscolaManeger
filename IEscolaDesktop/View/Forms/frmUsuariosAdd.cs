namespace IEscolaDesktop.View.Forms
{

    using DevExpress.XtraBars.Docking2010;
    using DevExpress.XtraEditors;
    using IEscolaDesktop.View.Helps;
    using IEscolaEntity.Controllers.Helps;
    using IEscolaEntity.Controllers.Interfaces;
    using IEscolaEntity.Controllers.Repository;
    using IEscolaEntity.Models;
    using IEscolaEntity.Models.Helps;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class frmUsuariosAdd : XtraUserControl
    {
        IUsuarios usuariosRepository;
        IGrupos gruposRepository;

        public frmUsuariosAdd(Usuarios usuarios = null)
        {
            InitializeComponent();

            usuariosRepository = new UsuariosRepository();
            gruposRepository = new GruposRepository();

            txtSenha.ButtonClick += delegate { TxtSenha_ButtonClick(txtSenha); };
            txtSenhaRepetir.ButtonClick += delegate { TxtSenha_ButtonClick(txtSenhaRepetir); };

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };
            txtFirstName.EditValueChanged += delegate { ChangeValudations(txtFirstName); };
            txtLastName.EditValueChanged += delegate { ChangeValudations(txtLastName); };
            txtEmail.EditValueChanged += delegate { ChangeValudations(txtEmail); };
            txtSenha.EditValueChanged += delegate { ChangeValudations(txtSenha); };
            txtSenhaRepetir.EditValueChanged += delegate { ChangeValudations(txtSenhaRepetir); };
            txtGrupos.EditValueChanged += delegate { ChangeValudations(txtGrupos); };

            btnBuscarGrupos.Click += BtnBuscarGrupos_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {              
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtFirstName.EditValue = usuarios.FirstName;
                txtLastName.EditValue = usuarios.LastName;
                txtEmail.EditValue = usuarios.Email;

                txtSenha.EditValue = usuarios.Senha;
                txtSenhaRepetir.EditValue = usuarios.Senha;

                txtEstado.EditValue = usuarios.Estado;
                txtData.EditValue = usuarios.Data;
                txtGrupos.EditValue = usuarios.GruposID;
                txtCodigo.EditValue = usuarios.UsuariosID;

                txtFirstName.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
                txtData.DateTime = DateTime.Now;
            }

            this.Load += FrmUsuariosAdd_Load;
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmGruposAdd(null));

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult = await gruposRepository.GetAll();
            gruposBindingSource.DataSource = dataResult;

            var DataResultEstados = Enum.GetValues(typeof(Estado));
            txtEstado.Properties.DataSource = DataResultEstados;
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
                    var apagar = await usuariosRepository.Excluir(x => x.UsuariosID == data);

                    if (apagar)
                    {
                        Mensagens.Display("Apagar Dados",
                                          "Dados apagados com exito",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                    }
                }
            }     
        }

        private async void Guardar()
        {
            if (!await ValidationDatabase())
            {
                // save Data
                var data = new Usuarios
                {
                    UsuariosID = string.IsNullOrWhiteSpace(txtCodigo.Text) == true ? 0 : (int)txtCodigo.EditValue,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Senha = txtSenha.Text.Trim(),
                    Data = txtData.DateTime,
                    Estado = (Estado)txtEstado.EditValue,
                    GruposID = (int)txtGrupos.EditValue,
                    ImagemURL = null,
                };

                var dataResult = await usuariosRepository.GuardarUser(data);

                if (dataResult)
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
            var dataResult = await usuariosRepository.Get(x => x.Email == txtEmail.Text, null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if(dataResult.UsuariosID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Email", "Este Email já temos em nossa base de Dados!",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);

                        txtEmail.SelectAll();
                        txtEmail.Focus();

                        return true;
                    }
                }
            }
            return false;
        }

        private void TxtSenha_ButtonClick(ButtonEdit txtPin)
        {
            if (txtPin != null)
            {
                if (txtPin.Name.Equals(txtPin.Name))
                {
                    if (txtPin.Properties.UseSystemPasswordChar)
                        txtPin.Properties.UseSystemPasswordChar = false;
                    else
                        txtPin.Properties.UseSystemPasswordChar = true;
                }
                else
                {
                    if (txtSenha.Properties.UseSystemPasswordChar)
                        txtSenha.Properties.UseSystemPasswordChar = false;
                    else
                        txtSenha.Properties.UseSystemPasswordChar = true;
                }     
            }
        }

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtCodigo.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSenha.Text = string.Empty;
            txtSenhaRepetir.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtData.DateTime = DateTime.Now;
            txtTitulo.Text = "[Novo]";
            txtFirstName.Focus();
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
                if (control.Name.Equals(txtFirstName.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtLastName.Text) &&
                            !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenha.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenhaRepetir.Text) &&
                            !(string.IsNullOrWhiteSpace(txtGrupos.Text) || txtGrupos.Text == "[Selecione o Grupo por favor]"))
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

                #region LastName
                if (control.Name.Equals(txtLastName.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtLastName.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                            !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenha.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenhaRepetir.Text) &&
                            !(string.IsNullOrWhiteSpace(txtGrupos.Text) || txtGrupos.Text == "[Selecione o Grupo por favor]"))
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

                #region Email
                if (control.Name.Equals(txtEmail.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                            !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenha.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenhaRepetir.Text) &&
                            !(string.IsNullOrWhiteSpace(txtGrupos.Text) || txtGrupos.Text == "[Selecione o Grupo por favor]"))
                        {
                            // Comparar se é mesmo um EMail
                            var data = EmailValidade.GetIstance().IsValidEmail(txtEmail.Text);

                            if (data)
                                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                            else
                                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
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

                #region Grupos
                if (control.Name.Equals(txtGrupos.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtGrupos.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                            !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenha.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenhaRepetir.Text) &&
                            !string.IsNullOrWhiteSpace(txtEmail.Text))
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

                #region Senha Nova
                if (control.Name.Equals(txtSenha.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtSenha.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                            !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                            !(string.IsNullOrWhiteSpace(txtGrupos.Text) || txtGrupos.Text == "[Selecione o Grupo por favor]") &&
                            !string.IsNullOrWhiteSpace(txtSenhaRepetir.Text) &&
                            !string.IsNullOrWhiteSpace(txtEmail.Text))
                        {
                            Comparacao_Senhas(txtSenha);
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

                #region Senha Nova Repetir
                if (control.Name.Equals(txtSenhaRepetir.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtSenhaRepetir.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                            !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                            !(string.IsNullOrWhiteSpace(txtGrupos.Text) || txtGrupos.Text == "[Selecione o Grupo por favor]") &&
                            !string.IsNullOrWhiteSpace(txtSenha.Text) &&
                            !string.IsNullOrWhiteSpace(txtEmail.Text))
                        {
                            Comparacao_Senhas(txtSenhaRepetir);
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

        private void Comparacao_Senhas(Control control)
        {
            #region Verificacao se a senha e igual           
            string SenhaNova = txtSenha.Text.Trim();
            string SenhaNovaRepetir = txtSenhaRepetir.Text.Trim();

            if (SenhaNova == SenhaNovaRepetir)
            {
                if (control.Text.Length >= 4)
                    windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                else
                    windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            }
            else
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            #endregion
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