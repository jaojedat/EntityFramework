using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId {get; set;}
        [MaxLength(150)]
        public string Name {get; set;}
        public string Descripcion {get; set;}
        public virtual ICollection<Task> Tasks {get; set;}

    }
}