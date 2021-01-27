using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "You must to set a Name for Project."), MinLength(3, ErrorMessage = "Minimum 3 characters by Project")]
        public string Name { get; set; }
        [MinLength(3, ErrorMessage = "Minimum 3 characters by Description of the Project")]
        public string Description { get; set; }   

        public DateTime Created { get; set; }

        //[ForeignKey("DeveloperId")]
        //public virtual Developer Developer { get; set; }
    }
}
