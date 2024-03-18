using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Task
    {
        public Guid TaskId {get; set;}
        public Guid CategoryId {get; set;}
        public string Title {get; set;}
        public string Descripcion {get; set;}
        public Priority TaskPriority {get; set;}
        public DateTime DateCreation {get; set;}
        public virtual Category Category {get; set;}
    }

    public enum Priority 
    {
        Low,
        Mediun,
        High
    }
}