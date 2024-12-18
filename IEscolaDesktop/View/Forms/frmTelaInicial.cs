using DevExpress.XtraSplashScreen;
using System;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmTelaInicial : SplashScreen
    {
        public frmTelaInicial()
        {
            InitializeComponent();

            //inicializacao de Valores
            timer1.Enabled = true;
            Opacity = 0.00;

            //Metodos
            timer1.Tick += Timer1_Tick;
            //GlobalthemeConfig.themeEscolas1 = ThemeEscolas.Claro;
            //GlobalthemeConfig.Theme(this);
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Opacity += 0.05;
            progressBar1.Increment(5);
            if (progressBar1.Value == 100)
            {

                timer1.Stop();

                var frm = new frmLogin();
                frm.Show();
                this.Hide();
            }
        }
    }
}