using Shelterprojekt.Shared;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Server.Services
{
    public class ShelterService
    {
        MongoDBService _dbService = new MongoDBService();

        public async Task<List<Shelter>> GetSheltersAsync()
        {
            try
            {
                return await _dbService.ShelterCollection.Find(_ => true).ToListAsync().ConfigureAwait(false);
            }
            catch 
            {
                throw;
            }
        }

    }
}
