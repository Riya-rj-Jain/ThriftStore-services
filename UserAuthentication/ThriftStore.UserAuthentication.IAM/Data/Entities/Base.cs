
using ThriftStore.UserAuthentication.IAM.Enums;

namespace ThriftStore.UserAuthentication.IAM.Data.Entities
{
    public class Base
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public Status Status { get; set; }
    }
}
