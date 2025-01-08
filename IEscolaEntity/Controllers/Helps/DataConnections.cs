using IEscolaEntity.Models;
using IEscolaEntity.Models.Helps;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IEscolaEntity.Controllers.Helps
{
    public class DataConnections
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

            var permissions = db.Select<Permission>();
            var permissoesID = 0L;
            var gruposID = 0L;

            #region Permissoes
            if (permissions == null || permissions.Count == 0)
            {
                //Permissoes
                var permissoes = new Permission()
                {
                    Update = true,
                    Create = true,
                    List = true,
                    Usuarios = true,
                    Classes = true,
                    Delete = true,
                    Estudantes = true,
                    Periodos = true,
                    Grupo = true,
                    Logs = true,
                    Permissions = true,
                    Turmas = true,
                };
                permissoesID = db.Insert<Permission>(permissoes, true);
            }
            #endregion
                
            #region Grupos
            var grupos = db.Select<Grupos>();

            if (grupos.Count == 0)
            {
                Grupos r = new Grupos();

                r.Referencias = "Default";

                if (permissoesID == 0)
                    r.PermissionID = permissions.FirstOrDefault().PermissionsID;
                else
                    r.PermissionID = (int)permissoesID;

                gruposID = db.Insert<Grupos>(r);
            }
            #endregion

            #region Usuarios
            var user = db.Select<Usuarios>();
            if (user.Count == 0)
            {
                Usuarios usuarios = new Usuarios();
                usuarios.FirstName = "Admins";
                usuarios.LastName = "admin";
                usuarios.Email = "admin@outlook.pt";
                usuarios.Senha = MD5Create.GetMD5Hash("0000");
                usuarios.Pin = MD5Create.GetMD5Hash("1123");
                usuarios.Data = DateTime.Now;
                usuarios.Estado = Estado.Activado;
                usuarios.GruposID = gruposID == 0 ? grupos.FirstOrDefault().PermissionID : (int)gruposID;
                await db.SaveAsync(usuarios);
            }
            #endregion
        }

        public void CREATETABLE(IDbConnection Db)
        {
            //Verificacao das tabelas apenas
            Db.CreateTableIfNotExists<Permission>();
            Db.CreateTableIfNotExists<Grupos>();
            Db.CreateTableIfNotExists<Usuarios>();
            Db.CreateTableIfNotExists<Logs>();

            Db.CreateTableIfNotExists<Classes>();
            Db.CreateTableIfNotExists<Periodos>();
            Db.CreateTableIfNotExists<Turmas>();
            Db.CreateTableIfNotExists<Estudantes>();
            Db.CreateTableIfNotExists<Professores>();
        }

        public void UPDATETABLE()
        {
            var Db = DataConnectionConfig.Conection().OpenDbConnection();

            //Ajustar as colunas em Fantas
            DataColunsAsync<Permission>.AsyncColuns(Db);
            DataColunsAsync<Grupos>.AsyncColuns(Db);
            DataColunsAsync<Usuarios>.AsyncColuns(Db);
            DataColunsAsync<Logs>.AsyncColuns(Db);

            DataColunsAsync<Classes>.AsyncColuns(Db);
            DataColunsAsync<Periodos>.AsyncColuns(Db);
            DataColunsAsync<Estudantes>.AsyncColuns(Db);
            DataColunsAsync<Turmas>.AsyncColuns(Db);
            DataColunsAsync<Professores>.AsyncColuns(Db);
        }
    }
}
