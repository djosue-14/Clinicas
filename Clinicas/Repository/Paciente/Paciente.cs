using Clinicas.Models;
using Clinicas.ViewModels.Paciente;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clinicas.Repository.Paciente
{
    public class Paciente : IPaciente
    {
        private ClinicasEntities DB;

        public Paciente() {
            DB = new ClinicasEntities();
        }

        public List<Models.Paciente> All()
        {
            var paciente = DB.Paciente.Include(x => x.TipoSangre).Include(x => x.Sexo).ToList();
            return paciente;
        }

        public Models.Paciente One(int id)
        {
            return DB.Paciente.Find(id);
        }

        public Models.Paciente Store(PacienteVM model)
        {
            var paciente = new Models.Paciente() {
                PrimerNombre = model.PrimerNombre,
                SegundoNombre = model.SegundoNombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
                CodigoPaciente = "",
                FechaNacimiento = model.FechaNacimiento,
                Ocupacion = model.Ocupacion,
                TipoSangreId = model.TipoSangreId,
                SexoId = model.SexoId,
            };
            DB.Paciente.Add(paciente);
            DB.SaveChanges();
            return paciente;
        }
        
        public Models.Paciente Edit(PacienteVM model) {
            var paciente = DB.Paciente.Find(model.Id);

            paciente.PrimerNombre = model.PrimerNombre;
            paciente.SegundoNombre = model.SegundoNombre;
            paciente.PrimerApellido = model.PrimerApellido;
            paciente.SegundoApellido = model.SegundoApellido;
            paciente.Direccion = model.Direccion;
            paciente.Telefono = model.Telefono;
            paciente.CodigoPaciente = model.CodigoPaciente;
            paciente.FechaNacimiento = model.FechaNacimiento;
            paciente.Ocupacion = model.Ocupacion;
            paciente.TipoSangreId = model.TipoSangreId;

            DB.SaveChanges();
            return paciente;
        }
    }
}