using UpgradeApi.Connection;
using UpgradeERP.Models.Personas;

namespace ApiEcommerce.Persistencia
{
    public class PersonaPersistencia
    {

        private readonly ConnectionDB connection;

        public PersonaPersistencia(ConnectionDB connection)
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
