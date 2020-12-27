using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace TodoApi.Models
{
    public class TodoItemDTO
    {
        [Required]
        public long? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool? isComplete { get; set; }
    }
}