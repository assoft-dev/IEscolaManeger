namespace IEscolaDesktop.View.Forms
{
    using DevExpress.XtraEditors;
    using IEscolaDesktop.View.Helps;
    using IEscolaEntity.Models;
    using System.Windows.Forms;

    public partial class frmMenu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frmMenu(Permissoes permission)
        {
            InitializeComponent();

            ActivarBotoes(permission);

            //Metodos
            this.FormClosing += FrmMenu_FormClosing;

            // Usuarios
            btnUser.Click += delegate { OpenForms(new frmUsuarios()); };
            btnGroup.Click += delegate { OpenForms(new frmGrupos()); };
            btnPermis.Click += delegate { OpenForms(new frmPermissoes()); };
            btnUserLogs.Click += delegate { OpenForms(new frmUsuariosLogs()); };

            // Localizacao
            btnMunicipios.Click += delegate { OpenForms(new frmMunicipios()); };
            btnProvincias.Click += delegate { OpenForms(new frmProvincias()); };
            btnProvinciasMunicipios.Click += delegate { OpenForms(new frmProvinciasMunicipios()); };

            // Escolas
            btnTurma.Click += delegate { OpenForms(new frmTurmas()); };
            btnPeriodos.Click += delegate { OpenForms(new frmPeriodos()); };
            btnClasses.Click += delegate { OpenForms(new frmClasses()); };
            btnSalas.Click += delegate { OpenForms(new frmSalas()); };
            btnCursos.Click += delegate { OpenForms(new frmCursos()); };

            // Biblioteca
            btnCategoria_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Categorias()); };
            Editoras_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Editoras()); };
            btnPais_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Pais()); };
            Autores_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Autores()); };
            Livros_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Livros()); };
            btnPedidos_Consltas_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Pedidos()); };
            btnPedidos_Requisicao_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_PedidosAdd()); };

            btnEstudantesInscricoes.Click += delegate { OpenForms(new frmEstudantesInscritos()); };
            btnEstudantes.Click += delegate { OpenForms(new frmEstudantes()); };

        }

        private void OpenForms(XtraUserControl control)
        {
            Cursor =  Cursors.WaitCursor;
            try
            {
                if (control != null)
                {
                    if (control.Name.Equals(typeof(frmUsuarios).Name))
                    {
                        this.Text = "Usuários [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmGrupos).Name))
                    {
                        this.Text = "Grupos [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmPermissoes).Name))
                    {
                        this.Text = "Permissões [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmUsuariosLogs).Name))
                    {
                        this.Text = "Usuarios Auditoria - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }

                    // Provincias
                    else if (control.Name.Equals(typeof(frmProvincias).Name))
                    {
                        this.Text = "Provincias - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    // Municipios
                    else if (control.Name.Equals(typeof(frmMunicipios).Name))
                    {
                        this.Text = "Municipios - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    // Provincias Municipios
                    else if (control.Name.Equals(typeof(frmProvinciasMunicipios).Name))
                    {
                        this.Text = "Provincias-Municipios - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }

                    #region Escolas
                    // Turma
                    else if (control.Name.Equals(typeof(frmTurmas).Name))
                    {
                        this.Text = "Turmas - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    // Clase
                    else if (control.Name.Equals(typeof(frmClasses).Name))
                    {
                        this.Text = "Classe - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    // Salas
                    else if (control.Name.Equals(typeof(frmSalas).Name))
                    {
                        this.Text = "Salas - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    //Periodos
                    else if (control.Name.Equals(typeof(frmPeriodos).Name))
                    {
                        this.Text = "Periodos - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    // Cursos
                    else if (control.Name.Equals(typeof(frmCursos).Name))
                    {
                        this.Text = "Cursos - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    #endregion

                    #region Bibliotecas
                    // Turma
                    else if (control.Name.Equals(typeof(frmBiblioteca_Categorias).Name))
                    {
                        this.Text = "Categorias - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    // Clase
                    else if (control.Name.Equals(typeof(frmBiblioteca_Autores).Name))
                    {
                        this.Text = "Autores - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    // Salas
                    else if (control.Name.Equals(typeof(frmBiblioteca_Editoras).Name))
                    {
                        this.Text = "Editoras - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    //Periodos
                    else if (control.Name.Equals(typeof(frmBiblioteca_Pais).Name))
                    {
                        this.Text = "Pais - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmBiblioteca_Livros).Name))
                    {
                        this.Text = "Livros - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmBiblioteca_Pedidos).Name))
                    {
                        this.Text = "Ped. (Consultas) [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmBiblioteca_PedidosAdd).Name))
                    {
                        this.Text = "Ped. (Requisição) -[Aberto]";

                        OpenFormsDialog.ShowForm(this, null, control);
                    }
                    #endregion

                    #region Estudantes
                    else if (control.Name.Equals(typeof(frmEstudantes).Name))
                    {
                        this.Text = "Estudantes -[Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmEstudantesInscritos).Name))
                    {
                        this.Text = "Estudantes -[Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    #endregion

                    else
                    {
                        this.Text = "IGest-Escola";
                    }
                }
            }
            catch (System.Exception exe)
            {
                GlobalException.CapturarError(exe);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ActivarBotoes(Permissoes permission)
        {

        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForms();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                CloseForms();

                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }

        public void CloseForms()
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == (typeof(frmLogin)).Name)
                {
                    item.Show();
                }
            }
        }
    }
}
