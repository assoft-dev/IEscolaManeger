using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEscolaDesktop.View.Helps
{
    public static class GlobalArquivos
    {
        public static FileInfo[] Lerarquivos(string folder)
        {
            return (new DirectoryInfo(GetLocalData(folder))).GetFiles();
        }
        public static FileInfo[] Lerarquivos(string folder, string extensoes)
        {
            return (new DirectoryInfo(GetLocalData(folder))).GetFiles($"*.{extensoes}", SearchOption.AllDirectories);
        }

        public static FileInfo[] GetLocalFileError()
        {
            var caminho = GetLocalData("Logs");
            return (new DirectoryInfo(caminho)).GetFiles();
        }
        public static string GetLocalDataSoftware()
        {
            var Directo = @"C:\IGestEscola\";
            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }

        /// <summary>
        /// Colocar a pasta
        /// </summary>
        /// <param name="Pasta"></param>
        /// <returns>C:\ISOFTComercial\{0}</returns>
        public static string GetLocalData(string Pasta)
        {
            var Directo = string.Format(@"C:\IGestEscola\{0}", Pasta);
            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }
        public static string GetLocalData(LocalFolder localFolder, string patha_dicional = null)
        {
            var Directo = string.Empty;
            switch (localFolder)
            {
                case LocalFolder.Backup:
                    Directo = patha_dicional == null ? @"C:\IGestEscola\Backups" :
                                 string.Format(@"C:\IGestEscola\Backups\{0}", patha_dicional);
                    break;
                case LocalFolder.BackupHTML:
                    Directo = patha_dicional == null ? @"C:\IGestEscola\BackupHTML" :
                                 string.Format(@"C:\IGestEscola\BackupHTML\{0}", patha_dicional);
                    break;
                case LocalFolder.Config:
                    Directo = patha_dicional == null ? @"C:\IGestEscola\Config" :
                                 string.Format(@"C:\IGestEscola\Config\{0}", patha_dicional);
                    break;
                case LocalFolder.ConfigRH:
                    Directo = patha_dicional == null ? @"C:\IGestEscola\ConfigRH" :
                                 string.Format(@"C:\IGestEscola\ConfigRH\{0}", patha_dicional);
                    break;
                case LocalFolder.Log:
                    Directo = patha_dicional == null ? @"C:\IGestEscola\Logs" :
                                 string.Format(@"C:\IGestEscola\Logs\{0}", patha_dicional);
                    break;
                case LocalFolder.SAF:
                    Directo = patha_dicional == null ? @"C:\IGestEscola\SAF-T" :
                                 string.Format(@"C:\IGestEscola\SAF-T\{0}", patha_dicional);
                    break;
                case LocalFolder.REPORT:
                    Directo = patha_dicional == null ? @"C:\IGestEscola\Relatórios" :
                                string.Format(@"C:\IGestEscola\Relatórios\{0}", patha_dicional);
                    break;
                default:
                    Directo = string.Format(@"C:\IGestEscola\");
                    break;
            }

            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }
        public static string GetLocal()
        {
            return Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory.ToString());
        }
        public static string GetLocalDataUsert(string pasta)
        {
            var Directo = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Directo = Path.Combine(Directo, pasta);
            return Directo;
        }
        public static string GetLocalDataUsert(string pasta, string pasta1)
        {
            var Directo = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Directo = Path.Combine(Directo, pasta, pasta1);
            if (!Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }
        public static string CreateLocalDataUsert(string pasta, string pasta1)
        {
            var Directo = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            Directo = Path.Combine(Directo, pasta, pasta1);

            if (Directory.Exists(Directo))
                Directory.CreateDirectory(Directo);
            return Directo;
        }
    }

    public enum LocalFolder
    {
        Backup = 0,
        BackupHTML = 1,
        Config = 2,
        ConfigRH = 3,
        Log = 4,
        SAF = 5,
        REPORT = 6,
    }

}
