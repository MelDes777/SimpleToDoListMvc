using System.ComponentModel.DataAnnotations;

namespace SimpleTodoMvc.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
