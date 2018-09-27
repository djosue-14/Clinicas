using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinicas.ViewModels.CrecimientoPaciente;
using Clinicas.Extensions;
using Clinicas.Repository.CrecimientoPaciente;
using Clinicas.Repository.Consultas;
using Clinicas.Validations.CrecimientoPaciente;
using FluentValidation.Results;
using Clinicas.Extensions.Reports;
using Microsoft.Reporting.WebForms;
using Clinicas.Models;

namespace Clinicas.Controllers
{
    public class GraficasController : Controller
    {
        //public ClinicasEntities DB;
        private readonly CrecimientoPacientes crecimientoPaciente = new CrecimientoPacientes();
        private readonly JsonConfiguration jsonConfig = new JsonConfiguration();
        
        // GET: Graficas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Historial()
        {
            return View();
        }

        public JsonResult Store(CrecimientoPacienteVM model)
        {
            string jsonString;
            var crecimientoValidator = new CrecimientoPacienteValidator();
            ValidationResult crecimientoValidado = crecimientoValidator.Validate(model);

            if (!crecimientoValidado.IsValid)
            {
                return Json(new { success = false, responseText = crecimientoValidado.Errors }, JsonRequestBehavior.AllowGet);
            }

            jsonString = this.jsonConfig.Serialize(this.crecimientoPaciente.Store(model));
            return Json(jsonString, JsonRequestBehavior.AllowGet);

        }

        public JsonResult getHistorial(int id)
        {
            string jsonString = this.jsonConfig.Serialize(this.crecimientoPaciente.Prueba(id));
            return Json(jsonString, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetReport()
        {
            FormatReports report = new FormatReports("ReportPacientes.rdlc");

            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.AddRange(report.GlobalParameters());

            ReportDataSource data = new ReportDataSource("dtPacientes", new ClinicasEntities().uspReportePacientes());

            report.Report.DataSources.Add(data);

            report.Report.SetParameters(parameters);

            CustomFileReport file = report.GetFile();

            return File(file.renderedBytes, file.mimeType);
        }
    }
}