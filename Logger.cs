using CoreLabs.NET.Logger.SystemBackends;
using CoreLabs.NET.Logger.SystemBackends.LoggerAPI;

namespace CoreLabs.NET.Logger;

public static class Log
{
    private static readonly CoreLogger _logger = new CoreLogger()
        .AddSink(new ConsoleLogger());

    public static LoggerOptions Options => _logger.Options;

    // Allow app to configure sinks at startup
    public static void AddSink(ILogger sink) => _logger.AddSink(sink);

    public static void Write(LogLevel level, string message, Exception? ex = null)
        => _logger.Log(level, message, ex);

    // Convenience
    public static void Trace(string message) => _logger.Trace(message);
    public static void Debug(string message) => _logger.Debug(message);
    public static void Info(string message) => _logger.Info(message);
    public static void Success(string message) => _logger.Success(message);
    public static void Warn(string message) => _logger.Warn(message);
    public static void Error(string message, Exception? ex = null) => _logger.Error(message, ex);
    public static void Critical(string message, Exception? ex = null) => _logger.Critical(message, ex);
}
