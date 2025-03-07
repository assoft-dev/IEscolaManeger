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
            #region Closes
            //// Creates and initializes an object with message box settings.
            //XtraMessageBoxArgs args = new XtraMessageBoxArgs()
            //{
            //    // Sets the caption of the message box.
            //    Caption = "Confirmation",
            //    // Sets the message of the message box.
            //    Text = "Do you want to close the application?",
            //    // Sets the buttons of the message box.
            //    Buttons = new DialogResult[] { DialogResult.Yes, DialogResult.No },
            //    // Sets the auto-close options of the message box.
            //    AutoCloseOptions = new AutoCloseOptions()
            //    {
            //        // Sets the delay before the message box automatically closes.
            //        Delay = 5000,
            //        // Displays the timer on the default button.
            //        ShowTimerOnDefaultButton = true
            //    }
            //};
            //// Displays the message box and checks if a user clicked "No".
            //if (XtraMessageBox.Show(args) == DialogResult.No)
            //    e.Cancel = true;
            #endregion

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
