using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("Todo/api")]
    public class ToDoController : ControllerBase
    {
       

        private readonly ILogger<ToDoController> _logger;
        private ToDoContext _context;
        public ToDoController(ToDoContext context,ILogger<ToDoController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int userId)
        {
            var todoList = _context.ToDoLists.All(a => a.UserId == userId);
            return Ok(todoList);
        }
    }
}
