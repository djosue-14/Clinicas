using Clinicas.Extensions;
using Clinicas.Repository.EstadoConsulta;
using Clinicas.Validations.EstadoConsulta;
using Clinicas.ViewModels.EstadoConsulta;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinicas.Controllers
{
    public class EstadoConsultasController : Controller
    {
        private readonly EstadoConsulta estadoConsulta;
        private readonly JsonConfiguration jsonConfig;

        public EstadoConsultasController()
        {
            this.estadoConsulta = new EstadoConsulta();
            this.jsonConfig = new JsonConfiguration();
        }

        // GET: EstadoConsultas
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
            var jsonString = this.jsonConfig.Serialize(this.estadoConsulta.All());
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Devuelve solamente una consulta
        [HttpGet]
        public JsonResult One(int id)
        {
            var jsonString = this.jsonConfig.Serialize(this.estadoConsulta.One(id));

            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        //Almacena el paciente creado
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Store(EstadoConsultaVM model)
        {
            string jsonString;
            var estadoConsultaValidator = new EstadoConsultaValidator();
            ValidationResult estadoConsultaValidado = estadoConsultaValidator.Validate(model);

            if (!estadoConsultaValidado.IsValid)
            {
                return Json(new { success = false, responseText = estadoConsultaValidado.Errors }, JsonRequestBehavior.AllowGet);
            }

            jsonString = this.jsonConfig.Serialize(this.estadoConsulta.Store(model));
            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }

        //Devuelve el paciente editado
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(EstadoConsultaVM model)
        {
            string jsonString;
            var estadoConsultaValidator = new EstadoConsultaValidator();
            ValidationResult estadoConsultaValidado = estadoConsultaValidator.Validate(model);

            if (!estadoConsultaValidado.IsValid)
            {
                return Json(new { success = false, responseText = estadoConsultaValidado.Errors }, JsonRequestBehavior.AllowGet);
            }
            jsonString = this.jsonConfig.Serialize(this.estadoConsulta.Edit(model));
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
    }
}