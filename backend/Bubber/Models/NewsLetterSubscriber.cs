using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bubber.Models
{
    public class Subscriber
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("SubscriberId")]
        public int SubscriberId { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        public string LastName { get; set; }

        [BsonElement("DateSubscribed")]
        public DateTime DateSubscribed { get; set; }
    }
}