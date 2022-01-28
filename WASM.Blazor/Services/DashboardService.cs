using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public class DashboardService : IDashboardService
    {
        private const string DashboardController = "Dashboard";
        private string RequestUri = $"{Config.BaseUrl}/{DashboardController}";
        private readonly HttpClient tokenHttpClient;
        private readonly HttpClient baseHttpClient;
        private JsonSerializerOptions json = new() { PropertyNameCaseInsensitive = true };

        public DashboardService(HttpClient httpClient, HttpClient coinHttpClient)
        {
            this.tokenHttpClient = httpClient;

            this.tokenHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.OAuthToken);
            this.baseHttpClient = coinHttpClient;
        }

        public async Task<List<TopProductDTO>> GetTop5Products()
            => await tokenHttpClient.GetFromJsonAsync<List<TopProductDTO>>($"{RequestUri}/GetTop5Products", json);

        public async Task<List<ExpensiveTeamDTO>> GetExpensiveTeams()
            => await tokenHttpClient.GetFromJsonAsync<List<ExpensiveTeamDTO>>($"{RequestUri}/Get10ExpensiveTeams", json);

        public async Task<List<Visit>> GetLast30Days()
            => await tokenHttpClient.GetFromJsonAsync<List<Visit>>($"{RequestUri}/Last30Days", json);

        public async Task<CovidRecordDTO> GetLast6MonthsCovid()
            => await tokenHttpClient.GetFromJsonAsync<CovidRecordDTO>($"{RequestUri}/Last6MonthsCovid", json);

        public async Task<Covid> GetCovidInfo()
            => await baseHttpClient.GetFromJsonAsync<Covid>($"https://covid19-api.vost.pt/Requests/get_last_update", json);
    }
}
