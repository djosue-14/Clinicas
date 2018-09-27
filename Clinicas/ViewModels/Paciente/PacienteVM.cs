using Clinicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.ViewModels.Paciente
{
    public class PacienteVM
    {
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string CodigoPaciente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Ocupacion { get; set; }
        public int TipoSangreId { get; set; }
        public int SexoId { get; set; }
        //public virtual ICollection<EncargadoPaciente> EncargadoPaciente { get; set; }
        public ICollection<TipoSangre> TipoSangre { get; set; }
        //public virtual ICollection<Consultas> Consultas { get; set; }
        public ICollection<Sexo> Sexo { get; set; }
    }
}