namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext; 

        public UserController(DatabaseContext database)
        {
            _databaseContext = database;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok( _databaseContext.Users );
        }
    }
}