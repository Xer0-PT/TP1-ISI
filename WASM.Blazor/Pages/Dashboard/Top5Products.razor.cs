using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Pages.Dashboard
{
    public partial class Top5Products
    {
        public TopProductDTO[] List { get; set; } = System.Array.Empty<TopProductDTO>();

        public double[] Data { get; set; } = System.Array.Empty<double>();
        public string[] Labels { get; set; } = System.Array.Empty<string>();
        public int Index { get; set; } = -1;
        public bool IsLoading { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            List = (await DashboardService.GetTop5Products()).OrderByDescending(x => x.Count).ToArray();

            int length = List.Length;

            Data = new double[length];
            Labels = new string[length];

            for (int i = 0; i < length; i++)
            {
                Data[i] = List[i].Count;
                Labels[i] = List[i].ProductName;
            }
            IsLoading = false;
        }
    }
}
