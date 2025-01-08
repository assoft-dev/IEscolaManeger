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
            return XtraMessageBox.Show(Texto, Titulo, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        public static DialogResult Display(string Titulo, string Texto, MessageBoxIcon messageBoxIcon)
        {
            return  XtraMessageBox.Show(Texto, Titulo, MessageBoxButtons.OKCancel, messageBoxIcon);
        }
        public static DialogResult Display(string Titulo, string Texto, MessageBoxButtons messageBoxButtons, MessageBoxIcon messageBoxIcon)
        {
            return XtraMessageBox.Show(Texto, Titulo, messageBoxButtons, messageBoxIcon);
        }
    }
}
