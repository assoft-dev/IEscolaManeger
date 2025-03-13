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

            labelCopyright.Text = string.Format("Copyright: {0} ASINFORPREST", DateTime.Now.Year);
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

            switch (Opacity)
            {
                case 0.5:
                    labelStatus.Text = "Inicial...";
                    break;
                    case 0.7:
                    labelStatus.Text = "Leitura dos Modulos";
                    break;
                default:
                    labelStatus.Text = "Concluindo leituras";
                    break;
            }

            if (Opacity == 1.00)
            {
                labelStatus.Text = "Concluido!...";
                timer1.Stop();
                var frm = new frmLogin1();
                frm.Show();
                this.Hide();
            }
        }
    }
}