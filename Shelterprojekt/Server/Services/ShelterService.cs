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
        MainDbContext _dbContext = new MainDbContext();

        // Hent listen over shelters
        public async Task<List<Shelter>> GetSheltersAsync()
        {
            try
            {
                return await _dbContext.ShelterCollection.Find(_ => true).ToListAsync().ConfigureAwait(false);
            }
            catch 
            {
                throw;
            }
        }

    }
}
