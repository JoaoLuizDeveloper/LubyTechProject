using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LubyTechAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LubyTechAPI.Controllers.Version2
{
    [Route("api/v{version:apiversion}/projects")]
    [ApiVersion("2.0")]
    [ApiController]
    public class ProjectsV2Controller : ControllerBase
    {
        #region Construtor/Injection
        private readonly IProjectRepository _project;
        private readonly IUnitOfWork _unitofwork;
        public readonly IMapper _mapper;

        public ProjectsV2Controller(IUnitOfWork unit, IProjectRepository project, IMapper mapper)
        {
            _project = project;
            _mapper = mapper;
            _unitofwork = unit;
        }
        #endregion

        #region AddDeveloperToProjects
        /// <summary>
        /// Add Developer To Project
        /// </summary>
        /// <param name="developerId">Id of the Developer</param>
        /// <param name="projectId">Id of the Project</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddDeveloperToProject(int developerId, int projectId)
        {
            if (! (await _unitofwork.Project.Exists(projectId)))
            {
                return NotFound();
            }

            if (! (await _unitofwork.Developer.Exists(developerId)))
            {
                return NotFound();
            }


            if (! (await _project.AddDeveloperToProject(developerId, projectId)))
            {
                ModelState.AddModelError("", $"Something went wrong when you trying to add this developer to project");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }
        #endregion
    }
}
