using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace RestfullAPI.Infrastructure.Repositories
{
    public interface IDashboardRepository
    {
        List<ExpensiveTeamDTO> GetExpensiveTeamsAsync();
        Task<List<Visit>> GetVisitLastDays();
        Task<CovidRecordDTO> GetCovidRecords6Month();
    }
}
