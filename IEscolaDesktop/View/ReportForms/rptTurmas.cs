using DevExpress.XtraReports.UI;
using IEscolaEntity.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace IEscolaDesktop.View.ReportForms
{
    public partial class rptTurmas : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTurmas(List<Turmas> turmas)
        {
            InitializeComponent();

            DataSource = turmas;
        }

        private void Detail_BeforePrint(object sender, CancelEventArgs e)
        {

        }
    }
}
