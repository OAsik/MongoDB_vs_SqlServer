using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using DbComparison.DataLayer.MongoDB.Setting;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbComparison.ProjectLayer.Data.Common.Model
{
    [BsonCollection("User")]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        [NotMapped]
        public string Id { get; set; }

        [Key]
        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public int? UserAge { get; set; }

        public string UserAddress { get; set; }

        public string UserTag { get; set; }

        public string UserPassword { get; set; }

        public decimal UserRating { get; set; }
    }
}