using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Helps
{
    public  class Mensagens
    {
        public static DialogResult Display(string Titulo, string Texto)
        {
            return FlyoutMessageBox.Show(Texto, Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Display(string Titulo, string Texto, MessageBoxIcon messageBoxIcon)
        {
            return FlyoutMessageBox.Show(Texto, Titulo, MessageBoxButtons.OKCancel, messageBoxIcon, MessageBoxDefaultButton.Button1);
        }
        public static DialogResult Display(string Titulo, string Texto, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            return FlyoutMessageBox.Show(Texto, Titulo, messageBoxButtons, messageBoxIcon, MessageBoxDefaultButton.Button1);
        }
    }
}
