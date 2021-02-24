using LubyTechModel.Models;
using System.Threading.Tasks;

namespace LubyTechAPI.Repository.IRepository
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<bool> AddDeveloperToProject(int developerId, int projectId);
    }
}