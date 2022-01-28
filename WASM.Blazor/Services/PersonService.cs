using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public class PersonService : IPersonService
    {
        private const string PersonController = "Person";
        private string RequestUri = $"{Config.BaseUrl}/{PersonController}";
        private readonly HttpClient httpClient;
        private JsonSerializerOptions json = new() { PropertyNameCaseInsensitive = true };

        public PersonService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
        public async Task<PersonDTO> CreatePerson(PersonDTO person)
        {
            var response = await httpClient.PostAsJsonAsync($"{RequestUri}/CreatePerson", person, json);
            return await response.Content.ReadFromJsonAsync<PersonDTO>();
        }

        public async Task<HttpResponseMessage> CreatePersonCovid(PersonCovidDTO personCovid)
            => await httpClient.PostAsJsonAsync($"{RequestUri}/CreatePersonCovid", personCovid, json);

        public async Task<HttpResponseMessage> CreatePersonsContact(List<CreatePersonContactDto> personsList)
            => await httpClient.PostAsJsonAsync($"{RequestUri}/CreatePersonsContact", personsList, json);

        public async Task<List<PersonDTO>> GetAllActivePersons()
            => await httpClient.GetFromJsonAsync<List<PersonDTO>>($"{RequestUri}/GetAllActivePersons", json);

        public async Task<List<PersonDTO>> GetAllPersons()
            => await httpClient.GetFromJsonAsync<List<PersonDTO>>($"{RequestUri}/GetAllPersons", json);

        public async Task<PersonDTO> GetPerson(int id)
            => await httpClient.GetFromJsonAsync<PersonDTO>($"{RequestUri}/GetPerson?id={id}", json);

        public async Task<HttpResponseMessage> UpdatePerson(PersonDTO person)
            => await httpClient.PutAsJsonAsync($"{RequestUri}/UpdatePerson", person, json);

        public async Task<List<PersonCovidDTO>> GetAllCovidPeople()
            => await httpClient.GetFromJsonAsync<List<PersonCovidDTO>>($"{RequestUri}/GetAllCovidPeople", json);

        public async Task<List<PersonDTO>> GetAllContactPersons(int id, DateTime date)
            => await httpClient.GetFromJsonAsync<List<PersonDTO>>($"{RequestUri}/GetAllContacts?id={id}&date={date}", json);

        public async Task<HttpResponseMessage> DeletePerson(int id)
            => await httpClient.PutAsJsonAsync($"{RequestUri}/DeletePerson?id={id}", json);
    }
}
