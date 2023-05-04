using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class PdfController : Controller
    {
        private readonly Consultas consultas;

        public PdfController(Consultas consultas)
        {
            this.consultas = consultas;
        }

        [HttpGet]
        public async Task<IActionResult> ReporteTecnico(string id)
        {

            var report = await consultas.GetReporteTecnicoId(id);
            return new ViewAsPdf(report)
            {
                PageSize = Size.A4,
                PageOrientation = Orientation.Landscape,
                PageMargins = new Margins(1, 1, 1, 1),
            };
        }

        public async Task<IActionResult> ReporteGarantia(string id)
        {
            var report = await consultas.GetReporteGarantiaId(id);
            return new ViewAsPdf(report)
            {
                PageSize = Size.A4,
                PageOrientation = Orientation.Landscape,
                PageMargins = new Margins(1, 1, 1, 1),
            };
        }

        public IActionResult PdfPrueba()
        {

            return new ViewAsPdf();
        }
    }
}
