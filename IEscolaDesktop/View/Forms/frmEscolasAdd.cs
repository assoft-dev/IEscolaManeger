using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmEscolasAdd : XtraUserControl
    {
        IEntidades DataRepository;
        IProvinciasMunicipios provinciaRepository;
        bool IsValidate = false;

        public frmEscolasAdd(Entidade usuarios = null)
        {
            InitializeComponent();

            DataRepository = new EntidadeRepository();
            provinciaRepository = new ProvinciasMunicipiosRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtAssinaturaDr.EditValueChanged += delegate { ChangeValudations(txtAssinaturaDr); };
            txtAssinaturaSub.EditValueChanged += delegate { ChangeValudations(txtAssinaturaSub); };
            txtRodape.EditValueChanged += delegate { ChangeValudations(txtRodape); };
            txtProvinciaMunicipio.EditValueChanged += delegate { ChangeValudations(txtProvinciaMunicipio); };

            btnProvincia.Click += BtnBuscarGrupos_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtAssinaturaDr.EditValue = usuarios.AssinaturaDirector;
                txtAssinaturaSub.EditValue = usuarios.AssinaturaSubDirector;
                txtCabecalho.EditValue = usuarios.Header1;
                txtRodape.EditValue = usuarios.Header2;
                txtProvinciaMunicipio.EditValue = usuarios.ProvinciaMunicipioID;
                txtCodigo.EditValue = usuarios.EntidadeID;
                txtDescricao.EditValue = usuarios.Descricao;
                txtNIF.EditValue = usuarios.EscolaCodigo;
                txtEstadoEScola.EditValue = (EscolaEstatuto) usuarios.Estatuto;
                txtFazemTestes.EditValue = usuarios.FazemTeste;

                txtAssinaturaDr.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;
            txtProvinciaMunicipio.Properties.NullText = provincia;
            txtEstadoEScola.Properties.NullText = escolaestado;
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmProvinciasMunicipiosAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult = await provinciaRepository.GetAll();
            provinciasMunicipiosBindingSource.DataSource = dataResult;
            txtEstadoEScola.Properties.DataSource = Enum.GetValues(typeof(EscolaEstatuto));
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
                    var apagar = await DataRepository.Excluir(x => x.EntidadeID == data);

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
                var data = new Entidade
                { 
                    EntidadeID = ID,
                    AssinaturaDirector = txtAssinaturaDr.Text.Trim(),
                    AssinaturaSubDirector = txtAssinaturaSub.Text.Trim(),
                    Header1 = txtCabecalho.Text.Trim(),
                    Header2 = txtRodape.Text.Trim(),
                    Descricao = txtDescricao.Text.Trim(),
                    EscolaCodigo = txtNIF.Text.Trim(),
                    FazemTeste = txtFazemTestes.IsOn,
                    ProvinciaMunicipioID = (int) txtProvinciaMunicipio.EditValue,
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.EntidadeID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => x.Descricao == txtAssinaturaDr.Text, null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.ProvinciaMunicipioID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtAssinaturaDr.SelectAll();
                        txtAssinaturaDr.Focus();

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
            txtAssinaturaDr.Text = string.Empty;
            txtAssinaturaSub.Text = string.Empty;
            txtCabecalho.Text = string.Empty; 
            txtDescricao.Text = string.Empty; 
            txtRodape.Text = string.Empty; 
            
            txtTitulo.Text = "[Novo]";
            txtAssinaturaDr.Focus();
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

        private string provincia = "* [Selecione [Provincia => Municipio] por favor";
        private string escolaestado = "* [Selecione o estado da Escola por favor";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Descricao
                if (control.Name.Equals(txtDescricao.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtAssinaturaDr.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtAssinaturaSub.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtNIF.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtEstadoEScola.Text) || txtEstadoEScola.Text == escolaestado) &&
                            !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == provincia))
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
                
                #region Assinatura
                else if (control.Name.Equals(txtAssinaturaDr.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtAssinaturaDr.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                             !(string.IsNullOrWhiteSpace(txtAssinaturaSub.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtNIF.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtEstadoEScola.Text) || txtEstadoEScola.Text == escolaestado) &&
                            !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == provincia))
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
                
                #region Assinatura Sub
                else if (control.Name.Equals(txtAssinaturaSub.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtAssinaturaSub.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtAssinaturaDr.Text) &&
                            !(string.IsNullOrWhiteSpace(txtNIF.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtDescricao.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtEstadoEScola.Text) || txtEstadoEScola.Text == escolaestado) &&
                            !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == provincia))
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

                #region Estado
                else if (control.Name.Equals(txtEstadoEScola.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtEstadoEScola.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtAssinaturaDr.Text) &&
                            !(string.IsNullOrWhiteSpace(txtNIF.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtDescricao.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtAssinaturaSub.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == provincia))
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

                #region Estado
                else if (control.Name.Equals(txtProvinciaMunicipio.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtAssinaturaDr.Text) &&
                            !(string.IsNullOrWhiteSpace(txtNIF.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtDescricao.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtAssinaturaSub.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtEstadoEScola.Text) || txtEstadoEScola.Text == escolaestado))
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
                    if (!string.IsNullOrWhiteSpace(txtAssinaturaDr.Text) &&
                        !(string.IsNullOrWhiteSpace(txtNIF.Text)) &&
                        !(string.IsNullOrWhiteSpace(txtDescricao.Text)) &&
                        !string.IsNullOrWhiteSpace(txtAssinaturaSub.Text) &&
                        !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == provincia))

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