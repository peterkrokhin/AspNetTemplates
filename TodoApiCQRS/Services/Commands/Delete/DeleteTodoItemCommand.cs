using MediatR;

namespace TodoApiCQRS.Services
{
    public class DeleteTodoItemCommand : IRequest<long>
    {
        public long Id { get; set; }

        public DeleteTodoItemCommand(long id)
        {
            Id = id;
        }
    }
}