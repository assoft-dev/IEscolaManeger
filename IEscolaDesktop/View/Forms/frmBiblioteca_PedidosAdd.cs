using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaDesktop.View.ReportForms;
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
        List<PedidosOrdems> livrosOriginalList;

        public frmBiblioteca_PedidosAdd(Pedidos usuarios = null)
        {
            InitializeComponent();

            txtDataReserva.DateTime = DateTime.Now;
            txtdatEntrega.DateTime = DateTime.Now.AddDays(5);

            PedidosRepository = new PedidosRepository();
            PedidosOrdemRepository = new PedidosOrdemRepository();
            EstudantesRespository =  new EstudantesRepository();

            livrosOriginalList = new List<PedidosOrdems>();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtEstado.EditValueChanged += delegate { ChangeValudations(txtEstado); };
            txtDescricao.EditValueChanged += delegate { ChangeValudations(txtDescricao);};
            txtDocumentos.EditValueChanged += delegate { ChangeValudations(txtDocumentos); };
            txtEstudantes.EditValueChanged += delegate { ChangeValudations(txtEstudantes); };
            txtEstudantes.Properties.EditValueChanged += Properties_EditValueChanged; ;
            btnestudantes.Click += BtnBuscarEdicoes_Click;

            this.Load += FrmUsuariosAdd_Load;
            txtDesconto.EditValueChanged += CalculosDesconto;
            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            // Menu de Contexto
            #region Menu Populat
            MenuPrinciapl.Opening += ContextMenuStrip1_Opening;
            gridControl1.ContextMenuStrip = MenuPrinciapl;
            btnBuscarItems.Click += BtnBuscarItems_Click;
            btnApagar.Click += delegate { RemoverCarrinho(); };

            //btnApagar.Click += Apagar_Click;
            //btnAtualizar.Click += Atualizar_Click;
            btnRelatorios.Click += delegate { gridControl1.ShowRibbonPrintPreview(); };
            #endregion


            txtDesconto.ValueChanged += TxtDesconto_ValueChanged;


            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtCodigo.EditValue = usuarios.PedidosID;
                txtDoc_Numero.EditValue = usuarios.DocNumero;
                txtIsValido.EditValue = usuarios.IsValid;
                txtDescricao.EditValue = usuarios.Descricao;
                txtdatEntrega.EditValue = usuarios.DataEntrega;
                txtDataReserva.EditValue = usuarios.DataReserva;
                txtDocumentos.EditValue = usuarios.PedidosDocuments;
                txtEstudantes.EditValue = usuarios.EstudantesID;
                txtEstado.EditValue = usuarios.PedidosEstado;

                // Preencher estudantes
                var estuda = estudantesBindingSource.List as Estudantes;
                if (estuda != null) {
                    txtFullName.EditValue = estuda.Inscricoes.FullName;
                    txtTelemovel.EditValue = estuda.Inscricoes.Celular;
                }
                else
                {
                    var estudantes = EstudantesRespository.Get(x => x.EstudantesID == (int) txtEstudantes.EditValue, null);
                    if (estudantes != null)
                    {
                        Task.Factory.StartNew(async () =>
                        {
                            var t = await estudantes;
                            txtFullName.EditValue = t.Inscricoes.FullName;
                            txtTelemovel.EditValue = t.Inscricoes.Celular;
                        });                    
                    }
                }

                livrosOriginalList = usuarios.PedidosOrdems;
                pedidosOrdemsBindingSource.DataSource = livrosOriginalList;
                Calculos();



                txtDescricao.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }
        }

        private void Properties_EditValueChanged(object sender, EventArgs e)
        {
            var result = estudantesBindingSource.Current as Estudantes;

            if (result != null)
            {
                txtFullName.EditValue = result.Inscricoes.FullName;
                txtTelemovel.EditValue = result.Inscricoes.Celular;
                windowsUIButtonPanel1.Focus();
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
                        livrosOriginalList.Add(new PedidosOrdems {  
                            DocNumero = null,
                            PedidoID = 0,
                            PedidosOrdemID = 0,
                            Quantidade = (int) LivrosBuscar.Quantidade,
                            Precounitario = (decimal) LivrosBuscar.PrecoUnitario ,
                            Total = LivrosBuscar.TotalGeral,
                            LivrosID = LivrosBuscar.LivrosID,
                            Livros = LivrosBuscar,
                            FirstName = txtEstudantes.Text,

                            ISBN= LivrosBuscar.ISBN,
                            Titulo = LivrosBuscar.Titulo,
                        });
                    }
                    else if (Existe == null)
                    {
                        livrosOriginalList.Add(new PedidosOrdems
                        {
                            DocNumero = null,
                            PedidoID = 0,
                            PedidosOrdemID = 0,
                            Quantidade = (int)LivrosBuscar.Quantidade,
                            Precounitario = (decimal)LivrosBuscar.PrecoUnitario,
                            Total = LivrosBuscar.TotalGeral,
                            LivrosID = LivrosBuscar.LivrosID,
                            Livros = LivrosBuscar,
                            FirstName = txtEstudantes.Text,

                            ISBN = LivrosBuscar.ISBN,
                            Titulo = LivrosBuscar.Titulo,
                        });
                    }
                }

                pedidosOrdemsBindingSource.DataSource = livrosOriginalList;
                pedidosOrdemsBindingSource.ResetBindings(true);
                Calculos();
            }
        }

        private void Calculos()
        {
            var total = livrosOriginalList.Sum(x => x.Total);
            txtDesconto.Properties.MaxValue = total;

            txtTotal.Value = total;
            txtSubTotal.Value = total - txtDesconto.Value;
        } 
        private void CalculosDesconto(object e, EventArgs eventArgs)
        {
            txtTotal.Value = txtSubTotal.Value - txtDesconto.Value;
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
                    var apagar = await PedidosRepository.Excluir(x => x.PedidosID == data);

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

        private void RemoverCarrinho()
        {
            var existe = pedidosOrdemsBindingSource.Current as PedidosOrdems;

            if (existe != null)
            {
                var msg = Mensagens.Display("Apagar Permanentemente",
                                         "Queres apagar de forma permanente esta informação?", MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

                if (msg == DialogResult.Yes)
                {
                    livrosOriginalList.Remove(existe);

                    pedidosOrdemsBindingSource.DataSource = livrosOriginalList;
                    pedidosOrdemsBindingSource.ResetBindings(true);

                    Calculos();
                }
            }
        }

        private async void Guardar()
        {
            if (!await ValidationDatabase())
            {
                var ID = string.IsNullOrWhiteSpace(txtCodigo.Text)  ? 0 : (int)txtCodigo.EditValue;
                var NumeroDoc = await PedidosRepository.GetQR();

                await PedidosRepository.TaskExecutes(async () =>
                {
                    // save Data
                    var pedido = new Pedidos
                    {
                        PedidosID = ID,
                        Descricao = txtDescricao.Text,
                        DocNumero = NumeroDoc,
                        DataEntrega = (DateTime)txtdatEntrega.DateTime,
                        DataReserva = (DateTime)txtDataReserva.DateTime,
                        IsValid = (bool)txtIsValido.IsOn,
                        PedidosEstado = (PedidosEstado)txtEstado.EditValue,
                        PedidosDocuments = (PedidosDocuments)txtDocumentos.EditValue,
                        EstudantesID = (int)txtEstudantes.EditValue,
                        TotalGeral = (decimal)txtTotal.EditValue,
                    };
                    var IDResult = PedidosRepository.DoInsertReturnAsync(pedido);

                    var ordem = pedidosOrdemsBindingSource.List as IList<PedidosOrdems>;

                    foreach (var item in ordem)
                    {
                        var pedidoOrdem = new PedidosOrdems
                        {
                            DocNumero = NumeroDoc,
                            Livros = item.Livros,
                            LivrosID = item.LivrosID,
                            PedidoID = IDResult.PedidosID,

                            Quantidade = item.Quantidade,
                            Total = item.Total,
                            Precounitario = item.Precounitario,

                            FirstName = item.FirstName,
                            ISBN = item.ISBN,
                            Titulo = item.Titulo,
                        };
                        PedidosRepository.DoSaveAsync(pedidoOrdem);
                    }
                });

                if (PedidosRepository.EndTransaction().Estado)
                {
                    Mensagens.Display("Guardar Dados", "Dados Guardados com muito Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Imprimir o comprovativo

                    #region Imprimir
                    var data = new List<Pedidos>();
                    {

                    };

                    GlobalReport.GetReport(new rptPedidoInvoice(data));
                    #endregion

                    Limpar();
                }
                else {
                    Mensagens.Display("Impossivel Guardar Dados", "Não foi possivel guardar a informação requerida",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Error);
                }
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
            txtIsValido.EditValue = string.Empty;

            livrosOriginalList.Clear();
            pedidosOrdemsBindingSource.DataSource = livrosOriginalList;
            
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