using MediatR;

namespace TodoApiWithMediatr.Services
{
    public class GetTodoItemByIdQuery : IRequest<GetTodoItemByIdResponse>
    {
        public long Id { get; set; }

        public GetTodoItemByIdQuery(long id)
        {
            Id = id;
        }
    }
}