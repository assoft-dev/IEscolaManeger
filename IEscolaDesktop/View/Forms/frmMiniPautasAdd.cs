using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmMiniPautasAdd : XtraUserControl
    {
        IPautas_Mini DataRepository;
        IProfessoresDisciplinas professoresDisciplinasRepository;
        ITurmas TurmasRepository;

        IEstudantes InscricoesRepository;

        ITransationRepository TransationRepository;

        bool IsValidate = false;

        public frmMiniPautasAdd(MiniPautas usuarios = null)
        {
            InitializeComponent();

            repositoryItemSpinEdit1.MinValue = 0;
            repositoryItemSpinEdit1.MaxValue = 20;

            DataRepository = new MiniPautaRepository();

            professoresDisciplinasRepository = new ProfessoresDisciplinasRepository();
            TurmasRepository = new TurmasRepository();
            InscricoesRepository = new EstudantesRepository();
            TransationRepository = new TransationRepository();

            //txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtTurma.TextChanged += delegate { ChangeValudations(txtTurma); };
            txtDisciplinas.TextChanged += delegate { ChangeValudations(txtDisciplinas); };


            txtTurma.EditValueChanged += TxtTurma_EditValueChanged;
            txtDisciplinas.EditValueChanged += TxtTurma_EditValueChanged;
          

            btnTurma.Click += BtnBuscarTurmas_Click;
            btnProfessorDisciplinas.Click += BtnBuscarProfessorDisciplinas_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                //txtDescricao.EditValue = usuarios.Descricao;
                //txtIdade1.EditValue = usuarios.Idades1;
                //txtIdade2.EditValue = usuarios.Idades2;
                //txtQuantidade.EditValue = usuarios.Quantidade;
                //txtClasse.EditValue = usuarios.ClassesID;
                //txtCurso.EditValue = usuarios.CursosID;
                //txtSala.EditValue = usuarios.SalasID;
                //txtPeriodo.EditValue = usuarios.PeriodosID;
                //txtCodigo.EditValue = usuarios.TurmaID;

                txtTurma.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;

            txtTurma.Properties.NullText = turma;
            txtDisciplinas.Properties.NullText = disciplina;
        }

        private async void TxtTurma_EditValueChanged(object sender, EventArgs e)
        {
            var estudantes = txtTurma.GetSelectedDataRow() as Turmas;

            var professordisciplina = txtDisciplinas.GetSelectedDataRow() as ProfessoresDisciplinas;

            if (professordisciplina == null)
            {
                Mensagens.Display("Falta de Selessão", "Selecione uma disciplina por favor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDisciplinas.Properties.ShowPopupShadow = true;
                txtDisciplinas.Focus();
                return;
            }

            if (estudantes != null)
            {
                //Preenchimentos
                var data = await EstudantesSetAsync(estudantes.Estudantes);
                 
                miniPautasBindingSource.DataSource = data;
            }
        }

        private async Task<List<MiniPautas>> EstudantesSetAsync(List<Estudantes> estudantes)
        {
            var list = new List<MiniPautas>();

            foreach (var x in estudantes)
            {
                var data = new MiniPautas();

                data.MAC = 0;
                data.NPP = 0;
                data.NPT = 0;

                data.MAC1 = 0;
                data.NPP1 = 0;
                data.NPT1 = 0;

                data.MAC2 = 0;
                data.NPP2 = 0;
                data.NPT2 = 0;

                data.ProfessoresCursosID = (professoresDisciplinasBindingSource.Current as ProfessoresDisciplinas).ProfessoresDisciplinasID;
                data.TurmasID = x.TurmaID;

                data.EstudantesID = x.EstudantesID;
                data.Estudantes = await InscricoesRepository.Get(y => y.EstudantesID == x.EstudantesID, null);

                list.Add(data);
            }
            return list;
        }

        private void BtnBuscarTurmas_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmTurmasAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private void BtnBuscarProfessorDisciplinas_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmProfessoresDisciplinaAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

       

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            var dataResult5 = await TurmasRepository.GetAll();
            turmasBindingSource.DataSource = dataResult5;

            var dataResult6 = await professoresDisciplinasRepository.GetAllinclud();
            professoresDisciplinasBindingSource.DataSource = dataResult6;
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
            //if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            //{
            //    var msg = Mensagens.Display("Apagar Permanentemente", 
            //                                "Queres apagar de forma permanente esta informação?", MessageBoxButtons.YesNo,
            //                                 MessageBoxIcon.Question);

            //    if (msg == DialogResult.Yes)
            //    {
            //        var data = int.Parse(txtCodigo.Text);
            //        var apagar = await DataRepository.Excluir(x => x.PautasID == data);

            //        if (apagar)
            //        {
            //            Mensagens.Display("Apagar Dados",
            //                              "Dados apagados com exito",
            //                              MessageBoxButtons.OK,
            //                              MessageBoxIcon.Information);
            //            Limpar();
            //        }
            //    }
            //}     
        }

        private async void Guardar()
        {
            if (!await ValidationDatabase())
            {

                TransationRepository.DoInsert

               // var ID = string.IsNullOrWhiteSpace(txtCodigo.Text) == true ? 0 : (int)txtCodigo.EditValue;

                // save Data
                //var data = new Turmas
                //{
                //    TurmaID = ID,
                //    //Descricao = (string) txtDescricao.Text.Trim(),

                //    //ClassesID = (int) txtClasse.EditValue,
                //    //CursosID = (int) txtTurma.EditValue,
                //    //PeriodosID = (int) txtPeriodo.EditValue,
                //    //SalasID = (int) txtSala.EditValue,
                //};

                //IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.TurmaID == ID) > 0 :
                //                       await DataRepository.Guardar(data, true);

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
            //var dataResult = await DataRepository.Get(x => (x.Descricao.ToUpper() == txtDescricao.Text.ToUpper()) &&
            //                                               ((x.SalasID == (int) txtSala.EditValue) && 
            //                                               (x.CursosID == (int) txtTurma.EditValue) &&
            //                                               (x.PeriodosID == (int) txtPeriodo.EditValue) &&
            //                                               (x.CursosID == (int)txtClasse.EditValue)), null);

            //if (dataResult != null)
            //{
            //    if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            //    {
            //        if (dataResult.TurmaID != Convert.ToInt32(txtCodigo.Text))
            //        {
            //            Mensagens.Display("Duplicação de Valores as Atualiar", "Já existe uma descrição na nossa base de Dados!",
            //                         MessageBoxButtons.OK,
            //                         MessageBoxIcon.Error);

            //            txtTurma.SelectAll();
            //            txtTurma.Focus();
            //            return true;
            //        }

            //        // Verificar a possibilidade de atualizar com base nos valores Sala Cursos e Periodos
            //        var dataResult2 = await DataRepository.Get(x => ((x.SalasID == (int)txtSala.EditValue) &&
            //                                                         (x.CursosID == (int)txtTurma.EditValue) &&
            //                                                         (x.PeriodosID == (int)txtPeriodo.EditValue) &&
            //                                                         (x.CursosID == (int)txtClasse.EditValue)), null);

            //        if (dataResult2 != null)
            //        {
            //            Mensagens.Display("Duplicação de Valores", "Já existe uma Turma com a descrição abaixo mencionada!",
            //                         MessageBoxButtons.OK,
            //                         MessageBoxIcon.Error);
            //            return true;
            //        }
            //    }
            //    else
            //    {
            //        Mensagens.Display("Duplicação de Valores ao Criar", "Já existe uma descrição na nossa base de Dados!",
            //                         MessageBoxButtons.OK,
            //                         MessageBoxIcon.Error);

            //        txtClasse.SelectAll();
            //        txtClasse.Focus();

            //        return true;
            //    }
            //}
            return false;
        }

        private void Limpar()
        {
            //windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            // txtDescricao.EditValue = string.Empty;
            //txtQuantidade.EditValue = string.Empty;
            //txtIdade1.EditValue = string.Empty;
            //txtIdade2.EditValue = string.Empty;

            //txtCodigo.Text = string.Empty;
            txtTitulo.Text = "[Novo]";
           //  txtDescricao.Focus();
        }

        private void ChangeValidationCodigo()
        {
            //if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            //{
            //    windowsUIButtonPanel1.Buttons[1].Properties.Caption = "Atualizar";
            //    windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
            //    windowsUIButtonPanel1.Buttons[3].Properties.Enabled = true;
            //}
            //else {
            //    windowsUIButtonPanel1.Buttons[1].Properties.Caption = "Guardar";
            //    windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            //}
        }

        private string turma = "[Selecione a provincia por favor]";
        private string disciplina = "[Selecione a Disciplina por favor]";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Turma
                if (control.Name.Equals(txtTurma.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtTurma.Text))
                    {
                        if (
                             !(string.IsNullOrWhiteSpace(txtDisciplinas.Text) || txtDisciplinas.Text == disciplina) &&
                             !(miniPautasBindingSource.DataSource == null))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                    }
                    else
                        windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                }
                #endregion

                #region Disciplinas
                else if (control.Name.Equals(txtDisciplinas.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDisciplinas.Text))
                    {
                        if (
                             !(string.IsNullOrWhiteSpace(txtTurma.Text) || txtTurma.Text == turma) &&
                             !(miniPautasBindingSource.DataSource == null))
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
                    if (!(string.IsNullOrWhiteSpace(txtTurma.Text) || txtTurma.Text == turma) &&
                           !(string.IsNullOrWhiteSpace(txtDisciplinas.Text) || txtDisciplinas.Text == disciplina) &&
                           !(miniPautasBindingSource.DataSource == null))
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