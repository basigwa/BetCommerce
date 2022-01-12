using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetCommerce.Entities.AuthenticationEntities
{
    [Owned]
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public Account Account { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string RevokedByIp { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
