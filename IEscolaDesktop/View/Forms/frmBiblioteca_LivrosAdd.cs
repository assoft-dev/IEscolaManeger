using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Summary.Native;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Controllers.Repository.Biblioteca;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmBiblioteca_LivrosAdd : XtraUserControl
    {
        ILivros DataRepository;
        IEditoras EditoresRepository;
        IAutores AutoresRepository;
        ICategorias CateoriaRepository;

        bool IsValidate = false;

        public frmBiblioteca_LivrosAdd(Livros usuarios = null)
        {
            InitializeComponent();

            DataRepository = new LivrosRepository ();
            EditoresRepository = new EditorasRepository();
            AutoresRepository = new AutoresRepository();
            CateoriaRepository =  new CategoriasRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtDisponibilidade.EditValueChanged += delegate { ChangeValudations(txtDisponibilidade); };
            txtCAtegoria.EditValueChanged += delegate { ChangeValudations(txtCAtegoria); };

            btnEditoras.Click += BtnBuscarEdicoes_Click;
            btnAutor.Click += BtnBuscarAutores_Click;
            btnCategoria.Click += BtnBuscarCategoria_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtTitulos.EditValue = usuarios.Titulo;
                txtSubtitulos.EditValue = usuarios.SubTitulo;
                txtSbn.EditValue = usuarios.ISBN;
                txtEdicoes.EditValue = usuarios.Edicao;
                txtDescricao.EditValue = usuarios.Descricao;
                txtComentarios.EditValue = usuarios.Comentarios;
                txtLancamento.EditValue = usuarios.Lancamento;
                txtLocalLancamento.EditValue = usuarios.LocalLancamento;            
                txtCodigoBarra.EditValue = usuarios.CodBar;
                txtValidade.EditValue = usuarios.IsValidade;
                txtPratileira.EditValue = usuarios.Pratileira;
                txtPratileiraPosicao.EditValue = usuarios.PratileiraPosicao;
                txtRating.EditValue = usuarios.Rating;
                txtFavoritar.EditValue = usuarios.Favoritar;
                txtAno.EditValue = usuarios.Ano;
                txtEdicoes.EditValue = usuarios.EditorasID;
                txtAutor.EditValue = usuarios.AutoresID;
                txtCAtegoria.EditValue = usuarios.CategoriasID;
                txtDisponibilidade.EditValue = usuarios.Disponibilidade;
                txtTitulos.Focus();
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
            var dataResult1 = await EditoresRepository.GetAll();
            editoresBindingSource.DataSource = dataResult1;

            var dataResult2 = await AutoresRepository.GetAll();
            autoresBindingSource.DataSource = dataResult2;

            txtDisponibilidade.Properties.DataSource = Enum.GetValues(typeof(Disponibilidade)); 

            var dataResult4 = await CateoriaRepository.GetAll();
            categoriasBindingSource.DataSource = dataResult4;
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
                var ID = string.IsNullOrWhiteSpace(txtCodigo.Text) == true ? 0 : (int)txtCodigo.EditValue;

                // save Data
                var data = new Livros
                {
                    LivrosID = ID,
                    Titulo =  (string) txtAno.EditValue,
                    SubTitulo = (string) txtAno.EditValue,
                    ISBN = (string) txtAno.EditValue,
                    Edicao = (string) txtAno.EditValue,
                    Descricao = (string) txtAno.EditValue,
                    Comentarios = (string) txtAno.EditValue,
                    Lancamento = (string) txtAno.EditValue,
                    LocalLancamento = (string) txtAno.EditValue,
                    CodBar = (string) txtAno.EditValue,
                    IsValidade = (bool) txtAno.EditValue,
                    Pratileira = (string) txtAno.EditValue,
                    PratileiraPosicao = (string) txtAno.EditValue,
                    Rating = (int) txtAno.EditValue,
                    Favoritar = (bool) txtAno.EditValue,
                    Ano = (int) txtAno.EditValue,

                    CategoriasID = (int) txtAno.EditValue,
                    EditorasID = (int) txtAno.EditValue,
                    AutoresID = (int)txtAno.EditValue,
                    Disponibilidade = (Disponibilidade) txtAno.EditValue,
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
            var dataResult = await DataRepository.Get(x => (x.Descricao.ToUpper() == txtTitulos.Text.ToUpper()) &&
                                                           ((x.EditorasID == (int) txtAutor.EditValue) && 
                                                           (x.AutoresID == (int) txtCAtegoria.EditValue) &&
                                                           (x.CategoriasID == (int) txtEditora.EditValue)), null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.EditorasID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores as Atualiar", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtDisponibilidade.SelectAll();
                        txtDisponibilidade.Focus();
                        return true;
                    }

                    // Verificar a possibilidade de atualizar com base nos valores Sala Cursos e Periodos
                    var dataResult2 = await DataRepository.Get(x => ((x.EditorasID == (int)txtAutor.EditValue) &&
                                                                     (x.AutoresID == (int)txtCAtegoria.EditValue) &&
                                                                     (x.CategoriasID == (int)txtEditora.EditValue)), null);
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

                    txtDisponibilidade.SelectAll();
                    txtDisponibilidade.Focus();

                    return true;
                }
            }
            return false;
        }

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtTitulos.EditValue = string.Empty;
            txtTitulos.EditValue = string.Empty;
            txtSubtitulos.EditValue = string.Empty;
            txtSbn.EditValue = string.Empty;
            txtEdicoes.EditValue = string.Empty;
            txtDescricao.EditValue = string.Empty;
            txtComentarios.EditValue = string.Empty;
            txtLancamento.EditValue = string.Empty;
            txtLocalLancamento.EditValue = string.Empty;
            txtCodigoBarra.EditValue = string.Empty; ;
            txtValidade.EditValue = string.Empty;
            txtPratileira.EditValue = string.Empty;
            txtPratileiraPosicao.EditValue = string.Empty;
            txtRating.EditValue = string.Empty;
            txtFavoritar.EditValue = string.Empty;
            txtAno.EditValue = string.Empty;
            txtDisponibilidade.EditValue = string.Empty;
            txtTitulos.Focus();

            txtCodigo.Text = string.Empty;
            txtTitulo.Text = "[Novo]";
            txtTitulos.Focus();
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
                #region Descricao
                if (control.Name.Equals(txtTitulos.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtTitulos.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtCAtegoria.Text) || txtCAtegoria.Text == "[Selecione o Curso por favor]") &&
                             !(string.IsNullOrWhiteSpace(txtAutor.Text) || txtAutor.Text == "[Selecione a Sala por por favor]") &&
                             !(string.IsNullOrWhiteSpace(txtEditora.Text) || txtEditora.Text == "[Selecione o Periodo por favor]") &&
                             !(string.IsNullOrWhiteSpace(txtDisponibilidade.Text) || txtDisponibilidade.Text == "[Selecione a Classe por favor]"))
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

                #region Provincias
                if (control.Name.Equals(txtDisponibilidade.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDisponibilidade.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtCAtegoria.Text) || txtCAtegoria.Text == "[Selecione o municipio por favor]"))
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
                if (control.Name.Equals(btnCategoria.Name))
                {
                    if (!string.IsNullOrWhiteSpace(btnCategoria.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtDisponibilidade.Text) || txtDisponibilidade.Text == "[Selecione a provincia por favor]"))
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