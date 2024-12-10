using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Menetrend.Models
{
    public class Akcio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Leiras { get; set; }
        public decimal Kedvezmeny { get; set; }
    }
}
