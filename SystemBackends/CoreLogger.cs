using CoreLabs.NET.Logger.SystemBackends;

namespace CoreLabs.NET.Logger;

public sealed class LoggerOptions
{
    public LogLevel MinimumLevel { get; set; } = LogLevel.Information;
    public string TimestampFormat { get; set; } = "yyyy-MM-dd HH:mm:ss";
}

public sealed class CoreLogger
{
    private readonly List<ILogger> _sinks = new();
    public LoggerOptions Options { get; } = new();

    public CoreLogger AddSink(ILogger sink)
    {
        _sinks.Add(sink);
        return this;
    }

    public void Log(LogLevel level, string message, Exception? ex = null)
    {
        if (level < Options.MinimumLevel) return;

        foreach (var sink in _sinks)
            sink.Log(level, message, ex);
    }

    // Convenience methods (replaces InfoLogging/SuccessLogging/etc.)
    public void Trace(string message) => Log(LogLevel.Trace, message);
    public void Debug(string message) => Log(LogLevel.Debug, message);
    public void Info(string message) => Log(LogLevel.Information, message);
    public void Success(string message) => Log(LogLevel.Success, message);
    public void Warn(string message) => Log(LogLevel.Warning, message);
    public void Error(string message, Exception? ex = null) => Log(LogLevel.Error, message, ex);
    public void Critical(string message, Exception? ex = null) => Log(LogLevel.Critical, message, ex);
}
