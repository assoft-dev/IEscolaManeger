using DevExpress.XtraReports.UI;
using IEscolaEntity.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace IEscolaDesktop.View.ReportForms
{
    public partial class rptEstudantesInscritos : DevExpress.XtraReports.UI.XtraReport
    {
        public rptEstudantesInscritos(List<EstudantesInscricoes> estudantesInscricoes)
        {
            InitializeComponent();
            DataSource = estudantesInscricoes;
        }

    }
}
