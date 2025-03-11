using DevExpress.CodeParser;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using IEscolaDesktop.View.Forms;
using IEscolaDesktop.View.Helps;
using IEscolaEntity.Controllers.Helps;
using System;
using System.Collections;
using System.IO;
using System.Linq;
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
            Db.UPDATETABLE();
            inicializacaoDirectory();

            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            WindowsFormsSettings.TrackWindowsAccentColor = DevExpress.Utils.DefaultBoolean.True;
            WindowsFormsSettings.EnableMdiFormSkins();
            UserLookAndFeel.Default.SetSkinStyle(SkinStyle.WXI);
            //DevExpress.UserSkins.BonusSkins.Register();

            Mutex mutex = new Mutex(true, name: "{Escola - F1056557-EDEF-4A8B-8AC7-7D5D659FA2C7}");

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.Run(new frmTelaInicial());
            }
            else {
                mutex.Close();

                Mensagens.Display("[IEscola - já em Execução]", "\nDesculpe mais a sua Aplicação Já esta em Execução\nTente verificar na barra de baixo do windows (Menu inicial)", 
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                Application.Exit();
            }
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

            Mensagens.Display("Global Exceptions", e.Exception.Message);
        }
    }
}
