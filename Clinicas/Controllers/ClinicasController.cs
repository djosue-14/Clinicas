using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinicas.Extensions;
using Clinicas.Repository;
using Clinicas.Validations.Clinicas;
using Clinicas.ViewModels.Clinicas;
using FluentValidation.Results;

namespace Clinicas.Controllers
{
    public class ClinicasController : Controller
    {
        //referencia a la clase Clinicas del namespace Repository.Clinicas.Clinicas
        private readonly Repository.Clinicas.Clinicas clinica;
        //referencia a la clase JsonConfiguration del namespace Extensions
        private readonly JsonConfiguration jsonConfig;

        public ClinicasController()
        {
            this.clinica = new Repository.Clinicas.Clinicas();
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

        //Devuelve todas las clinicas
        [HttpGet]
        public JsonResult All()
        {
            var jsonString = this.jsonConfig.Serialize(this.clinica.All());
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Devuelve solamente una clinica
        [HttpGet]
        public JsonResult One(int id)
        {
            var jsonString = this.jsonConfig.Serialize(this.clinica.One(id));

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Devuelve la clinica insertada
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Store(ClinicasVM model)
        {
            string jsonString;
            var pacienteValidator = new ClinicasValidator();
            ValidationResult clinicaValidada = pacienteValidator.Validate(model);

            if (!clinicaValidada.IsValid)
            {
                return Json(new { success = false, responseText = clinicaValidada.Errors }, JsonRequestBehavior.AllowGet);
            }

            jsonString = this.jsonConfig.Serialize(this.clinica.Store(model));
            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }

        //Devuelve la clinica editada.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(ClinicasVM model)
        {
            string jsonString;
            var pacienteValidator = new ClinicasValidator();
            ValidationResult clinicaValidada = pacienteValidator.Validate(model);

            if (clinicaValidada.IsValid)
            {
                return Json(new { success = false, responseText = clinicaValidada.Errors }, JsonRequestBehavior.AllowGet);
            }
            jsonString = this.jsonConfig.Serialize(this.clinica.Edit(model));
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
    }
}