using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shelterprojekt.Shared.Models
{
    [BsonIgnoreExtraElements]       // Ekstra elementer, der ikke specificeres i klassen (f.eks. 'geometry', og 'type') bliver ignoreret, når databasen loades. Kun elementer der eksplicit nævnes ('id' og 'properties') loades.
    public class Shelter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Properties properties { get; set; }
    }



    [BsonIgnoreExtraElements]
    public class Properties
    {
        public string navn { get; set; }
        public string beskrivels { get; set; }
        public string cvr_navn { get; set; }
        public double? antal_pl { get; set; }
        public double? postnr { get; set; }
        public string vejnavn { get; set; }
        public string kontakt_ved { get; set; }
        public string handicap { get; set; }
    }
}
