using MediatR;


namespace TodoApiWithMediatr.Services
{
    public class PutTodoItemCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool isCompleted { get; set; }
        public string Description { get; set; }
    }
}