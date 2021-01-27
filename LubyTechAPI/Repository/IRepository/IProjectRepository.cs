using LubyTechAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Repository.IRepository
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<bool> AddDeveloperToProject(int developerId, int projectId);
    }
}