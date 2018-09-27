using Clinicas.ViewModels.Consulta;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.Validations.Consulta
{
    public class ConsultaValidator: AbstractValidator<ConsultaVM>
    {
        //Reglas de validación para los datos de consulta.
        public ConsultaValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty().Length(3, 30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.Inicio).NotNull();
            RuleFor(x => x.Fin).NotNull();
            RuleFor(x => x.Descripcion).NotNull().Length(3, 30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.UsuarioCreaId).NotNull();
            RuleFor(x => x.UsuarioAsignadoId).NotNull();
            RuleFor(x => x.PacienteId).NotNull();
            RuleFor(x => x.EstadoConsultaId).NotNull();
        }
    }
}