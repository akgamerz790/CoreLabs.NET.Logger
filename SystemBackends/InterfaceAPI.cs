using System;

namespace CoreLabs.NET.Logger.SystemBackends
{
    public enum LogLevel
    {
        Trace = 0,
        Debug = 1,
        Information = 2,
        Success = 3,
        Warning = 4,
        Error = 5,
        Critical = 6
    }

    public interface ILogger
    {
        void Log(LogLevel level, string message, Exception? exception = null);
    }
}
