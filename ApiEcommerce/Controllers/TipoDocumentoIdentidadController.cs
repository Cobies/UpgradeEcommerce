using ApiEcommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiEcommerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TipoDocumentoIdentidadController : ControllerBase
    {

        private readonly ILogger<TipoDocumentoIdentidadController> _logger;
        private readonly ITipoDocumentoServices tipodocumentoServices;

        public TipoDocumentoIdentidadController(ILogger<TipoDocumentoIdentidadController> logger, ITipoDocumentoServices services)
        {
            _logger = logger;
            tipodocumentoServices = services;
        }

        [HttpGet("TipoDocumentoAll")]
        public async Task<string> GetAllTipoDocumento()
        {
            try
            {
                var tipodocumento = await tipodocumentoServices.GetAllDocumentoTipo();
                if (tipodocumento != null)
                {
                    return JsonConvert.SerializeObject(tipodocumento);
                }
                else
                {
                    return "400 pendejo te weveaste";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("TipoDocumentoPorId/{id}")]
        public async Task<string> GetTipoDocumentoIdentidadId([FromRoute] string id)
        {
            try
            {
                var tipodocumento = await tipodocumentoServices.GetDocumentoTipoId(id);
                if (tipodocumento != null)
                {
                    return JsonConvert.SerializeObject(tipodocumento);
                }
                else
                {
                    return "400 pendejo te weveaste";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}

