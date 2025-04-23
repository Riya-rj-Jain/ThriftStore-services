
using Microsoft.EntityFrameworkCore;
using ThriftStore.UserAuthentication.IAM.Data.ViewModels;
using ThriftStore.UserAuthentication.IAM.Interface;

namespace ThriftStore.UserAuthentication.IAM.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            var userViewModels = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email
            }).ToList();

            return userViewModels;
        }

    }
