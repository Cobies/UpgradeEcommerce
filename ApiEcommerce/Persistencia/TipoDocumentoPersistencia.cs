using MongoDB.Driver;
using UpgradeApi.Connection;
using UpgradeERP.Models.Helpers;

namespace ApiEcommerce.Persistencia
{
    public class TipoDocumentoPersistencia
    {
        private readonly ConnectionDB connection;

        public TipoDocumentoPersistencia(ConnectionDB connection)
        {
            this.connection = connection;
        }

        public async Task<List<TipoDocumentoIdentidad>> GetAllDocumentoTipo()
        {
            try
            {
                var col = connection.Connect().GetCollection<TipoDocumentoIdentidad>("TipoDocumentoIdentidad");
                var filtro = Builders<TipoDocumentoIdentidad>.Filter;
                var filcon = filtro.Where(p => p._id != null);
                var result = await col.Find(filcon).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public async Task<TipoDocumentoIdentidad> GetDocumentoTipoId(string id)
        {
            try
            {
                var col = connection.Connect().GetCollection<TipoDocumentoIdentidad>("TipoDocumentoIdentidad");
                var filtro = Builders<TipoDocumentoIdentidad>.Filter;
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
