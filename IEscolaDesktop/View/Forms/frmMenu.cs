using IEscolaEntity.Models;
using System;
using System.Windows.Forms;

namespace IEscolaDesktop.View.Forms
{
    public partial class frmMenu : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMenu(Permission permission)
        {
            InitializeComponent();

            ActivarBotoes(permission);

            //Metodos 
            this.FormClosing += FrmMenu_FormClosing;
        }

        private void ActivarBotoes(Permission permission)
        {
            
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForms();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                CloseForms();

                bool res = base.ProcessCmdKey(ref msg, keyData);
                return res;
            }
            return false;
        }

        public void CloseForms()
        {
            foreach (Form item in Application.OpenForms)
            {
                if (item.Name == (typeof(frmLogin)).Name)
                {
                    item.Show();
                }
            }
        }


    }
}