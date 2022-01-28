using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public class RequisitionService : IRequisitionService
    {
        private const string RequisitionController = "Requisition";
        private readonly HttpClient httpClient;
        private JsonSerializerOptions json = new() { PropertyNameCaseInsensitive = true };
        public RequisitionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddRequisition(CreateRequisitionDTO requisition)
            => await httpClient.PostAsJsonAsync($"{Config.BaseUrl}/{RequisitionController}/CreateRequisition", requisition, json);

        public async Task<List<RequisitionDTO>> GetAllRequisitions()
            => await httpClient.GetFromJsonAsync<List<RequisitionDTO>>($"{Config.BaseUrl}/{RequisitionController}/GetAllRequisitions", json);

        public async Task<HttpResponseMessage> UpdateRequisition(RequisitionDTO requisition)
            => await httpClient.PutAsJsonAsync($"{Config.BaseUrl}/{RequisitionController}/UpdateRequisition", requisition, json);

        public async Task<List<RequisitionDTO>> GetRequisitionsByTeam(int teamId)
            => await httpClient.GetFromJsonAsync<List<RequisitionDTO>>($"{Config.BaseUrl}/{RequisitionController}/GetRequisitionsByTeam?teamId={teamId}", json);
    }
}
