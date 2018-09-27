using Clinicas.ViewModels.CrecimientoPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.Repository.CrecimientoPaciente
{
    public interface ICrecimientoPaciente
    {
        Models.CrecimientoPaciente Store(CrecimientoPacienteVM model);
    }
}