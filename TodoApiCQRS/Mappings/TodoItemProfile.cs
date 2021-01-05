using AutoMapper;
using TodoApiCQRS.Models;
using TodoApiCQRS.Services;

namespace TodoApiCQRS.Mappings
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItem, GetTodoItemByIdResponse>();
            CreateMap<TodoItem, GetAllTodoItemsResponse>();
            CreateMap<CreateTodoItemCommand, TodoItem>();
        }
    }
}