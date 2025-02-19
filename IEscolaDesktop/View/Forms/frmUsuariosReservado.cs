using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmUsuariosReservado : DevExpress.XtraEditors.XtraUserControl
    {
        public frmUsuariosReservado()
        {
            InitializeComponent();

            richTextBox1.DoubleClick += RichTextBox1_DoubleClick;
        }

        private void RichTextBox1_DoubleClick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
