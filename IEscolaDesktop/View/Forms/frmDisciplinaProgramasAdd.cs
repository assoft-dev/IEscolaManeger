using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmDisciplinaProgramasAdd : XtraUserControl
    {
        IDisciplinaPrograma DataRepository;
        ICursoClasseDisciplina paisRepository;
        bool IsValidate = false;

        public frmDisciplinaProgramasAdd(DisciplinasProgramas usuarios = null)
        {
            InitializeComponent();

            DataRepository = new DisciplinaProgramaRepository();
            paisRepository = new CursoClasseDisciplinaRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txttitulo2.EditValueChanged += delegate { ChangeValudations(txttitulo2); };
            txtDescricao.EditValueChanged += delegate { ChangeValudations(txtDescricao); };
            txtLei.EditValueChanged += delegate { ChangeValudations(txtLei); };
            txtCursoClasseDesciplinas.EditValueChanged += delegate { ChangeValudations(txtCursoClasseDesciplinas); };

            btnBuscarGrupos.Click += BtnBuscarGrupos_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txttitulo2.EditValue = usuarios.Titulo;
                txtDescricao.EditValue = usuarios.Descricao;
                txtComentarios.EditValue = usuarios.Comentario;
                txtLei.EditValue = usuarios.Lei;
                txtCursoClasseDesciplinas.EditValue = usuarios.CursoClasseDisciplinaID;
                txtCodigo.EditValue = usuarios.DisciplinasProgramasID;

                txttitulo2.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;

            txtCursoClasseDesciplinas.Properties.NullText = cursosClassedisci;
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmCursoClasseDisciplinaAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult = await paisRepository.GetAll();
            cursoClasseDisciplinaBindingSource.DataSource = dataResult;
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
                    var apagar = await DataRepository.Excluir(x => x.DisciplinasProgramasID == data);

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
                var data = new DisciplinasProgramas
                { 
                    DisciplinasProgramasID = ID,
                    Titulo = txttitulo2.Text.Trim(),
                    Descricao = txtDescricao.Text.Trim(),
                    Comentario = txtComentarios.Text.Trim(),
                    CursoClasseDisciplinaID = (int) txtCursoClasseDesciplinas.EditValue,
                    Lei = txttitulo2.Text.Trim(),
                    Data = DateTime.Now,
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.DisciplinasProgramasID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => x.Descricao.ToUpper() == txtTitulo.Text.ToUpper().Trim(), null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.DisciplinasProgramasID != Convert.ToInt32(txtCodigo.Text))
                        return ResultValuesExiste();
                }
                else
                    return ResultValuesExiste();
            }
            return false;
        }

        private bool ResultValuesExiste()
        {
            Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                                 MessageBoxButtons.OK,
                                                 MessageBoxIcon.Error);
            txtDescricao.SelectAll();
            txtDescricao.Focus();
            return true;
        }

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtCodigo.Text = string.Empty;
            txttitulo2.Text = string.Empty;
            txtComentarios.Text = string.Empty; 
            txtDescricao.Text = string.Empty; 
            
            txtTitulo.Text = "[Novo]";
            txttitulo2.Focus();
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

        private string cursosClassedisci = "* [Selecione a Disciplina [Curso => Claase => Disciplina]";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Titulo
                if (control.Name.Equals(txttitulo2.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txttitulo2.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                            !(string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text) || txtCursoClasseDesciplinas.Text == cursosClassedisci))
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
                
                #region Descricao
                else if (control.Name.Equals(txtDescricao.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txttitulo2.Text) &&
                            !(string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text) || txtCursoClasseDesciplinas.Text == cursosClassedisci))
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
                        if (!string.IsNullOrWhiteSpace(txttitulo2.Text) &&
                            !string.IsNullOrWhiteSpace(txtDescricao.Text))
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
                    if (!string.IsNullOrWhiteSpace(txttitulo2.Text) &&
                        !string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                        !(string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text) || txtCursoClasseDesciplinas.Text == cursosClassedisci))
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