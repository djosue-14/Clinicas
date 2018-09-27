using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clinicas.Models;
using Clinicas.ViewModels.CrecimientoPaciente;

namespace Clinicas.Repository.CrecimientoPaciente
{
    public class CrecimientoPacientes : ICrecimientoPaciente
    {
        private ClinicasEntities DB = new ClinicasEntities();

        public object Prueba(int id)
        {
            var historial = DB.CrecimientoPaciente.Select(x => new {
                x.EdadActual,
                x.Peso,
                x.Talla,
                Consulta = new
                {
                    Paciente = new
                    {
                        x.Consulta.Paciente.Id,
                        x.Consulta.Paciente.PrimerNombre,
                        x.Consulta.Paciente.PrimerApellido,
                        Sexo = new
                        {
                            x.Consulta.Paciente.Sexo.Tipo
                        }
                    }
                }
            }).Where(x => x.Consulta.Paciente.Id == id);

            return historial;
        }



        public Models.CrecimientoPaciente Store(CrecimientoPacienteVM model)
        {
            
            var crecimientoPaciente = new Models.CrecimientoPaciente()
            {
                Peso = model.Peso,
                Talla = model.Talla,
                EdadActual = model.EdadActual,
                ConsultaId = model.ConsultaId,
            };

            DB.CrecimientoPaciente.Add(crecimientoPaciente);
            DB.SaveChanges();
            return crecimientoPaciente;
        }
    }
}