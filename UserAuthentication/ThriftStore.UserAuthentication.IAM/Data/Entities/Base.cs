using ThriftStore.UserAuthentication.IAM.Enums;

namespace ThriftStore.UserAuthentication.IAM.Data.Entities
{
    /// <summary>
    /// Base entity class that provides common properties 
    /// for tracking creation, updates, and status of entities.
    /// </summary>
    public class Base
    {
        /// <summary>
        /// The date and time when the entity was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// The username or identifier of the user who created the entity.
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// The date and time when the entity was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// The username or identifier of the user who last updated the entity.
        /// </summary>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// The current status of the entity (e.g., Active, Inactive, Deleted).
        /// </summary>
        public Status Status { get; set; }
    }
}
