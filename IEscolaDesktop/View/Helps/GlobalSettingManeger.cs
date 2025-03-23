using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace IEscolaDesktop.View.Helps
{
    public enum SettingsKey
    {
        //USERPROFILE
        Estado,           //False
        Nome,             //admin
        Senha,            //admin
        Conection,        //Default
        DefaultAppFont,   //Bahnschrift Light; 9,75pt
        inicializaWindows,//False
        TouchUI,          //False
        DefaultPalette,   //Plastic Space
        iServer,          //False

        //MOEDAS
        Cambio,   //0
        Simbolo,  //EUR

        //IMPRESSORA
        Fatura80, //
        FaturaA4,
        Modelo80,
        FacturaIs80,
        FaturaNormal,
        Copias,   // 1
        PRECEDENTE_FATURA, //FAC
        FaturasInicioFatura, // 1
        ImprimirDirecto,         //True
        ImprimirPrevisualizar,   //False           
    }

    public enum SettingsSession
    {
        USERPROFILE,
        OUTROS,
        IMPRESSORA,
        MOEDAS
    }

    public class SettingsIniSerialization
    {
        public SettingsKey Key { get; set; }
        public string Values { get; set; }
        public SettingsSession Session { get; set; }
    }

    public class IniSerializationData
    {
        private List<SettingsIniSerialization> GetIniSerializations()
        {
            return new List<SettingsIniSerialization>
            {
                //USERPROFILE
                new SettingsIniSerialization { Key = SettingsKey.Estado, Values = "False", Session = SettingsSession.USERPROFILE },
                new SettingsIniSerialization { Key = SettingsKey.Nome, Values = "admin", Session = SettingsSession.USERPROFILE },
                new SettingsIniSerialization { Key = SettingsKey.Senha, Values = "admin", Session = SettingsSession.USERPROFILE },
                new SettingsIniSerialization { Key = SettingsKey.Conection, Values = "", Session = SettingsSession.USERPROFILE },
                new SettingsIniSerialization { Key = SettingsKey.inicializaWindows, Values = "False", Session = SettingsSession.USERPROFILE },

                new SettingsIniSerialization { Key = SettingsKey.TouchUI, Values = "False", Session = SettingsSession.USERPROFILE },
                new SettingsIniSerialization { Key = SettingsKey.DefaultAppFont, Values = "Bahnschrift Light; 9,75pt", Session = SettingsSession.USERPROFILE },
                new SettingsIniSerialization { Key = SettingsKey.DefaultPalette, Values = "Sharpness", Session = SettingsSession.USERPROFILE },
                new SettingsIniSerialization { Key = SettingsKey.iServer, Values = "False", Session = SettingsSession.USERPROFILE },

                new SettingsIniSerialization { Key = SettingsKey.Cambio, Values = "0", Session = SettingsSession.MOEDAS },
                new SettingsIniSerialization { Key = SettingsKey.Simbolo, Values = "EUR", Session =     SettingsSession.MOEDAS },

                new SettingsIniSerialization { Key = SettingsKey.Fatura80, Values = "", Session = SettingsSession.IMPRESSORA },
                new SettingsIniSerialization { Key = SettingsKey.FaturaA4, Values = "", Session = SettingsSession.IMPRESSORA },
                new SettingsIniSerialization { Key = SettingsKey.Modelo80, Values = "", Session = SettingsSession.IMPRESSORA },
                new SettingsIniSerialization { Key = SettingsKey.FaturaNormal, Values = "", Session = SettingsSession.IMPRESSORA },
                new SettingsIniSerialization { Key = SettingsKey.Copias, Values = "1", Session = SettingsSession.IMPRESSORA },
                new SettingsIniSerialization { Key = SettingsKey.PRECEDENTE_FATURA, Values = "FAC", Session = SettingsSession.IMPRESSORA },
                
                new SettingsIniSerialization { Key = SettingsKey.ImprimirDirecto, Values = "True", Session = SettingsSession.IMPRESSORA },
                new SettingsIniSerialization { Key = SettingsKey.ImprimirPrevisualizar, Values = "False", Session = SettingsSession.IMPRESSORA },
            };
        }

        public void SetIniSerializar()
        {
            foreach (var item in GetIniSerializations())
            {
                if (!GlobalSettingManeger.KeyExists(item.Key, item.Session))
                    GlobalSettingManeger.Write(item.Key, item.Values, item.Session);
            }
        }
    }

    public static class GlobalSettingManeger
    {
        private static string Path = new FileInfo(@"C:\asinforprest\IEscola\Config\SettingsEscola.ini").FullName;
        static string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);


        public static string Read(SettingsKey Key)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(EXE.ToString(), Key.ToString(), "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public static string Read(SettingsKey Key, SettingsSession Section)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section.ToString(), Key.ToString(), "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public static void Write(SettingsKey Key, string Valuel)
        {
            WritePrivateProfileString(EXE, Key.ToString(), Valuel, Path);
        }

        public static void Write(SettingsKey Key, string Value, SettingsSession Section)
        {
            WritePrivateProfileString(Section.ToString(), Key.ToString(), Value, Path);
        }

        public static void DeleteKey(SettingsKey Key, SettingsSession SettingsSession)
        {
            Write(Key, null, SettingsSession);
        }

        public static bool KeyExists(SettingsKey Key, SettingsSession Section)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
