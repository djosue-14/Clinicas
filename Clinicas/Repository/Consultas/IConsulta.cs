using Clinicas.Models;
using Clinicas.ViewModels.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinicas.Repository.Consultas
{
    interface IConsulta
    {
        List<Models.Consulta> All();

        Models.Consulta One(int id);

        Models.Consulta Store(ConsultaVM model);

        Models.Consulta Edit(ConsultaVM model);
    }
}
