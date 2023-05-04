using ApiEcommerce.Connection;
using ApiEcommerce.ModelsHelpers;
using ApiEcommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {

        private readonly ILogger<AutenticacionController> _logger;
        private readonly IAutenticacion autenticacion;
        private readonly IClientesServices clientes;

        public AutenticacionController(ILogger<AutenticacionController> logger, IAutenticacion autenticacion, IClientesServices cliente)
        {
            _logger = logger;
            this.autenticacion = autenticacion;
            this.clientes = cliente;
        }

        [HttpPost("Autenticacion")]
        [Consumes("application/json")]
        public async Task<string> AutenticacionCliente([FromBody] Users usuario)
        {
            try
            {
                Cifrado cifrado = new Cifrado();
                usuario.Password = await cifrado.GetSHA256(usuario.Password);
                var cliente = await clientes.GetAutentificacionCliente(usuario);
                if (cliente != null)
                {
                    string jwt = await autenticacion.GenerarToken(cliente);
                    return jwt;
                }
                return "false";

            }
            catch (Exception ex)
            {
                return "te weveaste";
                throw ex;
            }
        }
    }
}
