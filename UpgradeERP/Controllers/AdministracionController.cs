using Microsoft.AspNetCore.Mvc;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class AdministracionController : Controller
    {
        private readonly ILogger<AdministracionController> _logger;
        private readonly Consultas consultas;

        public AdministracionController(ILogger<AdministracionController> logger, Consultas consultas)
        {
            _logger = logger;
            this.consultas = consultas;
        }

        public IActionResult Index()
        {
            return View();

        }
    }
}
