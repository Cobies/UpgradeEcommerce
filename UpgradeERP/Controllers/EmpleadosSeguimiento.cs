using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UpgradeERP.Models;
using UpgradeERP.Models.Empleados;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.Personas;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class EmpleadosSeguimiento : Controller
    {

        private readonly ILogger<EmpleadosSeguimiento> logger;
        private readonly Consultas consultas;

        public EmpleadosSeguimiento(ILogger<EmpleadosSeguimiento> logger, Consultas consultas)
        {
            this.logger = logger;
            this.consultas = consultas;
        }

        public async Task<IActionResult> SeguimientoVendedores()
        {
            try
            {
                return View();
            } catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public async Task<string> SemaforoVendedores()
        {
            try
            {
                var empleadosseguimiento = await consultas.GetAllEmpleadosActivos();
                return JsonConvert.SerializeObject(empleadosseguimiento);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> SemaforoYaTransformado()
        {
            try
            {
                var listsemaforo = new List<Semaforo>();
                var empleadosseguimiento = await consultas.GetAllEmpleadosActivos();
                foreach (var emp in empleadosseguimiento)
                {
                    
                    var semafo = new Semaforo();
                    semafo.Vendedor = emp;
                    semafo.ClienteVendedors = await consultas.GetClienteVendedorForVendedor(emp._id);
                    if(semafo.ClienteVendedors != null) { 
                    foreach(var punt in semafo.ClienteVendedors)
                    {
                        foreach(var campo in punt.ClienteVendedorDetalles) {
                            semafo.Totalpuntos += campo.Acciones.Puntaje;
                        }

                    }
                    listsemaforo.Add(semafo);
                    }
                }


                return JsonConvert.SerializeObject(listsemaforo);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> VendedoresSemaforos(string vendedores)
        {
            try
            {
                var lista = JsonConvert.DeserializeObject<Empleado>(vendedores);
                var semaforo = await consultas.GetAllClienteVendedor(lista);
                return JsonConvert.SerializeObject(semaforo);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> EmpleadoActividades()
        {
            try
            {
                var empleadoacciones = await consultas.GetAccionesEmpleado();
                return JsonConvert.SerializeObject(empleadoacciones);
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoAcciones(string nombre, string puntaje, DateTime fecha)
        {
            try
            {
                var acciones = new Acciones();
                acciones.Nombre = nombre.ToUpper();
                acciones.Puntaje = Convert.ToInt32(puntaje);
                return null;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> RellenarSemaforoPersonaldelVendedor(string idvendedor)
        {
            try
            {
                var semaforovendedor = await consultas.GetSemaforoVendedor(idvendedor);
                return JsonConvert.SerializeObject(semaforovendedor);
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
