using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Controllers.Repository.Biblioteca;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmBiblioteca_PedidosAdd : XtraUserControl
    {
        IPedidos PedidosRepository;
        IPedidosOrdem PedidosOrdemRepository;
        IEstudantes EstudantesRespository;

        List<Livros> livrosOriginalList;

        bool IsValidate = false;

        public frmBiblioteca_PedidosAdd(Pedidos usuarios = null)
        {
            InitializeComponent();

            txtDataReserva.DateTime = DateTime.Now;
            txtdatEntrega.DateTime = DateTime.Now.AddDays(5);

            PedidosRepository = new PedidosRepository();
            PedidosOrdemRepository = new PedidosOrdemRepository();
            EstudantesRespository =  new EstudantesRepository();

            livrosOriginalList = new List<Livros>();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtEstado.EditValueChanged += delegate { ChangeValudations(txtEstado); };
            txtDescricao.EditValueChanged += delegate { ChangeValudations(txtDescricao);};
            txtDocumentos.EditValueChanged += delegate { ChangeValudations(txtDocumentos); };
            txtEstudantes.EditValueChanged += delegate { ChangeValudations(txtEstudantes); };

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

            // Menu de Contexto
            #region Menu Populat
            MenuPrinciapl.Opening += ContextMenuStrip1_Opening;
            gridControl1.ContextMenuStrip = MenuPrinciapl;
            btnBuscarItems.Click += BtnBuscarItems_Click;

            //btnApagar.Click += Apagar_Click;
            //btnAtualizar.Click += Atualizar_Click;
            btnRelatorios.Click += delegate { gridControl1.ShowRibbonPrintPreview(); };
            #endregion

            this.Load += FrmUsuariosAdd_Load;

            txtDesconto.ValueChanged += TxtDesconto_ValueChanged;

            txtEstudantes.KeyDown += TxtEstudantes_KeyDown;

            btnApagar.Click += delegate { Apagar(); };
        }

        private void TxtEstudantes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var result = estudantesBindingSource.Current as Estudantes;

                if (result != null)
                {
                    txtFullName.EditValue = result.FullName;
                    txtTelemovel.EditValue = result.Telemovel;
                    windowsUIButtonPanel1.Focus();
                }
            }
        }

        private void TxtDesconto_ValueChanged(object sender, EventArgs e)
        {
            txtTotal.Value = txtSubTotal.Value - txtDesconto.Value;
        }

        private void BtnBuscarItems_Click(object sender, EventArgs e)
        {
            // Buscar Grupos

            var frmBuscar = new frmBiblioteca_PedidosBuscar();

            var forms = new OpenFormsDialog(null, null, frmBuscar);

           var t = forms.ShowDialog();

            if (t == DialogResult.None || t == DialogResult.Cancel)
            {
                var LivrosBuscar = frmBuscar.livrosBindingSource.Current as Livros;

                if (LivrosBuscar != null)
                {
                    var Existe = livrosOriginalList.Find(x => x.LivrosID == LivrosBuscar.LivrosID);

                    if (livrosOriginalList.Count == 0)
                    {
                        livrosOriginalList.Add(LivrosBuscar);
                    }
                    else if (Existe == null)
                    {
                        livrosOriginalList.Add(LivrosBuscar);
                    }
                }

                livrosBindingSource.DataSource = livrosOriginalList;
                livrosBindingSource.ResetBindings(true);

                Calculos();
            }
        }

        private void Calculos()
        {
            var total = livrosOriginalList.Sum(x => x.TotalGeral);
            txtDesconto.Properties.MaxValue = total;

            txtSubTotal.Value = total;
            txtSubTotal.Value = total - txtDesconto.Value;
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if ((gridView1.SelectedRowsCount > 0) || (gridView1.FocusedRowHandle > 0))
            {
                btnApagar.Enabled = true;
                btnAtualizar.Enabled = true;
                btnRelatorios.Enabled = true;
                btnReportdatabase.Enabled = true;
            }
            else
            {
                btnApagar.Enabled = false;
                btnAtualizar.Enabled = false;
                btnRelatorios.Enabled = false;
                btnReportdatabase.Enabled = false;
            }
        }

        private void BtnBuscarEdicoes_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmBiblioteca_EditorasAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult1 = await EstudantesRespository.GetAll();
            estudantesBindingSource.DataSource = dataResult1;

            txtEstado.Properties.DataSource = Enum.GetValues(typeof(PedidosEstado)); 
            txtDocumentos.Properties.DataSource = Enum.GetValues(typeof(PedidosDocuments));

            gridControl1.ContextMenuStrip = MenuPrinciapl;
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
                    default:
                        Apagar();
                        break;
                }
            }
        }

        private void Apagar()
        {
            var existe = livrosBindingSource.Current as Livros;

            if (existe != null)
            {
                var msg = Mensagens.Display("Apagar Permanentemente",
                                         "Queres apagar de forma permanente esta informação?", MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    livrosOriginalList.Remove(existe);

                    livrosBindingSource.DataSource = livrosOriginalList;
                    livrosBindingSource.ResetBindings(true);

                    Calculos();
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

            txtDescricao.EditValue = string.Empty;
            txtTelemovel.EditValue = string.Empty;
            txtDoc_Numero.EditValue = string.Empty;
            txtFullName.EditValue = string.Empty;
            txtFavoritar.EditValue = string.Empty;

            livrosOriginalList.Clear();
            livrosBindingSource.DataSource = livrosOriginalList;
            
            Calculos();

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
                #region Descricao
                if (control.Name.Equals(txtDescricao.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtDocumentos.Text) || txtDocumentos.Text == "[Selecione o documento por favor]") &&
                             !(string.IsNullOrWhiteSpace(txtEstudantes.Text) || txtEstudantes.Text == "[Selecione o estado por favor]") &&
                             !(string.IsNullOrWhiteSpace(txtEstado.Text) || txtEstado.Text == "[Selecione o estudante por favor]"))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Documentos
                if (control.Name.Equals(txtDocumentos.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDocumentos.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtDescricao.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtEstudantes.Text) || txtEstudantes.Text == "[Selecione o estudante por favor]") &&
                            !(string.IsNullOrWhiteSpace(txtEstado.Text) || txtEstado.Text == "[Selecione o estado por favor]"))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Estudantes
                if (control.Name.Equals(txtEstudantes.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtEstudantes.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtDescricao.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtDocumentos.Text) || txtDocumentos.Text == "[Selecione o documento por favor]") &&
                            !(string.IsNullOrWhiteSpace(txtEstado.Text) || txtEstado.Text == "[Selecione o estado por favor]"))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Estados
                if (control.Name.Equals(txtEstado.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtEstado.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtDescricao.Text)) &&
                            !(string.IsNullOrWhiteSpace(txtDocumentos.Text) || txtDocumentos.Text == "[Selecione o documento por favor]") &&
                            !(string.IsNullOrWhiteSpace(txtEstudantes.Text) || txtEstudantes.Text == "[Selecione o estudante por favor]"))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
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
    }
}