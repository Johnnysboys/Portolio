using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Joller.Models
{
    public class AboutMe
    {
        [BsonId]
        public ObjectId internalId;
        public string Text;
    }
}