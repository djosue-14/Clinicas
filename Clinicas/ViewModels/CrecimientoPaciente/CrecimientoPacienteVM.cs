using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.ViewModels.CrecimientoPaciente
{
    public class CrecimientoPacienteVM
    {
        public int Id { get; set; }
        public decimal Peso { get; set; }
        public decimal Talla { get; set; }
        public int EdadActual { get; set; }
        public int ConsultaId { get; set; }
    }
}