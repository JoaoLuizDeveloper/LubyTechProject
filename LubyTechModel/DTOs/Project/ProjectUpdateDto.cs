using System;
using System.ComponentModel.DataAnnotations;

namespace LubyTechModel.Models.DTOs
{
    public class ProjectUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }
    }
}
