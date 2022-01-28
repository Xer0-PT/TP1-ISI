using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

#pragma warning disable CS8632

namespace RestfullAPI.Infrastructure.Services
{
    public interface IRequisitionService
    {
        Task<bool> CreateRequisition(string teamName, List<ProductQuantityDTO> products);
        Task<List<RequisitionDTO>> GetRequisitionsByTeam(int? teamId, string? teamName);
        Task CheckTimeOfRequisition();
        Task<List<RequisitionDTO>> GetAllRequisitions();
    }
}
