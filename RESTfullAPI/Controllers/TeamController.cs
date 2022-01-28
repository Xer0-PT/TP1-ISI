using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfullAPI.Infrastructure.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

#pragma warning disable CS8632

namespace RestfullAPI.Controllers
{
    /// <summary>
    /// Classe de controladores de Equipas
    /// </summary>

    //api/<teamController>
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// Método GET que devolve todas as equipas atualmente ativas
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get all active teams", null, Tags = new[] { "5. Teams" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<TeamDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // GET: api/<teamController>/GetAllActive
        [HttpGet("GetAllActiveTeams")]
        public async Task<ActionResult<List<TeamDTO>>> GetAllActive()
        {
            return Ok(await _teamService.GetAllActive());
        }

        /// <summary>
        /// Método GET que devolva todas as Equipas na DB
        /// </summary>
        /// <returns></returns>
        [SwaggerOperation("Get all teams", null, Tags = new[] { "5. Teams" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<TeamDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet("GetAllTeams")]
        public async Task<ActionResult<List<TeamDTO>>> GetAll()
        {
            return Ok(await _teamService.GetAll());

        }

        /// <summary>
        /// Método GET que devolve uma Equipa por Id ou nome
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [SwaggerOperation("Get team by name or id", null, Tags = new[] { "5. Teams" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(TeamDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // GET api/<teamController>/{5}
        [HttpGet("GetTeamByIdOrName")]
        public async Task<ActionResult<TeamDTO>> GetTeamByIdOrName(int? id, string? name)
        {
            return Ok(await _teamService.GetTeamDTO(id, name));
        }

        /// <summary>
        /// Método POST que cria uma nova equipa
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        [SwaggerOperation("Add a team", null, Tags = new[] { "5. Teams" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // POST api/<teamController>/AddTeam
        [HttpPost("AddTeam")]
        public async Task<ActionResult<bool>> AddTeam([FromBody] TeamDTO team)
        {
            var result = await _teamService.AddTeam(team);

            if (result == false) { return BadRequest(new { message = "Team already exist with that name." }); }

            else { return Ok(new { message = "Team successfully created." }); }
        }

        /// <summary>
        /// Método PUT que atualiza determinada Equipa
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        [SwaggerOperation("Update a team", null, Tags = new[] { "5. Teams" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // PUT api/<teamController>/UpdateTeam
        [HttpPut("UpdateTeam")]
        public async Task<ActionResult<bool>> UpdateTeam([FromBody] TeamDTO team)
        {
            var result = await _teamService.UpdateTeam(team);

            if (result == false) { return BadRequest(new { message = "Team doesn't exist." }); }

            else { return Ok(new { message = "Team successfully updated." }); }

        }

        /// <summary>
        /// Método DELETE que apaga uma equipa atualmente ativa
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [SwaggerOperation("Remove a team", null, Tags = new[] { "5. Teams" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // DELETE api/<teamController>/RemoveTeam
        [HttpPut("RemoveTeam")]
        public async Task<ActionResult<bool>> RemoveTeam(string? name, int? id)
        {
            var result = await _teamService.RemoveTeam(id, name);

            if (result == false) { return BadRequest(new { message = "Team doesn't exist." }); }

            else { return Ok(new { message = "Team successfully removed." }); }
        }
    }
}
