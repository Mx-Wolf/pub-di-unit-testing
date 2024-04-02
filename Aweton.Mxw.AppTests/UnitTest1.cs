using Aweton.Mxw.App;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;

namespace Aweton.Mxw.AppTests
{
    [TestClass]
    public class DiContainerTest
    {


        [DataRow(typeof(IPowerSupply))]
        [DataRow(typeof(ILogger))]
        [DataRow(typeof(IHostApplicationLifetime))]
        [TestMethod]
        public void ThrowsIfAnyExternalTypeNotRegistered(Type type)
        {
            var sc = (new Mock[] {
                new Mock<IPowerSupply>(),
                new Mock<ILogger>(),
                new Mock<IHostApplicationLifetime>(),
            })
            .Where(b => b.GetComponentType() != type)
            .Aggregate(
                new ServiceCollection() as IServiceCollection,
                (a, b) => a.AddSingleton(type, b.Object)
              );
            Assert.ThrowsException<ArgumentException>(sc.ConfitureSmartComputer);
        }

        [TestMethod]
        public void CanProvideInstance()
        {
            var sc = new ServiceCollection();
            sc.AddSingleton(new Mock<IPowerSupply>().Object);
            sc.AddSingleton(new Mock<IHostApplicationLifetime>().Object);
            sc.AddLogging();
            var provider = sc.ConfitureSmartComputer().BuildServiceProvider();
            var result = provider.GetService<IHostedService>();
            Assert.IsNotNull(result);
        }
    }
}