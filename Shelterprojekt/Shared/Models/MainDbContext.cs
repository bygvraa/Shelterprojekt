using MongoDB.Driver;
using System;

namespace Shelterprojekt.Shared.Models
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

        // henter shelters fra _mongoDatabase ("shelterdb")
        public IMongoCollection<Shelter> ShelterCollection
        {
            get
            {
                return _mongoDatabase.GetCollection<Shelter>("shelter_minus");
            }
        }

        // henter bookings fra _mongoDatabase ("shelterdb)
        public IMongoCollection<Booking> BookingCollection
        {
            get
            {
                return _mongoDatabase.GetCollection<Booking>("bookings");
            }
        }

    }
}
