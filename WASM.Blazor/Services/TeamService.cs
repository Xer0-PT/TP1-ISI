using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public class TeamService : ITeamService
    {
        private const string TeamController = "Team";

        private readonly HttpClient httpClient;

        private JsonSerializerOptions json = new() { PropertyNameCaseInsensitive = true };

        public TeamService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddTeam(TeamDTO team) =>
            await httpClient.PostAsJsonAsync($"{Config.BaseUrl}/{TeamController}/AddTeam", team, json);

        public async Task<List<TeamDTO>> GetAllTeams() => 
            await httpClient.GetFromJsonAsync<List<TeamDTO>>($"{Config.BaseUrl}/{TeamController}/GetAllTeams", json);

        public async Task<List<TeamDTO>> GetAllActiveTeams()
            => await httpClient.GetFromJsonAsync<List<TeamDTO>>($"{Config.BaseUrl}/{TeamController}/GetAllActiveTeams", json);

        public async Task<TeamDTO> GetTeam(int id)
            => await httpClient.GetFromJsonAsync<TeamDTO>($"{Config.BaseUrl}/{TeamController}/GetTeamByIdOrName?id={id}", json);

        public async Task<HttpResponseMessage> UpdateTeam(TeamDTO team) =>
            await httpClient.PutAsJsonAsync($"{Config.BaseUrl}/{TeamController}/UpdateTeam", team, json);

        public async Task<HttpResponseMessage> DeleteTeam(int id)
            => await httpClient.PutAsJsonAsync($"{Config.BaseUrl}/{TeamController}/RemoveTeam?id={id}", json);
    }
}
