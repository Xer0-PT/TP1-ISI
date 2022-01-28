using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Dashboard
{
    public partial class LastSixMonths
    {
        public CovidRecordDTO Record { get; set; } = new();
        public bool IsLoading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            Record = await DashboardService.GetLast6MonthsCovid();

            IsLoading = false;
        }
    }
}
