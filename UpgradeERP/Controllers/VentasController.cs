using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UpgradeERP.Models.Ventas;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class VentasController : Controller
    {
        private readonly ILogger<VentasController> _logger;
        private readonly Consultas consultas;

        public IActionResult SeguimientoClientes()
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
        public VentasController(ILogger<VentasController> logger, Consultas consultas)
        {
            _logger = logger;
            this.consultas = consultas;
        }

        public async Task<IActionResult> OrdenesDeVenta()
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
        public async Task<string> BusquedaNotaPedidoLimite(string numelement, string busqueda)
        {
            try
            {
                if (busqueda == null || busqueda.Trim() == "")
                {
                    int num = Convert.ToInt32(numelement);
                    var busq = await consultas.GetNotaPedidoLimite(num);
                    return JsonConvert.SerializeObject(busq);
                }
                else
                {
                    int num = Convert.ToInt32(numelement);
                    var busq = await consultas.GetBusquedaNotaPedidoLimite(num, busqueda.ToUpper());
                    return JsonConvert.SerializeObject(busq);
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaNotaPedido(string busqueda)
        {
            try
            {
                var busq = await consultas.GetBusquedaNotaPedido(busqueda);
                return JsonConvert.SerializeObject(busq);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaNotaPedido()
        {
            try
            {
                var notapedido = await consultas.GetAllNotaPedido();
                return JsonConvert.SerializeObject(notapedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public async Task<string> IngresoNotaPedido(string cliente, string vendedor, string fecha, string fechaentrega, string moneda, string formadepago, string observaciones, string notapedidodetalle)
        {
            try
            {
                var notapedido = new NotaPedido();
                var notapedidodetalles = new List<NotaPedidoDetalle>();
                notapedido.Cliente = await consultas.GetClienteId(cliente);
                notapedido.Vendedor = await consultas.GetVendedorId(vendedor);
                notapedido.Fecha = DateTime.Parse(fecha);
                if (fechaentrega != null)
                {
                    notapedido.FechaEntrega = DateTime.Parse(fechaentrega);
                }
                else
                {
                    notapedido.FechaEntrega = DateTime.Now;
                }
                notapedido.Moneda = await consultas.GetMonedaId(moneda);
                notapedido.FormaDePago = await consultas.GetFormaDePagoId(formadepago);
                notapedido.Observacion = observaciones;
                var notadetalle = JsonConvert.DeserializeObject<List<NotaPedidoDetalle>>(notapedidodetalle);
                foreach (var not in notadetalle)
                {
                    not._id = await consultas.SetNotaPedidoDetalle(not);
                    if (not._id != null)
                    {
                        notapedidodetalles.Add(not);
                    }

                }
                notapedido.Descargado = false;
                notapedido.NotaPedidoDetalle = notapedidodetalles;
                notapedido._id = await consultas.SetNotaPedido(notapedido);
                if (notapedido._id != null)
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
        public async Task<string> IngresoNotaPedidoDetalle(NotaPedidoDetalle notaPedidoDetalle)
        {
            try
            {
                notaPedidoDetalle._id = await consultas.SetNotaPedidoDetalle(notaPedidoDetalle);
                if (notaPedidoDetalle._id != null)
                {
                    return notaPedidoDetalle._id;
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

        [HttpPost]
        public async Task<string> OrganizarTablaNotaPedidoDetalle(string producto, string cantidad, string preciounitario)
        {
            try
            {
                var notapedidodetalle = new NotaPedidoDetalle();
                var listado = new List<NotaPedidoDetalle>();
                notapedidodetalle.Producto = await consultas.GetProductoId(producto);
                notapedidodetalle.Cantidad = Convert.ToInt32(cantidad);
                notapedidodetalle.PrecioUnitario = Convert.ToDouble(preciounitario);


                return JsonConvert.SerializeObject(notapedidodetalle);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> CancelarVenta(List<string> notapedidodetalle)
        {
            try
            {
                string cod = "";
                foreach (var not in notapedidodetalle)
                {
                    cod = await consultas.DeleteNotaPedidoDetalle(not);
                }
                if (cod == "200")
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
        public async Task<string> TablaNotaPedidoDetalle(string[] notapedidodetalles)
        {
            try
            {
                if (notapedidodetalles != null)
                {
                    var not = notapedidodetalles;
                    var notapedidodetalle = new List<NotaPedidoDetalle>();
                    for (int x = 0; x <= notapedidodetalle.Count; x++)
                    {
                        var notapedidodet = new NotaPedidoDetalle();
                        notapedidodet = await consultas.GetNotaPedidoDetalleId(notapedidodetalles[x]);
                        notapedidodetalle.Add(notapedidodet);
                    }
                    return JsonConvert.SerializeObject(notapedidodetalle);
                }
                return "400";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
