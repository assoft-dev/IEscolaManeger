using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace IEscolaEntity.Controllers.Helps
{
    public class DataMigrateConnections
    {
        private IDbConnection DbConection = null;

        public void OpenConection()
        {
            /// teste Inicial de Conexao
            if (DbConection == null)
                this.DbConection = new DataConnectionConfig().ConectionDb().OpenDbConnection();
        }

        public bool CREATEDATABASE()
        {
            try
            {
                OpenConection();
                UPDATETABLE();
            }
            catch (Exception error)
            {
                // Criate database
                if (error.Message.Contains("Cannot open database") ||
                     error.Message.Contains("does not exist") ||
                       error.Message.Contains("Unable to open the physical file"))
                {
                    DataConnectionConfig.connectionString = new SqlConnectionStringBuilder();

                    //Testar conexão
                    DataConnectionConfig.connectionString.DataSource = ".";
                    DataConnectionConfig.connectionString.InitialCatalog = "master";
                    DataConnectionConfig.connectionString.IntegratedSecurity = true;

                    if (DbConection == null)
                        DbConection = (new OrmLiteConnectionFactory(DataConnectionConfig.connectionString.ConnectionString, 
                            SqlServerDialect.Provider)).CreateDbConnection();

                    if (DbConection.State == ConnectionState.Closed)
                        DbConection.Open();

                    DbConection.ExecuteSql("if(db_id('IEscola_Gest') IS NULL) CREATE DATABASE [IEscola_Gest]");
                    DbConection.ConnectionString.Replace("master", "IEscola_Gest");
                    DbConection.ChangeDatabase("IEscola_Gest");

                    //Criar as Tabelas
                    CREATETABLE();

                    //Migracao Primaria
                    CREATEMIGRATION();
                }
                else if (error.Message.Contains("error: 26"))
                {
                    DbConection.ExecuteSql("if(db_id('IEscola_Gest') IS NULL) CREATE DATABASE [IEscola_Gest]");
                    DbConection.ChangeDatabase("IEscola_Gest");

                    //Erro da instancia de SQL
                    DbConection.ExecuteSql("if(db_id('IEscola_Gest') IS NULL) CREATE DATABASE [IEscola_Gest]");

                    //Criar as Tabelas
                    CREATETABLE();

                    //Migracao Primaria
                    CREATEMIGRATION();
                }
                else if (error.Message.Contains("Invalid object name"))
                {
                    UPDATETABLE();
                }
                else if (error.Message.Contains("provider: Named Pipes Provider, error: 40") ||
                           error.Message.Contains("SQL Server service has been paused"))
                {
                    //Inicia o servidor por intermedio do SQL SERVER

                }
                //MessageBox.Show("Alguns procedimentos teram mesmo que ser feitos manualamente \n(Fornecedor_Caixa FornecedorCaixa_FornecedorCaixaID (Eliminar))" +
                //                                                                               "(FacturaOrdem     FaturasNotaEntregaFaturasID (Eliminar)) \n\n\n" + "2)	Retirar Chave Primaria nas Tabelas (FacturaArmazem, NotaEntrega, ReciboPagamento) 3)  FaturaAmrazemOrdem Retirar a Nota NotaEntrega\n\n" + exe.Message, "Tabelas/Colunas", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (DbConection.State == ConnectionState.Open)
                    DbConection.Close();
            }
            return true;
        }

        private async void CREATEMIGRATION()
        {
            var permissions = DbConection.Select<Permissoes>();
            var permissoesID = 0L;
            var gruposID = 0L;

            #region Permissoes
            if (permissions == null || permissions.Count == 0)
            {
                //Permissoes
                var permissoes = new Permissoes()
                {
                    Update = true,
                    Create = true,
                    List = true,
                    Usuarios = true,
                    Classes = true,
                    Delete = true,
                    Estudantes = true,
                    Periodos = true,
                    Grupos = true,
                    Logs = true,
                    Permissions = true,
                    Turmas = true,
                    Autores = true,
                    Categorias = true,
                    Cursos = true,
                    Editores = true,
                    EstudantesInscricao = true,
                    Livros = true,
                    Municipios = true,
                    PedidosConsultas = true,
                    PedidosAquisicao = true,
                    PropinasConfig = true,
                    PropinasPagamento = true,
                    Provincias = true,
                    PropinasRecibo = true,
                    Pais = true,
                    ProvinciasMunicipios = true,    
                    Salas = true, 
                    
                    ProfessoresCategorias = true,
                    ProfessoresDisciplinas = true,
                    ProfessorAreaFormacao = true,
                    DisciplinasProgramas = true,
                    CursoClasseDisciplina = true,
                    Disciplinas = true,
                    Professores = true,    
                };
                permissoesID = DbConection.Insert<Permissoes>(permissoes, true);
            }
            #endregion
                
            #region Grupos
            var grupos = DbConection.Select<Grupos>();

            if (grupos.Count == 0)
            {
                Grupos r = new Grupos();

                r.Descricao = "Default";

                if (permissoesID == 0)
                    r.PermissionID = permissions.FirstOrDefault().PermissoeID;
                else
                    r.PermissionID = (int)permissoesID;

                gruposID = DbConection.Insert<Grupos>(r);
            }
            #endregion

            #region Usuarios
            var user = DbConection.Select<Usuarios>();

            long userID = 0;

            if (user.Count == 0)
            {
                Usuarios usuarios = new Usuarios();
                usuarios.FirstName = "Admins";
                usuarios.LastName = "admin";
                usuarios.Email = "admin@outlook.pt";
                usuarios.Senha = MD5Create.GetMD5Hash("0000");
                usuarios.Data = DateTime.Now;
                usuarios.Estado = Estado.Activado;
                usuarios.GruposID = gruposID == 0 ? grupos.FirstOrDefault().PermissionID : (int)gruposID;
                userID = await DbConection.InsertAsync(usuarios);
            }
            else
            {
                userID = user.FirstOrDefault().UsuariosID;
            }
            #endregion

            #region UsuariosLogs
            var logs = new UsuariosLogs
            {
                Data = DateTime.Now,
                Descricao = "Dados Iniciais",
                Local = "Local",
                UsuariosID = (int) userID,
                UsuariosLogsID = 0
            };
            await DbConection.SaveAsync(logs);
            #endregion

            #region Provincias
            var provincia = new List<Provincias>();
            provincia.Add(new Provincias {   Referencias = "LUANDA", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.LA, });
            provincia.Add(new Provincias {   Referencias = "BENGUELA", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.BE, });
            provincia.Add(new Provincias {   Referencias = "CABINDA", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.CA, });
            provincia.Add(new Provincias {   Referencias = "MOXICO", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.MO, });
            provincia.Add(new Provincias {   Referencias = "MOXICO LESTE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.ML, });
            provincia.Add(new Provincias {   Referencias = "MOXICO OESTE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.MO, });
            provincia.Add(new Provincias {   Referencias = "CUBANGO", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.CO, });
            provincia.Add(new Provincias {   Referencias = "CUANDO", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.COU, });
            provincia.Add(new Provincias {   Referencias = "LUNDA NORTE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.LN, });
            provincia.Add(new Provincias {   Referencias = "LUNDA SUL", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.LS, });
            provincia.Add(new Provincias {   Referencias = "CUANZA NORTE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.CN, });
            provincia.Add(new Provincias {   Referencias = "CUANZA SUL", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.CS, });
            provincia.Add(new Provincias {   Referencias = "BENGO", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.BA, });
            provincia.Add(new Provincias {   Referencias = "ICOLE BENGO", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.IC, });
            provincia.Add(new Provincias {   Referencias = "MALANJE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.ME, });
            provincia.Add(new Provincias {   Referencias = "UIGE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.UE, });
            provincia.Add(new Provincias {   Referencias = "ZAIRE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.ZE, });
            provincia.Add(new Provincias {   Referencias = "NAMIBE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.NE,  });
            await DbConection.SaveAsync(provincia);
            #endregion
        }

        private void CREATETABLE()
        {
            //Verificacao das tabelas apenas
            DbConection.CreateTableIfNotExists<Permissoes>();
            DbConection.CreateTableIfNotExists<Grupos>();
            DbConection.CreateTableIfNotExists<Usuarios>();
            DbConection.CreateTableIfNotExists<UsuariosLogs>();

            DbConection.CreateTableIfNotExists<Provincias>();
            DbConection.CreateTableIfNotExists<Municipios>();
            DbConection.CreateTableIfNotExists<ProvinciasMunicipios>();


            DbConection.CreateTableIfNotExists<Salas>();
            DbConection.CreateTableIfNotExists<Cursos>();
            DbConection.CreateTableIfNotExists<Classes>();
            DbConection.CreateTableIfNotExists<Periodos>();
            DbConection.CreateTableIfNotExists<Turmas>();

            DbConection.CreateTableIfNotExists<EstudantesInscricoes>();
            DbConection.CreateTableIfNotExists<Estudantes>();

            DbConection.CreateTableIfNotExists<Pais>();
            DbConection.CreateTableIfNotExists<Autores>();
            DbConection.CreateTableIfNotExists<Categorias>();
            DbConection.CreateTableIfNotExists<Editores>();
            DbConection.CreateTableIfNotExists<Livros>();
            DbConection.CreateTableIfNotExists<Pedidos>();
            DbConection.CreateTableIfNotExists<PedidosOrdems>();

            DbConection.CreateTableIfNotExists<PropinasConfig>();
            DbConection.CreateTableIfNotExists<PropinasPagamentos>();
            DbConection.CreateTableIfNotExists<PropinasRecibos>();

            DbConection.CreateTableIfNotExists<Disciplinas>();
            DbConection.CreateTableIfNotExists<CursoClasseDisciplina>();
            DbConection.CreateTableIfNotExists<DisciplinasProgramas>();

            DbConection.CreateTableIfNotExists<ProfessorAreaFormacao>();

            DbConection.CreateTableIfNotExists<ProfessoresCategorias>();
            DbConection.CreateTableIfNotExists<Professores>();

            DbConection.CreateTableIfNotExists<ProfessoresDisciplinas>();

            DbConection.CreateTableIfNotExists<Entidade>();
            DbConection.CreateTableIfNotExists<EntidadeConvenios>();
            DbConection.CreateTableIfNotExists<Notificacoes>();

            DbConection.CreateTableIfNotExists<MiniPauta_Trimestre>();
            DbConection.CreateTableIfNotExists<MiniPautas>();
        }

        public void UPDATETABLE()
        {
            DataColunsAsync<Permissoes>.AsyncColuns(DbConection);
            DataColunsAsync<Grupos>.AsyncColuns(DbConection);
            DataColunsAsync<Usuarios>.AsyncColuns(DbConection);
            DataColunsAsync<UsuariosLogs>.AsyncColuns(DbConection);
            DataColunsAsync<Provincias>.AsyncColuns(DbConection);
            DataColunsAsync<Municipios>.AsyncColuns(DbConection);
            DataColunsAsync<ProvinciasMunicipios>.AsyncColuns(DbConection);


            DataColunsAsync<Salas>.AsyncColuns(DbConection);
            DataColunsAsync<Cursos>.AsyncColuns(DbConection);
            DataColunsAsync<Classes>.AsyncColuns(DbConection);
            DataColunsAsync<Periodos>.AsyncColuns(DbConection);
            DataColunsAsync<Turmas>.AsyncColuns(DbConection);

            DataColunsAsync<EstudantesInscricoes>.AsyncColuns(DbConection);
            DataColunsAsync<Estudantes>.AsyncColuns(DbConection);

            DataColunsAsync<Pais>.AsyncColuns(DbConection);
            DataColunsAsync<Autores>.AsyncColuns(DbConection);
            DataColunsAsync<Categorias>.AsyncColuns(DbConection);
            DataColunsAsync<Editores>.AsyncColuns(DbConection);
            DataColunsAsync<Livros>.AsyncColuns(DbConection);
            DataColunsAsync<Pedidos>.AsyncColuns(DbConection);
            DataColunsAsync<PedidosOrdems>.AsyncColuns(DbConection);

            DataColunsAsync<PropinasConfig>.AsyncColuns(DbConection);
            DataColunsAsync<PropinasPagamentos>.AsyncColuns(DbConection);
            DataColunsAsync<PropinasRecibos>.AsyncColuns(DbConection);

            DataColunsAsync<Disciplinas>.AsyncColuns(DbConection);
            DataColunsAsync<CursoClasseDisciplina>.AsyncColuns(DbConection);
            DataColunsAsync<DisciplinasProgramas>.AsyncColuns(DbConection);

            DataColunsAsync<ProfessorAreaFormacao>.AsyncColuns(DbConection);
            DataColunsAsync<Professores>.AsyncColuns(DbConection);
            DataColunsAsync<ProfessoresDisciplinas>.AsyncColuns(DbConection);
            DataColunsAsync<ProfessoresCategorias>.AsyncColuns(DbConection);

            DataColunsAsync<Entidade>.AsyncColuns(DbConection);
            DataColunsAsync<EntidadeConvenios>.AsyncColuns(DbConection);
            DataColunsAsync<Notificacoes>.AsyncColuns(DbConection);

            DataColunsAsync<MiniPauta_Trimestre>.AsyncColuns(DbConection);
            DataColunsAsync<MiniPautas>.AsyncColuns(DbConection);
        }
    }
}