using System;

namespace CoreLabs.NET.Logger.SystemBackends
{
    public interface ILogger
    {
        void LogInformation(string message);
        void LogSuccess(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}