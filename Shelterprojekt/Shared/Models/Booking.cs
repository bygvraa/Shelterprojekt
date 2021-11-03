using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [Required(ErrorMessage = "Indtast venligst en gyldig dato")]
        public DateTime dato { get; set; }
        
        [Required(ErrorMessage = "Indtast venligst et brugernavn")]
        [MinLength(2, ErrorMessage = "Brugernavnet er for kort")]
        public string brugerNavn { get; set; }
    }

}
