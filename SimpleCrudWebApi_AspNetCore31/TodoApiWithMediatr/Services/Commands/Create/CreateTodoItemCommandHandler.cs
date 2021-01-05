using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using TodoApiWithMediatr.Models;

namespace TodoApiWithMediatr.Services
{
    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, GetTodoItemByIdResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateTodoItemCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetTodoItemByIdResponse> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = _mapper.Map<TodoItem>(request);

            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync(cancellationToken);
            
            return _mapper.Map<GetTodoItemByIdResponse>(todoItem);
        }
    }
}