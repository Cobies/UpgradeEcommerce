using Microsoft.AspNetCore.Mvc;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly ILogger<VendedoresController> _logger;
        private readonly Consultas consultas;

        public VendedoresController(ILogger<VendedoresController> logger, Consultas consultas)
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
