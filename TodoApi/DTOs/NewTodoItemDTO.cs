using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class NewTodoItemDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool? isComplete { get; set; }
    }
}