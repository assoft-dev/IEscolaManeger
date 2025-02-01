using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Helps
{
    public class OpenFormsDialog : FlyoutDialog
    {
        public OpenFormsDialog(Form owner, FlyoutAction actions, Control UserControleToShow)
          : base(owner, actions, UserControleToShow)
        {
            this.Properties.HeaderOffset = 0;
            Properties.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            Properties.Style = FlyoutStyle.Popup;
            FlyoutControl = UserControleToShow;
        }
        public static DialogResult ShowForm(Form owner, FlyoutAction actions, Control UserControleToShow)
        {
            OpenFormsDialog customFlyout = new OpenFormsDialog(owner, actions, UserControleToShow);
            customFlyout.FormClosing += delegate { customFlyout.DialogResult = DialogResult.OK; UserControleToShow.Dispose(); };
            return customFlyout.ShowDialog();
        }
        public static DialogResult ShowForm(FlyoutAction actions, Control UserControleToShow)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name.Equals("frmMenu"))
                {
                    OpenFormsDialog customFlyout = new OpenFormsDialog(frm, actions, UserControleToShow);
                    customFlyout.FormClosing += delegate { UserControleToShow.Dispose(); };
                    return customFlyout.ShowDialog();
                }
            }
            return DialogResult.No;
        }
    }
   
}
