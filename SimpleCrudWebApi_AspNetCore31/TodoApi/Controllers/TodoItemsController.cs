using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using TodoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        
        private readonly TodoContext _context;
        public TodoItemsController(TodoContext context)
        {
           _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItemDTO todoItemDTO)
        {
            var _todoItem = new TodoItem()
            {
                Name = todoItemDTO.Name,
                isComplete = todoItemDTO.isComplete.Value,
            };
            _context.TodoItems.Add(_todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new {id = _todoItem.Id}, new TodoItemDTO(_todoItem));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            return await _context.TodoItems
                .Select(t => new TodoItemDTO(t))
                .ToListAsync();
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
                return NotFound();
            return new TodoItemDTO(todoItem);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<TodoItemDTO>> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
                return NotFound();

            _context.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<TodoItemDTO>> PutTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
                return BadRequest();

            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
                return NotFound();

            todoItem.Name = todoItemDTO.Name;
            todoItem.isComplete = todoItemDTO.isComplete.Value;

            _context.TodoItems.Update(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        

        
    }
}
