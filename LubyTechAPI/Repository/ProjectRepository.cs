using Microsoft.EntityFrameworkCore;
using LubyTechAPI.Data;
using LubyTechAPI.Models;
using LubyTechAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        #region Constructor
        private readonly ApplicationDbContext _db;
        public ProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        #endregion
        public bool CreateProject(Project project)
        {
            _db.Projects.Add(project);
            return Save();
        }

        public bool DeleteProject(Project project)
        {
            _db.Projects.Remove(project);
            return Save();
        }

        public async Task<Project> GetProject(int projectId)
        {
            return await _db.Projects.FirstOrDefaultAsync(n => n.Id == projectId);
        }

        public async Task<ICollection<Project>> GetProjects()
        {
            return await _db.Projects.OrderBy(n => n.Name).ToListAsync();
        }

        public bool ProjectExists(string name)
        {
            bool value = _db.Projects.Any(n => n.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool ProjectExists(int id)
        {
            bool value = _db.Projects.Any(n => n.Id == id);
            return value;
        }
        
        public bool DeveloperExists(int id)
        {
            bool value = _db.Developers.Any(n => n.Id == id);
            return value;
        }
        
        public bool AddDeveloperToProject(int developerId, int projectId)
        {
            _db.Developers_Projects.Add(new Developers_Projects() { DeveloperId = developerId, ProjectId = projectId });
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateProject(Project project)
        {
            _db.Projects.Update(project);
            return Save();
        }
    }
}