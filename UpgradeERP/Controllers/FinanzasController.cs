using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class FinanzasController : Controller
    {
        private readonly ILogger<FinanzasController> _logger;
        private readonly Consultas consultas;

        public FinanzasController(ILogger<FinanzasController> logger, Consultas consultas)
        {
            _logger = logger;
            this.consultas = consultas;
        }

        public async Task<IActionResult> Transferencias()
        {
            try
            {
                var clientes = await consultas.GetAllClientes();
                foreach (var cliente in clientes)
                {
                    if(cliente.Persona.Ubigeo != null) { 
                    cliente.Persona.Distrito = await consultas.GetDistritoUbigeo(cliente.Persona.Ubigeo);
                        consultas.UpdatePersona(cliente.Persona);
                        consultas.UpdateCliente(cliente);
                    }
                }


                return View();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoFormaDePago(string nombre)
        {
            try
            {
                var formadepago = new FormaDePago();
                formadepago.Nombre = nombre.ToUpper();
                formadepago._id = await consultas.SetFormaDePago(formadepago);
                if (formadepago._id != null)
                {
                    return "200";
                }
                return "400";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaFormaDePago(string busqueda)
        {
            try
            {
                var formadepago = await consultas.GetBusquedaFormaDePago(busqueda.ToUpper());
                return JsonConvert.SerializeObject(formadepago);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaReciboId(string id)
        {
            try
            {
                var recibo = await consultas.GetReciboId(id);
                return JsonConvert.SerializeObject(recibo);
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public async Task<string> BusquedaTransferenciaLimite(string numelement, string busqueda)
        {
            try
            {
                if (busqueda == null || busqueda.Trim() == "")
                {
                    var busquedaRol = await consultas.GetAllTransferenciaLimite(Convert.ToInt32(numelement));
                    return JsonConvert.SerializeObject(busquedaRol);
                }
                else
                {
                    var busquedaRol = await consultas.GetBusquedaTransferenciaLimite(Convert.ToInt32(numelement), busqueda.ToUpper());
                    return JsonConvert.SerializeObject(busquedaRol);

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> Cheques()
        {
            try
            {
                return View();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaChequesLimite(string numelement, string busqueda)
        {
            try
            {
                if(busqueda == null || busqueda.Trim() == "")
                {
                    var cheques = await consultas.GetChequesLimite(Convert.ToInt32(numelement));
                    return JsonConvert.SerializeObject(cheques);
                }
                else
                {
                    var cheques = await consultas.GetBusquedaChequesLimite(Convert.ToInt32(numelement), busqueda.ToUpper());
                    return JsonConvert.SerializeObject(cheques);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public async Task<string> TablaFormaDePago()
        {
            try
            {
                var formadepago = await consultas.GetAllFormaDePago();
                return JsonConvert.SerializeObject(formadepago);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
