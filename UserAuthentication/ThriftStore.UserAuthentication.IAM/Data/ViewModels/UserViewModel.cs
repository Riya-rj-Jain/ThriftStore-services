namespace ThriftStore.UserAuthentication.IAM.Data.ViewModels
{
    /// <summary>
    /// User ViewModel class that provides properties for transferring user data 
    /// between layers without exposing the database entity directly.
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the username used for login or identification.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        public string? Email { get; set; }
    }
}

