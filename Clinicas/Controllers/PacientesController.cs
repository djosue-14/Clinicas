using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinicas.Extensions;
using Clinicas.Models;
using Clinicas.Repository.Paciente;
using Clinicas.Validations.Paciente;
using Clinicas.ViewModels.Paciente;
using FluentValidation.Results;

namespace Clinicas.Controllers
{
    public class PacientesController : Controller
    {
        //referencia a la clase Paciente del namespace Repository.Paciente
        private readonly Repository.Paciente.Paciente paciente;
        //referencia a la clase JsonConfiguration del namespace Extensions
        private readonly JsonConfiguration jsonConfig;

        public PacientesController() {
            this.paciente = new Repository.Paciente.Paciente();
            this.jsonConfig = new JsonConfiguration();
        }

        // GET: Vista
        public ActionResult Index()
        {
            return View();
        }

        /*
         * Todos los metodos devuelven un objeto json.
         */

        //Devuelve todos los pacientes
        [HttpGet]
        public JsonResult All()
        {
            var jsonString = this.jsonConfig.Serialize(this.paciente.All());
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Devuelve solamente un paciente
        [HttpGet]
        public JsonResult One(int id) {
            var jsonString = this.jsonConfig.Serialize(this.paciente.One(id));

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Devuelve el paciente insertado
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Store(PacienteVM paciente)
        {
            string jsonString;
            var pacienteValidator = new PacienteCreateValidator();
            ValidationResult pacienteValidado = pacienteValidator.Validate(paciente);

            if (!pacienteValidado.IsValid)
            {
                return Json(new { success = false, responseText = pacienteValidado.Errors }, JsonRequestBehavior.AllowGet);
            }

            jsonString = this.jsonConfig.Serialize(this.paciente.Store(paciente));
            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }

        //Devuelve el paciente editado
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(PacienteVM paciente)
        {
            string jsonString;
            var pacienteValidator = new PacienteEditValidator();
            ValidationResult pacienteValidado = pacienteValidator.Validate(paciente);

            if (pacienteValidado.IsValid)
            {
                return Json(new { success = false, responseText = pacienteValidado.Errors }, JsonRequestBehavior.AllowGet);
            }
            jsonString = this.jsonConfig.Serialize(this.paciente.Edit(paciente));
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
    }
}