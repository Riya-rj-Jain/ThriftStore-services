using Microsoft.AspNetCore.Mvc;
using ThriftStore.UserAuthentication.IAM.Interface;
using ThriftStore.UserAuthentication.IAM.Data.ViewModels;


namespace Thrifstore.UserAuthentication.Startup.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }
        public async Task<ActionResult<UserViewModel>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
