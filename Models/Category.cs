using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Category
    {
        public Guid CategoryId {get; set;}
        public string Name {get; set;}
        public string Descripcion {get; set;}

        [JsonIgnore]
        public virtual ICollection<Task> Tasks {get; set;}

    }
}