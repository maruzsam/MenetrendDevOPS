using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Menetrend.Models
{
    public class Utas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string JegyID { get; set; }

        public string Nev { get; set; }

        public string SzemelyIGsz { get; set; }

        public int DiakIGsz { get; set; }
    }
}
