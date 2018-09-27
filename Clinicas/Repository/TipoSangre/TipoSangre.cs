using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinicas.Models;

namespace Clinicas.Repository.TipoSangre
{
    public class TipoSangre : ITipoSangre
    {
        private ClinicasEntities DB;

        public TipoSangre()
        {
            this.DB = new ClinicasEntities();
        }
        public List<Models.TipoSangre> All()
        {
            return DB.TipoSangre.ToList();
        }
    }
}