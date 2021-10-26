using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelterprojekt.Shared
{
    public class MainDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MainDbContext()
        {
            // create a mongodb client
            var client = new MongoClient("mongodb://127.0.0.1:27017/");

            // get shelter database from client
            _mongoDatabase = client.GetDatabase("shelterdb");
        }

        // get shelters from _mongoDatabase
        public IMongoCollection<Shelter> ShelterCollection
        {
            get
            {
                return _mongoDatabase.GetCollection<Shelter>("shelter_minus");
            }
        }

    }
}
