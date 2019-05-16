using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo.Infra.Context;
using Todo.Infra.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase //ControllerBase = no view support - específico para APIs
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Post(TodoItem item)
        {
            _context.TodoItems.Add(item);
             await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new {id = item.Id}, item);
        }



    }
}
