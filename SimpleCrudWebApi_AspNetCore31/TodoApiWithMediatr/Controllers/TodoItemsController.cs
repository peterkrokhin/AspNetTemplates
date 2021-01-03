using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using TodoApiWithMediatr.Services;
using TodoApiWithMediatr.Exceptions;


namespace TodoApiWithMediatr.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<GetTodoItemByIdResponse>> PostTodoItem(CreateTodoItemCommand command)
        {
            var todoItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTodoItem), new {id = todoItem.Id}, todoItem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllTodoItemsResponse>>> GetTodoItems()
        {
            return Ok(await _mediator.Send(new GetAllTodoItemsQuery()));
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<GetTodoItemByIdResponse>> GetTodoItem(long id)
        {
            try 
            {
                return await _mediator.Send(new GetTodoItemByIdQuery(id));
            }
            catch (TodoItemNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
