using IEscolaEntity.Models.Helps;
using ServiceStack.OrmLite;
using System;
using System.Data.SqlClient;

namespace IEscolaEntity.Controllers.Helps
{
    public class DataConnectionConfig: DataBaseAtributos
    {

        public static SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
        public DataConnectionConfig()
        {
            ConectionStringInitial();

            OrmLiteConfig.DialectProvider = SqlServerDialect.Provider;
            OrmLiteConfig.DialectProvider.NamingStrategy = new OrmLiteNamingStrategyBase();
            SqlServerDialect.Provider.RegisterConverter<TimeSpan>(new ServiceStack.OrmLite.SqlServer.Converters.SqlServerTimeConverter { Precision = 7 });
            SqlServerDialect.Provider.RegisterConverter<decimal>(new ServiceStack.OrmLite.SqlServer.Converters.SqlServerDecimalConverter { Precision = 38, Scale = 2 });
        }
        private void ConectionStringInitial()
        {
            //Construir StringConection
            connectionString.DataSource = Server;
            connectionString.UserID = UserID;
            connectionString.Password = Password;
            connectionString.InitialCatalog = DataBase;
            connectionString.ConnectTimeout = TimeOut;
            connectionString.MaxPoolSize = 100;
            //connectionString.TrustServerCertificate = TruestConection;
        }

        public static OrmLiteConnectionFactory Conection()
        {
            var dbFactory = new OrmLiteConnectionFactory(connectionString.ConnectionString,
                                                         SqlServerDialect.Provider);
            return dbFactory;
        }
    }

    public class DataBaseAtributos
    {
        public string Server { get; set; } = ".";
        public string UserID { get; set; } = "sa";
        public string Password { get; set; } = "junior";
        public string DataBase { get; set; } = "IEscola_Gest";
        public int TimeOut { get; set; } = 60;
        public bool TruestConection { get; set; } = true;
    }
}
