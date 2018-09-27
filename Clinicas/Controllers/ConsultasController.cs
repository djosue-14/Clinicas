using Clinicas.Extensions;
using Clinicas.Repository.Consultas;
using Clinicas.Validations.Consulta;
using Clinicas.ViewModels.Consulta;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinicas.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly Consulta consulta;
        //referencia a la clase JsonConfiguration del namespace Extensions
        private readonly JsonConfiguration jsonConfig;

        public ConsultasController()
        {
            this.consulta = new Consulta();
            this.jsonConfig = new JsonConfiguration();
        }

        // GET: Consulta
        public ActionResult Index()
        {
            return View();
        }

        /*
         * Todos los metodos devuelven un objeto json.
         */
        [HttpGet]
        public JsonResult All()
        {
            var jsonString = this.jsonConfig.Serialize(this.consulta.All());
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Devuelve solamente una consulta
        [HttpGet]
        public JsonResult One(int id)
        {
            var jsonString = this.jsonConfig.Serialize(this.consulta.One(id));

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Almacena el paciente creado
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Store(ConsultaVM model)
        {
            string jsonString;
            var consultaValidator = new ConsultaValidator();
            ValidationResult consultaValidada = consultaValidator.Validate(model);

            if (!consultaValidada.IsValid)
            {
                return Json(new { success = false, responseText = consultaValidada.Errors }, JsonRequestBehavior.AllowGet);
            }

            jsonString = this.jsonConfig.Serialize(this.consulta.Store(model));
            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }

        //Devuelve el paciente editado
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(ConsultaVM model)
        {
            string jsonString;
            var consultaValidator = new ConsultaValidator();
            ValidationResult consultaValidada = consultaValidator.Validate(model);

            if (!consultaValidada.IsValid)
            {
                return Json(new { success = false, responseText = consultaValidada.Errors }, JsonRequestBehavior.AllowGet);
            }
            jsonString = this.jsonConfig.Serialize(this.consulta.Edit(model));
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
    }
}