using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Summary.Native;
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
    public partial class frmCursoClasseDisciplinaAdd : XtraUserControl
    {
        ICursoClasseDisciplina DataRepository;
        ICursos cursoRepository;
        IClasses classeRepository;
        IDisciplina DisciplinaRepository;
        bool IsValidate = false;

        public frmCursoClasseDisciplinaAdd(CursoClasseDisciplina usuarios = null)
        {
            InitializeComponent();

            DataRepository = new CursoClasseDisciplinaRepository();
            cursoRepository = new CursosRepository();
            classeRepository = new ClassesRepository();
            DisciplinaRepository = new DisciplinaRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtCurso.TextChanged += delegate { ChangeValudations(txtCurso); };
            txtCLasse.TextChanged += delegate { ChangeValudations(txtCLasse); };
            txtDisciplina.TextChanged += delegate { ChangeValudations(txtDisciplina); };
            txtComponentes.TextChanged += delegate { ChangeValudations(txtComponentes); };

            btnCurso.Click += BtnBuscarGrupos_Click;
            btnClasse.Click += BtnBuscar2Grupos_Click;
            btnDisciplina.Click += BtnBuscar3Grupos_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtCurso.EditValue = usuarios.CursosID;
                txtCLasse.EditValue = usuarios.ClassesID;      
                txtDisciplina.EditValue = usuarios.DisciplinasID;
                txtComponentes.EditValue = usuarios.DisciplinasComponentesType;

                txtCodigo.EditValue = usuarios.CursoClasseDisciplinaID;

                txtCurso.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;

            txtCurso.Properties.NullText = cursos;
            txtCLasse.Properties.NullText = classes;
            txtDisciplina.Properties.NullText = disciplinas;
            txtComponentes.Properties.NullText = componetes;
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmCursosAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }
        private void BtnBuscar2Grupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmClassesAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }
        private void BtnBuscar3Grupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmDisciplinaAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult = await cursoRepository.GetAll();
            cursosBindingSource.DataSource = dataResult;

            var dataResult2 = await classeRepository.GetAll();
            classesBindingSource.DataSource = dataResult2;

            var dataResult3 = await DisciplinaRepository.GetAll();
            disciplinasBindingSource.DataSource = dataResult3;

            txtComponentes.Properties.DataSource = Enum.GetValues(typeof(DisciplinasComponentesType));
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
                    var apagar = await DataRepository.Excluir(x => x.CursoClasseDisciplinaID == data);

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
                var data = new CursoClasseDisciplina
                {
                    CursoClasseDisciplinaID = ID,
                    CursosID = (int) txtCurso.EditValue,
                    ClassesID = (int) txtCLasse.EditValue,
                    DisciplinasID = (int) txtDisciplina.EditValue,
                    DisciplinasComponentesType = (DisciplinasComponentesType) txtComponentes.EditValue,
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.CursoClasseDisciplinaID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => (x.CursosID == (int) txtCurso.EditValue) &&
                                                           (x.DisciplinasID == (int)txtDisciplina.EditValue) &&
                                                           (x.ClassesID == (int) txtCLasse.EditValue) &&
                                                           (x.DisciplinasComponentesType == (DisciplinasComponentesType) txtComponentes.EditValue), null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.CursoClasseDisciplinaID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores as Atualiar", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtCurso.SelectAll();
                        txtCurso.Focus();

                        return true;
                    } 
                }
                else
                {
                    Mensagens.Display("Duplicação de Valores ao Criar", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                    txtCurso.SelectAll();
                    txtCurso.Focus();

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
            txtCurso.Focus();
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

        private string cursos = "[Selecione o Curso por favor]";
        private string classes = "[Selecione a Classe por favor]";
        private string disciplinas = "[Selecione a Disciplina por favor]";
        private string componetes = "[Selecione a Componente por favor]";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Cursos
                if (control.Name.Equals(txtCurso.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtCurso.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtCLasse.Text) || txtCLasse.Text == classes) &&
                            !(string.IsNullOrWhiteSpace(txtDisciplina.Text) || txtDisciplina.Text == disciplinas) &&
                            !(string.IsNullOrWhiteSpace(txtComponentes.Text) || txtComponentes.Text == componetes))
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

                #region Classe
                else if (control.Name.Equals(txtCLasse.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtCLasse.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtCurso.Text) || txtCurso.Text == cursos) &&
                            !(string.IsNullOrWhiteSpace(txtDisciplina.Text) || txtDisciplina.Text == disciplinas) &&
                            !(string.IsNullOrWhiteSpace(txtComponentes.Text) || txtComponentes.Text == componetes))
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

                #region Disciplina
                else if (control.Name.Equals(txtDisciplina.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDisciplina.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtCurso.Text) || txtCurso.Text == cursos) &&
                            !(string.IsNullOrWhiteSpace(txtCLasse.Text) || txtCLasse.Text == classes) &&
                            !(string.IsNullOrWhiteSpace(txtComponentes.Text) || txtComponentes.Text == componetes))
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

                #region Disciplina
                else if (control.Name.Equals(txtComponentes.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtComponentes.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtCurso.Text) || txtCurso.Text == cursos) &&
                            !(string.IsNullOrWhiteSpace(txtCLasse.Text) || txtCLasse.Text == classes) &&
                            !(string.IsNullOrWhiteSpace(txtDisciplina.Text) || txtDisciplina.Text == disciplinas))
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
                    if (!(string.IsNullOrWhiteSpace(txtCurso.Text) || txtCurso.Text == cursos) &&
                            !(string.IsNullOrWhiteSpace(txtCLasse.Text) || txtCLasse.Text == classes) &&
                            !(string.IsNullOrWhiteSpace(txtComponentes.Text) || txtComponentes.Text == componetes) &&
                            !(string.IsNullOrWhiteSpace(txtDisciplina.Text) || txtDisciplina.Text == disciplinas))
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

        private void btnCurso_Click(object sender, EventArgs e)
        {

        }

        private void txtDisciplina_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}