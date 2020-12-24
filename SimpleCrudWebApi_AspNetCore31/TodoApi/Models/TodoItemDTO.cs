using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace TodoApi.Models
{
    public class TodoItemDTO
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public bool? isComplete { get; set; }

        public TodoItemDTO() {}
        public TodoItemDTO(TodoItem todoItem)
        {
            Id = todoItem.Id;
            Name = todoItem.Name;
            isComplete = todoItem.isComplete;
        }
    }
    
}