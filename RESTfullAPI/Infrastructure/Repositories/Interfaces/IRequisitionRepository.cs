using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;

namespace RestfullAPI.Infrastructure.Repositories
{
    public interface IRequisitionRepository
    {
        Task<List<Requisition>> GetRequisitionsByTeam(Team team);
        Task<List<Requisition>> GetAllRequisitionsPendents();
        Task<bool> UpdateRequisition(Requisition requisition);
        Task<bool> CreateRequisitionProduct(int requisitionId, Product product, int quantity);
        Task<int> CreateRequisition(Team team);
        Task<List<Requisition>> GetAll();
        Task<List<RequisitionProduct>> GetRequisitionProductsAsync();

    }
}
