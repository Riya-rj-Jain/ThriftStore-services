
using ThriftStore.UserAuthentication.IAM.Data.ViewModels;

namespace ThriftStore.UserAuthentication.IAM.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();
    }
}
