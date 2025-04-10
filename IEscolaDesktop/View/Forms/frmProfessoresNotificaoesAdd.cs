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
    public partial class frmProfessoresNotificaoesAdd : XtraUserControl
    {
        INotificacoes DataRepository;
        IProfessores paisRepository;
        bool IsValidate = false;

        public frmProfessoresNotificaoesAdd(Notificacoes usuarios = null)
        {
            InitializeComponent();

            DataRepository = new NotificacoesRepository();
            paisRepository = new ProfessoresRepository();

            txtCodigo.EditValueChanged += delegate { ChangeValidationCodigo(); };

            txtData.EditValueChanged += delegate { ChangeValudations(txtData); };
            txtHoras.EditValueChanged += delegate { ChangeValudations(txtHoras); };
            txtDuracao.EditValueChanged += delegate { ChangeValudations(txtDuracao); };
            txtProfessor.EditValueChanged += delegate { ChangeValudations(txtProfessor); };

            btnBuscarGrupos.Click += BtnBuscarGrupos_Click;

            windowsUIButtonPanel1.ButtonClick += WindowsUIButtonPanel1_ButtonClick;

            if (usuarios != null) {     
                
                //Inicializar o Forms
                txtTitulo.Text = "[Edição]";

                txtData.EditValue = usuarios.Data;
                txtHoras.EditValue = usuarios.Hora;
                txtCaracter.EditValue = usuarios.Catater;
                txtDuracao.EditValue = usuarios.Duracao;
                txtDescricao.EditValue = usuarios.Descricao;
                txtProfessor.EditValue = usuarios.ProfessoresID;
                txtCodigo.EditValue = usuarios.NotificacoesID;

                txtData.Focus();
            }
            else {
                txtTitulo.Text = "[Novo]";
                windowsUIButtonPanel1.Buttons[1].Properties.Enabled = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Enabled = false;
            }

            this.Load += FrmUsuariosAdd_Load;

            txtProfessor.Properties.NullText = professor;
            txtCaracter.Properties.NullText = nivel;
        }

        private void BtnBuscarGrupos_Click(object sender, EventArgs e)
        {
            // Buscar Grupos
            var forms = OpenFormsDialog.ShowForm(null,
                  new frmProfessoresAdd());

            if (forms == DialogResult.None || forms == DialogResult.Cancel)
                FrmUsuariosAdd_Load(null, null);
        }

        private async void FrmUsuariosAdd_Load(object sender, EventArgs e)
        {
            // Leitura dos Grupos
            var dataResult = await paisRepository.GetAll();
            professoresBindingSource.DataSource = dataResult;

            txtCaracter.Properties.DataSource = Enum.GetValues(typeof(NotificacoesCatater));

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
                    var apagar = await DataRepository.Excluir(x => x.NotificacoesID == data);

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
                var data = new Notificacoes
                { 
                    NotificacoesID = ID,
                    Descricao = txtDescricao.Text.Trim(),
                    Duracao = (int) txtDuracao.Value,
                    ProfessoresID = (int) txtProfessor.EditValue,
                    Data = txtData.DateTime,
                    Catater = (NotificacoesCatater) txtCaracter.EditValue,
                    Hora = txtHoras.Time.TimeOfDay,
                     Visualizado = txtVisualizado.Checked,
                }; 

                IsValidate = ID != 0 ? await DataRepository.Guardar(data, X => X.NotificacoesID == ID) > 0 :
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
            var dataResult = await DataRepository.Get(x => x.Descricao == txtData.Text, null);

            if (dataResult != null)
            {
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    if (dataResult.NotificacoesID != Convert.ToInt32(txtCodigo.Text))
                    {
                        Mensagens.Display("Duplicação de Valores", "Já existe uma descrição na nossa base de Dados!",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);

                        txtData.SelectAll();
                        txtData.Focus();

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
            txtData.Text = string.Empty;
            txtDuracao.Text = string.Empty; 
            txtHoras.Text = string.Empty; 
            
            txtTitulo.Text = "[Novo]";
            txtData.Focus();
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

        private string professor = "* [Selecione o professor por favor]";
        private string nivel = "* [Selecione o estado desta notificação]";

        private void ChangeValudations(Control control)
        {
            if (control != null)
            {
                #region Descricao
                if (control.Name.Equals(txtDescricao.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtDescricao.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtHoras.Text) &&
                            !string.IsNullOrWhiteSpace(txtData.Text) &&
                            !(string.IsNullOrWhiteSpace(txtProfessor.Text) || txtProfessor.Text == professor) &&
                            !(string.IsNullOrWhiteSpace(txtCaracter.Text) || txtCaracter.Text == nivel))
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
                
                #region Horas
                else if (control.Name.Equals(txtHoras.Name))
                {
                    if (!string.IsNullOrWhiteSpace(txtHoras.Text))
                    {
                        if (!string.IsNullOrWhiteSpace(txtData.Text) &&
                            !string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                            !(string.IsNullOrWhiteSpace(txtProfessor.Text) || txtProfessor.Text == professor) &&
                            !(string.IsNullOrWhiteSpace(txtCaracter.Text) || txtCaracter.Text == nivel))
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
                        if (!string.IsNullOrWhiteSpace(txtData.Text) &&
                            !string.IsNullOrWhiteSpace(txtHoras.Text) &&
                            !string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                            !(string.IsNullOrWhiteSpace(txtCaracter.Text) || txtCaracter.Text == nivel))
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
                    if (!string.IsNullOrWhiteSpace(txtData.Text) &&
                        !string.IsNullOrWhiteSpace(txtHoras.Text) &&
                        !string.IsNullOrWhiteSpace(txtDescricao.Text) &&
                        !(string.IsNullOrWhiteSpace(txtProfessor.Text) || txtProfessor.Text == professor) &&
                        !(string.IsNullOrWhiteSpace(txtCaracter.Text) || txtCaracter.Text == nivel))
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