using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext context;
        private readonly IMapper mapper;
    
        public TodoItemsController(TodoContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemDTO>> PostTodoItem(NewTodoItemDTO newTodoItem)
        {
            TodoItem todoItem = mapper.Map<TodoItem>(newTodoItem);
            context.TodoItems.Add(todoItem);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new {id = todoItem.Id}, mapper.Map<TodoItemDTO>(todoItem));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            var todoItems = await context.TodoItems.ToListAsync();
            var todoItemsDTO = mapper.Map<IEnumerable<TodoItem>, IEnumerable<TodoItemDTO>>(todoItems);
            return Ok(todoItemsDTO);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem == null)
                return NotFound();
            
            return mapper.Map<TodoItemDTO>(todoItem);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await context.TodoItems.FindAsync(id);
            if (todoItem == null)
                return NotFound();

            context.Remove(todoItem);
            await context.SaveChangesAsync();

            return NoContent();

        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> PutTodoItem(long id, TodoItemDTO todoItemDTO)
        {
            if (id != todoItemDTO.Id)
                return BadRequest();

            var todoItem = await context.TodoItems.FindAsync(id);

            if (todoItem == null)
                return NotFound();

            todoItem.Name = todoItemDTO.Name;
            todoItem.isComplete = todoItemDTO.isComplete.Value;

            context.TodoItems.Update(todoItem);
            await context.SaveChangesAsync();

            return NoContent();
        }  
    }
}
