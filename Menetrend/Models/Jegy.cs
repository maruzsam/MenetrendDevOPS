using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Menetrend.Models
{
    public class Jegy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public decimal Ar {  get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string JaratID { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AkcioID { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string UtasID { get; set; }

        public DateTime Ervenyesseg { get; set; }
    }
}
