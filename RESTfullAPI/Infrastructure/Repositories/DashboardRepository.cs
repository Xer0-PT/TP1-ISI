using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Context;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace RestfullAPI.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly DataContext _context;

        public DashboardRepository(DataContext context)
        {
            _context = context;
        }


        public List<ExpensiveTeamDTO> GetExpensiveTeamsAsync()
        {




            var a = (from requisitionsproduct in _context.RequisitionProducts
                     join requisitions in _context.Requisitions on requisitionsproduct.RequisitionId equals requisitions.Id
                     join product in _context.Products on requisitionsproduct.ProductId equals product.Id
                     join team in _context.Teams on requisitions.TeamId equals team.Id
                     select new ExpensiveTeamDTO
                     {
                         TeamId = requisitions.TeamId,
                         TeamName = team.Name,
                         TotalPrice = product.Price * requisitionsproduct.Quantity
                     }).ToList();

            var result = a.GroupBy(x => x.TeamName).Select(x => new ExpensiveTeamDTO
            {
                TeamId = x.Select(x => x.TeamId).FirstOrDefault(),
                TeamName = x.Select(x => x.TeamName).FirstOrDefault(),
                TotalPrice = x.Sum(y => y.TotalPrice)
            }).OrderByDescending(x => x.TotalPrice).Take(10).ToList();
            

            return result;
                
        }

        public async Task<List<Visit>> GetVisitLastDays()
        {
            var result = new List<Visit>();

            var now = DateTime.UtcNow.AddDays(-30);

            result =  _context.Visits.Where(x => x.DateOfVisit.Date >= now.Date).ToList();


            return result;

        }

        public async Task<CovidRecordDTO> GetCovidRecords6Month()
        {
            var result = new CovidRecordDTO();

            var now = DateTime.UtcNow.AddMonths(-6);

            var personCovid = _context.PersonCovids.Where(x => x.DateOfInfection >= now).ToList();

            foreach (var item in personCovid)
            {
               
                result.DateOfInfection.Add(item.DateOfInfection);
            }

            result.TotalCount = result.DateOfInfection.Count();


            return result;

        }



    }
}
