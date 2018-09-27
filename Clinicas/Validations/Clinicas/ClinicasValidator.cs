using Clinicas.ViewModels.Clinicas;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.Validations.Clinicas
{
    public class ClinicasValidator: AbstractValidator<ClinicasVM>
    {
        public ClinicasValidator()
        {

        }
    }
}