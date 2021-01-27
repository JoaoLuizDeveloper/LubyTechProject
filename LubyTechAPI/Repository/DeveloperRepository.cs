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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LubyTechAPI.Repository
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        #region Construtor
        private readonly ApplicationDbContext _db;

        public DeveloperRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        #endregion

        public async Task<bool> AddHourToProject(Hour hour)
        {
            await _db.Hours.AddAsync(hour);
            return true;
        }

        public async Task<ICollection<HourByDeveloper>> GetRankinfOfDevelopers()
        {
            var Contagem = new List<HourByDeveloper>();
            var developers = await _db.Developers.Include(d=> d.Hours).ToListAsync();

            foreach(var dev in developers)
            {
                if(dev.Hours != null && dev.Hours.Count > 0)
                {
                    double GetWholeTime = 0;
                    var hoursDev = dev.Hours.Where(x => x.Created > DateTime.Now.AddDays(-7)).Select(x => x.Time);                   

                    foreach(var h in hoursDev)
                    {
                        GetWholeTime += h;
                    }

                    Contagem.Add(new HourByDeveloper { IdDev = dev.Id, NameDev = dev.Name,  AllTime = GetWholeTime });
                }
            }

            var retorno = Contagem.OrderByDescending(o => o.AllTime).Take(5).ToList();
            return retorno;
        }

        public async Task<bool> CPFExists(long cpf)
        {
            var exist = await  _db.Developers.FirstOrDefaultAsync(x => x.CPF == cpf);

            if(exist == null)
            {
                return false;
            }
            else
            {
                return true;
            }             
        }

        public string GetToken()
        {
            // User found and generate Jwt Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(new Random().Next().ToString());
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
    }
}
