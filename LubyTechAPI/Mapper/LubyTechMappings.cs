using AutoMapper;
using LubyTechAPI.Models;
using LubyTechAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Mapper
{
    public class LubyTechMappings: Profile
    {
        public LubyTechMappings()
        {
            CreateMap<Developer, DeveloperDto>().ReverseMap();
            CreateMap<Developer, DeveloperCreateDto>().ReverseMap();
            CreateMap<Hour, HourDto>().ReverseMap();
            CreateMap<Developers_Projects, Developers_ProjectsDto>().ReverseMap();
            CreateMap<Developer, DeveloperUpdateDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, ProjectCreateDto>().ReverseMap();
            CreateMap<Project, ProjectUpdateDto>().ReverseMap();
        }
    }
}
