using System.Windows.Forms;

namespace IEscolaDesktop.View.Helps
{
    public class GlobalOpenUserControl
    {


        public GlobalOpenUserControl(Control OriginalOwen,
                                     UserControl Afitriao, 
                                     Button button = null)
        {
            if (button != null)
            {
                button.Click += (sender, e) =>
                {
                    OriginalOwen.Controls.Remove(Afitriao);
                };
            }

            OriginalOwen.Controls.Add(Afitriao);
            Afitriao.Dock = DockStyle.Fill;
            Afitriao.Top = 1;
            Afitriao.BringToFront();

            //if (OriginalOwen.Controls.Count > 1 || OriginalOwen.Controls.Count != 10)
            //{
            //    foreach (Control item in OriginalOwen.Controls)
            //    {
            //        if (item.Name == Afitriao.Name)
            //        {
            //            Afitriao.BringToFront();
            //        }
            //    }
            //}
            //else
            //{
            //    OriginalOwen.Controls.Add(Afitriao);
            //    Afitriao.Dock = DockStyle.Fill;
            //    Afitriao.Top = 1;
            //    Afitriao.BringToFront();
            //}          
        }
        public GlobalOpenUserControl()
        {
            
        }
        public DialogResult GlobalOpenUserControlResult(UserControl Afitriao, int Width, int Height, 
                                                           int LocationX, int LocationY)
        {
            Form OriginalOwen = new Form();

            Afitriao.Dock = DockStyle.Fill;
            Afitriao.Top = 1;
            Afitriao.BringToFront();

            OriginalOwen.Height = Height;
            OriginalOwen.Width = Width;


            OriginalOwen.ShowInTaskbar = false;
            OriginalOwen.ShowIcon = false;

            OriginalOwen.Location = new System.Drawing.Point(LocationX, LocationY);

            OriginalOwen.FormBorderStyle = FormBorderStyle.None;
            OriginalOwen.StartPosition = FormStartPosition.CenterParent;
            OriginalOwen.Controls.Add(Afitriao);

            OriginalOwen.FormClosed += (e, x) =>
            {
                OriginalOwen.DialogResult = DialogResult.OK;
            };

            return OriginalOwen.ShowDialog();
        }
    }
}
