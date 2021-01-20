using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<Developers_Projects> DevProjects { get; set; }
        public virtual ICollection<Hour> Hours { get; set; }
    }
}
