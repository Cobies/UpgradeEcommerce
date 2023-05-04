using Microsoft.AspNetCore.Mvc;
using UpgradeERP.Models.Personas;
using UpgradeERP.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace UpgradeERP.Controllers
{
    public class SessionsController : Controller
    {
        private readonly ILogger<SessionsController> _logger;
        private readonly Consultas consultas;
        private readonly Encrypt encrypt;

        public SessionsController(ILogger<SessionsController> logger, Consultas consultas, Encrypt encrypt)
        {
            _logger = logger;
            this.consultas = consultas;
            this.encrypt = encrypt;
        }

        
        public async Task<IActionResult> Login()
        {
            try
            {
                var usu = JsonConvert.DeserializeObject<Empleado>(HttpContext.Session.GetString("usuario"));
                
                    return RedirectToAction("Index", "Home");
                


            }
            catch(Exception ex)
            {
                return View();

                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(string usuario, string password)
        {
            try
            {
                var pass = await encrypt.GetSHA256(password);
                var usu = await consultas.GetEmpleadoForUsuarioAndPassword(usuario.ToUpper(), pass);
                if(usu != null)
                {
                    var empleado = EmpleadoSesion(usu);
                    
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    return RedirectToAction("Login", "Sessions");
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        private async Task<Empleado> EmpleadoSesion(Empleado usu)
        {
            try
            {
                if(usu != null)
                {

                    HttpContext.Session.SetString("usuario", JsonConvert.SerializeObject(usu));
                    return JsonConvert.DeserializeObject<Empleado>(HttpContext.Session.GetString("usuario"));
                }
                else
                {
                    return null;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}
