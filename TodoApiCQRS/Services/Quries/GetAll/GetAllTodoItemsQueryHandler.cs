using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

using TodoApiCQRS.Models;

namespace TodoApiCQRS.Services
{
    public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<GetAllTodoItemsResponse>>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTodoItemsQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllTodoItemsResponse>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await _context.TodoItems.ToListAsync();
            return _mapper.Map<IEnumerable<TodoItem>, IEnumerable<GetAllTodoItemsResponse>>(todoItems);
        }
    }
}