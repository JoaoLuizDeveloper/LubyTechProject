﻿using System;
using System.ComponentModel.DataAnnotations;

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