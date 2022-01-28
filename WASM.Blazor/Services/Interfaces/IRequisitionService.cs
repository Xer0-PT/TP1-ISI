using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public interface IRequisitionService
    {
        Task<List<RequisitionDTO>> GetAllRequisitions();
        Task<HttpResponseMessage> AddRequisition(CreateRequisitionDTO requisition);
        Task<HttpResponseMessage> UpdateRequisition(RequisitionDTO requisition);
        Task<List<RequisitionDTO>> GetRequisitionsByTeam(int teamId);
    }
}
