using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Dashboard
{
    public partial class MostExpensiveTeams
    {
        public ExpensiveTeamDTO[] List { get; set; } = Array.Empty<ExpensiveTeamDTO>();

        public double[] Data { get; set; } = Array.Empty<double>();
        public string[] Labels { get; set; } = Array.Empty<string>();
        public int Index { get; set; } = -1;
        public bool IsLoading { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            List = (await DashboardService.GetExpensiveTeams()).OrderByDescending(x => x.TotalPrice).ToArray();

            int length = List.Length;

            Data = new double[length];
            Labels = new string[length];

            for (int i = 0; i < List.Length; i++)
            {
                Data[i] = List[i].TotalPrice;
                Labels[i] = List[i].TeamName;
            }

            IsLoading = false;
        }
    }
}
