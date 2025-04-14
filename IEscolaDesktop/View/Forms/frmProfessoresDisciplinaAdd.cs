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
    public partial class frmProfessoresDisciplinaAdd : XtraUserControl
    {
        IProfessoresDisciplinas DataRepository;
        ICursoClasseDisciplina cursosRepository;
        IProfessores professorRepository;
        bool IsValidate = false;

        public frmProfessoresDisciplinaAdd(ProfessoresDisciplinas usuarios = null)
        {
            InitializeComponent();

            DataRepository = new ProfessoresDisciplinasRepository();
            cursosRepository = new CursoClasseDisciplinaRepository();
            professorRepository = new ProfessoresRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtProfessor.EditValueChanged += delegate { ChangeValudations(txtProfessor); };
            txtCursoClasseDesciplinas.EditValueChanged += delegate { ChangeValudations(txtCursoClasseDesciplinas); };

            btnProfessor.Click += BtnBuscarGrupos_Click;
            btnDisciplina.Click += BtnBuscarGrupos2_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtProfessor.EditValue = usuarios.ProfessoresID;
                txtCursoClasseDesciplinas.EditValue = usuarios.CursoClasseDisciplinaID;
                txtCodigo.EditValue = usuarios.ProfessoresDisciplinasID;

                txtProfessor.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;

            txtProfessor.Properties.NullText = professor;
            txtCursoClasseDesciplinas.Properties.NullText = cursosClassedisci;
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmProfessoresAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private void BtnBuscarGrupos2_Click(object sender, EventArgs e)
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
            var dataResult = await professorRepository.GetAll();
            professoresBindingSource.DataSource = dataResult;
            
            var dataResult2 = await cursosRepository.GetAll();
            cursoClasseDisciplinaBindingSource.DataSource = dataResult2;
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
                    var apagar = await DataRepository.Excluir(x => x.ProfessoresDisciplinasID == data);

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
                var data = new ProfessoresDisciplinas
                { 
                    ProfessoresDisciplinasID = ID,
                    ProfessoresID = (int) txtProfessor.EditValue,
                    CursoClasseDisciplinaID = (int) txtCursoClasseDesciplinas.EditValue,
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.ProfessoresDisciplinasID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => x.ProfessoresID == (int) txtProfessor.EditValue &&
                                                           x.CursoClasseDisciplinaID == (int) txtCursoClasseDesciplinas.EditValue, null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.ProfessoresDisciplinasID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtProfessor.SelectAll();
                        txtProfessor.Focus();

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
            txtTitulo.Text = "[Novo]";
            txtProfessor.Focus();
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

        private string professor = "* [Selecione o Professor da disciplina por favor";
        private string cursosClassedisci = "* [Selecione a Disciplina [Curso => Claase => Disciplina]";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {

                #region Curso => Classe => Disciplina
                if (control.Name.Equals(txtCursoClasseDesciplinas.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtProfessor.Text) || txtProfessor.Text == professor))
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

                #region Professor
                else if (control.Name.Equals(txtProfessor.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtProfessor.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtCursoClasseDesciplinas.Text) || txtCursoClasseDesciplinas.Text == cursosClassedisci))
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
                    if (
                        !(string.IsNullOrWhiteSpace(txtProfessor.Text) || txtProfessor.Text == professor) &&
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