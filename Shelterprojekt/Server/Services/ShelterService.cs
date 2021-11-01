using Shelterprojekt.Shared.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Server.Services
{
    public class ShelterService
    {
        MainDbContext _db = new MainDbContext();


        // Get     - hent listen over alle shelters
        public async Task<List<Shelter>> GetShelters()
        {
            try
            {
                return await _db.ShelterCollection.Find(_ => true).ToListAsync().ConfigureAwait(false);
            }
            catch 
            {
                throw;
            }
        }

        // GET     - find specifik booking
        public async Task<Shelter> GetShelterById(string id)
        {
            try
            {
                FilterDefinition<Shelter> shelterFilter = Builders<Shelter>.Filter.Eq("Id", id);
                return await _db.ShelterCollection.FindSync(shelterFilter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

    }
}
