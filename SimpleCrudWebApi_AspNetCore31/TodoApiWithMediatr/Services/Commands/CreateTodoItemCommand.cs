using TodoApiWithMediatr.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;


namespace TodoApiWithMediatr.Services
{
    public class CreateTodoItemCommand : IRequest<GetTodoItemsByIdResponse>
    {
        public string Name { get; set; }
        public bool isCompleted { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, GetTodoItemsByIdResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CreateTodoItemCommandHandler(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetTodoItemsByIdResponse> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = _mapper.Map<TodoItem>(request);
            await _context.TodoItems.AddAsync(todoItem);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<GetTodoItemsByIdResponse>(todoItem);
        }
    }
}