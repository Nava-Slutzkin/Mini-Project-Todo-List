using BLL.services;
using DAL.Data;
using Microsoft.AspNetCore.Mvc;

namespace MiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users/1
        [HttpGet("{id}")]
        public ActionResult<Users> GetById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // GET api/users
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            return Ok(_userService.GetUsersList());
        }

        // POST api/users
        [HttpPost]
        public ActionResult<Users> Add([FromBody] Users user)
        {
            var created = _userService.AddUser(user);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}