using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Drawing.Text;
using UpgradeERP.Models;
using UpgradeERP.Models.Personas;

namespace UpgradeERP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string codigo()
        {
            try
            {
                string codigsss = "ddadbaafbadfbbdfa";
                return JsonConvert.SerializeObject(codigsss);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Index()
        {
            try {
                var usu = JsonConvert.DeserializeObject<Empleado>(HttpContext.Session.GetString("usuario"));
                return View();
            }catch(Exception ex)
            {
                return RedirectToAction("Login", "Sessions");
                throw ex;
            }
        }

        public IActionResult Privacy()
        {



            return View();

            

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}