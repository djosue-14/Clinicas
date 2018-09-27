using Clinicas.ViewModels.EstadoConsulta;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.Validations.EstadoConsulta
{
    public class EstadoConsultaValidator: AbstractValidator<EstadoConsultaVM>
    {
        public EstadoConsultaValidator()
        {
            RuleFor(x => x.Estado).NotNull().NotEmpty().Length(5, 15);
        }
    }
}