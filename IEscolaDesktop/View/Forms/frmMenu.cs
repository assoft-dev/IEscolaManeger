namespace IEscolaDesktop.View.Forms
{
    using DevExpress.LookAndFeel;
    using DevExpress.XtraEditors;
    using IEscolaDesktop.View.Helps;
    using IEscolaEntity.Models;
    using System.Windows.Forms;
    using DevExpress.Utils.Frames;
    using DevExpress.Skins;
    using DevExpress.Utils.Svg;
    using System.Drawing;

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

            btnEscola.Click += delegate { OpenForms(new frmEscola()); };
            btnEscolaConvenio.Click += delegate { OpenForms(new frmEscolaConvenio()); };


            // Biblioteca
            btnCategoria_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Categorias()); };
            Editoras_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Editoras()); };
            btnPais_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Pais()); };     
            Autores_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Autores()); };
            Livros_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Livros()); };
            btnPedidos_Consltas_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_Pedidos()); };
            btnPedidos_Requisicao_Biblioteca.Click += delegate { OpenForms(new frmBiblioteca_PedidosAdd()); };

            //Estudantes
            btnEstudantesInscricoes.Click += delegate { OpenForms(new frmEstudantesInscritos()); };
            btnEstudantes.Click += delegate { OpenForms(new frmEstudantes()); };

            //Financeiros
            btnPropinasConfig.Click += delegate { OpenForms(new frmPropinasConfig()); };
            btnPropinasPagamento.Click += delegate { OpenForms(new frmPropinasPagamentos()); };
            btnPropinasRecibo.Click += delegate { OpenForms(new frmPropinasRecibo()); };

            //Financeiros
            btnCursoClasseDisciplina.Click += delegate { OpenForms(new frmCursoClasseDisciplina()); };
            btnDisciplina.Click += delegate { OpenForms(new frmDisciplina()); };
            btnDisciplinaPrograma.Click += delegate { OpenForms(new frmDisciplinaProgramas()); };

            //Financeiros
            btnProfessor.Click += delegate { OpenForms(new frmProfessores()); };
            btnProfessorDisciplina.Click += delegate { OpenForms(new frmProfessoresDisciplina()); };
            btnProfessorFormacao.Click += delegate { OpenForms(new frmProfessoresAreaFormacao()); };
            btnProfessorCategoria.Click += delegate { OpenForms(new frmProfessoresCategorias()); };

            btnTema.ItemClick += BtnTema_ItemClick;
        }

        private void BtnTema_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!btnTema.Checked)
            {
                // Current skin/palette is dark
                UserLookAndFeel.Default.SetSkinStyle(SkinSvgPalette.WXI.OfficeWhite);
            }
            else
            {
                // Current skin/palette is light
                UserLookAndFeel.Default.SetSkinStyle(SkinSvgPalette.WXI.Sharpness);
            }
        }

        private void OpenForms(XtraUserControl control)
        {
            Cursor =  Cursors.WaitCursor;
            try
            {
                if (control != null)
                {

                    #region Sistemas
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
                    #endregion

                    #region Regioes

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
                    #endregion

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
                    // Cursos Classe Disciplina
                    else if (control.Name.Equals(typeof(frmCursoClasseDisciplina).Name))
                    {
                        this.Text = "Cursos/Classe/Dis - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }

                    // Disciplina
                    else if (control.Name.Equals(typeof(frmDisciplina).Name))
                    {
                        this.Text = "Disciplina - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    // Disciplina / Programa
                    else if (control.Name.Equals(typeof(frmDisciplinaProgramas).Name))
                    {
                        this.Text = "Disciplina/Programa - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }

                    // Escola
                    else if (control.Name.Equals(typeof(frmEscola).Name))
                    {
                        this.Text = "Escola - [Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    // Escola / Convenio
                    else if (control.Name.Equals(typeof(frmEscolaConvenio).Name))
                    {
                        this.Text = "Escola/Convénio - [Aberto]";
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

                    #region Financeiros
                    else if (control.Name.Equals(typeof(frmPropinasConfig).Name))
                    {
                        this.Text = "Propinas Config -[Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmPropinasPagamentos).Name))
                    {
                        this.Text = "Propinas Pag -[Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmPropinasRecibo).Name))
                    {
                        this.Text = "Propinas -[Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    #endregion

                    #region Professor
                    else if (control.Name.Equals(typeof(frmProfessores).Name))
                    {
                        this.Text = "Professor -[Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmProfessoresDisciplina).Name))
                    {
                        this.Text = "P/Disciplina -[Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    }
                    else if (control.Name.Equals(typeof(frmProfessoresAreaFormacao).Name))
                    {
                        this.Text = "P/Formação -[Aberto]";
                        new GlobalOpenUserControl(fluentDesignFormContainer1, control, null);
                    } 
                    else if (control.Name.Equals(typeof(frmProfessoresCategorias).Name))
                    {
                        this.Text = "P/Categorias -[Aberto]";
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
            // Usuarios
            btnUser.Enabled = permission.Usuarios;
            btnGroup.Enabled = permission.Grupos;
            btnPermis.Enabled = permission.Permissions;
            btnUserLogs.Enabled = permission.Logs;

            // Localizacao
            btnMunicipios.Enabled = permission.Municipios;
            btnProvincias.Enabled = permission.Provincias;
            btnProvinciasMunicipios.Enabled = permission.ProvinciasMunicipios   ;

            // Escolas
            btnTurma.Enabled = permission.Turmas  ;
            btnPeriodos.Enabled = permission.Periodos;
            btnClasses.Enabled = permission.Classes;

            btnSalas.Enabled = permission.Salas;
            btnCursos.Enabled = permission.Cursos;

            // Biblioteca
            btnCategoria_Biblioteca.Enabled = permission.Categorias;
            Editoras_Biblioteca.Enabled = permission.Editores;
            btnPais_Biblioteca.Enabled = permission.Pais;
            Autores_Biblioteca.Enabled = permission.Autores;
            Livros_Biblioteca.Enabled = permission.Livros;
            btnPedidos_Consltas_Biblioteca.Enabled = permission.Periodos;
            btnPedidos_Requisicao_Biblioteca.Enabled = permission.PedidosAquisicao;

            //Estudantes
            btnEstudantesInscricoes.Enabled = permission.EstudantesInscricao;
            btnEstudantes.Enabled = permission.Estudantes;

            //Financeiros
            btnPropinasConfig.Enabled = permission.PropinasConfig;
            btnPropinasPagamento.Enabled = permission.PropinasPagamento;
            btnPropinasRecibo.Enabled = permission.PropinasRecibo;
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
                if (item.Name == (typeof(frmLogin1)).Name)
                {
                    item.Show();
                }
            }
        }

        private void fluentDesignFormContainer1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
