using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace Aweton.Mxw.App
{
    public static class DependencyInjectionContainerConfigurator
    {
        public static IServiceCollection ConfitureSmartComputer(this IServiceCollection services) {
            if(!services.Any(e => e.ServiceType.IsAssignableTo(typeof(IPowerSupply))))
            {
                throw new ArgumentException($"{typeof(SmartComputerApp).Name} depends on existing service of type {typeof(IPowerSupply).Name} to be present");
            }
            if (!services.Any(e => e.ServiceType.IsAssignableTo(typeof(ILogger))))
            {
                throw new ArgumentException($"{typeof(SmartComputerApp).Name} depends on existing service of type {typeof(ILogger).Name} to be present");
            }

            return services.AddHostedService<SmartComputerApp>();
        }
    }
}
