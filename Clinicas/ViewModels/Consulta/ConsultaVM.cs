using Clinicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.ViewModels.Consulta
{
    public class ConsultaVM
    {
        public int Id { get; set; }
        public string Titulo  { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioCreaId { get; set; }
        public int UsuarioAsignadoId { get; set; }
        public int PacienteId { get; set; }
        public int EstadoConsultaId { get; set; }

        public ICollection<Models.Paciente> Pacientes { get; set; }
        public ICollection<Models.EstadoConsulta> EstadoConsulta { get; set; }
    }
}