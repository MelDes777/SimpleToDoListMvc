using System.ComponentModel.DataAnnotations;

namespace ToDoListMvcWebApp.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
