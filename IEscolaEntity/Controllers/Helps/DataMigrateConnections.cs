﻿using IEscolaEntity.Models;
using IEscolaEntity.Models.Biblioteca;
using IEscolaEntity.Models.Helps;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IEscolaEntity.Controllers.Helps
{
    public class DataMigrateConnections
    {
        public void InitialMetodos(DataConnectionConfig dataBaseConfig)
        {
            CREATEDATABASE();
        }

        public bool CREATEDATABASE()
        {
            try
            {
                /// teste Inicial de Conexao
                DataConnectionConfig.Conection().OpenDbConnection();
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

                    var Db = DataConnectionConfig.Conection().OpenDbConnection();

                    Db.ExecuteSql("if(db_id('IEscola_Gest') IS NULL) CREATE DATABASE [IEscola_Gest]");
                    Db.ConnectionString.Replace("master", "IEscola_Gest");
                    Db.ChangeDatabase("IEscola_Gest");

                    //Criar as Tabelas
                    CREATETABLE(Db);

                    //Migracao Primaria
                    CREATEMIGRATION(Db);

                    new DataConnectionConfig();
                }
                else if (error.Message.Contains("error: 26"))
                {
                    var Db = DataConnectionConfig.Conection().OpenDbConnection();

                    Db.ExecuteSql("if(db_id('IEscola_Gest') IS NULL) CREATE DATABASE [IEscola_Gest]");
                    Db.ChangeDatabase("IEscola_Gest");
                    //Erro da instancia de SQL
                    Db.ExecuteSql("if(db_id('IEscola_Gest') IS NULL) CREATE DATABASE [IEscola_Gest]");
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

            }
            return true;
        }

        public async void CREATEMIGRATION(IDbConnection db)
        {
            var permissions = db.Select<Permissoes>();
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
                permissoesID = db.Insert<Permissoes>(permissoes, true);
            }
            #endregion
                
            #region Grupos
            var grupos = db.Select<Grupos>();

            if (grupos.Count == 0)
            {
                Grupos r = new Grupos();

                r.Descricao = "Default";

                if (permissoesID == 0)
                    r.PermissionID = permissions.FirstOrDefault().PermissoeID;
                else
                    r.PermissionID = (int)permissoesID;

                gruposID = db.Insert<Grupos>(r);
            }
            #endregion

            #region Usuarios
            var user = db.Select<Usuarios>();

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
                userID = await db.InsertAsync(usuarios);
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
            await db.SaveAsync(logs);
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
            provincia.Add(new Provincias {   Referencias = "CUANDO", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.CD, });
            provincia.Add(new Provincias {   Referencias = "LUNDA NORTE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.LN, });
            provincia.Add(new Provincias {   Referencias = "LUNDA SUL", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.LS, });
            provincia.Add(new Provincias {   Referencias = "CUANZA NORTE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.CN, });
            provincia.Add(new Provincias {   Referencias = "CUANZA SUL", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.CS, });
            provincia.Add(new Provincias {   Referencias = "BENGO", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.BA, });
            provincia.Add(new Provincias {   Referencias = "ICOLE BENGO", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.IC, });
            provincia.Add(new Provincias {   Referencias = "MALANJE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.MA, });
            provincia.Add(new Provincias {   Referencias = "UIGE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.UI, });
            provincia.Add(new Provincias {   Referencias = "ZAIRE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.ZA, });
            provincia.Add(new Provincias {   Referencias = "NAMIBE", Detalhes = null, ProvinciasCodigo = ProvinciasCodigo.NA,  });
            await db.SaveAsync(provincia);
            #endregion
        }

        public void CREATETABLE(IDbConnection Db)
        {
            //Verificacao das tabelas apenas
            Db.CreateTableIfNotExists<Permissoes>();
            Db.CreateTableIfNotExists<Grupos>();
            Db.CreateTableIfNotExists<Usuarios>();
            Db.CreateTableIfNotExists<UsuariosLogs>();

            Db.CreateTableIfNotExists<Provincias>();
            Db.CreateTableIfNotExists<Municipios>();
            Db.CreateTableIfNotExists<ProvinciasMunicipios>();


            Db.CreateTableIfNotExists<Salas>();
            Db.CreateTableIfNotExists<Cursos>();
            Db.CreateTableIfNotExists<Classes>();
            Db.CreateTableIfNotExists<Periodos>();
            Db.CreateTableIfNotExists<Turmas>();

            Db.CreateTableIfNotExists<EstudantesInscricoes>();
            Db.CreateTableIfNotExists<Estudantes>();

            Db.CreateTableIfNotExists<Pais>();
            Db.CreateTableIfNotExists<Autores>();
            Db.CreateTableIfNotExists<Categorias>();
            Db.CreateTableIfNotExists<Editores>();
            Db.CreateTableIfNotExists<Livros>();
            Db.CreateTableIfNotExists<Pedidos>();
            Db.CreateTableIfNotExists<PedidosOrdems>();

            Db.CreateTableIfNotExists<PropinasConfig>();
            Db.CreateTableIfNotExists<PropinasPagamentos>();
            Db.CreateTableIfNotExists<PropinasRecibos>();
            
            Db.CreateTableIfNotExists<Disciplinas>();
            Db.CreateTableIfNotExists<CursoClasseDisciplina>();
            Db.CreateTableIfNotExists<DisciplinasProgramas>();

            Db.CreateTableIfNotExists<ProfessorAreaFormacao>(); 
            
            Db.CreateTableIfNotExists<ProfessoresCategorias>();
            Db.CreateTableIfNotExists<Professores>();  
            
            Db.CreateTableIfNotExists<ProfessoresDisciplinas>();

            Db.CreateTableIfNotExists<Entidade>();
            Db.CreateTableIfNotExists<EntidadeConvenios>();
            Db.CreateTableIfNotExists<Notificacoes>();
        }

        public void UPDATETABLE()
        {
            var Db = DataConnectionConfig.Conection().OpenDbConnection();

            DataColunsAsync<Permissoes>.AsyncColuns(Db);
            DataColunsAsync<Grupos>.AsyncColuns(Db);
            DataColunsAsync<Usuarios>.AsyncColuns(Db);
            DataColunsAsync<UsuariosLogs>.AsyncColuns(Db);
            DataColunsAsync<Provincias>.AsyncColuns(Db);
            DataColunsAsync<Municipios>.AsyncColuns(Db);
            DataColunsAsync<ProvinciasMunicipios>.AsyncColuns(Db);


            DataColunsAsync<Salas>.AsyncColuns(Db);
            DataColunsAsync<Cursos>.AsyncColuns(Db);
            DataColunsAsync<Classes>.AsyncColuns(Db);
            DataColunsAsync<Periodos>.AsyncColuns(Db);
            DataColunsAsync<Turmas>.AsyncColuns(Db);

            DataColunsAsync<EstudantesInscricoes>.AsyncColuns(Db);
            DataColunsAsync<Estudantes>.AsyncColuns(Db);

            DataColunsAsync<Pais>.AsyncColuns(Db);
            DataColunsAsync<Autores>.AsyncColuns(Db);
            DataColunsAsync<Categorias>.AsyncColuns(Db);
            DataColunsAsync<Editores>.AsyncColuns(Db);
            DataColunsAsync<Livros>.AsyncColuns(Db);
            DataColunsAsync<Pedidos>.AsyncColuns(Db);
            DataColunsAsync<PedidosOrdems>.AsyncColuns(Db);

            DataColunsAsync<PropinasConfig>.AsyncColuns(Db);
            DataColunsAsync<PropinasPagamentos>.AsyncColuns(Db);
            DataColunsAsync<PropinasRecibos>.AsyncColuns(Db);

            DataColunsAsync<Disciplinas>.AsyncColuns(Db);
            DataColunsAsync<CursoClasseDisciplina>.AsyncColuns(Db);
            DataColunsAsync<DisciplinasProgramas>.AsyncColuns(Db);

            DataColunsAsync<ProfessorAreaFormacao>.AsyncColuns(Db);
            DataColunsAsync<Professores>.AsyncColuns(Db);
            DataColunsAsync<ProfessoresDisciplinas>.AsyncColuns(Db);
            DataColunsAsync<ProfessoresCategorias>.AsyncColuns(Db);


            DataColunsAsync<Entidade>.AsyncColuns(Db);
            DataColunsAsync<EntidadeConvenios>.AsyncColuns(Db);
            DataColunsAsync<Notificacoes>.AsyncColuns(Db);
        }
    }
}