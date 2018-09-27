using Microsoft.Reporting.WebForms;
using System;
using System.IO;
using System.Web;
using System.Linq;
using System.Collections.Generic;

namespace Clinicas.Extensions.Reports
{

    public enum EReportType
    {
        PDF,
        EXCEL,
        WORD
    }

    public enum EFormatPaper
    {
        Carta,
        CartaHorizontal,
        Oficio,
        OficioHorizontal
    }

    public class FormatReports
    {

        public LocalReport Report = new LocalReport(); // reporte a generar 
        private readonly string reportType; // formato del reporte con valor pdf default                
        private readonly string deviceInfo; // Tamaño de papel
        private PaperFormatReport PaperFormat = new PaperFormatReport();

        public FormatReports(string nameReportFile, EReportType reportType = EReportType.PDF, EFormatPaper formatPaper = EFormatPaper.Carta, string mapPath = "~/Reports")
        {

            Report.ReportPath = Path.Combine(HttpContext.Current.Server.MapPath(mapPath), nameReportFile);
            Report.EnableExternalImages = true;

            switch (reportType)
            {
                case EReportType.PDF:
                    this.reportType = "pdf";
                    break;
                case EReportType.EXCEL:
                    this.reportType = "excel";
                    break;
                case EReportType.WORD:
                    this.reportType = "word";
                    break;
            }

            // Agregar aquí opciones de hoja, devuelve carta al enviar un dato invalido
            switch (formatPaper)
            {
                case EFormatPaper.Carta:
                    deviceInfo = PaperFormat.Carta();
                    break;
                case EFormatPaper.CartaHorizontal:
                    deviceInfo = PaperFormat.CartaHorizontal();
                    break;
                case EFormatPaper.Oficio:
                    deviceInfo = PaperFormat.Oficio();
                    break;
                case EFormatPaper.OficioHorizontal:
                    deviceInfo = PaperFormat.OficioHorizontal();
                    break;
            }

        }



        // Retorna la instancia de la clase CustomFileReport con los datos del reporte generado
        public CustomFileReport GetFile()
        {
            CustomFileReport customFile = new CustomFileReport();
            customFile.renderedBytes = Report.Render
                (
                reportType,
                deviceInfo,
                out customFile.mimeType,
                out customFile.encoding,
                out customFile.fileNameExtension,
                out customFile.streams,
                out customFile.warnings
            );
            return customFile;
        }

        public ReportParameter[] GlobalParameters(string logo = "logo.png")
        {
            ReportParameter[] global = new ReportParameter[]
            {
                new ReportParameter("logo", new Uri(HttpContext.Current.Server.MapPath("~/Images/"+logo)).AbsoluteUri)
            };

            return global;
        }
    }
}