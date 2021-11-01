using System;
using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shelterprojekt.Shared.Models
{
    public class Booking  
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string shelterId { get; set; }
        public string shelterNavn { get; set; }
        public DateTime dato { get; set; }
    }

}
