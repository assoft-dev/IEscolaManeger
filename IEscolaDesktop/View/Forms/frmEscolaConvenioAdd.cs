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
    public partial class frmEscolaConvenioAdd : XtraUserControl
    {
        IEntidadeConvenios DataRepository;
        ICursoClasseDisciplina paisRepository;
        IEntidades EntidadesRepository;
        bool IsValidate = false;

        public frmEscolaConvenioAdd(EntidadeConvenios usuarios = null)
        {
            InitializeComponent();

            DataRepository = new EntidadeConvenioRepository();
            paisRepository = new CursoClasseDisciplinaRepository();
            EntidadesRepository = new EntidadeRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtDescricao.EditValueChanged += delegate { ChangeValudations(txtDescricao); };
            txtEntidade.EditValueChanged += delegate { ChangeValudations(txtEntidade); };
            txtEstado.EditValueChanged += delegate { ChangeValudations(txtEstado); };
            txtCursoClasseDesciplinas.EditValueChanged += delegate { ChangeValudations(txtCursoClasseDesciplinas); };

            btnBuscarGrupos.Click += BtnBuscarGrupos_Click;
            btnEntidade.Click += BtnBuscarGrupos2_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtDescricao.EditValue = usuarios.Descricao;
                txtEstado.EditValue = usuarios.EntidadeConvenioEstado;
                txtEntidade.EditValue = usuarios.EntidadeID;
                txtCursoClasseDesciplinas.EditValue = usuarios.CursosClasseDisciplinasID;
                txtDescricao.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;

            txtCursoClasseDesciplinas.Properties.NullText = cursosClassedisci;
            txtEntidade.Properties.NullText = entidade;
            txtEstado.Properties.NullText = estado;
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmCursoClasseDisciplinaAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private void BtnBuscarGrupos2_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmEscolasAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult = await paisRepository.GetAll();
            cursoClasseDisciplinaBindingSource.DataSource = dataResult;

            var dataResult2 = await EntidadesRepository.GetAll();
            entidadeBindingSource.DataSource = dataResult2;

            txtEstado.Properties.DataSource = Enum.GetValues(typeof(EntidadeConvenioEstado));
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
                    var apagar = await DataRepository.Excluir(x => x.EntidadeConveniosID == data);

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
                var data = new EntidadeConvenios
                { 
                    EntidadeConveniosID = ID,
                    EntidadeConvenioEstado = (EntidadeConvenioEstado) txtEstado.EditValue,
                    Descricao = txtDescricao.Text.Trim(),
                    CursosClasseDisciplinasID = Convert.ToInt16(txtCursoClasseDesciplinas.EditValue), 
                    EntidadeID = Convert.ToInt16(txtEntidade.EditValue), 
                    DataSolicitacao = DateTime.Now,
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.EntidadeConveniosID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => x.Descricao == txtDescricao.Text, null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.EntidadeConveniosID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtDescricao.SelectAll();
                        txtDescricao.Focus();

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
            txtDescricao.Text = string.Empty;
            txtDescricao.Text = string.Empty; 
            
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

        private string entidade = "* [Selecione a Entidade em referencia";
        private string cursosClassedisci = "* [Selecione a Disciplina [Curso => Claase => Disciplina]";
        private string estado = "* [Selecione o Estado por favor";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Descricao
                if (control.Name.Equals(txtDescricao.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                            !(string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text) || txtCursoClasseDesciplinas.Text == cursosClassedisci) &&
                            !(string.IsNullOrWhiteSpace(txtEntidade.Text) || txtEntidade.Text == entidade) &&
                            !(string.IsNullOrWhiteSpace(txtEstado.Text) || txtEstado.Text == estado))
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
                else if (control.Name.Equals(txtEstado.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtEstado.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                            !(string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text) || txtCursoClasseDesciplinas.Text == cursosClassedisci) &&
                             !(string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text) || txtCursoClasseDesciplinas.Text == cursosClassedisci) &&
                            !(string.IsNullOrWhiteSpace(txtEntidade.Text) || txtEntidade.Text == entidade))
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
                
                #region Curso => Classe => Disciplina
                else if (control.Name.Equals(txtCursoClasseDesciplinas.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                            !(string.IsNullOrWhiteSpace(txtEntidade.Text) || txtEntidade.Text == entidade) &&
                            !(string.IsNullOrWhiteSpace(txtEstado.Text) || txtEstado.Text == estado))
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

                else
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                        !(string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text) || txtCursoClasseDesciplinas.Text == cursosClassedisci) &&
                            !(string.IsNullOrWhiteSpace(txtEntidade.Text) || txtEntidade.Text == entidade) &&
                            !(string.IsNullOrWhiteSpace(txtEstado.Text) || txtEstado.Text == estado))
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