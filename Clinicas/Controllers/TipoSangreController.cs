using Clinicas.Extensions;
using Clinicas.Repository.TipoSangre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clinicas.Controllers
{
    public class TipoSangreController : Controller
    {
        //referencia a la clase Paciente del namespace Repository.Paciente
        private readonly TipoSangre tipoSangre;
        //referencia a la clase JsonConfiguration del namespace Extensions
        private readonly JsonConfiguration jsonConfig;

        public TipoSangreController()
        {
            this.tipoSangre = new TipoSangre();
            this.jsonConfig = new JsonConfiguration();
        }

        // GET: TipoSangre
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult All()
        {
            var jsonString = this.jsonConfig.Serialize(this.tipoSangre.All());
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }
    }
}