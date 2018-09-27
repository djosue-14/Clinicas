using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinicas.Models;

namespace Clinicas.Repository.Sexo
{
    public class Sexo : ISexo
    {
        private ClinicasEntities DB;
        public Sexo() {
            this.DB = new ClinicasEntities();
        }
        public List<Models.Sexo> All()
        {
            return DB.Sexo.ToList();
        }
    }
}