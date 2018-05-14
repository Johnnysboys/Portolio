using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Joller.Models
{
    public class User
    {
        [BsonId]
        public ObjectId InternalId;
        [BsonRequired]
        public string Email;

        [BsonRequired]
        public string Password;

        public string Salt;
        public bool Admin;

    }
}