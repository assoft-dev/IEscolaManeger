namespace IEscolaDesktop.View.Helps
{
    using DevExpress.XtraReports.UI;
    using System;
    using System.Drawing.Printing;
    using System.Windows.Forms;

    public static class GlobalReport
    {
        private static XtraReport xtraReport { get; set; }
        private static ReportPrintTool ReportPrintTool { get; set; }
        private static PrinterSettings settings { get; set; }

        public static void GetReport(XtraReport report, bool inprimirDirecto = false, string Impressora = "", int Copy = 1)
        {
            if (report == null)
                report = new XtraReport();

            report.ShowPrintMarginsWarning = false;
            xtraReport = report;
            report.CreateDocument();

            ReportPrintTool = new ReportPrintTool(xtraReport);
            xtraReport.ShowPrintMarginsWarning = false;

            ReportPrintTool.PreviewForm.FormClosing += PreviewForm_FormClosing;

            if (!inprimirDirecto)
                ReportPrintTool.ShowPreview();
            else
            {
                if (string.IsNullOrWhiteSpace(Impressora))
                {
                    #region Prints
                    // MessageBox.Show("Lamentamos Mais tens que configurar a Impressora Antes de Começares a Fazer Vendas!...\n" +
                    //"Mais neste caso vamos imprimir na impressora definida como Padrão", "Configuração Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // ReportPrintTool.ShowPreview();
                    #endregion

                    settings = new PrinterSettings();
                    ReportPrintTool.Print(settings.PrinterName);
                }
                else
                {
                    if (Copy != 1)
                    {
                        while (Copy != 0)
                        {
                            ReportPrintTool.Print(Impressora);
                            Copy--;
                        }
                    }
                    else
                        ReportPrintTool.Print(Impressora);
                }
            }
        }

        private static void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xtraReport != null)
                xtraReport.Dispose();
        }
    }
    public class ReportDisposed : IDisposable
    {
        public XtraReport xtraReport { get; set; }
        public ReportPrintTool reportPrintTool { get; set; }
        public void GetReport(XtraReport report, string Impressora, int Copias)
        {
            if (report == null)
                report = new XtraReport();

            report.ShowPrintMarginsWarning = false;
            xtraReport = report;
            report.CreateDocument();

            reportPrintTool = new ReportPrintTool(xtraReport);
            xtraReport.ShowPrintMarginsWarning = false;

            if (Impressora != "")
            {
                while (Copias != 0)
                {
                    //ReportPrintTool.MA
                    reportPrintTool.Print(Impressora);
                    Copias--;
                }
            }
            else
            {
                MessageBox.Show("Lamentamos Mais tens que configurar a Impressora Antes de Começares a Fazer Vendas!...\nMais neste caso vamos imprimir na impressora definida como Padrão");
                while (Copias != 0)
                {
                    //ReportPrintTool.MA
                    reportPrintTool.Print();
                    Copias--;
                }
            }
        }
        public void GetReport(XtraReport report, string Impressora)
        {
            if (report == null)
                report = new XtraReport();

            report.ShowPrintMarginsWarning = false;
            xtraReport = report;
            report.CreateDocument();

            reportPrintTool = new ReportPrintTool(xtraReport);
            xtraReport.ShowPrintMarginsWarning = false;

            if (Impressora != "")
                reportPrintTool.Print(Impressora);
            else
                MessageBox.Show("Lamentamos Mais tens que configurar a Impressora Antes de Começares a Fazer Vendas!...\n" +
                    "Mais neste caso vamos imprimir na impressora definida como Padrão", "Configuração Requerida", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void GetReport(XtraReport report, string extensoes, string Caminho)
        {
            if (report == null)
                report = new XtraReport();

            xtraReport = report;
            report.CreateDocument();

            if (extensoes.Contains(".pdf") || extensoes.Contains(".PDF"))
                report.ExportToPdf(Caminho);
            else if (extensoes.Contains(".xls") || extensoes.Contains(".XLS"))
                report.ExportToXlsx(Caminho);
            else
                report.ExportToDocx(Caminho);
        }
        public void Dispose()
        {
            if (reportPrintTool != null)
                reportPrintTool.Dispose();
            xtraReport?.Dispose();
        }
    }
}
