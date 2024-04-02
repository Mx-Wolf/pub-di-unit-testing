using Aweton.Mxw.App;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;

namespace Aweton.Mxw.AppTests
{
    [TestClass]
    public class DiContainerTest
    {
        
        [TestMethod]
        public void ThrowsIfNotEnough()
        {
            var sc = new ServiceCollection();
            Assert.ThrowsException<ArgumentException>(() => sc.ConfitureSmartComputer());
        }
        [TestMethod]
        public void ThrowsIfNoLogger()
        {
            var ps = new Mock<IPowerSupply>();
            var sc = new ServiceCollection();
            sc.AddSingleton(ps.Object);
            Assert.ThrowsException<ArgumentException>(() => sc.ConfitureSmartComputer());
        }
        [TestMethod]
        public void CanProvideInstance ()
        {
            var ps = new Mock<IPowerSupply>();
            var sc = new ServiceCollection();
            sc.AddSingleton(ps.Object);
            sc.AddLogging();
            var provider = sc.ConfitureSmartComputer().BuildServiceProvider();
            var result = provider.GetService<IHostedService>();
            Assert.IsNotNull(result);
        }
    }
}