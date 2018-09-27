using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.ViewModels.Clinicas
{
    public class ClinicasVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
        public int CodigoPostal { get; set; }
        public string Referencia { get; set; }
        public int Telefono { get; set; }
        public string Logo { get; set; }
        public int CuentaId { get; set; }
    }
}