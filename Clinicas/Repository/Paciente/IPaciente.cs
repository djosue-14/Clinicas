using Clinicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinicas.ViewModels.Paciente;

namespace Clinicas.Repository.Paciente
{
    interface IPaciente
    {
        List<Models.Paciente> All();
        Models.Paciente One(int id);
        Models.Paciente Store(PacienteVM paciente);
        Models.Paciente Edit(PacienteVM paciente);
    }
}
