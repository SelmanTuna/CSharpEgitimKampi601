using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi601.Services
{
    public class MongoDbConnection
    {
        private IMongoDatabase _database;  // field örnekledik..

        public MongoDbConnection() // constractor (yapıcı method) oluşturduk.
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("CustomerDb_601");
        }

        public IMongoCollection<BsonDocument> GetCustomersCollection() // Customer classını bir koleksiyon olarak oluşturmak için method yazdık.
        {
            return _database.GetCollection<BsonDocument>("Customers");
        }
    }
}
