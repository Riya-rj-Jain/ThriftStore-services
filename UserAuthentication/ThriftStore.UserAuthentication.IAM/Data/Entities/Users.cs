using System.ComponentModel.DataAnnotations;
using ThriftStore.UserAuthentication.IAM.Validations;

namespace ThriftStore.UserAuthentication.IAM.Data.Entities
{
    /// <summary>
    /// User entity class that provides properties 
    /// for User id,name,password,email and username.
    /// Implements Base class for common properties.
    /// </summary>
    public class Users : Base
    {
        /// <summary>
        /// The Id of User,its autoincremented and its key.
        /// </summary>

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of User ,it is required field which have 255 maxlength.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string? Name { get; set; }

        /// <summary>
        ///Password of user, it is required field which have 255 maxlength.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string? Password { get; set; }

        /// <summary>
        /// Email for user login,it has email validation
        /// </summary>
        [EmailValidation]
        public string? Email { get; set; }

        /// <summary>
        /// Username of user , it is required field which have 255 maxlength.
        /// </summary>
        [Required] 
        [MaxLength(255)]
        public string? Username { get; set; }  

    }
}

