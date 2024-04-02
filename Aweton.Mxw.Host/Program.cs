using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Aweton.Mxw.App;
using Aweton.Mxw.BrainPower;

var build = Host.CreateDefaultBuilder();
build.ConfigureServices(services =>
{
    services.AddSingleton<IPowerSupply, BrainPowerSupply>();
    services.ConfitureSmartComputer();
});

var app  = build.Build();
app.Run();