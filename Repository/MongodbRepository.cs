using MongoDB.Driver;
using System.Security.Authentication;

namespace ShopInventory.Repository
{
    public class MongodbRepository
    {
        public MongoClient client;
        public IMongoDatabase db;
        
        public MongodbRepository()
        {
            string connectionString = @"mongodb://robertlyucra:ZPPJhZElLpCuzjvdlca3UcszX0bY1s03E3D42rjowrbpo3kPZryUCakGwraFZcjUry4mzYeYLkcZACDb17R0aQ==@robertlyucra.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@robertlyucra@";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            client = new MongoClient(settings);
            db = client.GetDatabase("Inventory");
        }
    }
}
