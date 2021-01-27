using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LubyTechAPI.Models;
using LubyTechAPI.Repository.IRepository;
using LubyTechAPI.Models.DTOs;
using X.PagedList;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LubyTechAPI.Controllers
{
    [Route("api/v{version:apiversion}/developers")]
    [ApiVersion("1.0")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class DevelopersController : ControllerBase
    {
        #region Construtor/Injection
        private readonly IUnitOfWork _unitofwork;
        public readonly IDeveloperRepository _dev;
        private readonly IMapper _mapper;

        public DevelopersController(IUnitOfWork unit, IDeveloperRepository dev, IMapper mapper)
        {
            _unitofwork = unit;
            _dev = dev;
            _mapper = mapper;
        }
        #endregion

        #region Get List of Developers
        /// <summary>
        /// Get List of Developers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type= typeof(List<Developer>))]
        public async Task<IEnumerable<Developer>> GetDevelopers()
        {
            return await _unitofwork.Developer.GetAll();
        }
        #endregion

        #region Get Individual Developer
        /// <summary>
        /// Get Individual Developer
        /// </summary>
        /// <param name="id">The id of the Developer</param>
        /// <returns></returns>
        [HttpGet("GetDeveloper/{id:int}", Name = "GetDeveloper")]
        [ProducesResponseType(200, Type = typeof(Developer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<Developer> GetDeveloper(int id)
        {
            var obj = await _unitofwork.Developer.Get(id);
            if (obj == null)
            {
                return null;
            }

            return obj;
        }
        #endregion

        #region Create Developer
        /// <summary>
        /// CreateDeveloper
        /// </summary>
        /// <param name="developers">Create of Developers</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Developer))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDeveloper([FromBody] DeveloperCreateDto developers)
        {
            if (developers == null)
            {
                return BadRequest(ModelState);
            }

            //if( await _unitofwork.Developer.ExistbyName(developers.Name))
            //{
            //    ModelState.AddModelError("", "Developers already Exist");
            //    return StatusCode(404, ModelState);
            //}

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var developerObj = _mapper.Map<Developer>(developers);

            if (!(await _unitofwork.Developer.Add(developerObj)))
            {
                ModelState.AddModelError("",$"Something went wrong when you trying to save {developerObj.Name}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetDeveloper", new { version=HttpContext.GetRequestedApiVersion().ToString(), id= developerObj.Id }, developers);
        }
        #endregion

        #region Update Developer
        /// <summary>
        /// UpdateDeveloper
        /// </summary>
        /// <param name=" developer">Object of Developer</param>
        /// <returns></returns>
        [HttpPatch(Name = "UpdateDeveloper")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDeveloper([FromBody] DeveloperUpdateDto developer)
        {
            if (developer == null)
            {
                return BadRequest(ModelState);
            }

            var developerObj = _mapper.Map<Developer>(developer);

            if (!(await _unitofwork.Developer.Update(developerObj)))
            {
                ModelState.AddModelError("", $"Something went wrong when you trying to update {developerObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        #endregion

        #region Delete Developer
        /// <summary>
        /// DeleteDeveloper
        /// </summary>
        /// <param name="id">Id of Developer</param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "DeleteDeveloper")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            if ( !(await _unitofwork.Developer.Exists(id)))
            {
                return NotFound();
            }

            var developerObj = await _unitofwork.Developer.Get(id);

            if (!(await _unitofwork.Developer.Remove(id)))
            {
                ModelState.AddModelError("", $"Something went wrong when you trying to delete {developerObj.Name}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        #endregion

        #region Developer CPF already  Exist?
        /// <summary>
        /// The Developer CPF already  Exist?
        /// </summary>
        /// <param name="cpf">The Developer CPF</param>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(Developer))]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [HttpGet("SearchCpf/{cpf:long}", Name = "SearchCpf")]
        public async Task<bool> SearchCpf(long cpf)
        {
            if (cpf > 0)
            {
                if (!await _unitofwork.Developer.CPFExists(cpf))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}