using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinicas.Models;
using Clinicas.ViewModels.Clinicas;

namespace Clinicas.Repository.Clinicas
{
    interface IClinicas
    {
        List<Clinica> All();
        object One(int id);
        Clinica Store(ClinicasVM model);
        Clinica Edit(ClinicasVM model);
    }
}
