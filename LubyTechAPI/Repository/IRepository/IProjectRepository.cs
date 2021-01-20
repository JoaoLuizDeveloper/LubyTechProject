using LubyTechAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Repository.IRepository
{
    public interface IProjectRepository
    {
        Task<ICollection<Project>> GetProjects();
        Task<Project> GetProject(int patrimonioId);
        bool ProjectExists(string name);
        bool ProjectExists(int id);
        bool DeveloperExists(int id);
        bool AddDeveloperToProject(int developerId, int projectId);
        bool CreateProject(Project patrimonio);
        bool UpdateProject(Project patrimonio);
        bool DeleteProject(Project patrimonio);
        bool Save();
    }
}