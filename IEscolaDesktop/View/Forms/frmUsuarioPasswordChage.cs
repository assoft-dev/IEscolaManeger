using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using System;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmUsuarioPasswordChage : XtraUserControl
    {
        private IUsuarios UsuariosRepository;

        public frmUsuarioPasswordChage()
        {
            InicialiacaoComponentes();
        }
        public frmUsuarioPasswordChage(long UserID)
        {
            InicialiacaoComponentes();
        }

        private void InicialiacaoComponentes()
        {
            InitializeComponent();
            UsuariosRepository = new UsuariosRepository();

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            // Activação
            txtUsuarios.EditValueChanged += delegate { ChangeValudations(txtUsuarios); };
            txtSenhaAntiga.EditValueChanged += delegate { ChangeValudations(txtSenhaAntiga); };
            txtSenhaNova.EditValueChanged += delegate { ChangeValudations(txtSenhaNova); };
            txtSenhaNovaRepetir.EditValueChanged += delegate { ChangeValudations(txtSenhaNovaRepetir); };

            windowsUIButtonPanel1.Enabled = false;
        }

        private async void WindowsUIButtonPanel1_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            if (Validacao())
            {
                if (e.Button.Properties.Tag.Equals("0"))
                {
                    var result = await UsuariosRepository.ChangePassword_Mode1(txtUsuarios.Text.Trim(),
                                                                           txtSenhaAntiga.Text.Trim(),
                                                                           txtSenhaNova.Text.Trim());
                    if (result)
                    {
                        Mensagens.Display("Alteração de credencias", "As alterações foram feitas com sucesso!");
                    }
                    else
                        Mensagens.Display("Alteração de credencias",
                                          "Infelixmente não foi possovel alterar as credencias! Queira voltar a colocar suas credencias por favor",
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
                #region Usuarios          
                if (control.Name.Equals(txtUsuarios.Name))
                {
                    if (!string.IsNullOrWhiteSpace(control.Text))
                    {
                        if (string.IsNullOrWhiteSpace(txtSenhaAntiga.Text) &&
                            string.IsNullOrWhiteSpace(txtSenhaNova.Text) &&
                            string.IsNullOrWhiteSpace(txtSenhaNovaRepetir.Text))
                        {
                            windowsUIButtonPanel1.Enabled = false;
                        }
                        else
                            windowsUIButtonPanel1.Enabled = true;
                    }
                    else
                        windowsUIButtonPanel1.Enabled = false;
                }
                #endregion

                #region Senha-Antiga     
                else if (control.Name.Equals(txtSenhaNova.Name))
                {
                    if (!string.IsNullOrWhiteSpace(control.Text))
                    {
                        if (string.IsNullOrWhiteSpace(txtUsuarios.Text) &&
                            string.IsNullOrWhiteSpace(txtSenhaAntiga.Text) &&
                            string.IsNullOrWhiteSpace(txtSenhaNovaRepetir.Text))
                        {
                            windowsUIButtonPanel1.Enabled = false;
                        }
                        else
                            windowsUIButtonPanel1.Enabled = true;
                    }
                    else
                        windowsUIButtonPanel1.Enabled = false;
                }
                #endregion  
                
                #region Senha-Nova     
                else if (control.Name.Equals(txtSenhaNova.Name))
                {
                    if (!string.IsNullOrWhiteSpace(control.Text))
                    {
                        if (string.IsNullOrWhiteSpace(txtUsuarios.Text) &&
                            string.IsNullOrWhiteSpace(txtSenhaAntiga.Text) &&
                            string.IsNullOrWhiteSpace(txtSenhaNovaRepetir.Text))
                        {
                            windowsUIButtonPanel1.Enabled = false;
                        }
                        else
                            windowsUIButtonPanel1.Enabled = true;
                    }
                    else
                        windowsUIButtonPanel1.Enabled = false;
                }
                #endregion  


                #region Senha-Nova -Repetir    
                else if (control.Name.Equals(txtSenhaNovaRepetir.Name))
                {
                    if (!string.IsNullOrWhiteSpace(control.Text))
                    {
                        if (string.IsNullOrWhiteSpace(txtUsuarios.Text) &&
                            string.IsNullOrWhiteSpace(txtSenhaAntiga.Text) &&
                            string.IsNullOrWhiteSpace(txtSenhaNova.Text))
                        {
                            windowsUIButtonPanel1.Enabled = false;
                        }
                        else
                            windowsUIButtonPanel1.Enabled = true;
                    }
                    else
                        windowsUIButtonPanel1.Enabled = false;
                }
                #endregion
            }
        }

        private bool Validacao()
        {
            if (string.IsNullOrWhiteSpace(txtUsuarios.Text))
            {
                Mensagens.Display("Validação", "Por favor coloque seu usuário (Email) por favor!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuarios.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSenhaAntiga.Text))
            {
                Mensagens.Display("Validação", "Por favor coloque sua senha (PIN) por favor!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaAntiga.Focus();
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
            //var compar = string.Compare(txtSenhaNova.Text.Trim(), txtSenhaNovaRepetir.Text.Trim());

            if (txtSenhaNova.Text.Trim().Equals(txtSenhaNovaRepetir.Text.Trim()))
            {
                Mensagens.Display("Comparação", "As senhas colocadas para serem alteradas não correspondem!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenhaNovaRepetir.Focus();
                return false;
            }  
            return true;
        }
    }
}