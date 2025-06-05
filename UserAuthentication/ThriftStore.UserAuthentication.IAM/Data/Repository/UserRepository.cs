using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThriftStore.UserAuthentication.IAM.Data.Entities;
using ThriftStore.UserAuthentication.IAM.Data.ViewModels;
using ThriftStore.UserAuthentication.IAM.Interface;

namespace ThriftStore.UserAuthentication.IAM.Data.Repository
{
    /// <summary>
    /// Repository class for managing User-related database operations.
    /// Implements IUserRepository interface.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The database context for accessing User entities.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor to initialize the UserRepository with the given database context.
        /// </summary>
        /// <param name="context">ApplicationDbContext instance injected via dependency injection.</param>
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all users from the database and maps them to UserViewModel.
        /// </summary>
        /// <returns>List of UserViewModel containing all users.</returns>
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

        /// <summary>
        /// Retrieves a specific user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>UserViewModel if found; otherwise, null.</returns>
        public async Task<UserViewModel?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return null;

            return new UserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Email = user.Email
            };
        }

        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="user">UserViewModel containing the user's details.</param>
        /// <returns>The created UserViewModel with the generated ID.</returns>
        public async Task<UserViewModel> CreateUser(UserViewModel user)
        {
            var newUser = new Users
            {
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = DateTime.UtcNow,
                Status = Enums.Status.Active,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            user.Id = newUser.Id; // Update ViewModel with generated ID.

            return user;
        }

        /// <summary>
        /// Deletes a user from the database by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>True if the user was successfully deleted; otherwise, false.</returns>
        public async Task<bool> DeleteUserById(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
