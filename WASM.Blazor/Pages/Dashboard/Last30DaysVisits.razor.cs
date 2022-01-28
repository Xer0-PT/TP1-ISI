using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Models;

namespace WASM.Blazor.Pages.Dashboard
{
    public partial class Last30DaysVisits
    {
        public List<Visit> List { get; set; } = new();
        public List<double> IrregularitiesData { get; set; } = new();
        public List<double> VisitsData { get; set; } = new();
        public List<double> IrregularitiesPercentagePerDay { get; set; } = new();
        public List<string> XAxisLabels { get; set; } = new();
        public List<DateTime> DatesArray { get; set; } = new();
        public ChartOptions Options { get; set; } = new();
        public int TotalVisits { get; set; }
        public int TotalIrregularities { get; set; }
        public List<ChartSeries> Series { get; set; } = new();
        public bool IsLoading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            List = (await DashboardService.GetLast30Days()).OrderBy(x => x.DateOfVisit).ToList();

            Options.YAxisTicks = 1; // altera escala do gráfico

            if (List.Count > 0)
            {
                TotalVisits = List.Count;

                TotalIrregularities = List.Select(x => x.Transgressions).Sum();

                var date = DateTime.UtcNow.AddDays(-30);

                for (int i = 0; i < 30; i++)
                {
                    var aux = List.Where(x => x.DateOfVisit.Date == date.Date).ToList();

                    if (aux.Count > 0)
                    {
                        DatesArray.Add(date);
                        XAxisLabels.Add(date.ToString("dd/MM"));
                    }
                    
                    date = date.AddDays(1);
                }

                foreach (var item in DatesArray)
                {
                    var visitsCount = List.Where(x => x.DateOfVisit.Date == item.Date).Count();
                    VisitsData.Add(visitsCount);

                    var irregularitiesCount = List.Where(x => x.DateOfVisit.Date == item.Date).Select(x => x.Transgressions).Sum();
                    IrregularitiesData.Add(irregularitiesCount);

                    var percentage = (double)(irregularitiesCount / (double)TotalIrregularities) * 100;

                    IrregularitiesPercentagePerDay.Add(percentage);
                }

                Series = new List<ChartSeries>()
                {
                    new ChartSeries() { Name = "Visits", Data = VisitsData.ToArray() },
                    new ChartSeries() { Name = "Irregularities", Data = IrregularitiesData.ToArray() },
                    new ChartSeries() { Name = "Irregularities Percentage", Data = IrregularitiesPercentagePerDay.ToArray() },
                };
            }
            IsLoading = false;
        }
    }
}
