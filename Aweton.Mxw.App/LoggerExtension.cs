using Microsoft.Extensions.Logging;

namespace Aweton.Mxw.App;

public static partial class LoggerExtension
{
    [LoggerMessage(LogLevel.Information, Message="Smart computer has started")]
    public static partial void StartSmartComputerInfo(this ILogger logger);
    [LoggerMessage(LogLevel.Warning, Message="Power supply interrupted")]
    public static partial void OnBatterWarning(this ILogger logger);
    [LoggerMessage(LogLevel.Information, Message="exiting with result: {result}")]
    public static partial void CompletingComputation(this  ILogger logger,  double result);

}
