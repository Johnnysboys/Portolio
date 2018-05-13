using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Joller.Models
{
    public class User
    {
        [BsonId]
        public ObjectId InternalId;
        public string Email;
        public string Name;
        public string Password;
        public string PhotoUrl;

    }
}