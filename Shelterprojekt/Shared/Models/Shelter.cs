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

        [BsonElement("properties")]
        public Properties Properties { get; set; }



    }



    [BsonIgnoreExtraElements]
    public class Properties
    {
        [BsonElement("navn")]
        public string Navn { get; set; }

        [BsonElement("beskrivels")]
        public string Beskrivelse { get; set; }
        
        [BsonElement("cvr_navn")]
        public string Kommune { get; set; }
        
        [BsonElement("antal_pl")]
        public double? AntalPl { get; set; }
        
        [BsonElement("postnr")]
        public double? Postnr { get; set; }
        
        [BsonElement("vejnavn")]
        public string Vejnavn { get; set; }
        
        [BsonElement("kontakt_ved")]
        public string Kontaktperson { get; set; }
        
        [BsonElement("handicap")]
        public string Handicap { get; set; }
    }

}
