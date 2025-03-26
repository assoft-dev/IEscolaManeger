using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Interfaces;
using IEscolaEntity.Controllers.Repository;
using IEscolaEntity.Models;
using IEscolaEntity.Models.Helps;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmEstudantesSimples : XtraUserControl
    {
        IEstudantes DataRepository;
        ITurmas turmasRepository;
        IEstudantesInscricoes inscricoesRepositorio;
        bool IsValidate = false;
        private string FolderImagem = @"C:\\asinforprest\\IEscola\\Estudantes\\";

        public frmEstudantesSimples(Estudantes usuarios = null)
        {
            InitializeComponent();

            DataRepository = new EstudantesRepository();
            turmasRepository = new TurmasRepository();
            inscricoesRepositorio = new EstudantesIncricoesRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtInscritos_.EditValueChanged += delegate { ChangeValudations(txtInscritos_); };
            txtTurmas.EditValueChanged += delegate { ChangeValudations(txtTurmas); };

            btnInscricoes.Click += BtnBuscarGrupos_Click;
            btnTurmas.Click += BtnBuscarGrupos2_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            txtInscritos_.Properties.NullText = estudantesinscritos;
            txtTurmas.Properties.NullText = turma;
            txtEstadoEstudantes.Properties.NullText = estudanteestado;
            txtFazes.Properties.NullText = fazes;

            this.Load += FrmUsuariosAdd_Load; 

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtInscritos_.EditValue = usuarios.InscricoesID;
                txtTurmas.EditValue = usuarios.TurmaID;
                txtCodigo.EditValue = usuarios.EstudantesID;
                txtEstadoEstudantes.EditValue = usuarios.EstadoEstudantes;
                txtCodigo2.EditValue = usuarios.Codigo;
                txtInscritos_.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmEstudantesInscritosAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private void BtnBuscarGrupos2_Click(object sender, EventArgs e)
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
            var dataResult = await inscricoesRepositorio.GetAll();
            estudantesInscricoesBindingSource.DataSource = dataResult;
            
            var dataResult1 = await turmasRepository.GetAll();
            turmasBindingSource.DataSource = dataResult1;

            txtEstadoEstudantes.Properties.DataSource = Enum.GetValues(typeof(EstadoEstudantes));
            txtFazes.Properties.DataSource = Enum.GetValues(typeof(FAZES));
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
                    var apagar = await DataRepository.Excluir(x => x.EstudantesID == data);

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

        private void PagarImagem()
        {
            if (!string.IsNullOrWhiteSpace(txtImagemURL.Text))
            {
                var caminho = FolderImagem + txtImagemURL.Text;

                if (File.Exists(caminho))
                    File.Delete(caminho);
            };
        }

        private string GuardarImagem()
        {
            if (pictureEdit1.Image != null)
            {
                var guidvalues = Guid.NewGuid() + ".jpg";
                pictureEdit1.Image.Save(FolderImagem + guidvalues);
                return guidvalues;
            }
            else
                return null;
        }

        private async void Guardar()
        {


            if (!await ValidationDatabase())
            {
                var ID = string.IsNullOrWhiteSpace(txtCodigo.Text) == true ? 0 : (int)txtCodigo.EditValue;
                var codigo = string.IsNullOrWhiteSpace(txtCodigo.Text) == true ? await DataRepository.GetQR() : txtCodigo2.Text;


                //Gerir Imagens
                var imagens = GuardarImagem();

                // save Data
                var data = new Estudantes
                {                    
                    Codigo = codigo,
                    EstudantesID = ID,
                    InscricoesID = (int) txtInscritos_.EditValue,
                    TurmaID = (int) txtTurmas.EditValue,
                    EstadoEstudantes = (EstadoEstudantes) txtEstadoEstudantes.EditValue,
                };

                var inscri = estudantesInscricoesBindingSource.Current as EstudantesInscricoes;

                if (inscri != null) {
                    inscri.ImagemURL = imagens;
                    inscri.FAZES = (FAZES) txtFazes.EditValue;
                }

                inscricoesRepositorio.DoUpdate<EstudantesInscricoes>(inscri);

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.EstudantesID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => x.EstadoEstudantes == (EstadoEstudantes) txtEstadoEstudantes.EditValue &&
                                                           x.InscricoesID == (int) txtInscritos_.EditValue && 
                                                           x.TurmaID == (int) txtTurmas.EditValue , null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.EstudantesID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtInscritos_.SelectAll();
                        txtInscritos_.Focus();

                        return true;
                    } 
                }
            }

            //Faze 2

            return false;
        }

        private void Limpar()
        {
            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
            windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;

            txtCodigo.Text = string.Empty;            
            txtTitulo.Text = "[Novo]";
            txtInscritos_.Focus();
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

        private string estudantesinscritos = "* [Selecione o Inscrito por favor";
        private string turma = "* [Selecione a turma por favor]";
        private string estudanteestado = "* [Selecione o estado do mesmo por favor]";
        private string fazes = "* [Selecione a faze por favor]";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {

                #region Turma
                if (control.Name.Equals(txtTurmas.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtTurmas.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtInscritos_.Text) || txtInscritos_.Text == estudantesinscritos) &&
                            !(string.IsNullOrWhiteSpace(txtEstadoEstudantes.Text) || txtEstadoEstudantes.Text == estudanteestado) && 
                            !(string.IsNullOrWhiteSpace(txtFazes.Text) || txtFazes.Text == fazes))
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

                #region Estados Estudantes
                else if (control.Name.Equals(txtEstadoEstudantes.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtEstadoEstudantes.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtTurmas.Text) || txtTurmas.Text == turma) &&
                            !(string.IsNullOrWhiteSpace(txtInscritos_.Text) || txtInscritos_.Text == estudantesinscritos) &&
                            !(string.IsNullOrWhiteSpace(txtFazes.Text) || txtFazes.Text == fazes))
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

                #region Inscricao
                else if (control.Name.Equals(txtInscritos_.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtInscritos_.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtTurmas.Text) || txtTurmas.Text == turma) &&
                            !(string.IsNullOrWhiteSpace(txtFazes.Text) || txtFazes.Text == fazes) &&
                            !(string.IsNullOrWhiteSpace(txtEstadoEstudantes.Text) || txtEstadoEstudantes.Text == estudanteestado))
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

                #region Fazes
                else if (control.Name.Equals(txtFazes.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtFazes.Text))
                    {
                        if (!(string.IsNullOrWhiteSpace(txtTurmas.Text) || txtTurmas.Text == turma) &&
                            !(string.IsNullOrWhiteSpace(txtEstadoEstudantes.Text) || txtEstadoEstudantes.Text == estudanteestado) &&
                            !(string.IsNullOrWhiteSpace(txtInscritos_.Text) || txtInscritos_.Text == estudantesinscritos))
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = true;
                        else
                            windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
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
                        !(string.IsNullOrWhiteSpace(txtInscritos_.Text) || txtInscritos_.Text == estudantesinscritos) &&
                        !(string.IsNullOrWhiteSpace(txtTurmas.Text) || txtTurmas.Text == turma) &&
                        !(string.IsNullOrWhiteSpace(txtEstadoEstudantes.Text) || txtEstadoEstudantes.Text == estudanteestado) &&
                        !(string.IsNullOrWhiteSpace(txtFazes.Text) || txtFazes.Text == fazes))
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
    }
}