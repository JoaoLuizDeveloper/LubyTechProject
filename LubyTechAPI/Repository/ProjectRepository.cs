using LubyTechAPI.Data;
using LubyTechAPI.Models;
using LubyTechAPI.Repository.IRepository;
using System.Threading.Tasks;

namespace LubyTechAPI.Repository
{
    public class ProjectRepository : Repository<Project> , IProjectRepository
    {
        #region Constructor
        private readonly ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        #endregion
        
        public async Task<bool> AddDeveloperToProject(int developerId, int projectId)
        {
            await _db.Developers_Projects.AddAsync(new Developers_Projects() { DeveloperId = developerId, ProjectId = projectId });
            return await _db.SaveChangesAsync() >= 0;
        }
    }
}