using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using System;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmPermissoesAdd : XtraUserControl
    {
        IPermissoes permissionRepository;
        bool IsValidate = false;

        public frmPermissoesAdd(Permissoes permissoes = null)
        {
            InitializeComponent();

            permissionRepository = new PermissionsRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };
            
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;


            if (permissoes != null) { 

            }
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            //// Buscar Grupos
            //var forms = OpenFormsDialog.ShowForm(null,
            //      new frmPermissoesAdd(null));

            //if (forms == DialogResult.None || forms == DialogResult.Cancel)
            //    FrmUsuariosAdd_Load(null, null);
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
                    var apagar = await permissionRepository.Excluir(x => x.PermissoeID == data);

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
            var ID = string.IsNullOrWhiteSpace(txtCodigo.Text) == true ? 0 : (int)txtCodigo.EditValue;

            // save Data
            var data = new Permissoes
            {
                PermissoeID = ID,
               
                List = (bool) cbCriar.EditValue,
                Create = (bool) cbCriar.EditValue,
                Update = (bool) cbCriar.EditValue,
                Delete = (bool) cbCriar.EditValue,

                Usuarios = (bool)cbCriar.EditValue,
                Grupos = (bool)cbCriar.EditValue,
                Permissions = (bool)cbCriar.EditValue,
                Logs = (bool)cbCriar.EditValue,

                Provincias = (bool)cbProvincias.EditValue,
                Municipios = (bool)CbMunicipios.EditValue,
                ProvinciasMunicipios = (bool)cbProvinciaMunicipios.EditValue,
            };

            IsValidate = ID != 0 ? await permissionRepository.Guardar(data, X => X.PermissoeID == ID) > 0 :
                                       await permissionRepository.Guardar(data, true);

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

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtCodigo.Text = string.Empty;

            cbList.Focus();
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