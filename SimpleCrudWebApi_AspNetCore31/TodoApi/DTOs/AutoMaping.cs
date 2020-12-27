using AutoMapper;

namespace TodoApi.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<TodoItem, TodoItemDTO>();
            CreateMap<NewTodoItemDTO, TodoItem>();
        }
    }
}