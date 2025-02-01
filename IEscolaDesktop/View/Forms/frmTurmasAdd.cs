using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.Summary.Native;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmTurmasAdd : XtraUserControl
    {
        ITurmas DataRepository;
        ISalas salasRepository;
        ICursos cursosRepository;
        IClasses classeRepository;
        IPeriodos periodoRepository;

        bool IsValidate = false;

        public frmTurmasAdd(Turmas usuarios = null)
        {
            InitializeComponent();

            DataRepository = new TurmasRepository();
            salasRepository = new SalasRepository();
            cursosRepository = new CursosRepository();
            periodoRepository = new PeriodosRepository();
            classeRepository =  new ClassesRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtClasse.EditValueChanged += delegate { ChangeValudations(txtClasse); };
            txtCurso.EditValueChanged += delegate { ChangeValudations(txtCurso); };

            btnProvincias.Click += BtnBuscarGrupos_Click;
            btnMunicipios.Click += BtnBuscar2Grupos_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtDescricao.EditValue = usuarios.Descricao;
                txtIdade1.EditValue = usuarios.Idades1;
                txtIdade2.EditValue = usuarios.Idades2;
                txtQuantidade.EditValue = usuarios.Quantidade;
                txtClasse.EditValue = usuarios.ClassesID;
                txtCurso.EditValue = usuarios.CursosID;
                txtSala.EditValue = usuarios.SalasID;
                txtPeriodo.EditValue = usuarios.PeriodosID;
                txtCodigo.EditValue = usuarios.TurmaID;

                txtClasse.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmTurmasAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }
        private void BtnBuscar2Grupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmTurmasAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult1 = await salasRepository.GetAll();
            salasBindingSource.DataSource = dataResult1;

            var dataResult2 = await cursosRepository.GetAll();
            cursosBindingSource.DataSource = dataResult2;

            var dataResult3 = await periodoRepository.GetAll();
            periodosBindingSource.DataSource = dataResult3;

            var dataResult4 = await classeRepository.GetAll();
            classesBindingSource.DataSource = dataResult4;
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
                    var apagar = await DataRepository.Excluir(x => x.TurmaID == data);

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
                var data = new Turmas
                {
                    TurmaID = ID,

                    Idades1 = Convert.ToInt32(txtIdade1.EditValue),
                    Idades2 = Convert.ToInt32(txtIdade2.EditValue),
                    Descricao = (string) txtDescricao.Text.Trim(),
                    Quantidade = Convert.ToInt32(txtQuantidade.EditValue),

                    ClassesID = (int) txtClasse.EditValue,
                    CursosID = (int) txtCurso.EditValue,
                    PeriodosID = (int) txtPeriodo.EditValue,
                    SalasID = (int) txtSala.EditValue,
                };

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.TurmaID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => (x.Descricao.ToUpper() == txtDescricao.Text.ToUpper()) &&
                                                           ((x.SalasID == (int) txtSala.EditValue) && 
                                                           (x.CursosID == (int) txtCurso.EditValue) &&
                                                           (x.PeriodosID == (int) txtPeriodo.EditValue) &&
                                                           (x.CursosID == (int)txtClasse.EditValue)), null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.TurmaID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores as Atualiar", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtClasse.SelectAll();
                        txtClasse.Focus();
                        return true;
                    }

                    // Verificar a possibilidade de atualizar com base nos valores Sala Cursos e Periodos
                    var dataResult2 = await DataRepository.Get(x => ((x.SalasID == (int)txtSala.EditValue) &&
                                                                     (x.CursosID == (int)txtCurso.EditValue) &&
                                                                     (x.PeriodosID == (int)txtPeriodo.EditValue) &&
                                                                     (x.CursosID == (int)txtClasse.EditValue)), null);

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

                    txtClasse.SelectAll();
                    txtClasse.Focus();

                    return true;
                }
            }
            return false;
        }

        private void Limpar()
        {
            //windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtDescricao.EditValue = string.Empty;
            //txtQuantidade.EditValue = string.Empty;
            //txtIdade1.EditValue = string.Empty;
            //txtIdade2.EditValue = string.Empty;

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
                        if (!(string.IsNullOrWhiteSpace(txtCurso.Text) || txtCurso.Text == "[Selecione o Curso por favor]") &&
                             !(string.IsNullOrWhiteSpace(txtSala.Text) || txtSala.Text == "[Selecione a Sala por por favor]") &&
                             !(string.IsNullOrWhiteSpace(txtPeriodo.Text) || txtPeriodo.Text == "[Selecione o Periodo por favor]") &&
                             !(string.IsNullOrWhiteSpace(txtClasse.Text) || txtClasse.Text == "[Selecione a Classe por favor]"))
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
                if (control.Name.Equals(txtClasse.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtClasse.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtCurso.Text) || txtCurso.Text == "[Selecione o municipio por favor]"))
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
                if (control.Name.Equals(btnMunicipios.Name))
                {
                    if (!string.IsNullOrWhiteSpace(btnMunicipios.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtClasse.Text) || txtClasse.Text == "[Selecione a provincia por favor]"))
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