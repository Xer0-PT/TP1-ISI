using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Threading.Tasks;
using WASM.Blazor.Services;

namespace WASM.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder
                .Services.AddHttpClient<ITeamService, TeamService>(client =>
                {
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                })
                .Services.AddHttpClient<IProductService, ProductService>(client =>
                {
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                })
                .Services.AddHttpClient<IRequisitionService, RequisitionService>(client =>
                {
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                })
                .Services.AddHttpClient<IPersonService, PersonService>(client =>
                {
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                })
                .Services.AddHttpClient<IDashboardService, DashboardService>(client =>
                {
                    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
                });
                


            builder.Services.AddMudServices();
            

            await builder.Build().RunAsync();
        }
    }
}
