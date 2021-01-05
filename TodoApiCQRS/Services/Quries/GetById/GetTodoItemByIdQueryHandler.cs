using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using TodoApiCQRS.Exceptions;
using TodoApiCQRS.Models;

namespace TodoApiCQRS.Services
{
    public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, GetTodoItemByIdResponse>
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public GetTodoItemByIdQueryHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetTodoItemByIdResponse> Handle(GetTodoItemByIdQuery query, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(query.Id);
            if (todoItem == null)
                throw new TodoItemNotFoundException();
            return _mapper.Map<GetTodoItemByIdResponse>(todoItem);
        }
    }
}