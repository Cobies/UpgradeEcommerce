using UpgradeApi.Connection;
using UpgradeERP.Models.Personas;

namespace ApiEcommerce.Services
{
    public interface IPersonaServices
    {
        Task<string> SetPersona(Persona persona);
    }
    public class PersonaServices : IPersonaServices
    {
        private readonly ConnectionDB connection;
        public PersonaServices(ConnectionDB connection)
        {
            this.connection = connection;
        }

        public async Task<string> SetPersona(Persona persona)
        {
            try
            {
                var col = connection.Connect().GetCollection<Persona>("Persona");
                await col.InsertOneAsync(persona);
                return persona._id;
            }
            catch (Exception ex)
            {
                return null;

                throw ex;

            }
        }
    }
}
