﻿using SimpleTodoMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace SimpleTodoMvc.Infrustructure
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoList> ToDoList { get; set; }
    }
}