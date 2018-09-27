using Microsoft.Reporting.WebForms;


namespace Clinicas.Extensions.Reports
{
    public class CustomFileReport
    {
        public byte[] renderedBytes;
        public string mimeType;
        public string encoding;
        public string fileNameExtension;
        public string[] streams;
        public Warning[] warnings;
    }
}