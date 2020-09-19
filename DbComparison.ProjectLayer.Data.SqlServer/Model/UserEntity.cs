using System;
using System.ComponentModel.DataAnnotations;

namespace DbComparison.ProjectLayer.Data.SqlServer.Model
{
    public partial class UserEntity
    {
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