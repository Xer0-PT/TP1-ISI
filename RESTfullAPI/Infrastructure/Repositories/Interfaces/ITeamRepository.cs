using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;

#pragma warning disable CS8632

namespace RestfullAPI.Infrastructure.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllActive();
        Task<List<Team>> GetAll();
        Task<bool> AddTeam(Team input);
        Task<bool> UpdateTeam(Team input);
        Task<bool> RemoveTeam(Team team);
        //Task<Team> GetTeam(int? id, string? name);
        Task<Team> GetTeam(int? id = 0, string? name = null);
    }
}
