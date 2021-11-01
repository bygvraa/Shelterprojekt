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
        [BsonElement("navn")]
        public string navn { get; set; }

        [BsonElement("beskrivels")]
        public string beskrivels { get; set; }
        
        [BsonElement("cvr_navn")]
        public string cvr_navn { get; set; }
        
        [BsonElement("antal_pl")]
        public double? antal_pl { get; set; }
        
        [BsonElement("postnr")]
        public double? postnr { get; set; }
        
        [BsonElement("vejnavn")]
        public string vejnavn { get; set; }
        
        [BsonElement("kontakt_ved")]
        public string kontakt_ved { get; set; }
        
        [BsonElement("handicap")]
        public string handicap { get; set; }
    }
}
