using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Joller.Models
{
    public class Subscriber
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public int SubscriberId { get; set; }
        [BsonRequired]
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UnsubscribedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public bool Subscribed { get; set; }


    }

}
