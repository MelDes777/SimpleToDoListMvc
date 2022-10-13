using System.ComponentModel.DataAnnotations;

namespace SimpleTodoMvc.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
