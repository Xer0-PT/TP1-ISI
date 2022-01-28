using RestfullAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace RestfullAPI.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IProductRepository _productRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IRequisitionRepository _requisitionRepository;
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IProductRepository productRepository, ITeamRepository teamRepository, IRequisitionRepository requisitionRepository, IDashboardRepository dashboardRepository)
        {
            _productRepository = productRepository;
            _teamRepository = teamRepository;
            _requisitionRepository = requisitionRepository;
            _dashboardRepository = dashboardRepository;
        }


        public async Task<List<TopProductDTO>> GetTop5Products()
        {
            var result = new List<TopProductDTO>();

            var requisitionsProduct = await _requisitionRepository.GetRequisitionProductsAsync();

            var products = await _productRepository.GetAll();

            var topFive = requisitionsProduct.GroupBy(g => g.ProductId)
                                             .OrderByDescending(gp => gp.Count())
                                             .Take(5)
                                             .Select(g => new { Element = g.Key, Counter = g.Sum(x => x.Quantity) })
                                             .ToList();


            foreach (var item in topFive)
            {
                var product = await _productRepository.GetProductAsync(item.Element, null);

                result.Add(new TopProductDTO
                {
                    IdProduct = product.Id,
                    ProductName = product.Name,
                    Count = item.Counter
                });

            }

            result.OrderByDescending(x => x.Count);


            return result;

        }

        public List<ExpensiveTeamDTO> GetExpensivesTeamsAsync()
        {
            var result =  _dashboardRepository.GetExpensiveTeamsAsync();
            return result;
        }

        public async Task<List<Visit>> GetLast30DaysAsync()
        {
            var result = await _dashboardRepository.GetVisitLastDays();
            return result;
        }

        public async Task<CovidRecordDTO> GetLast6Months()
        {
            var result = await _dashboardRepository.GetCovidRecords6Month();

            var days = (DateTime.UtcNow - DateTime.UtcNow.AddMonths(-6)).TotalDays;

            result.MediumNumber = result.TotalCount / days;

            return result;
        }
    }
}
