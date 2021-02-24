using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LubyTechModel.Models
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "You must to set a the  CPF field."), MinLength(11, ErrorMessage = "Minimum 11 characters by CPF")]
        public long CPF { get; set; }
        [Required(ErrorMessage = "You must to set a Name for Developer."), MinLength(3, ErrorMessage = "Minimum 3 characters by Name")]
        public string Name { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<Developers_Projects> DevProjects { get; set; }
        public virtual ICollection<Hour> Hours { get; set; }
    }
}
