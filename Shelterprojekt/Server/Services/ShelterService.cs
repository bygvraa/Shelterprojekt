using Shelterprojekt.Shared.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Server.Services
{
    public class ShelterService
    {
        ShelterDatabaseContext _db = new ShelterDatabaseContext();


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

        // GET     - find specifik shelter
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

        // CREATE  - lav en ny shelter
        public async Task CreateShelter(Shelter shelter)
        {
            try
            {
                await _db.ShelterCollection.InsertOneAsync(shelter);
            }
            catch
            {
                throw;
            }
        }

        // UPDATE  - opdater en eksisterende shelter
        public async Task UpdateShelter(Shelter shelter)
        {
            try
            {
                await _db.ShelterCollection.ReplaceOneAsync(filter: g => g.Id == shelter.Id, replacement: shelter);
            }
            catch
            {
                throw;
            }
        }

        // DELETE  - slet en shelter
        public async Task DeleteShelter(string id)
        {
            try
            {
                FilterDefinition<Shelter> shelter = Builders<Shelter>.Filter.Eq("Id", id);
                await _db.ShelterCollection.DeleteOneAsync(shelter);
            }
            catch
            {
                throw;
            }
        }

    }
}
