using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfullAPI.Infrastructure.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

#pragma warning disable CS8632

namespace RestfullAPI.Controllers
{
    /// <summary>
    /// Classe de controladores de requisições de produtos
    /// </summary>

    //api/<RequisitionController>
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitionController : ControllerBase
    {
        private readonly IRequisitionService _requisitionService;

        public RequisitionController(IRequisitionService requisitionService)
        {
            _requisitionService = requisitionService;
        }

        /// <summary>
        /// Método GET que devolve as requisições já existentes de determinada equipa por Id ou por nome
        /// </summary>
        /// <param name="teamId"></param>
        /// <param name="teamName"></param>
        /// <returns></returns>

        [SwaggerOperation("Get requisitions by teamId or teamName", null, Tags = new[] { "4. Requisitions" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<RequisitionDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // GET api/<RequisitionController>/GetRequisitionsByTeam
        [HttpGet("GetRequisitionsByTeam")]
        public async Task<ActionResult<List<RequisitionDTO>>> GetRequisitionsByTeam(int? teamId, string? teamName)
        {
            return Ok(await _requisitionService.GetRequisitionsByTeam(teamId, teamName));
        }

        /// <summary>
        /// Método PUT que cria uma nova requisição
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        [SwaggerOperation("Create a requisition", null, Tags = new[] { "4. Requisitions" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // POST api/<RequisitionController>/CreateRequisition
        [HttpPost("CreateRequisition")]
        public async Task<ActionResult<bool>> CreateRequisition([FromBody] CreateRequisitionDTO input)
        {
            var result = await _requisitionService.CreateRequisition(input.TeamName, input.Product);

            if (result == false) { return BadRequest(new { message = "Team/Product doesn't exist or quantity exceed the stock of product." }); }

            else { return Ok(new { message = "Requisition successfully created." }); }
        }

        /// <summary>
        /// Método GET que devolve todas as requisições
        /// </summary>
        /// <returns></returns>

        [SwaggerOperation("Get all requisitions", null, Tags = new[] { "4. Requisitions" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<RequisitionDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        // GET api/<RequisitionController>/GetAllRequisitions
        [HttpGet("GetAllRequisitions")]
        public async Task<ActionResult<List<RequisitionDTO>>> GetAllRequisitions()
        {
            return Ok(await _requisitionService.GetAllRequisitions());
        }
    }
}
