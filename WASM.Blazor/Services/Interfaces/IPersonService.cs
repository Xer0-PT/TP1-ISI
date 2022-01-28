using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public interface IPersonService
    {
        Task<PersonDTO> GetPerson(int id);
        Task<List<PersonDTO>> GetAllPersons();
        Task<HttpResponseMessage> CreatePersonCovid(PersonCovidDTO personCovid);
        Task<List<PersonDTO>> GetAllActivePersons();
        Task<List<PersonCovidDTO>> GetAllCovidPeople();
        Task<PersonDTO> CreatePerson(PersonDTO person);
        Task<HttpResponseMessage> UpdatePerson(PersonDTO person);
        Task<HttpResponseMessage> CreatePersonsContact(List<CreatePersonContactDto> personsList);
        Task<List<PersonDTO>> GetAllContactPersons(int id, DateTime date);
        Task<HttpResponseMessage> DeletePerson(int id);
    }
}
