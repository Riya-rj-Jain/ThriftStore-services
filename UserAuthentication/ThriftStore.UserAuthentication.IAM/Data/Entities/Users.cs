using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThriftStore.UserAuthentication.IAM.Validations;

namespace ThriftStore.UserAuthentication.IAM.Data.Entities
{
    public class Users
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

        public string? createdAt{  get; set; }

        public string? createdBy { get; set; }

        public string? updatedAt { get; set; } 

        public ? updatedBy { get; set; }
    }
}
