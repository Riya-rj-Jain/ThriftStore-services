﻿
using System.ComponentModel.DataAnnotations;
using ThriftStore.UserAuthentication.IAM.Validations;

namespace ThriftStore.UserAuthentication.IAM.Data.Entities
{
    public class Users :Base
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public string Password { get; set; }

        [EmailValidation]
        public string Email { get; set; }

        [MaxLength(255)]
        public string Username { get; set; } 

        public string? IsPrime { get; set; }

    }
}
