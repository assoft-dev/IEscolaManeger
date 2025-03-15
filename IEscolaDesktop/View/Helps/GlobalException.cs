using IEscolaEntity.Controllers.Helps;
using System;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Helps
{
    public class GlobalException
    {
        public static void CapturarError(Exception exe)
        {
            var Db = new DataMigrateConnections();

            if (exe.Message.Contains("Cannot open database") ||
                     exe.Message.Contains("does not exist") ||
                       exe.Message.Contains("Unable to open the physical file"))
            {
                Db.CREATEDATABASE();
            }
            else if (exe.Message.Contains("Invalid object name") ||
                        exe.Message.Contains("Invalid column name"))
            {
                Mensagens.Display("Localixao", "");

                Db.UPDATETABLE();       
            }
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
