using IEscolaDesktop.View.Forms;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Helps;
using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace IEscolaDesktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //Verificar a base de dados
            var Db = new DataConnections();
            Db.InitialMetodos(new DataConnectionConfig());
            inicializacaoDirectory();

            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmTelaInicial());
        }

        private static void inicializacaoDirectory()
        {
            var caminho = new ArrayList
            {
                @"C:\\GYM-System\\Usuarios",
                @"C:\\GYM-System\\Professores",
                @"C:\\GYM-System\\Estudantes",
            };

            foreach (string item in caminho)
            {
                if (!Directory.Exists(item))
                    Directory.CreateDirectory(item);
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {

            // Inicializacao dos Dados
            var Db = new DataConnections();
            Db.InitialMetodos(new DataConnectionConfig());

            GlobalException.CapturarError(e.Exception);

            MessageBox.Show("Error Global " + e.Exception.Message);
        }
    }
}
