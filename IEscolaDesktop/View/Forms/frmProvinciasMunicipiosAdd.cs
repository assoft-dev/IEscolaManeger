using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Summary.Native;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmProvinciasMunicipiosAdd : XtraUserControl
    {
        IProvinciasMunicipios DataRepository;
        IProvincias ProvinciasRepository;
        IMunicipios municipiosRepository;
        bool IsValidate = false;

        public frmProvinciasMunicipiosAdd(ProvinciasMunicipios usuarios = null)
        {
            InitializeComponent();

            DataRepository = new ProvinciasMunicipiosRepository();
            ProvinciasRepository = new ProvinciasRepository();
            municipiosRepository = new MunicipiosRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtProvincias.TextChanged += delegate { ChangeValudations(txtProvincias); };
            txtMunicipios.TextChanged += delegate { ChangeValudations(txtMunicipios); };

            btnProvincias.Click += BtnBuscarGrupos_Click;
            btnMunicipios.Click += BtnBuscar2Grupos_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtProvincias.EditValue = usuarios.ProvinciasID;
                txtMunicipios.EditValue = usuarios.MunicipiosID;
                txtCodigo.EditValue = usuarios.ProvinciasMunicipiosID;

                txtProvincias.Focus();
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
                  new frmProvinciasAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }
        private void BtnBuscar2Grupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmMunicipiosAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult = await ProvinciasRepository.GetAll();
            provinciasBindingSource.DataSource = dataResult;

            var data2Result = await municipiosRepository.GetAll();
            municipiosBindingSource.DataSource = data2Result;
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
                    var apagar = await DataRepository.Excluir(x => x.ProvinciasMunicipiosID == data);

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
                var data = new ProvinciasMunicipios
                {
                    ProvinciasMunicipiosID = ID,
                    MunicipiosID = (int) txtMunicipios.EditValue,
                    ProvinciasID = (int) txtProvincias.EditValue,
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.ProvinciasMunicipiosID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => (x.ProvinciasID == (int) txtProvincias.EditValue) && 
                                                           (x.MunicipiosID == (int) txtMunicipios.EditValue), null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.ProvinciasMunicipiosID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores as Atualiar", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtProvincias.SelectAll();
                        txtProvincias.Focus();

                        return true;
                    } 
                }
                else
                {
                    Mensagens.Display("Duplicação de Valores ao Criar", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                    txtProvincias.SelectAll();
                    txtProvincias.Focus();

                    return true;
                }
            }
            return false;
        }

        private void Limpar()
        {
            //windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtCodigo.Text = string.Empty;
            txtTitulo.Text = "[Novo]";
            txtProvincias.Focus();
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

        private string provincia = "[Selecione a provincia por favor]";
        private string muninicio ="[Selecione o municipio por favor]";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Provincias
                if (control.Name.Equals(txtProvincias.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtProvincias.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtMunicipios.Text) || txtMunicipios.Text == muninicio))
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

                #region Municipios
                else if (control.Name.Equals(btnMunicipios.Name))
                {
                    if (!string.IsNullOrWhiteSpace(btnMunicipios.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtProvincias.Text) || txtProvincias.Text == provincia))
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
                    if (!(string.IsNullOrWhiteSpace(txtProvincias.Text) || txtProvincias.Text == provincia) &&
                        !(string.IsNullOrWhiteSpace(txtMunicipios.Text) || txtMunicipios.Text == provincia))
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