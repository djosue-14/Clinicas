using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.Repository.TipoSangre
{
    interface ITipoSangre
    {
        List<Models.TipoSangre> All();
    }
}