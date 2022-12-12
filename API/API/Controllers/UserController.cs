namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            // TODO: Get a user's identity.
            int userId = 1;
            try
            {
                var users = _userRepository.GetAllUsers(userId);
                return Ok(users);
            }
            catch
            {
                return BadRequest("[FAILED] You are not authorised.");
            }
        }
        public ActionResult GetPassword(int length)
        {
            try
            {
                var password = _userRepository.GetGeneratedPassword(length);
                return Ok(password);
            }
            catch(Exception ex)
            {
                return BadRequest($"[ERROR] {ex.Message}");
            }
        }

        public ActionResult LogOn(User user)
        {
            try
            {
                var getUser = _userRepository.LogOn(user);
                return Ok();
            }
            catch
            {
                return BadRequest("[FAILED] Wrong credentials.");
            }
        }
    }
}