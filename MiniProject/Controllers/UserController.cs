using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        // GET api/users/1
        [HttpGet("{id}")]
        public ActionResult<Users> GetById(int id)
        {
            var user = _userRepo.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // GET api/users
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            return Ok(_userRepo.GetUsersList());
        }

        // POST api/users
        [HttpPost]
        public ActionResult<Users> Add([FromBody] Users user)
        {
            var created = _userRepo.AddUser(user);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}