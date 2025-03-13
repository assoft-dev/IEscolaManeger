using IEscolaDesktop.View.Helps;
using System.IO;
using System.Text;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmUsuarioHelps : DevExpress.XtraEditors.XtraUserControl
    {
        public frmUsuarioHelps(TelaHelps telaHelps)
        {
            InitializeComponent();

            var caminho = Path.Combine(GlobalArquivos.GetLocal(), @"Document\", telaHelps.ToString()+ ".txt").Replace("\\bin\\Debug", "");

            using (var text = new StreamReader(caminho))
            {
                var stn = text.ReadToEnd().Split(';');

                StringBuilder sb = new StringBuilder();

                int i = 0;

                foreach (var st in stn) 
                {
                    if (i != 0)
                      sb.AppendLine(st);
                    i++;
                }

                txtTitulos.Text = stn[0];
                txtDescricao.Text = sb.ToString();
            }
        }

        public enum TelaHelps
        {
            Login = 0,
            Usuario = 1,
            Menu = 2,
        }
    }
}
