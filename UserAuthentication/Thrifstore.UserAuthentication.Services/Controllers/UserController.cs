using Microsoft.AspNetCore.Mvc;
using ThriftStore.UserAuthentication.IAM.Interface;
using ThriftStore.UserAuthentication.IAM.Data.ViewModels;


namespace Thrifstore.UserAuthentication.Startup.Controllers
{
    /// <summary>
    /// Controller for managing user-related operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Repository for managing user-related database operations.
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// constructor to initialize the UserController with the given repository.
        /// </summary>
        /// <param name="userRepository"></param>
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all users from the database.
        /// </summary>
        /// <returns>List of userviewmodel users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return the specific user</returns>
        [HttpGet]
        public async Task<ActionResult<UserViewModel>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> CreateUser([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdUser = await _userRepository.CreateUser(user);
            return Ok(createdUser);
        }

        [HttpDelete("{user_id}")]
        public async Task<IActionResult> DeleteUser(int user_id)
        {
            var isDeleted = await _userRepository.DeleteUserById(user_id);
            if (!isDeleted)
            {
                return NotFound(); 
            }
            return NoContent(); 
        }

    }
}
