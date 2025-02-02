using DevExpress.XtraReports.UI;
using IEscolaEntity.Models.Biblioteca;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace IEscolaDesktop.View.ReportForms
{
    public partial class rptLivros : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLivros(List<Livros> livros)
        {
            InitializeComponent();

            DataSource = livros;
        }

    }
}
