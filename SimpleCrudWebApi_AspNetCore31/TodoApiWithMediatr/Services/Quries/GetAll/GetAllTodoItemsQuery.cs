using TodoApiWithMediatr.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace TodoApiWithMediatr.Services
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<GetAllTodoItemsResponse>>
    {    
    }

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