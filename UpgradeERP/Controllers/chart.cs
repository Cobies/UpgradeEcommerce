using Microsoft.AspNetCore.Mvc;

namespace UpgradeERP.Controllers
{
    public class chart : Controller
    {
        public IActionResult Chart()
        {
            return View();
        }
    }
}
