using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TodoApiCQRS.Exceptions;
using TodoApiCQRS.Models;

namespace TodoApiCQRS.Services
{
    class PutTodoItemCommandHandler : IRequestHandler<PutTodoItemCommand, long>
    {
        private readonly AppDbContext _context;

        public PutTodoItemCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<long> Handle(PutTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(request.Id);

            if (todoItem == null)
                throw new TodoItemNotFoundException();

            todoItem.Name = request.Name;
            todoItem.isCompleted = request.isCompleted;
            todoItem.Description = request.Description;

            _context.TodoItems.Update(todoItem);
            await _context.SaveChangesAsync(cancellationToken);

            return todoItem.Id;
        }
    }
}