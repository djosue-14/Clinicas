using Clinicas.ViewModels.EstadoConsulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinicas.Repository.EstadoConsulta
{
    interface IEstadoConsulta
    {
        List<Models.EstadoConsulta> All();

        Models.EstadoConsulta One(int id);

        Models.EstadoConsulta Store(EstadoConsultaVM model);
        Models.EstadoConsulta Edit(EstadoConsultaVM model);
    }
}
