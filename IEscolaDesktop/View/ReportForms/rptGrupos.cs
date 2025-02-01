using DevExpress.XtraReports.UI;
using IEscolaEntity.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace IEscolaDesktop.View.ReportForms
{
    public partial class rptGrupos : DevExpress.XtraReports.UI.XtraReport
    {
        public rptGrupos(List<Grupos> grupos)
        {
            InitializeComponent();

            DataSource = grupos;
        }

    }
}
