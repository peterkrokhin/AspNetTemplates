using MediatR;


namespace TodoApiWithMediatr.Services
{
    public class CreateTodoItemCommand : IRequest<GetTodoItemByIdResponse>
    {
        public string Name { get; set; }
        public bool isCompleted { get; set; }
        public string Description { get; set; }
    }
}