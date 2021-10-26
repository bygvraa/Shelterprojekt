using Shelterprojekt.Shared.IService;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelterprojekt.Shared.Service
{
    public class ShelterService : IShelterService
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Shelter> _shelterTable = null;

        public ShelterService()
        {
            _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            _database = _mongoClient.GetDatabase("shelterdb");
            _shelterTable = _database.GetCollection<Shelter>("shelters");
        }
        public string Delete(string shelterNavn)
        {
            throw new NotImplementedException();
        }

        public Shelter GetShelter(string shelterNavn)
        {
            return _shelterTable.Find(x=>x.Navn == shelterNavn).FirstOrDefault();
        }

        public List<Shelter> GetShelters()
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(Shelter shelter)
        {
            throw new NotImplementedException();
        }
    }
}
