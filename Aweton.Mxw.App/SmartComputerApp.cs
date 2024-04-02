using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Aweton.Mxw.App
{
    public class SmartComputerApp(ILogger<SmartComputerApp> logger, IPowerSupply powerSupply, IHostLifetime host) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.StartSmartComputerInfo();
            if (powerSupply.IsOnBattery())
            {
                logger.OnBatterWarning();
            }
            logger.CompletingComputation(42);
            await host.StopAsync(stoppingToken);
        }
    }
}
