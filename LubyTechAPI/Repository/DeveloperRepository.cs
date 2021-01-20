using LubyTechAPI.Data;
using LubyTechAPI.Models;
using LubyTechAPI.Repository.IRepository;
using LubyTechAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LubyTechAPI.Repository
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly AppSettings _appSettings;

        public DeveloperRepository(ApplicationDbContext db, IOptions<AppSettings> appSettings)
        {
            _db = db;
            _appSettings = appSettings.Value;
        }
        public bool CreateDeveloper(Developer developer)
        {
            _db.Developers.Add(developer);
            return Save();
        }
        
        public bool AddHourToProject(Hour hour)
        {
            _db.Hours.Add(hour);
            return Save();
        }

        public ICollection<HourByDeveloper> GetRankinfOfDevelopers()
        {
            var Contagem = new List<HourByDeveloper>();
            var developers = _db.Developers.Include(d=> d.Hours).ToList();

            foreach(var dev in developers)
            {
                if(dev.Hours != null && dev.Hours.Count > 0)
                {
                    double GetWholeTime = 0;
                    var hoursDev = dev.Hours.Where(x => x.created > DateTime.Now.AddDays(-7)).Select(x => x.Time);                   

                    foreach(var h in hoursDev)
                    {
                        GetWholeTime += h;
                    }

                    Contagem.Add(new HourByDeveloper { IdDev = dev.Id, NameDev = dev.Name,  AllTime = GetWholeTime });
                }
            }
            return Contagem.OrderByDescending(x => x.AllTime).Take(5).ToList();
        }

        public string GetToken()
        {
            // User found and generate Jwt Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, new Random().Next().ToString()),
                    
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
        
        public bool DeleteDeveloper(Developer developers)
        {
            _db.Developers.Remove(developers);
            return Save();
        }

        public async Task<Developer> GetDeveloper(int Id)
        {
            return await _db.Developers.Include(d=> d.DevProjects).FirstOrDefaultAsync(n => n.Id == Id);
        }
                
        public async Task<Project> GetProject(int Id)
        {
            return await _db.Projects.FirstOrDefaultAsync(n => n.Id == Id);
        }

        public async Task<ICollection<Developer>> GetDevelopers()
        {
            return await _db.Developers.OrderBy(n => n.Name).ToListAsync();
        }

        public bool DeveloperExists(string name)
        {
            bool value = _db.Developers.Any(n => n.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool DeveloperExists(int id)
        {
            bool value = _db.Developers.Any(n => n.Id == id);
            return value;
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateDeveloper(Developer developers)
        {
            _db.Developers.Update(developers);
            return Save();
        }

        public async Task<ICollection<Developer>> DeveloperCPFExists(long cpf)
        {
           return await  _db.Developers.Where(x => x.CPF.Replace(".", "").Replace("-", "").ToLower().Trim() == cpf.ToString().ToLower().Trim()).ToListAsync();
        }
    }
}
