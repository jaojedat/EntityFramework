using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.DBContext
{
    public class TasksContext : DbContext
    {
        public DbSet<Category> Categorys {get; set;}
        public DbSet<Models.Task> Tasks {get; set;}

        public TasksContext(DbContextOptions<TasksContext> options) : base(options){}
    }
}