using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static LubyTechAPI.Models.Project;

namespace LubyTechAPI.Models.DTOs
{
    public class ProjectCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }
    }
}