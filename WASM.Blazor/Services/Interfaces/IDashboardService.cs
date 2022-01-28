using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public interface IDashboardService
    {
        Task<List<TopProductDTO>> GetTop5Products();
        Task<List<ExpensiveTeamDTO>> GetExpensiveTeams();
        Task<List<Visit>> GetLast30Days();
        Task<CovidRecordDTO> GetLast6MonthsCovid();
        Task<Covid> GetCovidInfo();
    }
}
