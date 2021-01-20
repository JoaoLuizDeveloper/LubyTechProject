using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LubyTechAPI.Models;
using LubyTechAPI.Models.DTOs;
using LubyTechAPI.Repository.IRepository;
using X.PagedList;
using System.Threading.Tasks;

namespace LubyTechAPI.Controllers
{
    [Route("api/v{version:apiversion}/projects")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ProjectsController : ControllerBase
    {
        #region Construtor/Injection
        private readonly IProjectRepository _project;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectRepository project, IMapper mapper)
        {
            _project = project;
            _mapper = mapper;
        }
        #endregion

        #region Get List of Projects
        /// <summary>
        /// Get List of Projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type= typeof(List<Project>))]
        public async Task<IActionResult> GetProjects(int page  = 1)
        {
            var pro = await _project.GetProjects();
            return Ok(pro.ToPagedList(page, 5)); 
        }
        #endregion

        #region Get Individual Project
        /// <summary>
        /// Get Individual Project
        /// </summary>
        /// <param name="id">The id of the Project</param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetProject")]
        [ProducesResponseType(200, Type = typeof(Project))]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetProject(int id)
        {
            var obj = await _project.GetProject(id);
            if (obj == null)
            {
                return NotFound();
            }

            var objDTO = _mapper.Map<Project>(obj);
            return Ok(objDTO);
        }
        #endregion

        #region Create Project
        /// <summary>
        /// Create Project
        /// </summary>
        /// <param name="project">Object of the Project</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Project))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateProject([FromBody] ProjectCreateDto project)
        {
            if (project == null)
            {
                return BadRequest(ModelState);
            }

            if (_project.ProjectExists(project.Name))
            {
                ModelState.AddModelError("", "Project already Exist");
                return StatusCode(404, ModelState);
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectsObj = _mapper.Map<Project>(project);

            if (!_project.CreateProject(projectsObj))
            {
                ModelState.AddModelError("",$"Something went wrong when you trying to save {project.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetProject", new { version = HttpContext.GetRequestedApiVersion().ToString(), id = projectsObj.Id }, projectsObj);
        }
        #endregion

        #region Update project
        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="projectDto">Object of the Project</param>
        /// <returns></returns>
        [HttpPatch(Name = "UpdateProject")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProject([FromBody] ProjectUpdateDto projectDto)
        {
            if (projectDto == null)
            {
                return BadRequest(ModelState);
            }

            var projectsObj = _mapper.Map<Project>(projectDto);

            if (!_project.UpdateProject(projectsObj))
            {
                ModelState.AddModelError("", $"Something went wrong when you trying to update {projectDto.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        #endregion

        #region Delete project
        /// <summary>
        /// Delete Project
        /// </summary>
        /// <param name="id">Id of the Project</param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "DeleteProject")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (!_project.ProjectExists(id))
            {
                return NotFound();
            }

            var projectsDto = await _project.GetProject(id);

            if (!_project.DeleteProject(projectsDto))
            {
                ModelState.AddModelError("", $"Something went wrong when you trying to delete {projectsDto.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        #endregion
    }
}