using Microsoft.AspNetCore.Mvc;

namespace ApiEcommerce.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImagenesController : ControllerBase
    {
        private readonly ILogger<ImagenesController> _logger;

        public ImagenesController(ILogger<ImagenesController> logger)
        {
            _logger = logger;
        }

        [HttpPost("GuardarImagen")]
        public async Task<string> GuardarImagen([FromBody] IFormFile imagen)
        {
            try
            {
                var ruta = String.Empty;
                if (imagen.Length > 0)
                {
                    var nombrearchivo = Guid.NewGuid().ToString() + ".png";
                    ruta = $"Imagenes/Productos/{nombrearchivo}";
                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        await imagen.CopyToAsync(stream);
                    }
                }
                return ruta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
