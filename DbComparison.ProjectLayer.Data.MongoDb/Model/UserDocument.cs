using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using DbComparison.DataLayer.MongoDB.Setting;

namespace DbComparison.ProjectLayer.Data.MongoDb.Model
{
    [BsonCollection("User")]
    public class UserDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public string UserName { get; set; }

        public int? UserAge { get; set; }

        public string UserAddress { get; set; }

        public string UserTag { get; set; }

        public string UserPassword { get; set; }

        public decimal UserRating { get; set; }
    }
}