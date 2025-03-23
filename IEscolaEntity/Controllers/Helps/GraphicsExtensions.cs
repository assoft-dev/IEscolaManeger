using System.Drawing;
using System.Drawing.Drawing2D;

namespace IEscolaEntity.Controllers.Helps
{
    public static class GraphicsExtensions
    {
        public static System.Drawing.Image MakeCircleImage(System.Drawing.Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (GraphicsPath gpImg = new GraphicsPath())
            {
                gpImg.AddEllipse(0, 0, img.Width, img.Height);
                using (Graphics grp = Graphics.FromImage(bmp))
                {
                    grp.Clear(Color.White);
                    grp.SetClip(gpImg);
                    grp.DrawImage(img, Point.Empty);
                }
            }
            return bmp;
        }
    }
}
