using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Helps;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmLogin1 : XtraForm
    {
        #region Mover
        private int cX, cY;
        private bool mover;
        #endregion

        IUsuarios UserRepository;

        public frmLogin1()
        {
            InitializeComponent();

            //btnPasswordReset.Visible = false;
            windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;

            //Mover o formulario
            PainelMover.MouseMove += Panel1_MouseMove;
            PainelMover.MouseDown += Panel1_MouseDown;
            PainelMover.MouseUp += Panel1_MouseUp;

            txtSenha.ButtonClick += TxtSenha_ButtonClick;

            /// Chamada dos metodos
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;
            btnPasswordReset.Click += BtnPasswordReset_Click;

            // Validar Somente quando estiver tudo OK
            txtUsuarios.EditValueChanged += delegate { ChangeValudations(txtUsuarios); };
            txtSenha.EditValueChanged += delegate { ChangeValudations(txtSenha); };
            pictureEdit1.Click += PictureEdit1_Click;

            lblReservado.Click += LblReservado_Click;

            // Instancias das classe referente
            UserRepository = new UsuariosRepository();
            UserRepository.DoGetCount<Usuarios>();

            txtUsuarios.EditValue = "admin";
            txtSenha.EditValue = "0000";
        }

        private void PictureEdit1_Click(object sender, System.EventArgs e)
        {
            using (var frm = new frmUsuarioHelps(frmUsuarioHelps.TelaHelps.Login))
            {
                var r = new OpenFormsDialog(this, null, frm);
                r.ShowDialog();
            }
        }

        private void LblReservado_Click(object sender, System.EventArgs e)
        {
            using (var frm = new frmUsuariosReservado())
            {
                var r = new OpenFormsDialog(this, null, frm);
                r.ShowDialog();
            }
        }

        private void ChangeValudations(Control controlValues)
        {
            if (controlValues != null)
            {
                if (!string.IsNullOrWhiteSpace(controlValues.Text))
                {
                    //Usuarios
                    if (controlValues.Name.Equals(txtUsuarios.Name))
                    {
                        if (!string.IsNullOrWhiteSpace(txtUsuarios.Text))
                        {
                            if (!(string.IsNullOrWhiteSpace(txtSenha.Text) || txtSenha.Text.Length < 4))
                            {
                                if (txtUsuarios.Text.Contains("@"))
                                {
                                    if (EmailValidade.GetIstance().IsValidEmail(txtUsuarios.Text))
                                        windowsUIButtonPanel1.Buttons[0].Properties.Enabled = true;
                                    else
                                        windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
                                }
                            }
                            else
                            {
                                windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
                            }
                        }
                        else
                        {
                            windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
                        }
                    }

                    // Senha
                    if (!string.IsNullOrWhiteSpace(txtSenha.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtUsuarios.Text))
                        {
                            if (txtSenha.Text.Length > 3)
                                windowsUIButtonPanel1.Buttons[0].Properties.Enabled = true;
                            else
                                windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;

                            if (txtUsuarios.Text.Contains("@"))
                            {
                                if (EmailValidade.GetIstance().IsValidEmail(txtUsuarios.Text))
                                    windowsUIButtonPanel1.Buttons[0].Properties.Enabled = true;
                                else
                                    windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
                            }
                        }
                        else
                        {
                            windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
                        }
                    }
                    else
                    {
                        windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
                    }
                }
                else
                    windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
            }
            else
            {
                windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
            }
        }

        private void BtnPasswordReset_Click(object sender, System.EventArgs e)
        {
            OpenFormsDialog.ShowForm(this, null, new frmUsuarioPasswordChage());
            //if (frm == DialogResult.OK)
            //{
            //    Mensagens.Display("Alteração de senha: ", "As alterações foram feitas no entanto resta apenas");
            //}
        }

        private void TxtSenha_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (txtSenha.Properties.UseSystemPasswordChar)
                txtSenha.Properties.UseSystemPasswordChar = false;
            else
                txtSenha.Properties.UseSystemPasswordChar = true;
        }

        // Login

        private async void WindowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (e is null)
                await LoginForms();
            else
            {
                // Validacoes
                if (e.Button.Properties.Tag.Equals("0"))
                    await LoginForms();
                else
                    CloseForms();
            }
        }

        private static void CloseForms()
        {
            var result = Mensagens.Display("Sair",
                                           "Queres realmente sair do sistema?",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (Form item in Application.OpenForms)
                {
                    if (!item.Visible)
                        item.Close();
                }
                Application.Exit();
            }
        }

        private void Limpar()
        {
            txtSenha.Text = string.Empty;
            txtUsuarios.Text = string.Empty;
            txtUsuarios.Focus();
        }

        private async Task LoginForms()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                if (Validadacao())
                {
                    var result = await UserRepository.Login(txtUsuarios.Text, txtSenha.Text);

                    switch (result.usuariosRetorno)
                    {
                        case UsuariosRetorno.Valido:

                            #region Opem Menu
                            // Entrar no menu
                            var frm = new frmMenu(result.Permission);

                            this.Hide();
                            frm.ShowDialog();

                            frm.FormClosed += delegate
                            {
                                foreach (Form item in Application.OpenForms)
                                {
                                    if (item.Name == typeof(frmLogin1).Name)
                                    {
                                        item.Show();
                                    }
                                }
                            };
                            #endregion

                            break;
                        case UsuariosRetorno.Invalido:
                            Mensagens.Display("Usuario ou Senha invalida!",
                                              "Queira por favor voltar a colocar a senha/Usuario por favor",
                                              MessageBoxButtons.OK,
                                              MessageBoxIcon.Error);

                            btnPasswordReset.Visible = true;

                            Limpar();

                            break;
                        case UsuariosRetorno.Desativado:
                            Mensagens.Display("Usuario: Desativado",
                                              "Tens que contactar o Admin do sistema por favor",
                                              MessageBoxIcon.Error);
                            Limpar();
                            break;
                        case UsuariosRetorno.Initial:

                            #region Chamar a alteração de Senhas
                            var frmUserForm = OpenFormsDialog.ShowForm(this, null,
                                                    new frmUsuarioPasswordChage());
                            #endregion

                            break;
                        case UsuariosRetorno.PrimeiraVez:
                            break;
                        case UsuariosRetorno.Permissoes_Invalida:
                            break;
                        case UsuariosRetorno.Agrupamento_Invalida:
                            break;
                        case UsuariosRetorno.Desativado_Temp:
                            break;
                        default:
                            break;
                    }
                };
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool Validadacao()
        {
            if (string.IsNullOrWhiteSpace(txtUsuarios.Text))
            {
                MessageBox.Show("Coloque o seu Email por favor");
                txtUsuarios.SelectAll();
                txtUsuarios.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Coloque sua senha por favor");
                txtSenha.SelectAll();
                txtSenha.Focus();
                return false;
            }

            if (txtUsuarios.Text.Contains("@"))
            {
                if (!EmailValidade.GetIstance().IsValidEmail(txtUsuarios.Text))
                {
                    Mensagens.Display("Email", "Notamos que o seu EMail não esta correncto");
                    txtUsuarios.SelectAll();
                    txtUsuarios.Focus();
                    return false;
                }
            }
            return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                CloseForms();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.F1)
            {
                Limpar();
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.Enter)
            {
                if (windowsUIButtonPanel1.Buttons[0].Properties.Enabled)
                    WindowsUIButtonPanel1_ButtonClick(null, null);

                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }

        #region Mover formulátios Combinacoes de teclas
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cX = e.X;
                cY = e.Y;
                mover = true;
            }
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                this.Left += e.X - (cX - PainelMover.Left);
                this.Top += e.Y - (cY - PainelMover.Top);
            }
        }
        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mover = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- Minimize borderless form from taskbar
                return cp;
            }
        }
        #endregion
    }
}
