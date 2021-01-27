using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Models.DTOs
{
    public class DeveloperCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public long CPF { get; set; }

        public DateTime Created { get; set; }
    }
}
