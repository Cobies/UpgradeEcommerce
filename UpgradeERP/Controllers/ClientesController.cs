using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.Ubicacion;
using UpgradeERP.Servicios;

namespace UpgradeERP.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly Consultas consultas;

        public ClientesController(ILogger<ClientesController> logger, Consultas consultas)
        {
            _logger = logger;
            this.consultas = consultas;
        }

        public async Task<IActionResult> Clientes()
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
        public async Task<string> TablaClientes()
        {
            try
            {
                var clientes = await consultas.GetAllClientes();
                return JsonConvert.SerializeObject(clientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> IngresoCliente(string _id, string nombre, string tipodocumento, string documento, string telefono, string distrito, string direccion, string correo)
        {
            try
            {
                if(_id == null || _id.Trim() == ""){ 
                    var cliente = new Cliente();
                    var persona = new Persona();
                    cliente.Persona = persona;
                    cliente.Persona.Nombre = nombre.ToUpper();
                    cliente.Persona.TipoDocumentoIdentidad = await consultas.GetTipoDocumentoIdentidadId(tipodocumento);
                    cliente.Persona.DocumentoIdentidad = documento;
                    cliente.Persona.Telefono = telefono;
                    cliente.Persona.Distrito = await consultas.GetDistritoId(distrito);
                
                    cliente.Persona.Direccion = direccion;
                    cliente.Persona.Email = correo;
                    cliente.Persona._id = await consultas.SetPersona(cliente.Persona);
                    cliente._id = await consultas.SetCliente(cliente);
                    if (cliente._id != null)
                    {
                        return "200";
                    }
                }
                else
                {
                    var cliente = new Cliente();
                    var persona = new Persona();
                    cliente.Persona = persona;
                    cliente.Persona.Nombre = nombre.ToUpper();
                    cliente.Persona.TipoDocumentoIdentidad = await consultas.GetTipoDocumentoIdentidadId(tipodocumento);
                    cliente.Persona.DocumentoIdentidad = documento;
                    cliente.Persona.Telefono = telefono;
                    cliente.Persona.Distrito = await consultas.GetDistritoId(distrito);

                    cliente.Persona.Direccion = direccion;
                    cliente.Persona.Email = correo;
                    cliente.Persona._id = await consultas.SetPersona(cliente.Persona);
                    cliente._id = await consultas.UpdateCliente(cliente);
                    if (cliente._id != null)
                    {
                        return "200";
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
        public async Task<string> IngresoTipoDocumentoIdentidad(string nombre, string abreviatura)
        {
            try
            {
                var tipoDocumentoIdentidad = new TipoDocumentoIdentidad();
                tipoDocumentoIdentidad.Nombre = nombre.ToUpper();
                tipoDocumentoIdentidad.Abreviatura = nombre.ToUpper();
                tipoDocumentoIdentidad._id = await consultas.SetTipoDocumentoIdentidad(tipoDocumentoIdentidad);
                if (tipoDocumentoIdentidad._id != null)
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
        public async Task<string> IngresoDepartamento(string nombre)
        {
            try
            {
                var departamento = new Departamento();
                var pais = new Pais();
                departamento.Nombre = nombre.ToUpper();
                departamento.Pais = await consultas.GetPaisId("636ad61dd758540753377341");
                departamento._id = await consultas.SetDepartamento(departamento);
                if (departamento._id != null)
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
        public async Task<string> IngresoProvincia(string nombre, string departamento)
        {
            try
            {
                var provincia = new Provincia();
                provincia.Nombre = nombre.ToUpper();
                provincia.Departamento = await consultas.GetDepartamentoId(departamento);
                provincia._id = await consultas.SetProvincia(provincia);

                if (provincia._id != null)
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
        public async Task<string> IngresoDistrito(string nombre, string provincia)
        {
            try
            {
                var distrito = new Distrito();
                distrito.Nombre = nombre.ToUpper();
                distrito.Provincia = await consultas.GetProvinciaId(provincia);
                distrito._id = await consultas.SetDistrito(distrito);

                if (distrito._id != null)
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
        public async Task<string> BusquedaCliente(string busqueda)
        {
            try
            {
                var busquedaRol = await consultas.GetBusquedaCliente(busqueda.ToUpper());
                return JsonConvert.SerializeObject(busquedaRol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BuscarClienteId(string id)
        {
            try
            {
                var cliente = await consultas.GetClienteId(id);
                return JsonConvert.SerializeObject(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaClienteLimite(string numelement, string busqueda)
        {
            try
            {
                if (busqueda == null || busqueda.Trim() == "")
                {
                    var busq = await consultas.GetAllClientesLimite(Convert.ToInt32(numelement));
                    return JsonConvert.SerializeObject(busq);
                }
                else
                {
                    var busq = await consultas.GetBusquedaClienteLimite(Convert.ToInt32(numelement), busqueda.ToUpper());
                    return JsonConvert.SerializeObject(busq);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaTipoDocumentos()
        {
            try
            {
                var tipodocumento = await consultas.GetAllTipoDocumentoIdentidad();
                return JsonConvert.SerializeObject(tipodocumento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaTipoDocumento(string busqueda)
        {
            try
            {
                var tipodocumento = await consultas.GetBusquedaTipoDocumentoIdentidad(busqueda.ToUpper());
                return JsonConvert.SerializeObject(tipodocumento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaDepartamento()
        {
            try
            {
                var departamento = await consultas.GetAllDepartamento();
                return JsonConvert.SerializeObject(departamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaDepartamento(string busqueda)
        {
            try
            {
                var departamento = await consultas.GetBusquedaDepartamento(busqueda.ToUpper());
                return JsonConvert.SerializeObject(departamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaProvinciaForDepartamento(string departamento)
        {
            try
            {
                var provincia = await consultas.GetProvinciaForDepartamento(departamento);
                return JsonConvert.SerializeObject(provincia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaProvincia(string busqueda, string departamento)
        {
            try
            {
                var provincia = await consultas.GetBusquedaProvincia(busqueda.ToUpper(), departamento);
                return JsonConvert.SerializeObject(provincia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> TablaDistritoForProvincia(string provincia)
        {
            try
            {
                var distrito = await consultas.GetDistritoForProvincia(provincia);
                return JsonConvert.SerializeObject(distrito);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> BusquedaDistrito(string busqueda, string provincia)
        {
            try
            {
                var distrito = await consultas.GetBusquedaDistrito(busqueda.ToUpper(), provincia);
                return JsonConvert.SerializeObject(distrito);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
