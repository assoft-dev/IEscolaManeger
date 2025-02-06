using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Controllers.Repository.Biblioteca;
using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using ServiceStack.Script;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmBiblioteca_PedidosAdd : XtraUserControl
    {
        ILivros LivrosRepository;

        IPedidos PedidosRepository;
        IPedidosOrdem PedidosOrdemRepository;
        IEstudantes EstudantesRespository;

        bool IsValidate = false;

        public frmBiblioteca_PedidosAdd(Pedidos usuarios = null)
        {
            InitializeComponent();

            LivrosRepository = new LivrosRepository ();
            PedidosRepository = new PedidosRepository();
            PedidosOrdemRepository = new PedidosOrdemRepository();
            EstudantesRespository =  new EstudantesRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtEstado.EditValueChanged += delegate { ChangeValudations(txtEstado); };
            txtDocumentos.EditValueChanged += delegate { ChangeValudations(txtDocumentos); };

            btnestudantes.Click += BtnBuscarEdicoes_Click;
            //btnAutor.Click += BtnBuscarAutores_Click;
            //btnCategoria.Click += BtnBuscarCategoria_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                //txtTitulos.EditValue = usuarios.Titulo;
                //txtSubtitulos.EditValue = usuarios.SubTitulo;
                //txtSbn.EditValue = usuarios.ISBN;
                //txtEdicoes.EditValue = usuarios.Edicao;
                //txtDescricao.EditValue = usuarios.Descricao;
                //txtComentarios.EditValue = usuarios.Comentarios;
                //txtLancamento.EditValue = usuarios.Lancamento;
                //txtLocalLancamento.EditValue = usuarios.LocalLancamento;            
                //txtCodigoBarra.EditValue = usuarios.CodBar;
                //txtValidade.EditValue = usuarios.IsValidade;
                //txtPratileira.EditValue = usuarios.Pratileira;
                //txtPratileiraPosicao.EditValue = usuarios.PratileiraPosicao;
                //txtRating.EditValue = usuarios.Rating;
                //txtFavoritar.EditValue = usuarios.Favoritar;
                //txtAno.EditValue = usuarios.Ano;
                //txtEdicoes.EditValue = usuarios.EditorasID;
                //txtAutor.EditValue = usuarios.AutoresID;
                //txtCAtegoria.EditValue = usuarios.CategoriasID;
                //txtDisponibilidade.EditValue = usuarios.Disponibilidade;
                txtDescricao.Focus();
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
        //private void BtnBuscarAutores_Click(object sender, EventArgs e)
        //{
        //    // Buscar Grupos
        //    var forms = OpenFormsDialog.ShowForm(null,
        //          new frmBiblioteca_AutoresAdd());

        //    if (forms == DialogResult.None || forms == DialogResult.Cancel)
        //        FrmUsuariosAdd_Load(null, null);
        //}
        //private void BtnBuscarCategoria_Click(object sender, EventArgs e)
        //{
        //    // Buscar Grupos
        //    var forms = OpenFormsDialog.ShowForm(null,
        //          new frmBiblioteca_CategoriasAdd());

        //    if (forms == DialogResult.None || forms == DialogResult.Cancel)
        //        FrmUsuariosAdd_Load(null, null);
        //}

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult1 = await EstudantesRespository.GetAll();
            estudantesBindingSource.DataSource = dataResult1;

            var dataResult2 = await LivrosRepository.GetAll();
            livrosBindingSource.DataSource = dataResult2;

            txtEstado.Properties.DataSource = Enum.GetValues(typeof(PedidosEstado)); 
            txtDocumentos.Properties.DataSource = Enum.GetValues(typeof(PedidosDocuments)); 
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
                    var apagar = await LivrosRepository.Excluir(x => x.AutoresID == data);

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
                //var ID = string.IsNullOrWhiteSpace(txtCodigo.Text) == true ? 0 : (int)txtCodigo.EditValue;

                //// save Data
                //var data = new Pedidos
                //{
                //    LivrosID = ID,
                //    Titulo =  (string) txtTitulos.Text.Trim(),
                //    SubTitulo = (string) txtSubtitulos.Text.Trim(),
                //    ISBN = (string) txtSbn.Text.Trim(),
                //    Edicao = (string) txtEdicoes.Text.Trim(),
                //    Descricao = (string) txtDescricao.Text.Trim(),
                //    Comentarios = (string) txtComentarios.Text.Trim(),
                //    Lancamento = (string) txtDataReserva.Text.Trim(),
                //    LocalLancamento = (string) txtTelemovel.Text.Trim(),
                //    CodBar = (string) txtdatEntrega.Text.Trim(),
                //    IsValidade = (bool) txtValidade.EditValue,
                //    Pratileira = (string) txtDoc_Numero.Text.Trim(),
                //    PratileiraPosicao = (string) txtFullName.Text.Trim(),
                //    Rating = (int) txtRating.EditValue,
                //    Favoritar = (bool) txtFavoritar.EditValue,
                //    Ano = Convert.ToInt32(txtAno.EditValue, CultureInfo.CurrentCulture),

                //    CategoriasID = (int) txtAno.EditValue,
                //    EditorasID = (int) txtAno.EditValue,
                //    AutoresID = (int)txtAno.EditValue,
                //    Disponibilidade = (Disponibilidade) txtAno.EditValue,
                //};

                //IsValidate = ID != 0 ? await LivrosRepository.Guardar(data, X => X.AutoresID == ID) > 0 :
                //                       await LivrosRepository.Guardar(data, true);

                //if (IsValidate)
                //{
                //    Mensagens.Display("Guardar Dados", "Dados Guardados com muito Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    Limpar();
                //}
                //else
                //    Mensagens.Display("Impossivel Guardar Dados", "Não foi possivel guardar a informação requerida",
                //                       MessageBoxButtons.OK,
                //                       MessageBoxIcon.Error);
            }      
        }

        private async Task<bool> ValidationDatabase()
        {
            var dataResult = await PedidosRepository.Get(x => (x.Descricao.ToUpper() == txtDescricao.Text.ToUpper()) &&
                                                              ((x.EstudantesID == (int) txtEstudantes.EditValue) && 
                                                              (x.DocNumero == (string) txtDoc_Numero.EditValue)), null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.PedidosID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores as Atualiar", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtEstado.SelectAll();
                        txtEstado.Focus();
                        return true;
                    }

                    // Verificar a possibilidade de atualizar com base nos valores Sala Cursos e Periodos
                    var dataResult2 = await PedidosRepository.Get(x => ((x.DocNumero == (string) txtDoc_Numero.EditValue) &&
                                                                     (x.PedidosDocuments == (PedidosDocuments)txtDocumentos.EditValue)), null);
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

                    txtEstado.SelectAll();
                    txtEstado.Focus();
                    return true;
                }
            }
            return false;
        }

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            //txtTitulos.EditValue = string.Empty;
            //txtTitulos.EditValue = string.Empty;
            //txtSubtitulos.EditValue = string.Empty;
            //txtSbn.EditValue = string.Empty;
            //txtEdicoes.EditValue = string.Empty;
            //txtComentarios.EditValue = string.Empty;
            //txtValidade.EditValue = string.Empty;
            //txtRating.EditValue = string.Empty;
            //txtAno.EditValue = string.Empty;

            txtDescricao.EditValue = string.Empty;
            txtDataReserva.EditValue = string.Empty;
            txtTelemovel.EditValue = string.Empty;
            txtdatEntrega.EditValue = string.Empty; ;
            txtDoc_Numero.EditValue = string.Empty;
            txtFullName.EditValue = string.Empty;
            txtFavoritar.EditValue = string.Empty;
            txtEstado.EditValue = string.Empty;

            txtCodigo.Text = string.Empty;
            txtTitulo.Text = "[Novo]";
            txtDescricao.Focus();
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
                //if (control.Name.Equals(txtTitulos.Name))
                //{
                //    if (!string.IsNullOrWhiteSpace(txtTitulos.Text))
                //    {
                //        if (!(string.IsNullOrWhiteSpace(txtDocumentos.Text) || txtDocumentos.Text == "[Selecione o Curso por favor]") &&
                //             !(string.IsNullOrWhiteSpace(txtEstudantes.Text) || txtEstudantes.Text == "[Selecione a Sala por por favor]") &&
                //             !(string.IsNullOrWhiteSpace(txtEditora.Text) || txtEditora.Text == "[Selecione o Periodo por favor]") &&
                //             !(string.IsNullOrWhiteSpace(txtEstado.Text) || txtEstado.Text == "[Selecione a Classe por favor]"))
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
                //if (control.Name.Equals(txtEstado.Name))
                //{
                //    if (!string.IsNullOrWhiteSpace(txtEstado.Text))
                //    {
                //        if (!(string.IsNullOrWhiteSpace(txtDocumentos.Text) || txtDocumentos.Text == "[Selecione o municipio por favor]"))
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
                //        if (!(string.IsNullOrWhiteSpace(txtEstado.Text) || txtEstado.Text == "[Selecione a provincia por favor]"))
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
    }
}