using Clinicas.ViewModels.Paciente;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.Validations.Paciente
{
    public class PacienteCreateValidator: AbstractValidator<PacienteVM>
    {
        public PacienteCreateValidator()
        {
            RuleFor(x => x.PrimerNombre).NotNull().NotEmpty().Length(3,30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.SegundoNombre).Length(3, 30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.PrimerApellido).NotNull().NotEmpty().Length(3, 30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.SegundoApellido).Length(3, 30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.Direccion).Length(3, 30);
            RuleFor(x => x.Telefono).NotNull();
            //RuleFor(x => x.CodigoPaciente).NotEmpty();
            //RuleFor(x => x.FechaNacimiento).NotEmpty();
            RuleFor(x => x.Ocupacion).Length(5,30).Matches(@"^[A-Za-z]+$");
            RuleFor(x => x.TipoSangreId).NotNull();
            RuleFor(x => x.SexoId).NotNull();
        }
    }

    public class PacienteEditValidator : AbstractValidator<PacienteVM>
    {
        public PacienteEditValidator()
        {
            RuleFor(x => x.PrimerNombre).NotNull().NotEmpty().Length(3, 30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.SegundoNombre).Length(3, 30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.PrimerApellido).NotNull().NotEmpty().Length(3, 30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.SegundoApellido).Length(3, 30).Matches(@"^[A-Za-z ]+$");
            RuleFor(x => x.Direccion).NotNull().Length(3, 30);
            RuleFor(x => x.Telefono).NotNull();
            RuleFor(x => x.CodigoPaciente).NotNull();
            RuleFor(x => x.FechaNacimiento).NotNull();
            RuleFor(x => x.Ocupacion).NotNull().Length(3, 30).Matches(@"^[A-Za-z]+$");
            RuleFor(x => x.TipoSangreId).NotNull();
            RuleFor(x => x.SexoId).NotNull();
        }
    }
}