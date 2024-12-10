using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Menetrend.Models
{
    public class Jarat
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Indulas { get; set; }

        public string Erkezes { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string VonatID { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Indulo_allomasID { get; set; } 

        [BsonRepresentation(BsonType.ObjectId)]
        public string Cel_allomasID { get; set; }

    }
}
