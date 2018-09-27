using Clinicas.Models;
using Clinicas.ViewModels.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinicas.Repository.Consultas
{
    public class Consulta: IConsulta
    {
        private ClinicasEntities DB;

        public Consulta()
        {
            this.DB = new ClinicasEntities();
        }
        public List<Models.Consulta> All()
        {
            return DB.Consulta.ToList();
        }

        public Models.Consulta Edit(ConsultaVM model)
        {
            var consulta = DB.Consulta.Find(model.Id);

            consulta.Titulo = model.Titulo;
            consulta.Inicio = model.Inicio;
            consulta.Fin = model.Fin;
            consulta.Descripcion = model.Descripcion;
            consulta.UsuarioCreaId = model.UsuarioCreaId;
            consulta.UsuarioAsignadoId = model.UsuarioAsignadoId;
            consulta.PacienteId = model.PacienteId;
            consulta.EstadoConsultaId = model.EstadoConsultaId;

            DB.SaveChanges();
            return consulta;
        }

        public Models.Consulta One(int id)
        {
            return DB.Consulta.Find(id);
        }

        public Models.Consulta Store(ConsultaVM model)
        {
            var estadoConsulta = DB.EstadoConsulta.Where(s => s.Estado == "Pendiente").FirstOrDefault<Models.EstadoConsulta>(); ;
            var consulta = new Models.Consulta()
            {
                Titulo = model.Titulo,
                Inicio = model.Inicio,
                Fin = model.Fin,
                Descripcion = model.Descripcion,
                UsuarioCreaId = model.UsuarioCreaId,
                UsuarioAsignadoId = 1,//Cambiar esto
                PacienteId = model.PacienteId,
                EstadoConsultaId = estadoConsulta.Id,
            };
            DB.Consulta.Add(consulta);
            DB.SaveChanges();
            return consulta;
        }
    }
}