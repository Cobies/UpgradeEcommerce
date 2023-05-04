using MongoDB.Driver;
using UpgradeERP.Models.Empleados;
using UpgradeERP.Models.Finanzas;
using UpgradeERP.Models.Helpers;
using UpgradeERP.Models.Logistica;
using UpgradeERP.Models.Personas;
using UpgradeERP.Models.SoporteTecnico;
using UpgradeERP.Models.Sucursales;
using UpgradeERP.Models.Ubicacion;
using UpgradeERP.Models.Ventas;

namespace UpgradeERP.Servicios
{
    public class Consultas
    {


        private IMongoDatabase Connect()
        {
            try
            {

                //var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:admin@grupoupgrade.a4bgtb7.mongodb.net/?retryWrites=true&w=majority");
                //var client = new MongoClient(settings);
                //var database = client.GetDatabase("upgrade");

                var settings = MongoClientSettings.FromConnectionString("mongodb+srv://admin:admin@grupoupgrade.a4bgtb7.mongodb.net/?retryWrites=true&w=majority");
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);
                var client = new MongoClient(settings);
                var database = client.GetDatabase("upgrade");



                return database;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get

        public async Task<List<ReporteGarantia>> GetReporteGarantia(string nombre)
        {
            try
            {
                var col = Connect().GetCollection<ReporteGarantia>("ReporteGarantia");
                var filtro = Builders<ReporteGarantia>.Filter;
                var filcon = filtro.Where(p => p.Cliente.Persona.Nombre.Contains(nombre) || p.Articulo.Producto.Nombre.Contains(nombre) || p.Encargado.NombreUsuario.Contains(nombre) || p.Almacen.Nombre.Contains(nombre) || p.Descripcion.Contains(nombre));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReporteTecnico> GetReporteTecnicoId(string id)
        {
            try
            {
                var col = Connect().GetCollection<ReporteTecnico>("ReporteTecnico");
                var filtro = Builders<ReporteTecnico>.Filter;
                var filcon = filtro.Where(p => p._id == id);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Recibo> GetReciboId(string id)
        {
            try
            {
                var col = Connect().GetCollection<Recibo>("Recibo");
                var filtro = Builders<Recibo>.Filter;
                var filcon = filtro.Where(p => p._id == id);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReporteGarantia> GetReporteGarantiaId(string id)
        {
            try
            {
                var col = Connect().GetCollection<ReporteGarantia>("ReporteGarantia");
                var filtro = Builders<ReporteGarantia>.Filter;
                var filcon = filtro.Where(p => p._id == id);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ReporteGarantia>> GetAllReporteGarantias()
        {
            try
            {
                var col = Connect().GetCollection<ReporteGarantia>("ReporteGarantia");
                var filtro = Builders<ReporteGarantia>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ReporteTecnico>> GetAllReporteServicioTecnico(int pagina)
        {
            try
            {
                var col = Connect().GetCollection<ReporteTecnico>("ReporteTecnico");
                var filtro = Builders<ReporteTecnico>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(pagina).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ReporteTecnico>> GetBusquedaReporteTecnico(string nombre)
        {
            try
            {
                var col = Connect().GetCollection<ReporteTecnico>("ReporteTecnico");
                var filtro = Builders<ReporteTecnico>.Filter;
                var filcon = filtro.Where(p => p.Encargado.NombreUsuario.Contains(nombre) || p.Cliente.Persona.Nombre.Contains(nombre) || p.Articulo.Producto.Nombre.Contains(nombre) || p.Fallas.Contains(nombre) || p.Resultado.Contains(nombre) || p.ObjetosDejados.Contains(nombre));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NotaPedido> GetNotaPedidoId(string id)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p._id == id);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NotaPedido>> GetAllNotaPedido()
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<NotaPedido>> GetNotaPedidoLimite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p.Numero).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public async Task<List<NotaPedido>> GetAllNotaPedidoNoDescargadoLimite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NotaPedido>> GetBusquedaNotaPedidoNoDescargadoLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p.Descargado == false && (p.Numero == Convert.ToInt32(busqueda) || p.Almacen.Nombre.Contains(busqueda) || p.Cliente.Persona.Nombre.Contains(busqueda)));
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            try
            {
                var col = Connect().GetCollection<Cliente>("Cliente");
                var filtro = Builders<Cliente>.Filter;
                var filcon = filtro.Where(p => p._id != null && p.Persona.Distrito == null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> GetClienteId(string cliente)
        {
            try
            {
                var col = Connect().GetCollection<Cliente>("Cliente");
                var filtro = Builders<Cliente>.Filter;
                var filcon = filtro.Where(p => p._id == cliente);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TipoDocumentoIdentidad>> GetAllTipoDocumentoIdentidad()
        {
            try
            {
                var col = Connect().GetCollection<TipoDocumentoIdentidad>("TipoDocumentoIdentidad");
                var filtro = Builders<TipoDocumentoIdentidad>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Departamento>> GetAllDepartamento()
        {
            try
            {
                var col = Connect().GetCollection<Departamento>("Departamento");
                var filtro = Builders<Departamento>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Distrito> GetDistritoId(string distrito)
        {
            try
            {
                var col = Connect().GetCollection<Distrito>("Distrito");
                var filtro = Builders<Distrito>.Filter;
                var filcon = filtro.Where(p => p._id == distrito);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Distrito> GetDistritoUbigeo(string ubigeo)
        {
            try
            {
                var col = Connect().GetCollection<Distrito>("Distrito");
                var filtro = Builders<Distrito>.Filter;
                var filcon = filtro.Where(p => p.Ubigeo == ubigeo);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TipoDocumentoIdentidad> GetTipoDocumentoIdentidadId(string tipodocumento)
        {
            try
            {
                var col = Connect().GetCollection<TipoDocumentoIdentidad>("TipoDocumentoIdentidad");
                var filtro = Builders<TipoDocumentoIdentidad>.Filter;
                var filcon = filtro.Where(p => p._id == tipodocumento);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Provincia>> GetBusquedaProvincia(string busqueda, string departamento)
        {
            try
            {
                var col = Connect().GetCollection<Provincia>("Provincia");
                var filtro = Builders<Provincia>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda) && p.Departamento._id == departamento);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Provincia>> GetAllProvincia()
        {
            try
            {
                var col = Connect().GetCollection<Provincia>("Provincia");
                var filtro = Builders<Provincia>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            try
            {
                var col = Connect().GetCollection<Producto>("Producto");
                var filtro = Builders<Producto>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<Producto>> GetProductosLimite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<Producto>("Producto");
                var filtro = Builders<Producto>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }




        public async Task<List<Cliente>> GetBusquedaClienteLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Cliente>("Cliente");
                var filtro = Builders<Cliente>.Filter;
                var filcon = filtro.Where(p => p.Persona.Nombre.Contains(busqueda) || p.Persona.DocumentoIdentidad.Contains(busqueda) || p.Persona.TipoDocumentoIdentidad.Nombre.Contains(busqueda) || p.Persona.Direccion.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<Recibo>> GetAllTransferenciaLimite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<Recibo>("Recibo");
                var filtro = Builders<Recibo>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<Recibo>> GetBusquedaTransferenciaLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Recibo>("Recibo");
                var filtro = Builders<Recibo>.Filter;
                var filcon = filtro.Where(p => p.Notapedido.Numero == Convert.ToInt32(busqueda) || p.DepositoCliente.Operacion.Contains(busqueda) || p.DepositoCliente.AprobadoPorEmpleado.Persona.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }




        public async Task<List<Cliente>> GetAllClientesLimite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<Cliente>("Cliente");
                var filtro = Builders<Cliente>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public async Task<List<Empleado>> GetAllEmpleadosActivos()
        {
            try
            {
                var col = Connect().GetCollection<Empleado>("Empleado");
                var filtro = Builders<Empleado>.Filter;
                var filcon = filtro.Where(p => p._id != null && p.Activo == true);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<ClienteVendedor>> GetAccionesEmpleado()
        {
            try
            {
                var col = Connect().GetCollection<ClienteVendedor>("ClienteVendedor");
                var filtro = Builders<ClienteVendedor>.Filter;
                var filcon = filtro.Where(p => p.Vendedor.Activo == true);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<List<FormaDePago>> GetAllFormaDePago()
        {
            try
            {
                var col = Connect().GetCollection<FormaDePago>("FormaDePago");
                var filtro = Builders<FormaDePago>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Distrito>> GetAllDistrito()
        {
            try
            {
                var col = Connect().GetCollection<Distrito>("Distrito");
                var filtro = Builders<Distrito>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Almacen>> GetAllAlmacen()
        {
            try
            {
                var col = Connect().GetCollection<Almacen>("Almacen");
                var filtro = Builders<Almacen>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Distrito>> GetBusquedaDistrito(string busqueda, string provincia)
        {
            try
            {
                var col = Connect().GetCollection<Distrito>("Distrito");
                var filtro = Builders<Distrito>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda) && p.Provincia._id == provincia);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Distrito>> GetDistritoForProvincia(string provincia)
        {
            try
            {
                var col = Connect().GetCollection<Distrito>("Distrito");
                var filtro = Builders<Distrito>.Filter;
                var filcon = filtro.Where(p => p.Provincia._id == provincia);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteVendedor>> GetClienteVendedorForVendedor(string id)
        {
            try
            {
                var col = Connect().GetCollection<ClienteVendedor>("ClienteVendedor");
                var filtro = Builders<ClienteVendedor>.Filter;
                var filcon = filtro.Where(p => p.Vendedor._id == id);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TipoDocumentoIdentidad>> GetBusquedaTipoDocumentoIdentidad(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<TipoDocumentoIdentidad>("TipoDocumentoIdentidad");
                var filtro = Builders<TipoDocumentoIdentidad>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda) || p.Abreviatura.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Cliente>> GetBusquedaCliente(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Cliente>("Cliente");
                var filtro = Builders<Cliente>.Filter;
                var filcon = filtro.Where(p => p.Persona.Nombre.Contains(busqueda) || p.Persona.DocumentoIdentidad.Contains(busqueda) || p.Persona.TipoDocumentoIdentidad.Nombre.Contains(busqueda) || p.Persona.Direccion.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Provincia>> GetProvinciaForDepartamento(string departamento)
        {
            try
            {
                var col = Connect().GetCollection<Provincia>("Provincia");
                var filtro = Builders<Provincia>.Filter;
                var filcon = filtro.Where(p => p.Departamento._id == departamento);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ClienteVendedor>> GetSemaforoVendedor(string idvendedor)
        {
            try
            {
                var col = Connect().GetCollection<ClienteVendedor>("ClienteVendedor");
                var filtro = Builders<ClienteVendedor>.Filter;
                var filcon = filtro.Where(p => p.Vendedor._id == idvendedor);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ClienteVendedor>> GetAllClienteVendedor(Empleado lista)
        {
            try
            {
                var col = Connect().GetCollection<ClienteVendedor>("ClienteVendedor");
                var filtro = Builders<ClienteVendedor>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Articulo>> GetArticulosForProducto(string id)
        {
            try
            {
                var col = Connect().GetCollection<Articulo>("Articulo");
                var filtro = Builders<Articulo>.Filter;
                var filcon = filtro.Where(p => p.Producto._id == id && p.Almacen != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<long> GetCantStock(string id)
        {
            try
            {
                var col = Connect().GetCollection<Articulo>("Articulo");
                var filtro = Builders<Articulo>.Filter;
                var filcon = filtro.Where(p => p.Producto._id == id && p.Almacen != null);
                var result = await col.Find(filcon).CountAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Marca>> GetBusquedaMarca(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Marca>("Marca");
                var filtro = Builders<Marca>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda) || p.Abreviatura.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Marca>> GetAllMarca()
        {
            try
            {
                var col = Connect().GetCollection<Marca>("Marca");
                var filtro = Builders<Marca>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Persona> GetPersonaId(string persona)
        {
            try
            {
                var col = Connect().GetCollection<Persona>("Persona");
                var filtro = Builders<Persona>.Filter;
                var filcon = filtro.Where(p => p._id == persona);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RolDeUsuario> GetRolDeUsuarioId(string roldeusuario)
        {
            try
            {
                var col = Connect().GetCollection<RolDeUsuario>("RolDeUsuario");
                var filtro = Builders<RolDeUsuario>.Filter;
                var filcon = filtro.Where(p => p._id == roldeusuario);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Linea>> GetBusquedaLinea(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Linea>("Linea");
                var filtro = Builders<Linea>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda) || p.Descripcion.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Linea>> GetAllLinea()
        {
            try
            {
                var col = Connect().GetCollection<Linea>("Linea");
                var filtro = Builders<Linea>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Unidad>> GetAllUnidad()
        {
            try
            {
                var col = Connect().GetCollection<Unidad>("Unidad");
                var filtro = Builders<Unidad>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Persona>> GetAllPersonas()
        {
            try
            {
                var col = Connect().GetCollection<Persona>("Persona");
                var filtro = Builders<Persona>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Persona>> GetBusquedaPersona(string personabusqueda)
        {
            try
            {
                var col = Connect().GetCollection<Persona>("Persona");
                var filtro = Builders<Persona>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(personabusqueda) || p.DocumentoIdentidad.Contains(personabusqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Acciones> GetAccionId(string v)
        {
            try
            {
                var col = Connect().GetCollection<Acciones>("Acciones");
                var filtro = Builders<Acciones>.Filter;
                var filcon = filtro.Where(p => p._id == v);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ClienteVendedor> GetClienteVendedorId(string v)
        {
            try
            {
                var col = Connect().GetCollection<ClienteVendedor>("ClienteVendedor");
                var filtro = Builders<ClienteVendedor>.Filter;
                var filcon = filtro.Where(p => p._id == v);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Unidad>> GetBusquedaUnidad(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Unidad>("Unidad");
                var filtro = Builders<Unidad>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda) || p.Abreviatura.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Moneda>> GetAllMoneda()
        {
            try
            {
                var col = Connect().GetCollection<Moneda>("Moneda");
                var filtro = Builders<Moneda>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Moneda>> GetBusquedaMoneda(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Moneda>("Moneda");
                var filtro = Builders<Moneda>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Empleado>> GetAllEmpleadoLimite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<Empleado>("Empleado");
                var filtro = Builders<Empleado>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p.FechaRegistro).Skip(numelement).Limit(500).ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Empleado>> GetBusquedaEmpleadoLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Empleado>("Empleado");
                var filtro = Builders<Empleado>.Filter;
                var filcon = filtro.Where(p => p.NombreUsuario.Contains(busqueda) || p.Persona.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p.FechaRegistro).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Persona> GetPersonaIdentificador(string identificador)
        {
            try
            {
                var col = Connect().GetCollection<Persona>("Persona");
                var filtro = Builders<Persona>.Filter;
                var filcon = filtro.Where(p => p.DocumentoIdentidad == identificador);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Impuesto>> GetAllImpuesto()
        {
            try
            {
                var col = Connect().GetCollection<Impuesto>("Impuesto");
                var filtro = Builders<Impuesto>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Impuesto>> GetBusquedaImpuesto(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Impuesto>("Impuesto");
                var filtro = Builders<Impuesto>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DocumentoTipo> GetDocumentoTipoId(string documentotipo)
        {
            try
            {
                var col = Connect().GetCollection<DocumentoTipo>("DocumentoTipo");
                var filtro = Builders<DocumentoTipo>.Filter;
                var filcon = filtro.Where(p => p._id == documentotipo);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<SolicitudCompra>> GetAllSolicitudCompra()
        {
            try
            {
                var col = Connect().GetCollection<SolicitudCompra>("SolicitudCompra");
                var filtro = Builders<SolicitudCompra>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Articulo>> GetSeriesByProducto(string idproducto)
        {
            try
            {
                var col = Connect().GetCollection<Articulo>("Articulo");
                var filtro = Builders<Articulo>.Filter;
                var filcon = filtro.Where(p => p.Producto._id == idproducto && p.Almacen != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Almacen>> GetBusquedaAlmacen(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Almacen>("Almacen");
                var filtro = Builders<Almacen>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda) || p.Abreviatura.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SolicitudCompra>> GetBusquedaSolicitudCompra(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<SolicitudCompra>("SolicitudCompra");
                var filtro = Builders<SolicitudCompra>.Filter;
                var filcon = filtro.Where(p => p.Producto.Nombre.Contains(busqueda) || p.Producto.Codigo.Contains(busqueda) || p.Almacen.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SolicitudCompra>> GetAllSolicitudCompraLiomite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<SolicitudCompra>("SolicitudCompra");
                var filtro = Builders<SolicitudCompra>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p.Fecha).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SolicitudCompra>> GetBusquedaSolicitudCompraLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<SolicitudCompra>("SolicitudCompra");
                var filtro = Builders<SolicitudCompra>.Filter;
                var filcon = filtro.Where(p => p.Producto.Nombre.Contains(busqueda) || p.Producto.Codigo.Contains(busqueda) || p.Almacen.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p.Fecha).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NotaPedido>> GetAllDescargaProductoLimite(int numelement)
        {
            try { 
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p._id != null && p.Descargado == false);
                var result = await col.Find(filcon).SortByDescending(p => p.Fecha).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NotaPedido>> GetBusquedaDescargaProductoLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p._id != null && p.Descargado == false && p.Numero == Convert.ToInt32(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p.Fecha).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<NotaPedido>> GetBusquedaNotaPedidoLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p.Numero == Convert.ToInt32(busqueda) || p.Almacen.Nombre.Contains(busqueda) || p.Cliente.Persona.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p.Numero).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Cheque>> GetBusquedaChequesLimite(int numelement, string busqueda)
        {

            try
            {
                var col = Connect().GetCollection<Cheque>("NotaPedido");
                var filtro = Builders<Cheque>.Filter;
                var filcon = filtro.Where(p => p.Numero == Convert.ToInt32(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p.Numero).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
                   
            }
        }

        public async Task<List<Cheque>> GetChequesLimite(int numelement)
        {

            try
            {
                var col = Connect().GetCollection<Cheque>("NotaPedido");
                var filtro = Builders<Cheque>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p.Numero).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public async Task<List<Producto>> GetBusquedaProductoLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Producto>("Producto");
                var filtro = Builders<Producto>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda) || p.Codigo.Contains(busqueda) || p.Descripcion.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NotaPedido>> GetBusquedaNotaPedidoNoDescargado(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p.Descargado == false && (p.Numero == Convert.ToInt32(busqueda) || p.Almacen.Nombre.Contains(busqueda) || p.Cliente.Persona.Nombre.Contains(busqueda)));
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NotaPedido>> GetAllNotaPedidoNoDescargado()
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p._id != null && p.Descargado == false);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Departamento>> GetBusquedaDepartamento(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Departamento>("Departamento");
                var filtro = Builders<Departamento>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<FacturasCompra>> GetBusquedaEntradaProducto(string busqueda)
        {

            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                var filtro = Builders<FacturasCompra>.Filter;
                var filcon = filtro.Where(p => p.Ingresado == false && (p.Almacen.Nombre.Contains(busqueda) || p.Numero.Contains(busqueda) || p.Proveedor.Persona.Nombre.Contains(busqueda)));
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<FacturasCompra>> GetAllEntradaProducto()
        {
            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                var filtro = Builders<FacturasCompra>.Filter;
                var filcon = filtro.Where(p => p._id != null && p.Ingresado == false);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Articulo> GetArticuloId(string articulo)
        {
            try
            {
                var col = Connect().GetCollection<Articulo>("Articulo");
                var filtro = Builders<Articulo>.Filter;
                var filcon = filtro.Where(p => p._id == articulo);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Articulo> GetArticuloForSerie(string articulo)
        {
            try
            {
                var col = Connect().GetCollection<Articulo>("Articulo");
                var filtro = Builders<Articulo>.Filter;
                var filcon = filtro.Where(p => p.Serie == articulo);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<NotaPedido>> GetAllDescargaProducto()
        {

            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p._id != null && p.Descargado == false);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<NotaPedido>> GetBusquedaDescargaProducto(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p._id != null && p.Descargado == false);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FacturasCompra> GetFacturasCompraId(string facturaCompra)
        {
            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                var filtro = Builders<FacturasCompra>.Filter;
                var filcon = filtro.Where(p => p._id == facturaCompra);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Producto>> GetBusquedaProducto(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Producto>("Producto");
                var filtro = Builders<Producto>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda) || p.Codigo.Contains(busqueda) || p.Descripcion.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Empleado> GetEmpleadoId(string empleado)
        {
            try
            {
                var col = Connect().GetCollection<Empleado>("Empleado");
                var filtro = Builders<Empleado>.Filter;
                var filcon = filtro.Where(p => p._id == empleado);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Almacen> GetAlmacenId(string almacen)
        {
            try
            {
                var col = Connect().GetCollection<Almacen>("Almacen");
                var filtro = Builders<Almacen>.Filter;
                var filcon = filtro.Where(p => p._id == almacen);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<NotaPedido>> GetBusquedaNotaPedido(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                var filtro = Builders<NotaPedido>.Filter;
                var filcon = filtro.Where(p => p.Numero == Convert.ToInt32(busqueda) || p.Almacen.Nombre.Contains(busqueda) || p.Cliente.Persona.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FacturasCompra>> GetBusquedaFacturasCompra(string busqueda)
        {

            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                var filtro = Builders<FacturasCompra>.Filter;
                var filcon = filtro.Where(p => p.Almacen.Nombre.Contains(busqueda) || p.Numero.Contains(busqueda) || p.Proveedor.Persona.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Empleado> GetEmpleadoForUsuarioAndPassword(string usuario, string password)
        {
            try
            {
                var col = Connect().GetCollection<Empleado>("Empleado");
                var filtro = Builders<Empleado>.Filter;
                var filcon = filtro.Where(p => p.NombreUsuario.ToUpper() == usuario && p.Pass == password);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<FacturasCompra>> GetBusquedaFacturasCompraLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                var filtro = Builders<FacturasCompra>.Filter;
                var filcon = filtro.Where(p => p.Almacen.Nombre.Contains(busqueda) || p.Numero.Contains(busqueda) || p.Proveedor.Persona.Nombre.Contains(busqueda)); var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                var resul = await col.Find(filcon).SortByDescending(p => p.FechaCreado).Skip(numelement).Limit(20).ToListAsync();
                return resul;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FacturasCompra>> GetBusquedaEntradaProductoLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                var filtro = Builders<FacturasCompra>.Filter;
                var filcon = filtro.Where(p => p.Ingresado == false && (p.Almacen.Nombre.Contains(busqueda) || p.Numero.Contains(busqueda) || p.Proveedor.Persona.Nombre.Contains(busqueda)));
                var result = await col.Find(filcon).SortByDescending(p => p.FechaCreado).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FacturasCompra>> GetAllEntradaProductoLimite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                var filtro = Builders<FacturasCompra>.Filter;
                var filcon = filtro.Where(p => p.Ingresado == false && p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p.FechaCreado).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<FacturasCompra>> GetAllFacturasCompraLimite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                var filtro = Builders<FacturasCompra>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p.FechaCreado).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FormaDePago>> GetBusquedaFormaDePago(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<FormaDePago>("FormaDePago");
                var filtro = Builders<FormaDePago>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FacturasCompra>> GetAllFacturasCompra()
        {
            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                var filtro = Builders<FacturasCompra>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Empleado> GetVendedorId(string vendedor)
        {
            try
            {
                var col = Connect().GetCollection<Empleado>("Empleado");
                var filtro = Builders<Empleado>.Filter;
                var filcon = filtro.Where(p => p._id == vendedor);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pais> GetPaisId(string pais)
        {
            try
            {
                var col = Connect().GetCollection<Pais>("Pais");
                var filtro = Builders<Pais>.Filter;
                var filcon = filtro.Where(p => p._id == pais);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Moneda> GetMonedaId(string moneda)
        {
            try
            {
                var col = Connect().GetCollection<Moneda>("Moneda");
                var filtro = Builders<Moneda>.Filter;
                var filcon = filtro.Where(p => p._id == moneda);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Marca> GetMarcaId(string marca)
        {
            try
            {
                var col = Connect().GetCollection<Marca>("Marca");
                var filtro = Builders<Marca>.Filter;
                var filcon = filtro.Where(p => p._id == marca);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrdenCompra>> GetAllOrdenCompraLimite(int numelement)
        {
            try
            {
                var col = Connect().GetCollection<OrdenCompra>("OrdenCompra");
                var filtro = Builders<OrdenCompra>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p.Fecha).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrdenCompra>> GetBusquedaOrdenCompraLimite(int numelement, string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<OrdenCompra>("OrdenCompra");
                var filtro = Builders<OrdenCompra>.Filter;
                var filcon = filtro.Where(p => p.Numero == Convert.ToInt32(busqueda) || p.FormaDePago.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p.Fecha).Skip(numelement).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<OrdenCompra>> GetBusquedaOrdenCompra(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<OrdenCompra>("OrdenCompra");
                var filtro = Builders<OrdenCompra>.Filter;
                var filcon = filtro.Where(p => p.Numero == Convert.ToInt32(busqueda) || p.FormaDePago.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Linea> GetLineaId(string linea)
        {
            try
            {
                var col = Connect().GetCollection<Linea>("Linea");
                var filtro = Builders<Linea>.Filter;
                var filcon = filtro.Where(p => p._id == linea);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Unidad> GetUnidadId(string unidad)
        {
            try
            {
                var col = Connect().GetCollection<Unidad>("Unidad");
                var filtro = Builders<Unidad>.Filter;
                var filcon = filtro.Where(p => p._id == unidad);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Impuesto> GetImpuestoId(string impuesto)
        {
            try
            {
                var col = Connect().GetCollection<Impuesto>("Impuesto");
                var filtro = Builders<Impuesto>.Filter;
                var filcon = filtro.Where(p => p._id == impuesto);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Sede>> GetAllSede()
        {
            try
            {
                var col = Connect().GetCollection<Sede>("Sede");
                var filtro = Builders<Sede>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Sede>> GetBusquedaSede(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<Sede>("Sede");
                var filtro = Builders<Sede>.Filter;
                var filcon = filtro.Where(p => p.Nombre.Contains(busqueda));
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Producto> GetProductoId(string producto)
        {
            try
            {
                var col = Connect().GetCollection<Producto>("Producto");
                var filtro = Builders<Producto>.Filter;
                var filcon = filtro.Where(p => p._id == producto);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Sede> GetSedeId(string sede)
        {
            try
            {
                var col = Connect().GetCollection<Sede>("Sede");
                var filtro = Builders<Sede>.Filter;
                var filcon = filtro.Where(p => p._id == sede);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrdenCompra>> GetAllOrdenCompra()
        {
            try
            {
                var col = Connect().GetCollection<OrdenCompra>("OrdenCompra");
                var filtro = Builders<OrdenCompra>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<FormaDePago> GetFormaDePagoId(string formadepago)
        {
            try
            {
                var col = Connect().GetCollection<FormaDePago>("FormaDePago");
                var filtro = Builders<FormaDePago>.Filter;
                var filcon = filtro.Where(p => p._id == formadepago);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<NotaPedidoDetalle> GetNotaPedidoDetalleId(string notapedidodetalle)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedidoDetalle>("NotaPedidoDetalle");
                var filtro = Builders<NotaPedidoDetalle>.Filter;
                var filcon = filtro.Where(p => p._id == notapedidodetalle);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Departamento> GetDepartamentoId(string departamento)
        {
            try
            {
                var col = Connect().GetCollection<Departamento>("Departamento");
                var filtro = Builders<Departamento>.Filter;
                var filcon = filtro.Where(p => p._id == departamento);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GuiasRemision>> GetBusquedaGuiasRemision(string busqueda)
        {
            try
            {
                var col = Connect().GetCollection<GuiasRemision>("GuiasRemision");
                var filtro = Builders<GuiasRemision>.Filter;
                var filcon = filtro.Where(p => p._id == busqueda);
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(0).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GuiasRemision>> GetAllGuiasRemision()
        {
            try
            {
                var col = Connect().GetCollection<GuiasRemision>("GuiasRemision");
                var filtro = Builders<GuiasRemision>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).SortByDescending(p => p._id).Skip(0).Limit(20).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<Provincia> GetProvinciaId(string provincia)
        {
            try
            {
                var col = Connect().GetCollection<Provincia>("Provincia");
                var filtro = Builders<Provincia>.Filter;
                var filcon = filtro.Where(p => p._id == provincia);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Set

        public async Task<string> SetReporteGarantia(ReporteGarantia reporteGarantia)
        {
            try
            {
                var col = Connect().GetCollection<ReporteGarantia>("ReporteGarantia");
                await col.InsertOneAsync(reporteGarantia);
                return reporteGarantia._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetReporteServicioTecnico(ReporteTecnico reporteServicioTecnico)
        {
            try
            {
                var col = Connect().GetCollection<ReporteTecnico>("ReporteTecnico");
                await col.InsertOneAsync(reporteServicioTecnico);
                return reporteServicioTecnico._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetNotaPedido(NotaPedido nota)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedido>("NotaPedido");
                await col.InsertOneAsync(nota);
                return nota._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetPais(Pais pais)
        {
            try
            {
                var col = Connect().GetCollection<Pais>("Pais");
                await col.InsertOneAsync(pais);
                return pais._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetFormaDePago(FormaDePago formadepago)
        {
            try
            {
                var col = Connect().GetCollection<FormaDePago>("FormaDePago");
                await col.InsertOneAsync(formadepago);
                return formadepago._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetPersona(Persona persona)
        {
            try
            {
                var col = Connect().GetCollection<Persona>("Persona");
                await col.InsertOneAsync(persona);
                return persona._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> SetDetalle(ClienteVendedorDetalle detalle)
        {
            try
            {
                var col = Connect().GetCollection<ClienteVendedorDetalle>("ClienteVendedorDetalle");
                await col.InsertOneAsync(detalle);
                return detalle._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetCliente(Cliente cliente)
        {
            try
            {
                var col = Connect().GetCollection<Cliente>("Cliente");
                await col.InsertOneAsync(cliente);
                return cliente._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetTipoDocumentoIdentidad(TipoDocumentoIdentidad tipoDocumentoIdentidad)
        {
            try
            {
                var col = Connect().GetCollection<TipoDocumentoIdentidad>("TipoDocumentoIdentidad");
                await col.InsertOneAsync(tipoDocumentoIdentidad);
                return tipoDocumentoIdentidad._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetProducto(Producto producto)
        {
            try
            {
                var col = Connect().GetCollection<Producto>("Producto");
                await col.InsertOneAsync(producto);
                return producto._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> SetNotaPedidoDetalle(NotaPedidoDetalle notapedidodetalle)
        {
            try
            {
                var col = Connect().GetCollection<NotaPedidoDetalle>("NotaPedidoDetalle");
                await col.InsertOneAsync(notapedidodetalle);
                return notapedidodetalle._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<string> SetProvincia(Provincia provincia)
        {
            try
            {
                var col = Connect().GetCollection<Provincia>("Provincia");
                await col.InsertOneAsync(provincia);
                return provincia._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetFacturasCompraDetalle(FacturasCompraDetalle compraDetalle)
        {
            try
            {
                var col = Connect().GetCollection<FacturasCompraDetalle>("FacturasCompraDetalle");
                await col.InsertOneAsync(compraDetalle);
                return compraDetalle._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetRolDeUsuario(RolDeUsuario rolDeUsuario)
        {
            try
            {
                var col = Connect().GetCollection<RolDeUsuario>("RolDeUsuario");
                await col.InsertOneAsync(rolDeUsuario);
                return rolDeUsuario._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetFacturasCompra(FacturasCompra factura)
        {
            try
            {
                var col = Connect().GetCollection<FacturasCompra>("FacturasCompra");
                await col.InsertOneAsync(factura);
                return factura._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<string> SetDistrito(Distrito distrito)
        {
            try
            {
                var col = Connect().GetCollection<Distrito>("Distrito");
                await col.InsertOneAsync(distrito);
                return distrito._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetClienteVendedor(ClienteVendedor clienteVendedor)
        {
            try
            {
                var col = Connect().GetCollection<ClienteVendedor>("ClienteVendedor");
                await col.InsertOneAsync(clienteVendedor);
                return clienteVendedor._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetMarca(Marca marca)
        {
            try
            {
                var col = Connect().GetCollection<Marca>("Marca");
                await col.InsertOneAsync(marca);
                return marca._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> SetSede(Sede sede)
        {
            try
            {
                var col = Connect().GetCollection<Sede>("Sede");
                await col.InsertOneAsync(sede);
                return sede._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> SetLinea(Linea linea)
        {
            try
            {
                var col = Connect().GetCollection<Linea>("Linea");
                await col.InsertOneAsync(linea);
                return linea._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> SetOrdenCompraDetalle(OrdenCompraDetalle ordenCompraDetalle)
        {
            try
            {
                var col = Connect().GetCollection<OrdenCompraDetalle>("OrdenCompraDetalle");
                await col.InsertOneAsync(ordenCompraDetalle);
                return ordenCompraDetalle._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetOrdenCompra(OrdenCompra ordencompra)
        {
            try
            {
                var col = Connect().GetCollection<OrdenCompra>("OrdenCompra");
                await col.InsertOneAsync(ordencompra);
                return ordencompra._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetUnidad(Unidad unidad)
        {
            try
            {
                var col = Connect().GetCollection<Unidad>("Unidad");
                await col.InsertOneAsync(unidad);
                return unidad._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetCargaYDescargaProductos(CargaYDescargaProductos descarga)
        {
            try
            {
                var col = Connect().GetCollection<CargaYDescargaProductos>("CargaYDescargaProductos");
                await col.InsertOneAsync(descarga);
                return descarga._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetArticulo(Articulo articulo)
        {
            try
            {
                var col = Connect().GetCollection<Articulo>("Articulo");
                await col.InsertOneAsync(articulo);
                return articulo._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetCargaYDescargaProductosDetalle(CargaYDescargaProductosDetalle des)
        {
            try
            {
                var col = Connect().GetCollection<CargaYDescargaProductosDetalle>("CargaYDescargaProductosDetalle");
                await col.InsertOneAsync(des);
                return des._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<string> SetAlmacen(Almacen almacen)
        {
            try
            {
                var col = Connect().GetCollection<Almacen>("Almacen");
                await col.InsertOneAsync(almacen);
                return almacen._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> SetMoneda(Moneda moneda)
        {
            try
            {
                var col = Connect().GetCollection<Moneda>("Moneda");
                await col.InsertOneAsync(moneda);
                return moneda._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetImpuesto(Impuesto impuesto)
        {
            try
            {
                var col = Connect().GetCollection<Impuesto>("Impuesto");
                await col.InsertOneAsync(impuesto);
                return impuesto._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetSolicitudCompra(SolicitudCompra soli)
        {
            try
            {
                var col = Connect().GetCollection<SolicitudCompra>("SolicitudCompra");
                await col.InsertOneAsync(soli);
                return soli._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> SetDepartamento(Departamento departamento)
        {
            try
            {
                var col = Connect().GetCollection<Departamento>("Departamento");
                await col.InsertOneAsync(departamento);
                return departamento._id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Update

        public async Task<string> UpdateGarantia(ReporteGarantia reporteGarantia)
        {
            try
            {
                var con = Connect().GetCollection<ReporteGarantia>("ReporteGarantia");
                var fil = Builders<ReporteGarantia>.Filter.Where(p => p._id == reporteGarantia._id);
                await con.ReplaceOneAsync(fil, reporteGarantia);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateReporteTecnicoId(ReporteTecnico reporteTecnico)
        {
            try
            {
                var con = Connect().GetCollection<ReporteTecnico>("ReporteTecnico");
                var fil = Builders<ReporteTecnico>.Filter.Where(p => p._id == reporteTecnico._id);
                await con.ReplaceOneAsync(fil, reporteTecnico);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateNotaPedido(NotaPedido nota)
        {
            try
            {
                var con = Connect().GetCollection<NotaPedido>("NotaPedido");
                var fil = Builders<NotaPedido>.Filter.Where(p => p._id == nota._id);
                await con.ReplaceOneAsync(fil, nota);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateEmpleado(Empleado empleado)
        {
            try
            {
                var con = Connect().GetCollection<Empleado>("Empleado");
                var fil = Builders<Empleado>.Filter.Where(p => p._id == empleado._id);
                await con.ReplaceOneAsync(fil, empleado);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<string> UpdateArticulo(Articulo articulo)
        {
            try
            {
                var con = Connect().GetCollection<Articulo>("Articulo");
                var fil = Builders<Articulo>.Filter.Where(p => p._id == articulo._id);
                await con.ReplaceOneAsync(fil, articulo);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<string> UpdatePersona(Persona persona)
        {
            try
            {
                var con = Connect().GetCollection<Persona>("Persona");
                var fil = Builders<Persona>.Filter.Where(p => p._id == persona._id);
                await con.ReplaceOneAsync(fil, persona);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateProducto(Producto producto)
        {
            try
            {
                var con = Connect().GetCollection<Producto>("Producto");
                var fil = Builders<Producto>.Filter.Where(p => p._id == producto._id);
                await con.ReplaceOneAsync(fil, producto);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<string> UpdateClienteVendedor(ClienteVendedor clientevendedor)
        {
            try
            {
                var con = Connect().GetCollection<ClienteVendedor>("ClienteVendedor");
                var fil = Builders<ClienteVendedor>.Filter.Where(p => p._id == clientevendedor._id);
                await con.ReplaceOneAsync(fil, clientevendedor);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> UpdateCliente(Cliente cliente)
        {
            try
            {
                var con = Connect().GetCollection<Cliente>("Cliente");
                var fil = Builders<Cliente>.Filter.Where(p => p._id == cliente._id);
                await con.ReplaceOneAsync(fil, cliente);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<string> UpdateNotaPedidoDetalle(NotaPedidoDetalle det)
        {
            try
            {
                var con = Connect().GetCollection<NotaPedidoDetalle>("NotaPedidoDetalle");
                var fil = Builders<NotaPedidoDetalle>.Filter.Where(p => p._id == det._id);
                await con.ReplaceOneAsync(fil, det);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Delete

        public async Task<string> DeleteNotaPedidoDetalle(string notapedidodetalle)
        {
            try
            {
                var con = Connect().GetCollection<NotaPedidoDetalle>("NotaPedidoDetalle");
                var filtro = Builders<NotaPedidoDetalle>.Filter.Where(p => p._id == notapedidodetalle);
                await con.DeleteOneAsync(filtro);
                return "200";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> DeleteArticulo(string id)
        {
            try
            {
                var con = Connect().GetCollection<Articulo>("Articulo");
                var filtro = Builders<Articulo>.Filter.Where(p => p._id == id);
                await con.DeleteOneAsync(filtro);
                return "200";
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
