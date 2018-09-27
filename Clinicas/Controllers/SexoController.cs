using Clinicas.Extensions;
using Clinicas.Repository.Sexo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinicas.Controllers
{
    public class SexoController : Controller
    {
        //referencia a la clase Paciente del namespace Repository.Paciente
        private readonly Sexo sexo;
        //referencia a la clase JsonConfiguration del namespace Extensions
        private readonly JsonConfiguration jsonConfig;

        public SexoController()
        {
            this.sexo = new Sexo();
            this.jsonConfig = new JsonConfiguration();
        }

        // GET: Sexo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult All()
        {
            var jsonString = this.jsonConfig.Serialize(this.sexo.All());
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
    }
}