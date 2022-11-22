using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext; 
        private readonly ILogger<UserController> _logger;

        public UserController(DatabaseContext database, ILogger<UserController> logger)
        {
            _databaseContext = database;
            _logger = logger;
        }

        [HttpGet(Name = "GetAccounts")]
        public ActionResult Get(Privilege privilege)
        {
            return Ok();
        }
    }
}