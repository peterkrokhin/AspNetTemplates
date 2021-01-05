using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TodoApiCQRS.Exceptions;
using TodoApiCQRS.Models;

namespace TodoApiCQRS.Services
{
    class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand, long>
    {
        private readonly AppDbContext _context;

        public DeleteTodoItemCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(request.Id);
            if (todoItem == null)
                throw new TodoItemNotFoundException();
            
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync(cancellationToken);
            
            return todoItem.Id;
        }
    }
}