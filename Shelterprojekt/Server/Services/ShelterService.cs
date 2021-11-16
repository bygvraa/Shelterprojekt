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
                await _db.ShelterCollection.UpdateOneAsync(
                    Builders<Shelter>.Filter
                        .Eq(eksShelter => eksShelter.Id, shelter.Id),

                    Builders<Shelter>.Update
                        .Set(eksShelter => eksShelter.Properties.Navn,          shelter.Properties.Navn)
                        .Set(eksShelter => eksShelter.Properties.Beskrivelse,   shelter.Properties.Beskrivelse)
                        .Set(eksShelter => eksShelter.Properties.Kommune,       shelter.Properties.Kommune)
                        .Set(eksShelter => eksShelter.Properties.AntalPl,       shelter.Properties.AntalPl)
                        .Set(eksShelter => eksShelter.Properties.Postnr,        shelter.Properties.Postnr)
                        .Set(eksShelter => eksShelter.Properties.Vejnavn,       shelter.Properties.Vejnavn)
                        .Set(eksShelter => eksShelter.Properties.Kontaktperson, shelter.Properties.Kontaktperson)
                        .Set(eksShelter => eksShelter.Properties.Handicap,      shelter.Properties.Handicap)
                    );
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
