using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shelterprojekt.Shared
{
    [BsonIgnoreExtraElements]
    public class Shelter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("properties")]
        public Properties properties { get; set; }

    }

    [BsonIgnoreExtraElements]
    public class Properties
    {
        [BsonElement("navn")]
        public string navn { get; set; }
        public string cvr_navn { get; set; }
        public double? antal_pl { get; set; }
        public double? postnr { get; set; }
        public string vejnavn { get; set; }
        public string kontakt_ved { get; set; }
        public string handicap { get; set; }
    }
}
