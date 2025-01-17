using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECF2.Models
{
    public class EventParticipant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}