using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models.ViewModels;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmUsuarioPassword : XtraUserControl
    {
        private IUsuarios UsuariosRepository;
        public frmUsuarioPassword(UsuariosViewModels UserID)
        {
            InicialiacaoComponentes();

            txtUsuarios.Text = UserID.Email;
            txtUsuarioID.Text = UserID.UsuariosID.ToString();
        }

        private void InicialiacaoComponentes()
        {
            InitializeComponent();
            UsuariosRepository = new UsuariosRepository();

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;
            txtSenhaNova.EditValueChanged += delegate { ChangeValudations(txtSenhaNova); };
            txtSenhaNovaRepetir.EditValueChanged += delegate { ChangeValudations(txtSenhaNovaRepetir); };

            windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
            txtSenhaNova.ButtonClick += delegate { GetViewPassowrd(txtSenhaNova); };
            txtSenhaNovaRepetir.ButtonClick += delegate { GetViewPassowrd(txtSenhaNovaRepetir); };
        }

        private void GetViewPassowrd(ButtonEdit control)
        {
            if (control.Properties.UseSystemPasswordChar)
                control.Properties.UseSystemPasswordChar = false;
            else 
                control.Properties.UseSystemPasswordChar = true;
        }

        private void Limpar()
        {
            txtUsuarios.Text = string.Empty;
            txtSenhaNova.Text = string.Empty;
            txtSenhaNovaRepetir.Text = string.Empty;
            txtUsuarios.Focus();
        }

        private async void WindowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (Validacao())
            {
                if (e.Button.Properties.Tag.Equals("0"))
                {
                    var result = await UsuariosRepository.ChangePassword_Mode1(txtUsuarios.Text.Trim(),
                                                                               txtSenhaNova.Text.Trim());
                    if (result)
                    {
                        Mensagens.Display("Alteração de credencias", "As alterações foram feitas com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClose.DialogResult = DialogResult.OK;
                    }
                    else
                        Mensagens.Display("Alteração de credencias",
                                          "Infelizmente não foi possivel alterar as credencias! Queira voltar a colocar suas credencias por favor",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    btnClose.DialogResult = DialogResult.OK;
            }
        }

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {               
                #region Senha-Nova       
                if (control.Name.Equals(txtSenhaNova.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtSenhaNova.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtUsuarios.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenhaNovaRepetir.Text))
                        {
                            Comparacao_Senhas(txtSenhaNova);
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
                #endregion  

                #region Senha-Nova -Repetir
                else if (control.Name.Equals(txtSenhaNovaRepetir.Name))
               {
                    if (!string.IsNullOrWhiteSpace(txtSenhaNovaRepetir.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtUsuarios.Text) &&
                            !string.IsNullOrWhiteSpace(txtSenhaNova.Text))
                        {
                            Comparacao_Senhas(txtSenhaNovaRepetir);
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
                #endregion
            }
            else
            {
                windowsUIButtonPanel1.Enabled = false;
            }
        }

        private void Comparacao_Senhas(Control control)
        {
            #region Verificacao se a senha e igual           
            string SenhaNova = txtSenhaNova.Text.Trim();
            string SenhaNovaRepetir = txtSenhaNovaRepetir.Text.Trim();

            if (SenhaNova == SenhaNovaRepetir)
            {
                if (control.Text.Length >= 4)
                    windowsUIButtonPanel1.Buttons[0].Properties.Enabled = true;
                else
                    windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
            }
            else
                windowsUIButtonPanel1.Buttons[0].Properties.Enabled = false;
            #endregion
        }

        private bool Validacao()
        {
            if (string.IsNullOrWhiteSpace(txtUsuarios.Text))
            {
                Mensagens.Display("Validação", "Por favor coloque seu usuário (Email) por favor!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuarios.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSenhaNova.Text))
            {
                Mensagens.Display("Validação", "Por favor coloque a sua senha senha por favor!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaNova.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSenhaNovaRepetir.Text))
            {
                Mensagens.Display("Validação", "Por favor repita a sua senha por favor!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaNovaRepetir.Focus();
                return false;
            }
            var compar = string.Compare(txtSenhaNova.Text.Trim(), txtSenhaNovaRepetir.Text.Trim());

            if (compar != 0)
            {
                Mensagens.Display("Comparação", "As senhas colocadas para serem alteradas não correspondem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaNovaRepetir.Focus();
                return false;
            }  
            return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                btnClose.DialogResult = DialogResult.OK;
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
                if (windowsUIButtonPanel1.Buttons[0].Properties.Enabled == true)
                    WindowsUIButtonPanel1_ButtonClick(null, null);
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            if (keyData == Keys.Enter)
            {
                if (windowsUIButtonPanel1.Buttons[0].Properties.Enabled == true)
                    WindowsUIButtonPanel1_ButtonClick(null, null);
                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }
    }
}