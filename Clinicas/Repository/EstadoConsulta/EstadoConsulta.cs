using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinicas.Models;
using Clinicas.ViewModels.EstadoConsulta;

namespace Clinicas.Repository.EstadoConsulta
{
    public class EstadoConsulta : IEstadoConsulta
    {
        private ClinicasEntities DB;
        public EstadoConsulta()
        {
            this.DB = new ClinicasEntities();
        }
        public List<Models.EstadoConsulta> All()
        {
            return DB.EstadoConsulta.ToList();
        }

        public Models.EstadoConsulta Edit(EstadoConsultaVM model)
        {
            var estadoConsulta = DB.EstadoConsulta.Find(model.Id);
            estadoConsulta.Estado = model.Estado;
            DB.SaveChanges();
            return estadoConsulta;
        }

        public Models.EstadoConsulta One(int id)
        {
            return DB.EstadoConsulta.Find(id);
        }

        public Models.EstadoConsulta Store(EstadoConsultaVM model)
        {
            var estadoConsulta = new Models.EstadoConsulta()
            {
                Id = model.Id,
                Estado = model.Estado,
            };

            DB.EstadoConsulta.Add(estadoConsulta);
            DB.SaveChanges();
            return estadoConsulta;
        }
    }
}