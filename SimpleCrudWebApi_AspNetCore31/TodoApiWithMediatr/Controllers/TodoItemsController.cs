using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoMapper;
using MediatR;

using TodoApiWithMediatr.Models;
using TodoApiWithMediatr.Services;


using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<GetTodoItemsByIdResponse>> Post(CreateTodoItemCommand command)
        {
            var todoItem = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new {id = todoItem.Id}, todoItem);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllTodoItemsResponse>>> Get() =>
            Ok(await _mediator.Send(new GetAllTodoItemsQuery()));
    }
}
