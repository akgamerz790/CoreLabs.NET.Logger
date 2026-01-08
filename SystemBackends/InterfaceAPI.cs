using System;

namespace CoreLabs.NET.Logger.SystemBackends
{
    public enum LogLevel
    {
        Information,
        Success,
        Warning,
        Error
    }
    public enum LogLevelX
    {
        INFO,
        SUCCESS,
        WARN,
        ERROR
    }

    public interface ILogger
    {
        void Log(LogLevel level, string message);
    }
}