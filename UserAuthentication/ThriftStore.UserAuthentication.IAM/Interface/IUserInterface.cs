
using ThriftStore.UserAuthentication.IAM.Data.ViewModels;

namespace ThriftStore.UserAuthentication.IAM.Interface
{
    public interface IUserRepository
    {
        /// <summary>
        /// get all users interface
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();

        /// <summary>
        /// get user by id interface
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserViewModel> GetUserByIdAsync(int id);

        /// <summary>
        /// createuser interface
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<UserViewModel> CreateUser(UserViewModel user);

        /// <summary>
        /// delete user by id interface
        /// </summary>
        /// <param name="user_id"></param>
        /// <returns></returns>
        Task<bool> DeleteUserById(int user_id);
    }
}
