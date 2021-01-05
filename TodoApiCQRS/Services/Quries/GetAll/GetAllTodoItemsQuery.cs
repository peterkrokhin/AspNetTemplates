using System.Collections.Generic;

using MediatR;

namespace TodoApiCQRS.Services
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<GetAllTodoItemsResponse>>
    {    
    }
}