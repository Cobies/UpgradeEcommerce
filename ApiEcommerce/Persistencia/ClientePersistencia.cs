using ApiEcommerce.ModelsHelpers;
using MongoDB.Driver;
using UpgradeApi.Connection;
using UpgradeERP.Models.Personas;

namespace ApiEcommerce.Persistencia
{
    public class ClientePersistencia
    {
        private readonly ConnectionDB connection;


        public ClientePersistencia(ConnectionDB connectionDB)
        {
            this.connection = connectionDB;
        }

        public async Task<Cliente> GetAutentificacionCliente(Users cliente)
        {
            try
            {
                var col = connection.Connect().GetCollection<Cliente>("Cliente");
                var filtro = Builders<Cliente>.Filter;
                var filcon = filtro.Where(p => (p.NombreUsuario == cliente.Nombre || p.Persona.Email == cliente.Nombre) && p.Pass == cliente.Password);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;

                throw ex;
            }
        }


        public async Task<string> SetCliente(Cliente cliente)
        {
            try
            {
                var col = connection.Connect().GetCollection<Cliente>("Cliente");
                await col.InsertOneAsync(cliente);
                return cliente._id;
            }
            catch (Exception ex)
            {
                return null;

                throw ex;
            }
        }

        public async Task<Cliente> ValidacionClienteUnicoPorIdentificador(string tipodocumento, string identificador)
        {
            try
            {
                var col = connection.Connect().GetCollection<Cliente>("Cliente");
                var filtro = Builders<Cliente>.Filter;
                var filcon = filtro.Where(p => p.Persona.TipoDocumentoIdentidad._id == tipodocumento && p.Persona.DocumentoIdentidad == identificador);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;

                throw ex;
            }
        }

        public async Task<Cliente> ValidacionPorCorreoElectronico(string correoelectronico)
        {
            try
            {
                var col = connection.Connect().GetCollection<Cliente>("Cliente");
                var filtro = Builders<Cliente>.Filter;
                var filcon = filtro.Where(p => p.Persona.Email == correoelectronico);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;

                throw ex;
            }
        }

        public async Task<Cliente> GetClienteId(string id)
        {
            try
            {
                var col = connection.Connect().GetCollection<Cliente>("Cliente");
                var filtro = Builders<Cliente>.Filter;
                var filcon = filtro.Where(p => p._id == id);
                var result = await col.Find(filcon).FirstOrDefaultAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;

                throw ex;
            }
        }

    }
}
