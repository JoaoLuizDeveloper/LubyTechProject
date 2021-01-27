using LubyTechAPI.Models;
using LubyTechAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LubyTechAPI.Repository.IRepository
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        Task<ICollection<HourByDeveloper>> GetRankinfOfDevelopers();
        Task<bool> CPFExists(long cpf);
        Task<bool> AddHourToProject(Hour Hour);

        string GetToken();
    }
}