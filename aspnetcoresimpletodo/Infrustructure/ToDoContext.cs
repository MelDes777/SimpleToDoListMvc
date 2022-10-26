using ToDoListMvcWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ToDoListMvcWebApp.Infrustructure
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
        }

        public DbSet<ToDo> ToDoes { get; set; }
    }
}
