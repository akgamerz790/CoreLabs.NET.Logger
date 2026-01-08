using CoreLabs.NET.Logger.SystemBackends;
using CoreLabs.NET.Logger.SystemBackends.LoggerAPI;

namespace CoreLabs.NET.Logger;

public static class InfoLogging
{
    public static void Log(string message) => LogHelper.Log(message, LogLevel.Information);
}
public static class SuccessLogging
{
    public static void Log(string message) => LogHelper.Log(message, LogLevel.Success);
}
public static class WarnLogging
{
    public static void Log(string message) => LogHelper.Log(message, LogLevel.Warning);
}
public static class ErrorLogging
{
    public static void Log(string message) => LogHelper.Log(message, LogLevel.Error);
}
public static class LogHelper
{
    private static readonly ILogger _logger = new ConsoleLogger();

    public static void Log(string message, LogLevel level)
    {
        _logger.Log(level, message);
    }

    // convenience default
    public static void Log(string message) => Log(message, LogLevel.Information);
}
