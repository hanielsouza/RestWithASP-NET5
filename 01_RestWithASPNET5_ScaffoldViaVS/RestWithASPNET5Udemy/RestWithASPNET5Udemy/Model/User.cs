using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET5Udemy.Model
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        [Key]
        public long Id { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("full_name")]
        public string FullName { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("refresh_token")]
        public string RefreshToken { get; set; }

        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }

    }
}
