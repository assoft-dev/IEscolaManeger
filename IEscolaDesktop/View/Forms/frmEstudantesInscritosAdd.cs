using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Helps;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmEstudantesInscritosAdd : XtraUserControl
    {
        IEstudantesInscricoes DataRepository;
        IProvinciasMunicipios provinciasMunicipiosRepository;
        ICursos cursosRepository;

        bool IsValidate = false;

        public frmEstudantesInscritosAdd(EstudantesInscricoes usuarios = null)
        {
            InitializeComponent();

            DataRepository = new EstudantesIncricoesRepository();
            provinciasMunicipiosRepository = new ProvinciasMunicipiosRepository();
            cursosRepository = new CursosRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtSexo.EditValueChanged += delegate { ChangeValudations(txtSexo); };

            //txtCAtegoria.EditValueChanged += delegate { ChangeValudations(txtCAtegoria); };

            //btnEditoras.Click += BtnBuscarEdicoes_Click;
            //btnAutor.Click += BtnBuscarAutores_Click;
            //btnCategoria.Click += BtnBuscarCategoria_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtFirstName.EditValue = usuarios.FirstName;
                txtLastName.EditValue = usuarios.LastName;
                txtBI.EditValue = usuarios.BI;
                txtNacionalidade.EditValue = usuarios.Nacionalidade;
                txtSexo.EditValue = usuarios.Sexo;
                txtEstadoCivil.EditValue = usuarios.EstadoCivil;
                txtProvinciaMunicipio.EditValue = usuarios.ProvinciaMunicipioID;

                txtGrauParentesco.EditValue = usuarios.GrauParentesco;
                txtEncarregado.EditValue = usuarios.NomeEncarregado;
                txtNomePai.EditValue = usuarios.NomePai;
                txtNomeMae.EditValue = usuarios.NomeMae;
                txtMaeVive.EditValue = usuarios.MaeVive;
                txtPaiVive.EditValue = usuarios.PaiVive;

                txtResidencia.EditValue = usuarios.Residencia;
                txtenderco.EditValue = usuarios.Endereco;
                txtContactos.EditValue = usuarios.Contacto;
                txtCelular.EditValue = usuarios.Celular;
                txtEmail.EditValue = usuarios.Email;
                txtEmailFacebook.EditValue = usuarios.EmailFacebbok;

                txtLocalEmissao.EditValue = usuarios.LocalEmissao;
                txtDataEmissao.EditValue = usuarios.DataEmissao;
                txtDataExpiracao.EditValue = usuarios.DataExpiracao;
                txtTipoDocumentos.EditValue = usuarios.DocType;
                txtDocumento.EditValue = usuarios.Documento;
                txtDocumentoRecenciamnto.EditValue = usuarios.DocRecenciamentoMilitar;
                txtTurma.EditValue = usuarios.CursosID;

                txtEscolaOrigem.EditValue = usuarios.AdiconalEscolaOrigem;
                txtProvinciaOrigem.EditValue = usuarios.AdiconalProvincias;
                txtEscolaMedia.EditValue = usuarios.AdicionalMedia;
                txtIsActived.EditValue = usuarios.IsActived;
                txtMedia.EditValue = usuarios.Media;
                txtDataFicha.EditValue = usuarios.DataFicha;

                txtFazes.EditValue = usuarios.FAZES;
                txtFichaInscricao.EditValue = usuarios.AdicionalFichaInscricao;
                txtCertificadoAnexo.EditValue = usuarios.AdicionalCertificados;
                txtImagemURL.Text = usuarios.ImagemURL;

                txtCodigo.EditValue = usuarios.InscricaoID;
                txtCodigoUnico.EditValue = usuarios.Codigo;
                txtFirstName.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;
        }

        private void BtnBuscarEdicoes_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmBiblioteca_EditorasAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }
        private void BtnBuscarAutores_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmBiblioteca_AutoresAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }
        private void BtnBuscarCategoria_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmBiblioteca_CategoriasAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult1 = await provinciasMunicipiosRepository.GetAll();
            provinciasMunicipiosBindingSource.DataSource = dataResult1;

            var dataResult2 = await cursosRepository.GetAll();
            cursosBindingSource.DataSource = dataResult2;

            txtProvinciaMunicipio.Properties.DataSource = dataResult1;
            txtTurma.Properties.DataSource = dataResult2;

            /// Enumeradoes
            txtNacionalidade.Properties.DataSource = Enum.GetValues(typeof(Nacionalidade));
            txtSexo.Properties.DataSource = Enum.GetValues(typeof(Sexo));
            txtEstadoCivil.Properties.DataSource = Enum.GetValues(typeof(EstadoCivil));
            txtGrauParentesco.Properties.DataSource = Enum.GetValues(typeof(GrauParentesco));
            txtTipoDocumentos.Properties.DataSource = Enum.GetValues(typeof(DocType));
            txtFazes.Properties.DataSource = Enum.GetValues(typeof(FAZES));
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
                    var apagar = await DataRepository.Excluir(x => x.InscricaoID == data);

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
                var data = new EstudantesInscricoes
                {
                    InscricaoID = ID,

                    FirstName = (string) txtFirstName.EditValue,
                    LastName = (string) txtLastName.EditValue,
                    BI = (string) txtBI.EditValue,
                    Nacionalidade= (Nacionalidade) txtNacionalidade.EditValue,
                    Sexo= (Sexo) txtSexo.EditValue,
                    EstadoCivil= (EstadoCivil) txtEstadoCivil.EditValue,
                    ProvinciaMunicipioID= (int) txtProvinciaMunicipio.EditValue,

                    GrauParentesco= (GrauParentesco) txtGrauParentesco.EditValue,
                    NomeEncarregado= (string) txtEncarregado.EditValue,
                    NomePai= (string) txtNomePai.EditValue,
                    NomeMae= (string) txtNomeMae.EditValue,
                    MaeVive= (bool) txtMaeVive.Checked,
                    PaiVive= (bool) txtPaiVive.Checked,

                    Residencia= (string) txtResidencia.EditValue,
                    Endereco= (string) txtenderco.EditValue,
                    Contacto= (string) txtContactos.EditValue,
                    Celular= (string) txtCelular.EditValue,
                    Email= (string) txtEmail.EditValue,
                    EmailFacebbok= (string) txtEmailFacebook.EditValue,

                    LocalEmissao= (string) txtLocalEmissao.EditValue,
                    DataEmissao= (DateTime) txtDataEmissao.DateTime,
                    DataExpiracao= (DateTime) txtDataExpiracao.DateTime,
                    DocType= (DocType) txtTipoDocumentos.EditValue,
                    Documento= (string) txtDocumento.EditValue,
                    DocRecenciamentoMilitar= (string) txtDocumentoRecenciamnto.EditValue,
                    CursosID= (int) txtTurma.EditValue,

                    AdiconalEscolaOrigem= (string) txtEscolaOrigem.EditValue,
                    AdiconalProvincias= (string) txtProvinciaOrigem.EditValue,
                    AdicionalMedia= (decimal) txtEscolaMedia.EditValue,
                    IsActived= (bool) txtIsActived.Checked,
                    Media= (decimal) txtMedia.EditValue,
                    DataFicha= (DateTime)txtDataFicha.DateTime,

                    ImagemURL = txtImagemURL.Text,

                    FAZES = (FAZES) txtFazes.EditValue,
                    AdicionalFichaInscricao= (bool) txtFichaInscricao.EditValue,
                    AdicionalCertificados= (bool) txtCertificadoAnexo.EditValue,

                    Codigo = (string) txtCodigoUnico.EditValue,
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.InscricaoID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => (x.FirstName.ToUpper() == txtFirstName.Text.ToUpper()) &&
                                                           ((x.LastName.ToUpper() == txtLastName.Text) && 
                                                           (x.BI.ToUpper() == txtBI.Text.ToUpper()) &&
                                                           (x.DocType.ToString() == txtTipoDocumentos.Text.ToUpper())), null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.InscricaoID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores as Atualiar", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtSexo.SelectAll();
                        txtSexo.Focus();
                        return true;
                    }

                    // Verificar a possibilidade de atualizar com base nos valores Sala Cursos e Periodos
                    var dataResult2 = await DataRepository.Get(x => ((x.ProvinciaMunicipioID == (int) txtProvinciaMunicipio.EditValue) &&
                                                                     (x.CursosID == (int) txtTurma.EditValue)), null);
                    if (dataResult2 != null)
                    {
                        Mensagens.Display("Duplicação de Valores", "Já existe uma Turma com a descrição abaixo mencionada!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);
                        return true;
                    }
                }
                else
                {
                    Mensagens.Display("Duplicação de Valores ao Criar", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                    txtSexo.SelectAll();
                    txtSexo.Focus();
                    return true;
                }
            }
            return false;
        }

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtFirstName.EditValue = string.Empty;
            txtLastName.EditValue = string.Empty;
                txtBI.EditValue = string.Empty;
                txtNacionalidade.EditValue = string.Empty;
            txtSexo.EditValue = string.Empty;
            txtEstadoCivil.EditValue = string.Empty;
            txtProvinciaMunicipio.EditValue = string.Empty;

            txtGrauParentesco.EditValue = string.Empty;
            txtEncarregado.EditValue = string.Empty;
            txtNomePai.EditValue = string.Empty;
            txtNomeMae.EditValue = string.Empty;
            txtMaeVive.EditValue = string.Empty;
            txtPaiVive.EditValue = string.Empty;

            txtResidencia.EditValue = string.Empty;
            txtenderco.EditValue = string.Empty;
            txtContactos.EditValue = string.Empty;
            txtCelular.EditValue = string.Empty;
            txtEmail.EditValue = string.Empty;
            txtEmailFacebook.EditValue = string.Empty;

            txtLocalEmissao.EditValue = string.Empty;
            txtDataEmissao.EditValue = string.Empty;
            txtDataExpiracao.EditValue = string.Empty;
            txtTipoDocumentos.EditValue = string.Empty;
            txtDocumento.EditValue = string.Empty;
            txtDocumentoRecenciamnto.EditValue = string.Empty;
            txtTurma.EditValue = string.Empty;

            txtEscolaOrigem.EditValue = string.Empty;
            txtProvinciaOrigem.EditValue = string.Empty;
            txtEscolaMedia.EditValue = string.Empty;
            txtIsActived.EditValue = string.Empty;
            txtMedia.EditValue = string.Empty;
            txtDataFicha.EditValue = string.Empty;

            txtFazes.EditValue = string.Empty;
            txtFichaInscricao.EditValue = string.Empty;
            txtCertificadoAnexo.EditValue = string.Empty;

            txtCodigo.EditValue = string.Empty;
            txtCodigoUnico.EditValue = string.Empty;
            txtImagemURL.Text = string.Empty;

            txtCodigo.Text = string.Empty;
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
                //#region Descricao
                //if (control.Name.Equals(txtFirstName.Name))
                //{
                //    if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                //    {
                //        if (!(string.IsNullOrWhiteSpace(txtCAtegoria.Text) || txtCAtegoria.Text == "[Selecione o Curso por favor]") &&
                //             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == "[Selecione a Sala por por favor]") &&
                //             !(string.IsNullOrWhiteSpace(txtEditora.Text) || txtEditora.Text == "[Selecione o Periodo por favor]") &&
                //             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == "[Selecione a Classe por favor]"))
                //        {
                //            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                //        }
                //        else
                //        {
                //            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                //        }
                //    }
                //    else
                //    {
                //        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                //    }
                //}
                //#endregion

                //#region Provincias
                //if (control.Name.Equals(txtSexo.Name))
                //{
                //    if (!string.IsNullOrWhiteSpace(txtSexo.Text))
                //    {
                //        if (!(string.IsNullOrWhiteSpace(txtCAtegoria.Text) || txtCAtegoria.Text == "[Selecione o municipio por favor]"))
                //        { 
                //            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                //        }
                //        else {
                //            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                //        }
                //    }
                //    else {
                //        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                //    }
                //}
                //#endregion

                //#region Municipios
                //if (control.Name.Equals(btnCategoria.Name))
                //{
                //    if (!string.IsNullOrWhiteSpace(btnCategoria.Text))
                //    {
                //        if (!(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == "[Selecione a provincia por favor]"))
                //        {
                //            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                //        }
                //        else
                //        {
                //            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                //        }
                //    }
                //    else
                //    {
                //        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                //    }
                //}
                //#endregion
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

        private void txtSala_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}