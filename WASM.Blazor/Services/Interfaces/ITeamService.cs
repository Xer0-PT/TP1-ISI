using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public interface ITeamService
    {
        Task<List<TeamDTO>> GetAllTeams();
        Task<List<TeamDTO>> GetAllActiveTeams();
        Task<HttpResponseMessage> AddTeam(TeamDTO team);
        Task<HttpResponseMessage> UpdateTeam(TeamDTO team);
        Task<TeamDTO> GetTeam(int id);
        Task<HttpResponseMessage> DeleteTeam(int id);
    }
}
