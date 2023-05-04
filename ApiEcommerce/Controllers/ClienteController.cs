using ApiEcommerce.Connection;
using ApiEcommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UpgradeERP.Models.Personas;

namespace ApiEcommerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IAutenticacion autenticacion;
        private readonly ILogger<ClienteController> _logger;
        private readonly IClientesServices clientesService;
        private readonly IPersonaServices personaService;


        public ClienteController(ILogger<ClienteController> logger, IClientesServices clientesServices, IPersonaServices personaServices, IAutenticacion autenticacion)
        {
            _logger = logger;
            this.clientesService = clientesServices;
            this.personaService = personaServices;
            this.autenticacion = autenticacion;
        }

        [HttpPost("SetCliente")]
        [Consumes("application/json")]
        public async Task<string> SetCliente([FromBody] Cliente cliente)
        {
            try
            {
                cliente.Persona._id = await personaService.SetPersona(cliente.Persona);
                if (cliente.Persona._id != null)
                {
                    Cifrado cifrado = new Cifrado();
                    cliente.Pass = await cifrado.GetSHA256(cliente.Pass);
                    cliente._id = await clientesService.SetCliente(cliente);

                    if (cliente._id != null || cliente._id.Trim() != "")
                    {
                        return "200";
                    }
                    else
                    {
                        return "400";
                    }
                }
                else
                {
                    return "400";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ValidateIdentificador/{tipodocumento}&{identificador}")]
        [Consumes("application/json")]
        public async Task<string> ValidacionIdentificadorClienteUnico([FromRoute] string tipodocumento, [FromRoute] string identificador)
        {
            try
            {
                var cliente = await clientesService.ValidacionClienteUnicoPorIdentificador(tipodocumento, identificador);
                if (cliente != null)
                {
                    return "200";
                }
                else
                {
                    return "400 la cagaste";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("ValidacionCorreo/{correo}")]
        [Consumes("application/json")]
        public async Task<string> ValidacionClienteCorreo([FromRoute] string correo)
        {
            try
            {
                var cliente = await clientesService.ValidacionPorCorreoElectronico(correo);
                if (cliente != null)
                {
                    return "200";
                }
                else
                {
                    return "400 te weveaste";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetCliente/{id}")]
        [Consumes("application/json")]
        [Authorize]
        public async Task<string> GetClienteId([FromRoute] string id)
        {
            try
            {
                var cliente = await clientesService.GetClienteId(id);
                if (cliente != null)
                {
                    cliente.Pass = "";
                    return JsonConvert.SerializeObject(cliente);
                }
                else
                {
                    return "400 te wevesate";
                }


            }
            catch (Exception ex)
            {
                return "te weveaste excepcion";
                throw ex;
            }
        }

    }
}
