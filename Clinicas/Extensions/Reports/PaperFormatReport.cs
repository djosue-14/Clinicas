

namespace Clinicas.Extensions.Reports
{
    public class PaperFormatReport
    {
        /* Formatos de hoja */
        public string Carta()
        {

            return "<DeviceInfo>" +
                    "<PageWidth>8.5in</PageWidth>" +
                    "<PageHeight>11in</PageHeight>" +
                    "<MarginTop>0.3in</MarginTop>" +
                    "<MarginBottom>0.3in</MarginBottom>" +
                    "<MarginLeft>0.3in</MarginLeft>" +
                    "<MarginRight>0.3in</MarginRight>" +
                    "</DeviceInfo>";
        }

        /* Formatos de hoja */
        public string CartaHorizontal()
        {

            return "<DeviceInfo>" +
                    "<PageWidth>11in</PageWidth>" +
                    "<PageHeight>8.5in</PageHeight>" +
                    "<MarginTop>0.3in</MarginTop>" +
                    "<MarginBottom>0.3in</MarginBottom>" +
                    "<MarginLeft>0.3in</MarginLeft>" +
                    "<MarginRight>0.3in</MarginRight>" +
                    "</DeviceInfo>";
        }


        /* Formatos de hoja */
        public string OficioHorizontal()
        {

            return "<DeviceInfo>" +
                    "<PageWidth>13in</PageWidth>" +
                    "<PageHeight>8.5in</PageHeight>" +
                    "<MarginTop>0.3in</MarginTop>" +
                    "<MarginBottom>0.3in</MarginBottom>" +
                    "<MarginLeft>0.3in</MarginLeft>" +
                    "<MarginRight>0.3in</MarginRight>" +
                    "</DeviceInfo>";
        }

        /* Formatos de hoja */
        public string Oficio()
        {

            return "<DeviceInfo>" +
                    "<PageWidth>8.5in</PageWidth>" +
                    "<PageHeight>13in</PageHeight>" +
                    "<MarginTop>0.3in</MarginTop>" +
                    "<MarginBottom>0.3in</MarginBottom>" +
                    "<MarginLeft>0.3in</MarginLeft>" +
                    "<MarginRight>0.3in</MarginRight>" +
                    "</DeviceInfo>";
        }

    }
}