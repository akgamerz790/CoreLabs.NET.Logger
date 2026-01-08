using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreLabs.NET.Logger.SystemBackends.LoggerAPI
{
    public class ConsoleLogger : ILogger
    {
        public void LogInformation(string message)
        {
            Colors.ConsoleColorManager.Info();
            Write("INFO", message);
        }

        public void LogSuccess(string message)
        {
            Colors.ConsoleColorManager.Success();
            Write("SUCCESS", message);
        }

        public void LogWarning(string message)
        {
            Colors.ConsoleColorManager.Warning();
            Write("WARN", message);
        }

        public void LogError(string message)
        {
            Colors.ConsoleColorManager.Error();
            Write("ERROR", message);
        }

        private static void Write(string level, string message)
        {
            Console.WriteLine($"[{level}] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
            Colors.ConsoleColorManager.Reset();
        }
    }
}