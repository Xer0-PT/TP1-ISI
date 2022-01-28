using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfullAPI.Connected_Services.PersonSoapService;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersons _personsClient;
        private readonly IMapper _mapper;
        public PersonController(IPersons personsClient, IMapper mapper)
        {
            _personsClient = personsClient;
            _mapper = mapper;
        }

        [SwaggerOperation("Get Person by Id", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(PersonDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet("GetPerson")]
        public async Task<ActionResult<PersonDTO>> GetPerson(int id)
        {
            var person = await _personsClient.GetPersonAsync(id);

            return Ok(_mapper.Map<PersonDTO>(person));
        }

        [SwaggerOperation("Get All Persons", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<PersonDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet("GetAllPersons")]
        public async Task<ActionResult<List<PersonDTO>>> GetAllPersons()
        {
            var personsList = await _personsClient.GetAllPersonsAsync();

            return Ok(_mapper.Map<List<PersonDTO>>(personsList));
        }

        [SwaggerOperation("Get Active All Persons", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<PersonDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet("GetAllActivePersons")]
        public async Task<ActionResult<List<PersonDTO>>> GetAllActivePersons()
        {
            var personsList = await _personsClient.GetAllActivePersonsAsync();

            return Ok(_mapper.Map<List<PersonDTO>>(personsList));
        }

        [SwaggerOperation("POST Create Person", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(PersonDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost("CreatePerson")]
        public async Task<ActionResult<PersonDTO>> CreatePerson([FromBody] PersonDTO person)
        {
            var result = await _personsClient.CreatePersonAsync(_mapper.Map<Person>(person));

            if (result == null) { return BadRequest(new { message = "Person already exist with that name." }); }

            else { return Ok(_mapper.Map<PersonDTO>(result)); }
        }

        [SwaggerOperation("PUT Update Person", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(PersonDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPut("UpdatePerson")]
        public async Task<ActionResult<bool>> UpdatePerson([FromBody] PersonDTO input)
        {
            var result = await _personsClient.UpdatePersonAsync(input.Id, input.Covid, input.Name, input.SnsNumber, input.Email);
            
            if (result == false) { return BadRequest(new { message = "Person doesn't exist" }); }

            else { return Ok(new { message = "Person successfully updated." }); }
        }

        [SwaggerOperation("Delete a Person", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPut("DeletePerson")]
        public async Task<ActionResult<bool>> DeletePerson(int id)
        {
            var result = await _personsClient.DeletePersonAsync(id);

            if (result == false) { return BadRequest(new { message = "Person doesn't exist" }); }

            else { return Ok(new { message = "Person successfully removed." }); }
        }

        [SwaggerOperation("Create a Person Covid", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(PersonCovidDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost("CreatePersonCovid")]
        public async Task<ActionResult<bool>> CreatePersonCovid([FromBody] PersonCovidDTO person)
        {
            var result = await _personsClient.CreatePersonCovidAsync(_mapper.Map<PersonCovid>(person));

            if (result == false) { return BadRequest(new { message = "Person does not exist." }); }

            else { return Ok(new { message = "Person successfully created." }); }
        }

        [SwaggerOperation("Get all Person Covid", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(PersonCovidDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet("GetAllCovidPeople")]
        public async Task<ActionResult<List<PersonCovidDTO>>> GetAllCovidPeople()
        {
            var personsList = await _personsClient.GetAllCovidPeopleAsync();

            return Ok(_mapper.Map<List<PersonCovidDTO>>(personsList));
        }

        [SwaggerOperation("Create all Person Contact", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(bool))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpPost("CreatePersonsContact")]
        public async Task<ActionResult<bool>> CreatePersonsContact([FromBody] List<CreatePersonContactDto> personsList)
        {
            bool result = true;

            foreach (var item in personsList)
            {
                var contactPerson = _mapper.Map<Person>(item.ContactPerson);
                var infectedPerson = _mapper.Map<Person>(item.InfectedPerson);
                var personContact = new PersonContact(
                        item.InfectedPersonId,
                        item.ContactPersonID,
                        item.Date,
                        contactPerson,
                        infectedPerson
                    );

                await _personsClient.CreatePersonContactAsync(personContact);
            }

            if (result == false) { return BadRequest(new { message = "Person does not exist." }); }

            else { return Ok(new { message = "Person successfully created." }); }
        }

        [SwaggerOperation("Get all Contacts", null, Tags = new[] { "2. Persons" })]
        [SwaggerResponse(StatusCodes.Status200OK, Description = "Method successfully executed.", Type = typeof(List<PersonDTO>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Description = "The endpoint or data structure is not in line with expectations.", Type = typeof(BadRequestResult))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, Description = "Api key authentication was not provided or it is not valid.", Type = typeof(UnauthorizedResult))]
        [SwaggerResponse(StatusCodes.Status403Forbidden, Description = "You do not have permissions to perform the operation.", Type = typeof(StatusCodeResult))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Description = "The requested resource was not found.", Type = typeof(NotFoundResult))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, Description = "An unexpected API error has occurred.", Type = typeof(StatusCodeResult))]
        [HttpGet("GetAllContacts")]
        public async Task<ActionResult<List<PersonDTO>>> GetAllContacts(int id, DateTime date)
        {
            var personsList = await _personsClient.GetAllContactsAsync(id, date);

            return Ok(_mapper.Map<List<PersonDTO>>(personsList));
        }

    }
}
