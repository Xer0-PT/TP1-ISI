using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;

namespace WASM.Blazor.Pages.Dashboard
{
    public partial class CovidInfo
    {
        public Covid Covid { get; set; }
        
        public double[] DataPie { get; set; } = Array.Empty<double>();
        public string[] LabelsPie { get; set; } = Array.Empty<string>();
        
        public List<ChartSeries> SeriesBar1 { get; set; } = new();
        public string[] XAxisLabelsBar1 { get; set; } = Array.Empty<string>();
        public ChartOptions Options1 { get; set; } = new();

        public List<ChartSeries> SeriesBar2 { get; set; } = new();
        public ChartOptions Options2 { get; set; } = new();

        public List<ChartSeries> SeriesBar3 { get; set; } = new();
        public string[] XAxisLabelsBar3 { get; set; } = Array.Empty<string>();
        public ChartOptions Options3 { get; set; } = new();


        public int IndexPie { get; set; } = -1;
        public bool IsLoading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            Covid = await DashboardService.GetCovidInfo();
            

            LabelsPie = new string[] { "Confirmados", "Obitos" };

            DataPie = new double[] { Covid.Confirmados, Covid.Obitos };


            Options1.YAxisTicks = 10000; // altera escala do gráfico

            XAxisLabelsBar1 = new string[] {
                "0-9",
                "10-19",
                "20-29",
                "30-39",
                "40-49",
                "50-59",
                "60-69",
                "70-79",
                "80+"
            };

            SeriesBar1 = new List<ChartSeries>()
                {
                    new ChartSeries() { Name = "F", Data = new double[] {
                        Covid.Confirmados_0_9_f,
                        Covid.Confirmados_10_19_f,
                        Covid.Confirmados_20_29_f,
                        Covid.Confirmados_30_39_f,
                        Covid.Confirmados_40_49_f,
                        Covid.Confirmados_50_59_f,
                        Covid.Confirmados_60_69_f,
                        Covid.Confirmados_70_79_f,
                        Covid.Confirmados_80_plus_f 
                        }
                    },

                    new ChartSeries() { Name = "M", Data = new double[] {
                        Covid.Confirmados_0_9_m,
                        Covid.Confirmados_10_19_m,
                        Covid.Confirmados_20_29_m,
                        Covid.Confirmados_30_39_m,
                        Covid.Confirmados_40_49_m,
                        Covid.Confirmados_50_59_m,
                        Covid.Confirmados_60_69_m,
                        Covid.Confirmados_70_79_m,
                        Covid.Confirmados_80_plus_m
                        }
                    }
                };

            
            
            
            Options2.YAxisTicks = 1000; // altera escala do gráfico

            SeriesBar2 = new List<ChartSeries>()
                {
                    new ChartSeries() { Name = "F", Data = new double[] {
                        Covid.Obitos_0_9_f,
                        Covid.Obitos_10_19_f,
                        Covid.Obitos_20_29_f,
                        Covid.Obitos_30_39_f,
                        Covid.Obitos_40_49_f,
                        Covid.Obitos_50_59_f,
                        Covid.Obitos_60_69_f,
                        Covid.Obitos_70_79_f,
                        Covid.Obitos_80_plus_f
                        }
                    },

                    new ChartSeries() { Name = "M", Data = new double[] {
                        Covid.Obitos_0_9_m,
                        Covid.Obitos_10_19_m,
                        Covid.Obitos_20_29_m,
                        Covid.Obitos_30_39_m,
                        Covid.Obitos_40_49_m,
                        Covid.Obitos_50_59_m,
                        Covid.Obitos_60_69_m,
                        Covid.Obitos_70_79_m,
                        Covid.Obitos_80_plus_m
                        }
                    }
                };




            Options3.YAxisTicks = 20000; // altera escala do gráfico

            XAxisLabelsBar3 = new string[] {
                "ARS Norte",
                "ARS Centro",
                "ARS LVT",
                "ARS Alentejo",
                "ARS Algarve",
                "Açores",
                "Madeira"                
            };

            SeriesBar3 = new List<ChartSeries>()
                {
                    new ChartSeries() { Name = "Confirmados", Data = new double[] {
                        Covid.Confirmados_arsnorte,
                        Covid.Confirmados_arscentro,
                        Covid.Confirmados_arslvt,
                        Covid.Confirmados_arsalentejo,
                        Covid.Confirmados_arsalgarve,
                        Covid.Confirmados_acores,
                        Covid.Confirmados_madeira
                        }
                    },
                    new ChartSeries() { Name = "Óbitos", Data = new double[] {
                        Covid.Obitos_arsnorte,
                        Covid.Obitos_arscentro,
                        Covid.Obitos_arslvt,
                        Covid.Obitos_arsalentejo,
                        Covid.Obitos_arsalgarve,
                        Covid.Obitos_acores,
                        Covid.Obitos_madeira
                        }
                    }
                };

            IsLoading = false;
        }
    }
}
