using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using UpgradeERP.Models.Personas;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly ConexionSunat conexsunat;
        private readonly Consultas consultas;
        private ISession session;
        public UsuariosController(ILogger<UsuariosController> logger, Consultas consultas, ConexionSunat conexsunat)
        {
            _logger = logger;
            this.consultas = consultas;
            this.conexsunat = conexsunat;
        }

        public async Task<IActionResult> Usuarios()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IdentificarDocumento(string tipodocumento, string documento)
        {
            try
            {
                if (tipodocumento != null && documento != null)
                {
                    if (tipodocumento == "63b5a2e3ca0c1153c0a9cccd")
                    {
                        var dni = await conexsunat.ObtenerDNI(documento);
                        return JsonConvert.SerializeObject(dni);
                    }
                    else if (tipodocumento == "63b5a2e3ca0c1153c0a9cccf")
                    {
                        var ruc = await conexsunat.ObtenerRUC(documento);
                        return JsonConvert.SerializeObject(ruc);
                    }
                }
                return "400";
            }
            catch (Exception ex)
            {
                return "400";
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> Perosnapordni(string dni)
        {

            var dnerso = conexsunat.ObtenerDNI(dni);
            return JsonConvert.SerializeObject(dnerso);
        }
        [HttpPost]
        public async Task<string> Perosnaporruc(string ruc)
        {
            var dnerso = conexsunat.ObtenerRUC(ruc);
            return JsonConvert.SerializeObject(dnerso);
        }

        [HttpPost]
        public async Task<string> BusquedaEmpleadoLimite(string numelement, string busqueda)
        {
            try
            {
                if(busqueda == null || busqueda.Trim() == "")
                {
                    var empleados = await consultas.GetAllEmpleadoLimite(Convert.ToInt32(numelement));
                    return JsonConvert.SerializeObject(empleados);
                }
                else
                {
                    var empleados = await consultas.GetBusquedaEmpleadoLimite(Convert.ToInt32(numelement), busqueda);
                    return JsonConvert.SerializeObject(empleados);
                }

            }catch(Exception ex)
            {
                throw ex;

            }
        }


        [HttpPost]
        public async Task<string> AgregarVendedor(string identificador, string usuario, string contrasena, string almacen)
        {
            try
            {
                Encrypt encrypt = new Encrypt();
                var vendedor = new Empleado();
                vendedor.Persona = await consultas.GetPersonaIdentificador(identificador);
                vendedor.NombreUsuario = usuario;
                vendedor.Pass = await encrypt.GetSHA256(contrasena);
                vendedor.Activo = true;
                vendedor.RolDeUsuario = await consultas.GetRolDeUsuarioId("6414f3cd750ebbe82536dd1a");
                vendedor.Almacen = await consultas.GetAlmacenId(almacen);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> GetAllPersonaBusqueda(string personabusqueda)
        {
            try
            {
                if(personabusqueda == null || personabusqueda.Trim() == "")
                {
                    var personas = await consultas.GetAllPersonas();
                    return JsonConvert.SerializeObject(personas);
                }
                else
                {
                    var personas = await consultas.GetBusquedaPersona(personabusqueda);
                    return JsonConvert.SerializeObject(personas);
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }



    }
}

