using AutoMapper;
using LubyTechModel.Models;
using LubyTechModel.Models.DTOs;

namespace LubyTechModel.Mapper
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
