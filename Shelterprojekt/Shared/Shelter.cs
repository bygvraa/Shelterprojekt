using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shelterprojekt.Shared
{
    public class Shelter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Navn { get; set; }
        public int Cvr { get; set; }
        public int AntalPersoner { get; set; }
        public int Postnr { get; set; }
        public string VejNavn { get; set; }
        public string Kontakt { get; set; }
        public string Handicap { get; set; }

    }
}
