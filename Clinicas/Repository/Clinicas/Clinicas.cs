using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinicas.Models;
using Clinicas.ViewModels.Clinicas;

namespace Clinicas.Repository.Clinicas
{
    public class Clinicas : IClinicas
    {
        private ClinicasEntities DB = new ClinicasEntities();
        public List<Clinica> All()
        {
            return DB.Clinica.ToList();
        }

        public Clinica Edit(ClinicasVM model)
        {
            var clinica = DB.Clinica.Find(model.Id);

            clinica.Nombre = model.Nombre;
            clinica.Nit = model.Nit;
            clinica.Direccion = model.Direccion;
            clinica.CodigoPostal = model.CodigoPostal;
            clinica.Referencia = model.Referencia;
            clinica.Telefono = model.Telefono;
            clinica.Logo = model.Logo;
            clinica.CuentaId = model.CuentaId;

            DB.SaveChanges();
            return clinica;
        }

        public object One(int id)
        {
            var clinica = DB.Clinica.Select(x => new {
                x.Id,
                x.Nombre,
                x.Nit,
                x.Direccion,
                x.CodigoPostal,
                x.Referencia,
                x.Telefono,
                x.Logo,
                x.CuentaId
            }).Where(x => x.Id == id);

            return clinica;
        }

        public Clinica Store(ClinicasVM model)
        {
            var clinica = new Clinica()
            {
                Nombre = model.Nombre,
                Nit = model.Nit,
                Direccion = model.Direccion,
                CodigoPostal = model.CodigoPostal,
                Referencia = model.Referencia,
                Telefono = model.Telefono,
                Logo = model.Logo,
                CuentaId = model.CuentaId
            };
            DB.Clinica.Add(clinica);
            DB.SaveChanges();
            return clinica;
        }
    }
}