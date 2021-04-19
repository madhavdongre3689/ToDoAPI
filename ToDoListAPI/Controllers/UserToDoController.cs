using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ToDoListAPI.Controllers
{
    [Route("api/todo")]
    [Authorize]
    public class UserToDoController : Controller
    {

        private readonly ILogger<UserToDoController> _logger;
        private ToDoContext _context;
        public UserToDoController(ToDoContext context, ILogger<UserToDoController> logger)
        {
            _logger = logger;
            _context = context;
           
        }

        [HttpGet("{Title}")]
        public ActionResult<List<ToDoItem>> Get(string title)
        {
            string userId = HttpContext.User.Identity.Name;
            var toDoItems = _context.ToDoItems.Include(a => a.ToDoUser).Where(a => a.ToDoUser.Email == userId);


            var toDoItem = toDoItems.FirstOrDefault(a => a.Title == title);

            if (toDoItem == null)
            {
                return BadRequest("Todo Item Does not exists");
            }
            return Ok(toDoItem);
        }
        [HttpGet]
        public ActionResult<List<ToDoItem>> Get()
        {
            //We receive the userId as email
            string userId = HttpContext.User.Identity.Name;
            var toDoItems = _context.ToDoItems.Include(a => a.ToDoUser).Where(a => a.ToDoUser.Email == userId);
            if (toDoItems == null || toDoItems.Count()==0)
            {
                return Ok("No ToDo Items for the User");
            }
            return Ok(toDoItems);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var toDoItem = _context.ToDoItems.FirstOrDefault(a => a.Title == todoItem.Title);

            if (todoItem != null)
            {
                return BadRequest("Todo Item Already exists");
            }
            _context.ToDoItems.Add(todoItem);
            _context.SaveChanges();

            var key = todoItem.Title;
            return Created("api/todo/" + key, null);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ToDoItem todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var toDoItem = _context.ToDoItems.FirstOrDefault(a => a.Id == todo.Id);

            if (toDoItem == null)
            {
                toDoItem = new ToDoItem();
            }

            toDoItem.Title = todo.Title;
            toDoItem.status = todo.status;
            toDoItem.Description = todo.Description;
            toDoItem.StartDate = todo.StartDate;
            toDoItem.TargetDate = toDoItem.TargetDate;
            _context.Update(toDoItem);
            _context.SaveChanges();
            return NoContent();


        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var toDoItem = _context.ToDoItems.FirstOrDefault(a => a.Id == Id);

            if (toDoItem == null)
            {
                return BadRequest("Todo Item Does not exists");
            }

            _context.ToDoItems.Remove(toDoItem);
            _context.SaveChanges();
            return Ok();
        }
    }
}
