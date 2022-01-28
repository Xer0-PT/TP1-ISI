using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace RestfullAPI.Infrastructure.Services
{
    public interface IDashboardService
    {
        Task<List<TopProductDTO>> GetTop5Products();
        List<ExpensiveTeamDTO> GetExpensivesTeamsAsync();
        Task<List<Visit>> GetLast30DaysAsync();

        Task<CovidRecordDTO> GetLast6Months();
    }
}
