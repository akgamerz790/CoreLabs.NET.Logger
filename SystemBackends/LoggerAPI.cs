using CoreLabs.NET.Logger.SystemBackends;

namespace CoreLabs.NET.Logger.SystemBackends.LoggerAPI;

public sealed class ConsoleLogger : ILogger
{
    public void Log(LogLevel level, string message, Exception? exception = null)
    {
        SetColor(level);

        var ts = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"[{level}] {ts}: {message}");

        if (exception is not null)
        {
            Console.WriteLine(exception); // prints type/message/stacktrace
        }

        Colors.ConsoleColorManager.Reset();
    }

    private static void SetColor(LogLevel level)
    {
        switch (level)
        {
            case LogLevel.Trace:
            case LogLevel.Debug:
            case LogLevel.Information: Colors.ConsoleColorManager.Info(); break;
            case LogLevel.Success:     Colors.ConsoleColorManager.Success(); break;
            case LogLevel.Warning:     Colors.ConsoleColorManager.Warning(); break;
            case LogLevel.Error:
            case LogLevel.Critical:    Colors.ConsoleColorManager.Error(); break;
        }
    }
}
