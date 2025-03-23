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
            IniciarBaseDados();
            inicializacaoDirectory();
            InicializarSettings();
            InicializarThemas();


            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           

            Mutex mutex = new Mutex(true, name: "{Escola - F1056557-EDEF-4A8B-8AC7-7D5D659FA2C7}");

            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.Run(new frmTelaInicial());
            }
            else
            {
                mutex.Close();

                Mensagens.Display("[IEscola - já em Execução]", "\nDesculpe mais a sua Aplicação Já esta em Execução\nTente verificar na barra de baixo do windows (Menu inicial)",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private static void InicializarThemas()
        {
            var skin2 = GlobalSettingManeger.Read(SettingsKey.DefaultPalette, SettingsSession.USERPROFILE);

            if (skin2.Equals("Sharpness"))
                UserLookAndFeel.Default.SetSkinStyle(SkinSvgPalette.WXI.Sharpness);
            else
                UserLookAndFeel.Default.SetSkinStyle(SkinSvgPalette.WXI.OfficeWhite);

            WindowsFormsSettings.TrackWindowsAccentColor = DevExpress.Utils.DefaultBoolean.True;
            WindowsFormsSettings.EnableMdiFormSkins();
        }

        private static void InicializarSettings()
        {
            new IniSerializationData().SetIniSerializar();
        }

        private static void IniciarBaseDados()
        {
            //Verificar a base de dados
            var Db = new DataMigrateConnections();
            Db.CREATEDATABASE();
        }

        private static void inicializacaoDirectory()
        {
            var caminho = new ArrayList
            {
                @"C:\\asinforprest\\IEscola\\Config\\",
                @"C:\\asinforprest\\IEscola\\Usuarios",
                @"C:\\asinforprest\\IEscola\\Professores",
                @"C:\\asinforprest\\IEscola\\Estudantes",
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
            var Db = new DataMigrateConnections();
            Db.CREATEDATABASE();
            GlobalException.CapturarError(e.Exception);

            Mensagens.Display("Global Exceptions", e.Exception.Message);
        }
    }
}
