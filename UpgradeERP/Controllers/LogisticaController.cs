using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UpgradeERP.Models.Logistica;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Ventas;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class LogisticaController : Controller
    {
        private readonly ILogger<LogisticaController> logger;
        private readonly Consultas consultas;

        public LogisticaController(ILogger<LogisticaController> logger, Consultas consultas)
        {
            this.logger = logger;
            this.consultas = consultas;
        }

        public async Task<IActionResult> FacturasCompra()
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
        public async Task<string> TablaFacturasCompra()
        {
            try
            {
                var facturas = await consultas.GetAllFacturasCompra();
                return JsonConvert.SerializeObject(facturas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaFacturasCompra(string busqueda)
        {
            try
            {
                var facturas = await consultas.GetBusquedaFacturasCompra(busqueda.ToUpper());
                return JsonConvert.SerializeObject(facturas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaFacturasCompraLimite(string numelement, string busqueda)
        {
            try
            {
                if (busqueda == null || busqueda.Trim() == "")
                {
                    int num = Convert.ToInt32(numelement);
                    var busq = await consultas.GetAllFacturasCompraLimite(num);
                    return JsonConvert.SerializeObject(busq);
                }
                else
                {
                    int num = Convert.ToInt32(numelement);
                    var busq = await consultas.GetBusquedaFacturasCompraLimite(num, busqueda.ToUpper());
                    return JsonConvert.SerializeObject(busq);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IActionResult> OrdenDeCompra()
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
        public async Task<string> TablaOrdenDeCompra()
        {
            try
            {
                var ordencompra = await consultas.GetAllOrdenCompra();
                return JsonConvert.SerializeObject(ordencompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaOrdenDeCompraLimite(string numelement, string busqueda)
        {
            try
            {
                if (busqueda == null || busqueda.Trim() == "")
                {
                    var descarga = await consultas.GetAllOrdenCompraLimite(Convert.ToInt32(numelement));
                    return JsonConvert.SerializeObject(descarga);
                }
                else
                {
                    var descarga = await consultas.GetBusquedaOrdenCompraLimite(Convert.ToInt32(numelement), busqueda.ToUpper());
                    return JsonConvert.SerializeObject(descarga);
                }
            }
            catch(Exception ex){
                throw ex;
            }
        }


        [HttpPost]
        public async Task<string> BusquedaOrdenDeCompra(string busqueda)
        {
            try
            {
                var ordencompra = await consultas.GetBusquedaOrdenCompra(busqueda.ToUpper());
                return JsonConvert.SerializeObject(ordencompra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoOrdenDeCompra(string proveedor, string almacen, string numero, string formadepago, string fecha, string fechaentrega, string moneda, string impuesto, string descuento, string listadoordencompradetalle)
        {
            try
            {
                var ordencompra = new OrdenCompra();
                List<OrdenCompraDetalle> ordencompradetalles = new List<OrdenCompraDetalle>();
                ordencompra.Proveedor = await consultas.GetClienteId(proveedor);
                ordencompra.Almacen = await consultas.GetAlmacenId(almacen);
                ordencompra.Numero = Convert.ToInt32(numero);
                ordencompra.FormaDePago = await consultas.GetFormaDePagoId(formadepago);
                ordencompra.Fecha = Convert.ToDateTime(fecha);
                if (fechaentrega != null)
                {
                    ordencompra.FechaEntrega = Convert.ToDateTime(fechaentrega);
                }
                else
                {
                    ordencompra.FechaEntrega = DateTime.Now;
                }
                ordencompra.Moneda = await consultas.GetMonedaId(moneda);
                ordencompra.Impuesto = await consultas.GetImpuestoId(impuesto);
                ordencompra.Descuento = Convert.ToDouble(descuento);
                var ordencompradetallelista = JsonConvert.DeserializeObject<List<OrdenCompraDetalle>>(listadoordencompradetalle);
                foreach (var ordencompradetalle in ordencompradetallelista)
                {
                    ordencompradetalle._id = await consultas.SetOrdenCompraDetalle(ordencompradetalle);
                    if (ordencompradetalle._id != null)
                    {
                        ordencompradetalles.Add(ordencompradetalle);
                    }
                }
                ordencompra.Ordencompradetalle = ordencompradetalles;
                ordencompra._id = await consultas.SetOrdenCompra(ordencompra);
                if (ordencompra._id != null)
                {
                    return "200";
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


        public async Task<IActionResult> SolicitudCompras()
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
        public async Task<string> TablaSolicitudCompra()
        {
            try
            {
                var soli = await consultas.GetAllSolicitudCompra();
                return JsonConvert.SerializeObject(soli);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaSolicitudCompraLimite(string numelement, string busqueda)
        {
            try
            {
                if(busqueda == null || busqueda.Trim() == "")
                {
                    int num = Convert.ToInt32(numelement);
                    var busq = await consultas.GetAllSolicitudCompraLiomite(num);
                    return JsonConvert.SerializeObject(busq);
                }
                else
                {
                    int num = Convert.ToInt32(numelement);
                    var busq = await consultas.GetBusquedaSolicitudCompraLimite(num, busqueda);
                    return JsonConvert.SerializeObject(busq);
                }
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaSolicitudCompra(string busqueda)
        {
            try
            {
                var soli = await consultas.GetBusquedaSolicitudCompra(busqueda);
                return JsonConvert.SerializeObject(soli);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoSolicitudCompra(string producto, string cantidad, string almacen, string numeroordenventa)
        {
            try
            {
                var soli = new SolicitudCompra();
                soli.Producto = await consultas.GetProductoId(producto);
                soli.Cantidad = Convert.ToInt32(cantidad);
                soli.Fecha = DateTime.Now;
                var tiposoli = numeroordenventa.Trim();
                soli.Empleado = HttpContext.Session.GetObject<Empleado>("Usuario");
                soli.Almacen = await consultas.GetAlmacenId(almacen);
                soli._id = await consultas.SetSolicitudCompra(soli);
                if (soli._id != null)
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
        public async Task<string> IngresoFacturasCompra(string documento, string numero, string cliente, string almacen, string fecha, string fechaentrega, string impuesto, string moneda, string formadepago, string descuento, string listadodetallefactura)
        {
            try
            {
                var factura = new FacturasCompra();
                List<FacturasCompraDetalle> facturasCompraDetalles = new List<FacturasCompraDetalle>();
                factura.DocumentoTipo = await consultas.GetDocumentoTipoId(documento);
                factura.Numero = numero;
                factura.Proveedor = await consultas.GetClienteId(cliente);
                factura.Almacen = await consultas.GetAlmacenId(almacen);
                factura.Fecha = Convert.ToDateTime(fecha);
                if (fechaentrega != null)
                {
                    factura.FechaLlegada = Convert.ToDateTime(fechaentrega);
                }
                else
                {
                    factura.FechaLlegada = DateTime.Now;
                }
                factura.Impuesto = await consultas.GetImpuestoId(impuesto);
                factura.Moneda = await consultas.GetMonedaId(moneda);
                factura.FormaDePago = await consultas.GetFormaDePagoId(formadepago);
                factura.Descuento = Convert.ToDouble(descuento);
                var listado = JsonConvert.DeserializeObject<List<FacturasCompraDetalle>>(listadodetallefactura);
                foreach (FacturasCompraDetalle compraDetalle in listado)
                {
                    compraDetalle._id = await consultas.SetFacturasCompraDetalle(compraDetalle);
                    if (compraDetalle._id != null)
                    {
                        facturasCompraDetalles.Add(compraDetalle);
                    }
                    else
                    {
                        return "400";
                    }
                }







                factura._id = await consultas.SetFacturasCompra(factura);
                if (factura._id != null)
                {
                    return "200";
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
        public async Task<string> OrganizarTablaFacturasCompraDetalle(string producto, string cantidad, string preciounitario)
        {
            try
            {
                var facturascompradetalle = new FacturasCompraDetalle();
                var listado = new List<NotaPedidoDetalle>();
                facturascompradetalle.Producto = await consultas.GetProductoId(producto);
                facturascompradetalle.Cantidad = Convert.ToInt32(cantidad);
                facturascompradetalle.PrecioUnitario = Convert.ToDouble(preciounitario);


                return JsonConvert.SerializeObject(facturascompradetalle);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
