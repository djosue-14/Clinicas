using Clinicas.ViewModels.CrecimientoPaciente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.Validations.CrecimientoPaciente
{
    public class CrecimientoPacienteValidator: AbstractValidator<CrecimientoPacienteVM>
    {
        public CrecimientoPacienteValidator()
        {
            RuleFor(x => x.Peso).NotNull();
            RuleFor(x => x.Talla).NotNull();
            RuleFor(x => x.EdadActual).NotNull();
            RuleFor(x => x.ConsultaId).NotNull();
        }
    }
}