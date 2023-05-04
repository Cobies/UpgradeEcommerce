using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using UpgradeERP.Models.Empleados;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.Logistica;
using UpgradeERP.Models.Sucursales;
using UpgradeERP.Models.Ventas;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class AlmacenController : Controller
    {
        private readonly ILogger<AlmacenController> _logger;
        private readonly Consultas consultas;
        private readonly Encrypt encrypt;

        public AlmacenController(ILogger<AlmacenController> logger, Consultas consultas, Encrypt encrypt)
        {
            _logger = logger;
            this.consultas = consultas;
            this.encrypt = encrypt;
        }

        [HttpPost]
        public async Task<string> TablaAlmacen()
        {
            try
            {
                var almacen = await consultas.GetAllAlmacen();
                return JsonConvert.SerializeObject(almacen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoAlmacen(string nombre, string abreviatura, string telefono, string sede)
        {
            try
            {
                var almacen = new Almacen();
                almacen.Nombre = nombre.ToUpper();
                almacen.Abreviatura = abreviatura.ToUpper();
                almacen.Telefono = telefono;
                almacen.Sede = await consultas.GetSedeId(sede);
                almacen._id = await consultas.SetAlmacen(almacen);
                if (almacen._id != null)
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
        public async Task<string> BusquedaAlmacen(string busqueda)
        {
            try
            {
                var sede = await consultas.GetBusquedaSede(busqueda.ToUpper());
                return JsonConvert.SerializeObject(sede);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaSede()
        {
            try
            {
                var sede = await consultas.GetAllSede();
                return JsonConvert.SerializeObject(sede);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoSerie(string producto, string serie)
        {
            try
            {
                var cargaydescargadetalle = new CargaYDescargaProductosDetalle();
                var articulo = new Articulo();
                articulo.Producto = await consultas.GetProductoId(producto);
                articulo.Volumen = 1;
                articulo.Serie = serie;
                cargaydescargadetalle.Articulo = articulo;
                cargaydescargadetalle.Cantidad = 1;
                return JsonConvert.SerializeObject(cargaydescargadetalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoSerieMasivo(string producto, string serie, string cantidad)
        {
            try
            {
                List<CargaYDescargaProductosDetalle> listado = new List<CargaYDescargaProductosDetalle>();
                var max = Convert.ToInt32(cantidad);
                for (int x = 0; x <= max; x++)
                {
                    var cargaydescargadetalle = new CargaYDescargaProductosDetalle();
                    var articulo = new Articulo();
                    articulo.Producto = await consultas.GetProductoId(producto);
                    articulo.Volumen = 1;
                    articulo.Serie = serie;
                    cargaydescargadetalle.Articulo = articulo;
                    cargaydescargadetalle.Cantidad = 1;
                    listado.Add(cargaydescargadetalle);
                }
                return JsonConvert.SerializeObject(listado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BuscarProductoId(string id)
        {
            try
            {
                var producto = await consultas.GetProductoId(id);
                return JsonConvert.SerializeObject(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<string> BuscarOrdenProId(string id)
        {
            try
            {
                var pedido = await consultas.GetNotaPedidoId(id);
                return JsonConvert.SerializeObject(pedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoSede(string nombre, string direccion, string telefono)
        {
            try
            {
                var sede = new Sede();
                sede.Nombre = nombre.ToUpper();
                sede.Direccion = direccion.ToUpper();
                sede.Telefono = telefono;
                sede._id = await consultas.SetSede(sede);
                if (sede._id != null)
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
        public async Task<string> BusquedaSede(string busqueda)
        {
            try
            {
                var almacen = await consultas.GetBusquedaAlmacen(busqueda.ToUpper());
                return JsonConvert.SerializeObject(almacen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> ProductosStock()
        {
            try
            {
                var empleado = await consultas.GetEmpleadoId("64261b59480c1db0158a5881");
                var rol = await consultas.GetRolDeUsuarioId("642819cc3c62c575ba16f4d9");
                empleado.RolDeUsuario = rol;
                await consultas.UpdateEmpleado(empleado);


                //var rol = new RolDeUsuario();
                //rol.Nombre = "ADMINISTRADOR";
                //rol.Descripcion = "ADMINISTRADOR";
                //rol.Nivel = 4;
                //await consultas.SetRolDeUsuario(rol);


                //var clienteVendedor = new ClienteVendedor();
                //clienteVendedor.Cliente = await consultas.GetClienteId("64213dfc6e63b87b9bfec936");
                //clienteVendedor.Vendedor = await consultas.GetEmpleadoId("64261bc5480c1db0158a59a4");
                //clienteVendedor.Activo = true;
                //consultas.SetClienteVendedor(clienteVendedor);

                //var detalle = new ClienteVendedorDetalle();
                //detalle.Acciones = await consultas.GetAccionId("642848666642fea8ef3056d9");
                //detalle.FechaCreado = DateTime.Now;
                //detalle._id = await consultas.SetDetalle(detalle);

                //var clientevendedor = await consultas.GetClienteVendedorId("642ab450de2f48be49619a4c");
                //List<ClienteVendedorDetalle> clien = new List<ClienteVendedorDetalle>();
                //clien.Add(detalle);
                //clientevendedor.ClienteVendedorDetalles = clien;
                //await consultas.UpdateClienteVendedor(clientevendedor);

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaProductoStock()
        {
            try
            {
                var productos = await consultas.GetAllProductos();
                var listado = new List<ProductosStock>();
                foreach (var product in productos)
                {
                    var stockproductos = new ProductosStock();
                    stockproductos.Producto = product;
                    stockproductos.Articulos = await consultas.GetArticulosForProducto(product._id);
                    listado.Add(stockproductos);
                }
                return JsonConvert.SerializeObject(listado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaProductoStock(string numelement, string busqueda)
        {
            try
            {
                if (busqueda == null || busqueda.Trim() == "")
                {
                    var producto = await consultas.GetProductosLimite(Convert.ToInt32(numelement));
                    var listado = new List<ProductosStock>();
                    foreach (var product in producto)
                    {
                        var stockproductos = new ProductosStock();
                        stockproductos.Producto = product;
                        stockproductos.Cantidad = await consultas.GetCantStock(product._id);
                        listado.Add(stockproductos);
                    }
                    return JsonConvert.SerializeObject(listado);
                }
                else
                {
                    var producto = await consultas.GetBusquedaProductoLimite(Convert.ToInt32(numelement), busqueda.ToUpper());
                    var listado = new List<ProductosStock>();
                    foreach (var product in producto)
                    {
                        var stockproductos = new ProductosStock();
                        stockproductos.Producto = product;
                        stockproductos.Cantidad = await consultas.GetCantStock(product._id);
                        listado.Add(stockproductos);
                    }
                    return JsonConvert.SerializeObject(listado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<string> BusquedaAllSeriesProducto(string idproducto)
        {
            try
            {
                ProductosStock product = new ProductosStock();
                product.Articulos = await consultas.GetSeriesByProducto(idproducto);
                product.Producto = await consultas.GetProductoId(idproducto);
                return JsonConvert.SerializeObject(product);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IActionResult> Productos()
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
        public async Task<string> TablaProductos()
        {
            try
            {

                var productos = await consultas.GetAllProductos();
                return JsonConvert.SerializeObject(productos);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        [HttpPost]
        public async Task<string> IngresoProducto(string _id, string codigo, string nombre, string descripcion, string marca, string linea, string unidad, string servicio, string codigosunat, string moneda, string impuesto, string costo, string garantia)
        {
            try
            {
                if(_id == null || _id.Trim() == "") { 
                var producto = new Producto();
                producto.Codigo = codigo.ToUpper();
                producto.Nombre = nombre.ToUpper();
                producto.Descripcion = nombre.ToUpper();
                producto.Marca = await consultas.GetMarcaId(marca);
                producto.Linea = await consultas.GetLineaId(linea);
                producto.Unidad = await consultas.GetUnidadId(unidad);
                producto.Servicio = Convert.ToBoolean(servicio);
                producto.CodigoSunat = codigosunat;
                producto.Moneda = await consultas.GetMonedaId(moneda);
                producto.Impuesto = await consultas.GetImpuestoId(impuesto);
                producto.Precio = Convert.ToDouble(costo);
                producto.Garantia = Convert.ToInt32(garantia);
                producto._id = await consultas.SetProducto(producto);
                if (producto._id != null)
                {
                    return "200";
                }
                }
                else
                {
                    var producto = new Producto();
                    producto.Codigo = codigo.ToUpper();
                    producto.Nombre = nombre.ToUpper();
                    producto.Descripcion = nombre.ToUpper();
                    producto.Marca = await consultas.GetMarcaId(marca);
                    producto.Linea = await consultas.GetLineaId(linea);
                    producto.Unidad = await consultas.GetUnidadId(unidad);
                    producto.Servicio = Convert.ToBoolean(servicio);
                    producto.CodigoSunat = codigosunat;
                    producto.Moneda = await consultas.GetMonedaId(moneda);
                    producto.Impuesto = await consultas.GetImpuestoId(impuesto);
                    producto.Precio = Convert.ToDouble(costo);
                    producto.Garantia = Convert.ToInt32(garantia);
                    producto._id = _id;
                    string resp = await consultas.UpdateProducto(producto);
                    if (resp == "200")
                    {
                        return resp;
                    }
                }
                return "400";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaProductoLimite(string numelement, string busqueda)
        {
            try
            {

                if (busqueda == null || busqueda.Trim() == "")
                {
                    var busquedaRol = await consultas.GetProductosLimite(Convert.ToInt32(numelement));
                    return JsonConvert.SerializeObject(busquedaRol);
                }
                else
                {
                    var busquedaRol = await consultas.GetBusquedaProductoLimite(Convert.ToInt32(numelement), busqueda.ToUpper());
                    return JsonConvert.SerializeObject(busquedaRol);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaProducto(string busqueda)
        {
            try
            {
                var busq = await consultas.GetBusquedaProducto(busqueda);
                return JsonConvert.SerializeObject(busq);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<IActionResult> GuiaRemision()
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


        public async Task<IActionResult> OrdenesDescargaProducto()
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
        public async Task<string> IngresoDescargaProductos(string almacen, string notapedidoid, string observacion, string cargaYDescargaProductosDetalles)
        {
            try
            {
                var descarga = new CargaYDescargaProductos();
                var descargadetalles = JsonConvert.DeserializeObject<List<CargaYDescargaProductosDetalle>>(cargaYDescargaProductosDetalles);
                descarga.Almacen = await consultas.GetAlmacenId(almacen);
                descarga.Notapedido = await consultas.GetNotaPedidoId(notapedidoid);
                descarga.Fecha = DateTime.Now;
                descarga.Observacion = observacion;
                descarga.Tipo = "SALIDA";
                var descargadetalleslista = new List<CargaYDescargaProductosDetalle>();
                foreach (var des in descargadetalles)
                {
                    des.Articulo._id = await consultas.SetArticulo(des.Articulo);
                    if (des.Articulo._id != null)
                    {
                        des._id = await consultas.SetCargaYDescargaProductosDetalle(des);
                        if (des._id != null)
                        {
                            descargadetalleslista.Add(des);
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
                descarga.CargaYDescargaProductosDetalles = descargadetalleslista;
                var nota = descarga.Notapedido;

                foreach (var actual in nota.NotaPedidoDetalle)
                {
                    await consultas.UpdateNotaPedidoDetalle(actual);
                }
                await consultas.UpdateNotaPedido(nota);

                foreach (var des in descargadetalles)
                {
                    des.Articulo.Almacen = null;
                    await consultas.UpdateArticulo(des.Articulo);
                }

                descarga._id = await consultas.SetCargaYDescargaProductos(descarga);

                if (descarga._id != null)
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
        public async Task<string> IngresoDescargaProductosDetalle(string productoid, string serie)
        {
            try
            {
                var descargadetalle = new CargaYDescargaProductosDetalle();
                descargadetalle.Cantidad = 1;
                descargadetalle.Articulo = await consultas.GetArticuloForSerie(serie);
                return JsonConvert.SerializeObject(descargadetalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost]
        public async Task<string> IngresoMarca(string nombre, string abreviatura)
        {
            try
            {
                var marca = new Marca();
                marca.Nombre = nombre.ToUpper();
                marca.Abreviatura = abreviatura.ToUpper();
                marca._id = await consultas.SetMarca(marca);
                if (marca._id != null)
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
        public async Task<string> TablaMarca()
        {
            try
            {
                var marca = await consultas.GetAllMarca();
                return JsonConvert.SerializeObject(marca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaMarca(string busqueda)
        {
            try
            {
                var marca = await consultas.GetBusquedaMarca(busqueda.ToUpper());
                return JsonConvert.SerializeObject(marca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoLinea(string nombre, string descripcion)
        {
            try
            {
                var linea = new Linea();
                linea.Nombre = nombre.ToUpper();
                linea.Descripcion = descripcion.ToUpper();
                linea._id = await consultas.SetLinea(linea);
                if (linea._id != null)
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
        public async Task<string> TablaLinea()
        {
            try
            {
                var linea = await consultas.GetAllLinea();
                return JsonConvert.SerializeObject(linea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaLinea(string busqueda)
        {
            try
            {
                var linea = await consultas.GetBusquedaLinea(busqueda.ToUpper());
                return JsonConvert.SerializeObject(linea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoUnidad(string nombre, string abreviatura)
        {
            try
            {
                var unidad = new Unidad();
                unidad.Nombre = nombre.ToUpper();
                unidad.Abreviatura = abreviatura.ToUpper();
                unidad._id = await consultas.SetUnidad(unidad);
                if (unidad._id != null)
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
        public async Task<string> TablaUnidad()
        {
            try
            {
                var unidad = await consultas.GetAllUnidad();
                return JsonConvert.SerializeObject(unidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaUnidad(string busqueda)
        {
            try
            {
                var unidad = await consultas.GetBusquedaUnidad(busqueda.ToUpper());
                return JsonConvert.SerializeObject(unidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoMoneda(string nombre, string cambio)
        {
            try
            {
                var moneda = new Moneda();
                moneda.Nombre = nombre.ToUpper();
                moneda.Cambio = Convert.ToDouble(cambio);
                moneda._id = await consultas.SetMoneda(moneda);
                if (moneda._id != null)
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
        public async Task<string> TablaMoneda()
        {
            try
            {
                var moneda = await consultas.GetAllMoneda();
                return JsonConvert.SerializeObject(moneda);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaMoneda(string busqueda)
        {
            try
            {
                var linea = await consultas.GetBusquedaMoneda(busqueda);
                return JsonConvert.SerializeObject(linea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoImpuesto(string nombre, string valor)
        {
            try
            {
                var impuesto = new Impuesto();
                impuesto.Nombre = nombre.ToUpper();
                impuesto.Valor = Convert.ToDouble(valor);
                impuesto._id = await consultas.SetImpuesto(impuesto);
                if (impuesto._id != null)
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
        public async Task<string> TablaImpuesto()
        {
            try
            {
                var linea = await consultas.GetAllImpuesto();
                return JsonConvert.SerializeObject(linea);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        [HttpPost]
        public async Task<string> BusquedaImpuesto(string busqueda)
        {
            try
            {
                var linea = await consultas.GetBusquedaImpuesto(busqueda);
                return JsonConvert.SerializeObject(linea);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaNotaPedidoNoDescargado(string busqueda)
        {
            var notapedidodescargado = await consultas.GetBusquedaNotaPedidoNoDescargado(busqueda);
            return JsonConvert.SerializeObject(notapedidodescargado);
        }

        [HttpPost]
        public async Task<string> BusquedaNotaPedidoNoDescargadoLimite(string numelement, string busqueda)
        {
            try
            {

                if (busqueda == null || busqueda.Trim() == "")
                {
                    var busq = await consultas.GetAllNotaPedidoNoDescargadoLimite(Convert.ToInt32(numelement));
                    return JsonConvert.SerializeObject(busq);
                }
                else
                {
                    var busq = await consultas.GetBusquedaNotaPedidoNoDescargadoLimite(Convert.ToInt32(numelement), busqueda.ToUpper());
                    return JsonConvert.SerializeObject(busq);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaNotaPedidoNoDescargado()
        {
            var notapedidodescargado = await consultas.GetAllNotaPedidoNoDescargado();
            return JsonConvert.SerializeObject(notapedidodescargado);
        }

        [HttpPost]
        public async Task<string> IngresoTabProductosSalida(string producto, string codigo, string almacen)
        {
            try
            {
                var articulo = new Articulo();
                var descarga = new CargaYDescargaProductosDetalle();
                articulo.Fecha = DateTime.Now;
                articulo.Serie = codigo;
                articulo.Almacen = await consultas.GetAlmacenId(almacen);
                articulo.Producto = await consultas.GetProductoId(producto);
                descarga.Articulo = articulo;

                return JsonConvert.SerializeObject(descarga);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> DescargaProductoModeloRellenar(string id)
        {
            try
            {
                var notaped = await consultas.GetNotaPedidoId(id);
                return JsonConvert.SerializeObject(notaped);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public async Task<IActionResult> OrdenesEntradaProducto()
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
        public async Task<string> TablaEntradaProducto()
        {
            try
            {
                var entradaproducto = await consultas.GetAllEntradaProducto();
                return JsonConvert.SerializeObject(entradaproducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaEntradaProductoLimite(string numelement, string busqueda)
        {
            try
            {
                if (busqueda == null || busqueda.Trim() == "")
                {
                    var descarga = await consultas.GetAllEntradaProductoLimite(Convert.ToInt32(numelement));
                    return JsonConvert.SerializeObject(descarga);
                }
                else
                {
                    var descarga = await consultas.GetBusquedaEntradaProductoLimite(Convert.ToInt32(numelement), busqueda.ToUpper());
                    return JsonConvert.SerializeObject(descarga);
                }
            }
            catch(Exception ex)
            {
                throw ex;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
            }
        }

        [HttpPost]
        public async Task<string> BusquedaEntradaProducto(string busqueda)
        {
            try
            {
                var entradaproducto = await consultas.GetBusquedaEntradaProducto(busqueda);
                return JsonConvert.SerializeObject(entradaproducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoEntradaProducto(string almacen, string facturaCompra, string observacion, string cargaYDescargaProductosDetalles)
        {
            try
            {
                var entrada = new CargaYDescargaProductos();
                var entradadetalle = JsonConvert.DeserializeObject<List<CargaYDescargaProductosDetalle>>(cargaYDescargaProductosDetalles);
                entrada.Almacen = await consultas.GetAlmacenId(almacen);
                entrada.FacturaCompra = await consultas.GetFacturasCompraId(facturaCompra);
                entrada.Observacion = observacion;
                entrada.Tipo = "ENTRADA";
                entrada.Fecha = DateTime.Now;
                var entradadetalles = new List<CargaYDescargaProductosDetalle>();

                foreach (var det in entradadetalle)
                {
                    var articulo = det.Articulo;
                    articulo.Almacen = entrada.Almacen;
                    articulo.Fecha = DateTime.Now;
                    articulo._id = await consultas.SetArticulo(articulo);
                    det.Articulo = articulo;
                    det._id = await consultas.SetCargaYDescargaProductosDetalle(det);
                    entradadetalles.Add(det);
                }
                entrada.CargaYDescargaProductosDetalles = entradadetalles;

                entrada._id = await consultas.SetCargaYDescargaProductos(entrada);


                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoEntradaProductoDetalle(string producto, string serie, string observaciones, string almacen)
        {
            try
            {
                var articulo = new Articulo();
                articulo.Producto = await consultas.GetProductoId(producto);
                articulo.Serie = serie;
                articulo.Observaciones = observaciones;
                articulo.Almacen = await consultas.GetAlmacenId(almacen);
                articulo.Fecha = DateTime.Now;
                var entradadetalle = new CargaYDescargaProductosDetalle();
                entradadetalle.Cantidad = 1;
                entradadetalle.Articulo = articulo;
                return JsonConvert.SerializeObject(entradadetalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> RellenarParaIngreso(string id)
        {
            try
            {
                var entrada = await consultas.GetFacturasCompraId(id);
                return JsonConvert.SerializeObject(entrada);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaDescargaProducto()
        {
            try
            {
                var descargaproducto = await consultas.GetAllDescargaProducto();
                return JsonConvert.SerializeObject(descargaproducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaDescargaProductoLimite(string numelement, string busqueda)
        {
            try
            {
                if (busqueda == null || busqueda.Trim() == "")
                {
                    var descarga = await consultas.GetAllDescargaProductoLimite(Convert.ToInt32(numelement));
                    return JsonConvert.SerializeObject(descarga);
                }
                else
                {
                    var descarga = await consultas.GetBusquedaDescargaProductoLimite(Convert.ToInt32(numelement), busqueda.ToUpper());
                    return JsonConvert.SerializeObject(descarga);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaDescargaProducto(string busqueda)
        {
            try
            {
                var descargaproducto = await consultas.GetBusquedaDescargaProducto(busqueda);
                return JsonConvert.SerializeObject(descargaproducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoDescargaArticulo(string serie, string productoDeDescaga, string almacen)
        {
            try
            {
                var articulo = new Articulo();
                articulo.Producto = await consultas.GetProductoId(productoDeDescaga);
                articulo.Almacen = await consultas.GetAlmacenId(almacen);
                articulo.Fecha = DateTime.Now;
                articulo.Serie = serie;

                return JsonConvert.SerializeObject(articulo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaAlmacenesDisponibles(string busqueda)
        {
            try
            {
                var almacenes = await consultas.GetBusquedaAlmacen(busqueda);
                List<Almacen> result = new List<Almacen>();
                foreach (var almacen in almacenes)
                {
                    if (almacen.Abreviatura == "A-Q001" && almacen.Nombre != null)
                    {
                        result.Add(almacen);
                    }
                    else if (almacen.Abreviatura == "C001" && almacen.Nombre != null)
                    {
                        result.Add(almacen);
                    }
                    else if (almacen.Abreviatura == "A0001" && almacen.Nombre != null)
                    {
                        result.Add(almacen);
                    }
                }
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> AlmacenesDisponibles()
        {
            try
            {
                var almacenes = await consultas.GetAllAlmacen();
                List<Almacen> result = new List<Almacen>();
                foreach (var almacen in almacenes)
                {
                    if (almacen.Abreviatura == "A-Q001")
                    {
                        result.Add(almacen);
                    }
                    else if (almacen.Abreviatura == "C001")
                    {
                        result.Add(almacen);
                    }
                    else if (almacen.Abreviatura == "A0001")
                    {
                        result.Add(almacen);
                    }
                }
                return JsonConvert.SerializeObject(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> GuiasRemision()
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
        public async Task<string> BusquedaGuiasRemision(string busqueda)
        {
            try
            {
                var guias = await consultas.GetBusquedaGuiasRemision(busqueda);

                return JsonConvert.SerializeObject(guias);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaGuiasRemision()
        {
            try
            {
                var guias = await consultas.GetAllGuiasRemision();

                return JsonConvert.SerializeObject(guias);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
