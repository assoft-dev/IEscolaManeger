using DevExpress.XtraReports.UI;
using IEscolaEntity.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace IEscolaDesktop.View.ReportForms
{
    public partial class rptProfessores1 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptProfessores1(List<Professores> ts)
        {
            InitializeComponent();

            DataSource = ts;
        }

    }
}
