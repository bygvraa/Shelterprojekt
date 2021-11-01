using MongoDB.Driver;
using System;

namespace Shelterprojekt.Shared.Models
{
    public class MainDbContext
    {
        private readonly IMongoDatabase _mongoDatabase;


        public MainDbContext()
        {
            // Opretter en MongoDB-client med forbindelse til MongoDB Atlas
            var client = new MongoClient("mongodb+srv://admindb:6!bWGg_i62ugLEJ@cluster0.zvgfl.mongodb.net/shelterdb?retryWrites=true&w=majority");

            // Henter shelter-databasen fra client
            _mongoDatabase = client.GetDatabase("shelterdb");

        }



        // Henter shelters fra _mongoDatabase ("shelterdb")
        public IMongoCollection<Shelter> ShelterCollection
        {
            get
            {
                return _mongoDatabase.GetCollection<Shelter>("shelters");
            }
        }



        // Henter bookings fra _mongoDatabase ("shelterdb")
        public IMongoCollection<Booking> BookingCollection
        {
            get
            {
                return _mongoDatabase.GetCollection<Booking>("bookings");
            }
        }

    }
}
