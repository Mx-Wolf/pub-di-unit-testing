using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Aweton.Mxw.App;

public class SmartComputerApp(
    ILogger<SmartComputerApp> logger, 
    IPowerSupply powerSupply,
    IHostApplicationLifetime host,
    IFloatingPointCopocessor coproc) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.StartSmartComputerInfo();
        if (powerSupply.IsOnBattery())
        {
            logger.OnBatterWarning();
        }
        var rc = await coproc.Divide(126, 3);
        logger.CompletingComputation(rc);
        
        host.StopApplication();
    }
}
