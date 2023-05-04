using ApiEcommerce.ModelsHelpers;
using ApiEcommerce.Persistencia;
using UpgradeApi.Connection;
using UpgradeERP.Models.Personas;

namespace ApiEcommerce.Services
{

    public interface IClientesServices
    {
        Task<Cliente> GetAutentificacionCliente(Users cliente);
        Task<Cliente> GetClienteId(string id);
        Task<string> SetCliente(Cliente cliente);
        Task<Cliente> ValidacionClienteUnicoPorIdentificador(string tipodocument, string identificador);
        Task<Cliente> ValidacionPorCorreoElectronico(string correoelectronico);
    }


    public class ClientesServices : IClientesServices
    {
        private readonly ConnectionDB connection;
        private readonly ClientePersistencia clienteP;
        public ClientesServices(ConnectionDB connection, ClientePersistencia clientePersistencia)
        {

            this.connection = connection;
            this.clienteP = clientePersistencia;
        }


        public async Task<Cliente> GetAutentificacionCliente(Users cliente)
        {
            try
            {
                return await clienteP.GetAutentificacionCliente(cliente);
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
                return await clienteP.SetCliente(cliente);
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
                return await clienteP.ValidacionClienteUnicoPorIdentificador(tipodocumento, identificador);
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
                return await clienteP.ValidacionPorCorreoElectronico(correoelectronico);
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
                return await clienteP.GetClienteId(id);
            }
            catch (Exception ex)
            {
                return null;

                throw ex;
            }
        }



    }
}
