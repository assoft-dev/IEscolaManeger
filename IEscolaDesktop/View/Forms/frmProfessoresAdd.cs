using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaDesktop.View.ReportForms;
using IEscolaEntity.Controllers.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Helps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmProfessoresAdd : XtraUserControl
    {
        IProfessores DataRepository;
        IProvinciasMunicipios provinciasMunicipiosRepository;

        IProfessoresCategorias professoresCategorias;
        IProfessoresAreaFormacao professoresAreaFormacaoRepository;

        bool IsValidate = false;

        public frmProfessoresAdd(Professores usuarios = null)
        {
            InitializeComponent();

            DataRepository = new ProfessoresRepository();
            provinciasMunicipiosRepository = new ProvinciasMunicipiosRepository();
            professoresCategorias = new ProfessoresCategoriasRepository();
            professoresAreaFormacaoRepository = new ProfessoresAreaFormacaoRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };
            txtSexo.TextChanged += delegate { ChangeValudations(txtSexo); };
            txtFirstName.EditValueChanged += delegate { ChangeValudations(txtFirstName); };
            txtLastName.EditValueChanged += delegate { ChangeValudations(txtLastName); };
            txtBI.EditValueChanged += delegate { ChangeValudations(txtBI); };
            txtNacionalidade.EditValueChanged += delegate { ChangeValudations(txtNacionalidade); };
            txtProvinciaMunicipio.EditValueChanged += delegate { ChangeValudations(txtProvinciaMunicipio); };
            txtEstadoCivil.TextChanged += delegate { ChangeValudations(txtEstadoCivil); };
            txtResidencia.EditValueChanged += delegate { ChangeValudations(txtResidencia); };
            txtenderco.EditValueChanged += delegate { ChangeValudations(txtenderco); };
            
            txtLocalEmissao.TextChanged += delegate { ChangeValudations(txtLocalEmissao); };
            txtTipoDocumentos.TextChanged += delegate { ChangeValudations(txtTipoDocumentos); };

            txtContactos.EditValueChanged += delegate { ChangeValudations(txtContactos); };
            txtEmail.EditValueChanged += delegate { ChangeValudations(txtEmail); };
            txtEmailFacebook.EditValueChanged += delegate { ChangeValudations(txtEmailFacebook); };

            txtCategoria.EditValueChanged += delegate { ChangeValudations(txtCategoria); };
            txtAreaFormacao.EditValueChanged += delegate { ChangeValudations(txtAreaFormacao); };

            txtEscolaridade.SelectionChanged += delegate { ChangeValudations(txtEscolaridade); };
            txtHabilitacoesLiterarias.TextChanged += delegate { ChangeValudations(txtHabilitacoesLiterarias); };
            txtProvinciasFormacao.TextChanged += delegate { ChangeValudations(txtProvinciasFormacao); };
            txtEscola.TextChanged += delegate { ChangeValudations(txtEscola); };

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            // Assinatura dos Nulable
            txtLocalEmissao.Properties.NullText = localemissao;
            txtTipoDocumentos.Properties.NullText = tipodoc;

            txtCategoria.Properties.NullText = categoria;
            txtAreaFormacao.Properties.NullText = areaformacao;

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

                txtCategoria.EditValue = usuarios.ProfessorCategoriaID;
                txtAreaFormacao.EditValue = usuarios.ProfessorAreaFormacaoID;

                txtDataNascimento.DateTime = usuarios.DataNascimento;
                txtIdade.EditValue = usuarios.Idade;

                txtEscola.EditValue = usuarios.AreaEscola;
                txtData.EditValue = usuarios.AreaData;
                txtIsActived.EditValue = usuarios.IsActived;
                txtProvinciasFormacao.EditValue = usuarios.AreaProvincia;
                txtDuracao.EditValue = usuarios.AreaData;

                txtImagemURL.Text = usuarios.ImagemURL;

                txtEscolaridade.EditValue = usuarios.Escolaridade;
                txtHabilitacoesLiterarias.EditValue = usuarios.abilitacoesLiterarias;

                txtCodigo.EditValue = usuarios.ProfessoresID;
                txtCodigoUnico.EditValue = usuarios.Codigo;
                txtFirstName.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

                txtDataEmissao.DateTime = DateTime.Now;
                txtDataExpiracao.DateTime = DateTime.Now;
                txtData.DateTime = DateTime.Now;
                txtDataNascimento.DateTime = DateTime.Now;
            }

            #region Calcula Idade
            txtDataNascimento.EditValueChanged += delegate {

                if (txtDataNascimento.DateTime != null)
                {
                    var idade = DateTime.Now.Year - txtDataNascimento.DateTime.Year;
                    txtIdade.EditValue = idade;
                }
            };
            #endregion

            txtImagemURL.ButtonClick += TxtImagemURL_ButtonClick;
            btnProvinciaMunicipios.Click += BtnProvinciaMunicipios_Click;
            pictureEdit1.MouseDoubleClick += PictureEdit1_MouseClick;

            btnCategoria.Click += BtnBuscarCategoria_Click;
            btnAreaFormacao.Click += BtnBuscarAreFormacao_Click;

            //Atribuicao de Parcelas de TextNULL 1-
            txtNacionalidade.Properties.NullText = nacionalidade;

            txtEscolaridade.Properties.NullText = escolaridade;
            txtHabilitacoesLiterarias.Properties.NullText = habilitacoesliterarias;

            txtSexo.Properties.NullText = sexo;
            txtEstadoCivil.Properties.NullText = estadocivil;

            // 2-
            txtLocalEmissao.Properties.NullText = localemissao;
            txtTipoDocumentos.Properties.NullText = tipodoc;
            txtProvinciaMunicipio.Properties.NullText = municipioprovincia;

            this.Load += FrmUsuariosAdd_Load;
        }

        private void BtnCurso_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmCursosAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private void PictureEdit1_MouseClick(object sender, MouseEventArgs e)
        {
            var fileStream = xtraOpenFileDialog1.ShowDialog();
            xtraOpenFileDialog1.FileName = string.Empty;
            xtraOpenFileDialog1.RestoreDirectory = true;


            if (fileStream == DialogResult.OK)
            {
                txtImagemURL.Text = xtraOpenFileDialog1.FileName;
                pictureEdit1.Image = Image.FromFile(xtraOpenFileDialog1.FileName); 
            }
        }

        private void BtnProvinciaMunicipios_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmProvinciasMunicipiosAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private void TxtImagemURL_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var fileStream = xtraOpenFileDialog1.ShowDialog();
            xtraOpenFileDialog1.FileName = string.Empty;
            xtraOpenFileDialog1.RestoreDirectory = true;

            if (fileStream == DialogResult.OK)
            {
                txtImagemURL.Text = xtraOpenFileDialog1.FileName;
            }
        }

        private void BtnBuscarCategoria_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmProfessoresCategoriasAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }
        private void BtnBuscarAreFormacao_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmProfessoresAreaFormacaoAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult1 = await provinciasMunicipiosRepository.GetAll();
            provinciasMunicipiosBindingSource.DataSource = dataResult1;

            var dataResult2 = await professoresCategorias.GetAll();
            professoresCategoriasBindingSource.DataSource = dataResult2;

            var dataResult3 = await professoresAreaFormacaoRepository.GetAll();
            professorAreaFormacaoBindingSource.DataSource = dataResult3;

            txtProvinciaMunicipio.Properties.DataSource = dataResult1;
            txtCategoria.Properties.DataSource = dataResult2;
            txtAreaFormacao.Properties.DataSource = dataResult3;

            /// Enumeradoes
            txtNacionalidade.Properties.DataSource = Enum.GetValues(typeof(Nacionalidade));
            txtProvinciasFormacao.Properties.DataSource = Enum.GetValues(typeof(ProvinciasLocal));
            txtSexo.Properties.DataSource = Enum.GetValues(typeof(Sexo));
            txtEstadoCivil.Properties.DataSource = Enum.GetValues(typeof(EstadoCivil));
            txtEscolaridade.Properties.DataSource = Enum.GetValues(typeof(Escolaridade));
            txtTipoDocumentos.Properties.DataSource = Enum.GetValues(typeof(DocType));
            txtHabilitacoesLiterarias.Properties.DataSource = Enum.GetValues(typeof(AbilitacoesLiterarias));
            txtLocalEmissao.Properties.DataSource = Enum.GetValues(typeof(ProvinciasLocal));
            //txtprov.Properties.DataSource = Enum.GetValues(typeof(ProvinciasLocal));
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
                    var apagar = await DataRepository.Excluir(x => x.ProfessoresID == data);

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
                var codigo = string.IsNullOrWhiteSpace(txtCodigo.Text) == true ? await DataRepository.GetQR() : txtCodigoUnico.Text;

                // save Data
                var data = new Professores
                { 
                    ProfessoresID = ID,
                    FirstName = (string)txtFirstName.EditValue,
                    LastName = (string)txtLastName.EditValue,
                    BI = (string)txtBI.EditValue,
                    Nacionalidade = (Nacionalidade)txtNacionalidade.EditValue,
                    Sexo = (Sexo)txtSexo.EditValue,
                    EstadoCivil = (EstadoCivil)txtEstadoCivil.EditValue,
                    ProvinciaMunicipioID = (int)txtProvinciaMunicipio.EditValue,
                    NumeroAgente = (string) txtNumeroAgente.EditValue,

                    ProfessorCategoriaID = (int)txtCategoria.EditValue,
                    ProfessorAreaFormacaoID = (int) txtAreaFormacao.EditValue,

                    Residencia = (string)txtResidencia.EditValue,
                    Endereco = (string)txtenderco.EditValue,
                    Contacto = (string)txtContactos.EditValue,
                    Celular = (string)txtCelular.EditValue,
                    Email = (string)txtEmail.EditValue,
                    EmailFacebbok = (string)txtEmailFacebook.EditValue,

                    LocalEmissao = (ProvinciasLocal)txtLocalEmissao.EditValue,
                    DataEmissao = (DateTime)txtDataEmissao.DateTime,
                    DataExpiracao = (DateTime)txtDataExpiracao.DateTime,
                    DocType = (DocType)txtTipoDocumentos.EditValue,
                    Documento = (string)txtDocumento.EditValue,

                    Escolaridade = (Escolaridade) txtEscolaridade.EditValue,
                    abilitacoesLiterarias = (AbilitacoesLiterarias)txtHabilitacoesLiterarias.EditValue,
                    AreaEscola = (string)txtEscola.EditValue,
                    AreaDuracao = Convert.ToInt32(txtDuracao.EditValue, CultureInfo.CurrentCulture),
                    AreaData = (DateTime) txtData.DateTime,
                    AreaProvincia = (ProvinciasLocal) txtProvinciasFormacao.EditValue,
                  
                    IsActived = txtIsActived.Checked,
                    DataFicha = DateTime.Now,
                    DataNascimento =  txtDataNascimento.DateTime,              
                    ImagemURL = txtImagemURL.Text,   

                    Codigo = (string)codigo
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.ProfessoresID == ID) > 0 :
                                       await DataRepository.Guardar(data, true);

                if (IsValidate)
                {
                    // Imprimir Relatorio

                    #region Imprimir
                    var items = new List<Professores>();
                    items.Add(data);

                    GlobalReport.GetReport(new rptProfessores(items));
                    #endregion

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
                    if (dataResult.ProfessoresID != Convert.ToInt32(txtCodigo.Text))
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
                                                                     (x.ProfessorCategoriaID == (int) txtCategoria.EditValue) &&
                                                                      (x.ProfessorAreaFormacaoID == (int)txtProvinciasFormacao.EditValue)), null);
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
            txtResidencia.EditValue = string.Empty;
            txtenderco.EditValue = string.Empty;
            txtContactos.EditValue = string.Empty;
            txtCelular.EditValue = string.Empty;
            txtEmail.EditValue = string.Empty;
            txtEmailFacebook.EditValue = string.Empty;

            txtLocalEmissao.EditValue = DateTime.Now;
            txtDataEmissao.EditValue = DateTime.Now;
            txtDataExpiracao.EditValue = DateTime.Now;
            txtDataNascimento.EditValue = DateTime.Now;
            txtData.EditValue = DateTime.Now;

            txtDocumento.EditValue = string.Empty;
            txtDocumentoRecenciamnto.EditValue = string.Empty;
            txtIsActived.EditValue = string.Empty;

            txtEscola.EditValue = string.Empty;
            txtDuracao.EditValue = string.Empty;

            txtCodigo.EditValue = string.Empty;
            txtCodigoUnico.EditValue = string.Empty;
            txtImagemURL.Text = string.Empty;
            pictureEdit1.Image = null;

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

        private string localemissao = "[Selecione o local por favor]";
        private string tipodoc = "[Selecione o tipo de Doc por favor]";
        private string provinciaOrigem = "[Selecione a provincia de onde vem por favor]";
        private string nacionalidade = "[Selecione a Nacionalidade por Favor]";
        private string sexo = "[Selecione o seu Genero por favor]";
        private string estadocivil = "[Selecione o estado civil por favor]";
        private string municipioprovincia = "[Selecione a Provincia/Municipio por favor]";
        private string categoria = "[Selecione a categorias por favor]";
        private string areaformacao = "[Selecione a sua Area de Formação por favor]";           
        private string escolaridade = "[Selecione o nivel de escolaridade por favor]";
        private string habilitacoesliterarias = "[Selecione sua Habilitações lit. por favor]";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region FirstName
                if (control.Name.Equals(txtFirstName.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtFirstName.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&
                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                                                        !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) &&
                             !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion
                
                #region LastName
                else if (control.Name.Equals(txtLastName.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtLastName.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&

                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                             !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                             !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                             !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                             !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region BI
                else if (control.Name.Equals(txtBI.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtBI.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                                                !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Nacionalidade
                else if (control.Name.Equals(txtNacionalidade.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtNacionalidade.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&
                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                                                   !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region BI
                else if (control.Name.Equals(txtProvinciaMunicipio.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&

                                                          !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                                                     !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Sexo
                else if (control.Name.Equals(txtSexo.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtSexo.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&

                                                          !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                                                       !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Estado Civil
                else if (control.Name.Equals(txtEstadoCivil.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtEstadoCivil.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&


                                                          !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                                                     !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))

                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Categoria
                else if (control.Name.Equals(txtCategoria.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtCategoria.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&
                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                       
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Area Formaç]ao
                else if (control.Name.Equals(txtAreaFormacao.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtAreaFormacao.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&
                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&

                            !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Habilitacoes Literarias
                else if (control.Name.Equals(txtHabilitacoesLiterarias.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&

                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                             !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))

                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Escolaridade
                else if (control.Name.Equals(txtEscolaridade.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtEscolaridade.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&

                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                             !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                             !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                             !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                             !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))

                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Residencias
                else if (control.Name.Equals(txtResidencia.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtResidencia.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text)  &&
                             !string.IsNullOrWhiteSpace(txtBI.Text)        &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text)   &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                                                    !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))

                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Endereco
                else if (control.Name.Equals(txtenderco.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtenderco.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&
                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao) &&
                             !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) && !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))

                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                 #region Local-Emisssao
                else if (control.Name.Equals(txtLocalEmissao.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtLocalEmissao.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) &&
                             !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc))

                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                 #region Tipo-Documento
                else if (control.Name.Equals(txtTipoDocumentos.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtTipoDocumentos.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                             !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                             !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                             !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                             !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                             !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                             !string.IsNullOrWhiteSpace(txtBI.Text) &&
                             !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                             !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                             !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                             !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                             !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                             !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) &&
                             !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao))

                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                else
                {
                    if (!(string.IsNullOrWhiteSpace(txtNacionalidade.Text) || txtNacionalidade.Text == nacionalidade) &&
                            !(string.IsNullOrWhiteSpace(txtSexo.Text) || txtSexo.Text == sexo) &&
                            !(string.IsNullOrWhiteSpace(txtEstadoCivil.Text) || txtEstadoCivil.Text == estadocivil) &&
                            !(string.IsNullOrWhiteSpace(txtProvinciaMunicipio.Text) || txtProvinciaMunicipio.Text == municipioprovincia) &&
                            !(string.IsNullOrWhiteSpace(txtTipoDocumentos.Text) || txtTipoDocumentos.Text == tipodoc) &&
                            !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                            !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                            !string.IsNullOrWhiteSpace(txtBI.Text) &&
                            !string.IsNullOrWhiteSpace(txtenderco.Text) &&
                            !string.IsNullOrWhiteSpace(txtResidencia.Text) &&
                            !(string.IsNullOrWhiteSpace(txtCategoria.Text) || txtCategoria.Text == categoria) &&
                            !(string.IsNullOrWhiteSpace(txtAreaFormacao.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtHabilitacoesLiterarias.Text) || txtHabilitacoesLiterarias.Text == habilitacoesliterarias) &&
                            !(string.IsNullOrWhiteSpace(txtEscolaridade.Text) || txtAreaFormacao.Text == areaformacao) &&
                            !(string.IsNullOrWhiteSpace(txtLocalEmissao.Text) || txtLocalEmissao.Text == localemissao))

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

        private void ActivarGuardar()
        {
            if (txtEmail.Text.Contains("@"))
            {
                if (EmailValidade.GetIstance().IsValidEmail(txtEmail.Text))
                    windowsUIButtonPanel1.Enabled = true;
                else
                    windowsUIButtonPanel1.Enabled = false;
            }

            if (txtEmail.Text.Contains("@"))
            {
                if (EmailValidade.GetIstance().IsValidEmail(txtEmail.Text))
                    windowsUIButtonPanel1.Enabled = true;
                else
                    windowsUIButtonPanel1.Enabled = false;
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