using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LubyTechAPI.Models;
using LubyTechAPI.Repository.IRepository;
using LubyTechAPI.Models.DTOs;
using LubyTechAPI.ViewModel;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace LubyTechAPI.Controllers
{
    [Route("api/v{version:apiversion}/developers")]
    [ApiVersion("2.0")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class DevelopersV2Controller : ControllerBase
    {
        #region Construtor/Injection
        private readonly IUnitOfWork _unitofwork;
        private readonly IDeveloperRepository _dev;
        private readonly IMapper _mapper;

        public DevelopersV2Controller(IUnitOfWork unit, IDeveloperRepository dev, IMapper mapper)
        {
            _dev = dev;
            _mapper = mapper;
            _unitofwork = unit;
        }
        #endregion

        #region Get List of Developers By week Progress
        /// <summary>
        /// Get List of Developers By week Progress
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetRankingOfDevelopers")]
        [ProducesResponseType(200, Type= typeof(List<HourByDeveloper>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ICollection<HourByDeveloper>> GetRankingOfDevelopers()
        {
            return await _dev.GetRankinfOfDevelopers();
        }
        #endregion

        #region Get The Token
        /// <summary>
        /// Get The Token
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("GetToken")]
        public string GetToken()
        {
            return _dev.GetToken();
        }
        #endregion

        #region Add Hour To Project
        /// <summary>
        /// Add Hour To Project
        /// </summary>
        /// <param name="hour">Hour Object with Developer and Project Id</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(201, Type = typeof(Hour))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddHourToProject([FromBody] HourDto hour)
        {
            var objDev = await _unitofwork.Developer.GetFirstOrDefault(x => x.Id == hour.DeveloperId, includeProperties: "DevProjects");
            if (objDev == null)
            {
                return NotFound();
            }
            
            var objProject = await _unitofwork.Project.Get(hour.ProjectId);
            if (objProject == null)
            {
                return NotFound();
            }

            if(objDev.DevProjects.Where(x=> x.ProjectId == hour.ProjectId).Count() == 0)
            {
                ModelState.AddModelError("", $"You do not participate on this Project {objDev.Name}");
                return StatusCode(500, ModelState);
            }

            var HourObj = _mapper.Map<Hour>(hour);

            //Getting the Time in Hours
            HourObj.Time = Math.Round((HourObj.DateEnd.Subtract(HourObj.DateBegin)).TotalHours, 5);

            if (!(await _dev.AddHourToProject(HourObj)))
            {
                ModelState.AddModelError("", $"Something went wrong when you trying to Add the Hour {objDev.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Added Hours");            
        }
        #endregion
    }
}