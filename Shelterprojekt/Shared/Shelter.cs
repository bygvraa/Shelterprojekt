using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shelterprojekt.Shared
{
    public class Shelter
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Navn { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        public int Cvr { get; set; } = 0;
        public int AntalPersoner { get; set; } = 0;
        public int Postnr { get; set; } = 0;
        public string VejNavn { get; set; } = "";
        public string Kontakt { get; set; } = "";
        public string Handicap { get; set; } = "";

    }
}
