using DAL.Data;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using MiniProject.DTOs;


namespace MiniProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly IListRepository _listRepo;
        private readonly IUserRepository _userRepo;

        public TodoItemsController(IListRepository listRepo, IUserRepository userRepo)
        {
            _listRepo = listRepo;
            _userRepo = userRepo;
        }

        // GET api/todoitems/5?userId=1
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(int id, [FromQuery] int userId)
        {
            var item = _listRepo.GetItemByID(id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // GET api/todoitems?userId=1
        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll([FromQuery] int userId)
        {
            return Ok(_listRepo.GetItemsList(userId));
        }

        // POST api/todoitems
        [HttpPost]
        public ActionResult<TodoItem> Add([FromBody] CreateTodoItemDto dto)
        {
            if (_userRepo.GetUserById(dto.UserId) == null)
                return BadRequest("User does not exist");

            var item = new TodoItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                IsCompleted = dto.IsCompleted,
                UserId = dto.UserId
            };

            var created = _listRepo.AddItem(item);
            return CreatedAtAction(nameof(GetById),
                new { id = created.Id, userId = created.UserId }, created);
        }
    }
}