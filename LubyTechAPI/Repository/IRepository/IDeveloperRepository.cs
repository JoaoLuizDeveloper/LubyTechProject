using LubyTechAPI.Models;
using LubyTechAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Repository.IRepository
{
    public interface IDeveloperRepository
    {
        Task<ICollection<Developer>> GetDevelopers();
        Task<Developer> GetDeveloper(int id);
        Task<Project> GetProject(int id);
        bool DeveloperExists(string name);
        string GetToken();
        ICollection<HourByDeveloper> GetRankinfOfDevelopers();

        Task<ICollection<Developer>> DeveloperCPFExists(long cpf);
        bool DeveloperExists(int id);
        bool CreateDeveloper(Developer Developer);
        bool AddHourToProject(Hour Hour);
        bool UpdateDeveloper(Developer Developer);
        bool DeleteDeveloper(Developer Developer);
        bool Save();
    }
}