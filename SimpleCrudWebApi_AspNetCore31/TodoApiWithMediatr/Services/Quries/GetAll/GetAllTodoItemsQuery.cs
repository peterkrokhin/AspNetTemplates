using System.Collections.Generic;

using MediatR;


namespace TodoApiWithMediatr.Services
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<GetAllTodoItemsResponse>>
    {    
    }
}