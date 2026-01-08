using System;
using CoreLabs.NET.Logger.SystemBackends;

namespace CoreLabs.NET.Logger.SystemBackends.LoggerAPI
{
    public class ConsoleLogger : ILogger
    {
        public void Log(LogLevel level, string message)
        {
            Write(level, message);
        }

        private static void Write(LogLevel level, string message)
        {
            // set color per level
            switch (level)
            {
                case LogLevel.Information: Colors.ConsoleColorManager.Info(); break;
                case LogLevel.Success:     Colors.ConsoleColorManager.Success(); break;
                case LogLevel.Warning:     Colors.ConsoleColorManager.Warning(); break;
                case LogLevel.Error:       Colors.ConsoleColorManager.Error(); break;
            }

            Console.WriteLine($"[{level}] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
            Colors.ConsoleColorManager.Reset();
        }
    }
}