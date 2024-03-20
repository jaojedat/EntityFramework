using System;
using System.Collections.Generic;
using System.Linq;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityFramework.DBContext
{
    public class TasksContext : DbContext
    {
        public DbSet<Category> Categorys {get; set;}
        public DbSet<Models.Task> Tasks {get; set;}
        public TasksContext(DbContextOptions<TasksContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(category => {
                category.ToTable("Category");
                category.HasKey(c => c.CategoryId);
                category.Property(c => c.Name).HasMaxLength(150).IsRequired();
                category.Property(c => c.Descripcion);
            });

            modelBuilder.Entity<Models.Task>(task =>{
                task.ToTable("Task");
                task.HasKey(t => t.TaskId);
                task.HasOne(c => c.Category).WithMany(t => t.Tasks).HasForeignKey(c => c.CategoryId);
                task.Property(t => t.Title);
                task.Property(t => t.Descripcion);
                task.Property(t => t.TaskPriority);
                task.Property(t => t.DateCreation);
            });
        }
    }
}