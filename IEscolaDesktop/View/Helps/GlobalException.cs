using IEscolaEntity.Controllers.Helps;
using System;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Helps
{
    public class GlobalException
    {
        public static void CapturarError(Exception exe)
        {
            var Db = new DataConnections();

            if (exe.Message.Contains("Invalid object name"))
                Db.UPDATETABLE();
            else if (exe.Message.Contains("Invalid column name"))
                Db.UPDATETABLE();

            MessageBox.Show(exe.Message);
        }
        public static void InitialAsync()
        {
            var u = DataConnectionConfig.Conection().OpenDbConnection();

            var Db = new DataConnections();
            Db.CREATEMIGRATION(u);
        } 
        public static void CapturarError(Action exe)
        {
            try
            {
                exe.Invoke();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }      
        }
    }
}
