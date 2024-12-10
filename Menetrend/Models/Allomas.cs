using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Menetrend.Models
{
    public class Allomas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nev { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string VarosID { get; set; }
    }
}
