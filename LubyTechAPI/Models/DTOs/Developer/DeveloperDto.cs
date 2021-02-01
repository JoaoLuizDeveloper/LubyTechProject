using System;
using System.ComponentModel.DataAnnotations;

namespace LubyTechAPI.Models.DTOs
{
    public class DeveloperDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public long CPF { get; set; }

        public DateTime Created { get; set; }
    }
}
