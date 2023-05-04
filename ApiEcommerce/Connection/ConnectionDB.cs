using MongoDB.Driver;

namespace UpgradeApi.Connection
{
    public class ConnectionDB
    {
        public ConnectionDB()
        {
        }

        public IMongoDatabase Connect()
        {
            try
            {
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

    }
}
