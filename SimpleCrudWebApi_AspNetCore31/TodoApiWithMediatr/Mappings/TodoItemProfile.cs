using AutoMapper;
using TodoApiWithMediatr.Models;
using TodoApiWithMediatr.Services;

namespace TodoApiWithMediatr.Mappings
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItem, GetTodoItemsByIdResponse>();
            CreateMap<TodoItem, GetAllTodoItemsResponse>();
            CreateMap<CreateTodoItemCommand, TodoItem>();
        }
    }
}