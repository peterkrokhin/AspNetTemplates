using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using MediatR;

using TodoApiWithMediatr.Services;
using TodoApiWithMediatr.Exceptions;
using FluentValidation.AspNetCore;

namespace TodoApiWithMediatr.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
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
            command.Name = "e";
            var validator = new CreateTodoItemCommandValidator();
            var results = validator.Validate(command);
            results.AddToModelState(ModelState, null);
            if (!ModelState.IsValid)
                return Ok(ModelState);

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

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteTodoItem(long id)
        {
            try
            {
                await _mediator.Send(new DeleteTodoItemCommand(id));
                return NoContent();
            }
            catch (TodoItemNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> PutTodoItem(long id, PutTodoItemCommand putTodoItemCommand)
        {
            if(id != putTodoItemCommand.Id)
                return BadRequest();

            try
            {
                await _mediator.Send(putTodoItemCommand);
                return NoContent();
            }
            catch (TodoItemNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
