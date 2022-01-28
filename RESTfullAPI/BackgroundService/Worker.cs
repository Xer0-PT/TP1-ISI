using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestfullAPI.Infrastructure.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerBackground
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var personService = scope.ServiceProvider.GetService<IPersonService>();
                    var requisitionService = scope.ServiceProvider.GetService<IRequisitionService>();
                    await requisitionService.CheckTimeOfRequisition();
                    await personService.CheckTimeOfCovid();
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.UtcNow);
                    await Task.Delay(30000, stoppingToken);
                }
            }
        }
    }
}
