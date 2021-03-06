﻿using System;
using System.ComponentModel.DataAnnotations;

namespace LubyTechModel.Models.DTOs
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
