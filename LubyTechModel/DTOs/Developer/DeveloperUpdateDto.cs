using System;
using System.ComponentModel.DataAnnotations;

namespace LubyTechModel.Models.DTOs
{
    public class DeveloperUpdateDto
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
