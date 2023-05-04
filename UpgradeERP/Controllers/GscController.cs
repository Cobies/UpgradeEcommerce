using Microsoft.AspNetCore.Mvc;
using UpgradeERP.Models.SoporteTecnico;
using UpgradeERP.Servicios;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace UpgradeERP.Controllers
{
    public class GscController : Controller
    {
        private readonly ILogger<GscController> _logger;
        private readonly Consultas consultas;

        public GscController(ILogger<GscController> logger, Consultas consultas)
        {
            _logger = logger;
            this.consultas = consultas;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult React()
        {
            return View();
        }

        public IActionResult ServicioTecnico()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pdfs(string id)
        {
            try
            {

                return RedirectToAction("ReporteTecnico", "Pdf", new { id = id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public IActionResult ServicioTecnico(ReporteTecnico reporteServicioTecnico)
        {
            //return RedirectToAction("Garantias");

            return View();

        }

        [HttpGet]
        public IActionResult Garantias()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> IngresoReporteTecnico(string cliente, string encargado, string datosdelequipo, string tipodemantenimiento, string mantenimientosRealizados, string observaciones, string objetosDejados)
        {
            try
            {
                var reporteServicioTecnico = new ReporteTecnico();
                reporteServicioTecnico.Cliente = await consultas.GetClienteId(cliente);
                reporteServicioTecnico.Encargado = await consultas.GetEmpleadoId(encargado);
                reporteServicioTecnico.Articulo = await consultas.GetArticuloId(datosdelequipo);
                reporteServicioTecnico.FechaRecepcion = DateTime.Now;
                reporteServicioTecnico.Tipodemantenimiento = tipodemantenimiento.ToUpper();
                reporteServicioTecnico.Fallas = mantenimientosRealizados.ToUpper();
                reporteServicioTecnico.Resultado = observaciones.ToUpper();
                reporteServicioTecnico.ObjetosDejados = objetosDejados.ToUpper();

                var cod = await consultas.SetReporteServicioTecnico(reporteServicioTecnico);
                if (cod != null)
                {
                    return "200";
                }
                return "404";
            }
            catch (Exception ex)
            {
                return "404";
            }
        }

        // Envio datos GARANTIAS
        [HttpPost]
        public async Task<string> IngresoGarantias(string cliente, string encargado, string articulo, string almacen, string descripcion, string objetosDejados)
        {
            try
            {
                var reporteGarantia = new ReporteGarantia();
                reporteGarantia.Cliente = await consultas.GetClienteId(cliente);
                reporteGarantia.Encargado = await consultas.GetEmpleadoId(encargado);
                reporteGarantia.Articulo = await consultas.GetArticuloForSerie(articulo);
                reporteGarantia.Almacen = await consultas.GetAlmacenId(almacen);
                reporteGarantia.FechaRecepcion = DateTime.Now;
                reporteGarantia.Descripcion = descripcion.ToUpper();
                reporteGarantia.ObjetosDejados = objetosDejados.ToUpper();

                var cod = await consultas.SetReporteGarantia(reporteGarantia);
                if (cod != null)
                {
                    return "200";
                }
                return "404";
            }
            catch (Exception ex)
            {
                return "404";
            }
        }

        [HttpPost]
        public async Task<string> BusquedaTablaReporteServicioTecnico(string busqueda)
        {
            try
            {
                var busquedaReporteST = await consultas.GetBusquedaReporteTecnico(busqueda.ToUpper());
                return JsonConvert.SerializeObject(busquedaReporteST);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Rellenar tabla de Reportes Tecnicos
        [HttpPost]
        public async Task<string> ObtenerTablaReporteServicioTecnico( int pagina)
        {
            try
            {

                var reporteST = await consultas.GetAllReporteServicioTecnico(pagina);
                return JsonConvert.SerializeObject(reporteST);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Rellenar tabla de Reportes Garantia
        [HttpGet]
        public async Task<string> ObtenerTablaReporteGarantias()
        {
            try
            {
                var reporteGarantias = await consultas.GetAllReporteGarantias();
                return JsonConvert.SerializeObject(reporteGarantias);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        // Actualizar un Reporte Garantia
        [HttpPost]
        public async Task<string> EditarReporteGarantia(string id, string cliente, string encargado, string articulo, string almacen, string descripcion, string objetosDejados)
        {
            try
            {
                var reporteGarantia = new ReporteGarantia();

                reporteGarantia._id = id;
                reporteGarantia.Cliente = await consultas.GetClienteId(cliente);
                reporteGarantia.Encargado = await consultas.GetEmpleadoId(encargado);
                reporteGarantia.Articulo = await consultas.GetArticuloId(articulo);
                reporteGarantia.Almacen = await consultas.GetAlmacenId(almacen);
                reporteGarantia.FechaEntrega = DateTime.Now;
                reporteGarantia.Descripcion = descripcion;
                reporteGarantia.ObjetosDejados = objetosDejados;

                var cod = await consultas.UpdateGarantia(reporteGarantia);
                if (cod != null)
                {
                    return "200";
                }

                return "404";



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Actualizar un Reporte Garantia
        [HttpPost]
        public async Task<string> EditarReporteTecnico(string id, string cliente, string encargado, string tipodemantenimiento, string datosdelequipo, string mantenimientosRealizados, string observaciones, string objetosDejados)
        {
            try
            {
                var reporteGarantia = new ReporteTecnico();
                reporteGarantia._id = id;
                reporteGarantia.Cliente = await consultas.GetClienteId(cliente);
                reporteGarantia.Encargado = await consultas.GetEmpleadoId(encargado);
                reporteGarantia.Tipodemantenimiento = tipodemantenimiento;
                reporteGarantia.Articulo = await consultas.GetArticuloId(datosdelequipo);
                reporteGarantia.FechaEntrega = DateTime.Now;
                reporteGarantia.Fallas = mantenimientosRealizados;
                reporteGarantia.Resultado = observaciones;
                reporteGarantia.ObjetosDejados = objetosDejados;

                var cod = await consultas.UpdateReporteTecnicoId(reporteGarantia);
                if (cod != null)
                {
                    return "200";
                }

                return "404";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Traer por busqueda input -> Tabla rellenar
        [HttpPost]
        public async Task<string> TraerDatosBusquedaTablaReportesGarantias(string nombre)
        {
            try
            {
                var busquedaGarantias = await consultas.GetReporteGarantia(nombre.ToUpper());
                return JsonConvert.SerializeObject(busquedaGarantias);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
