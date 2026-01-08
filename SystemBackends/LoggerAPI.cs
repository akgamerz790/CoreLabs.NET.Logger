using System;
using CoreLabs.NET.Logger.SystemBackends;

namespace CoreLabs.NET.Logger.SystemBackends.LoggerAPI
{
    /// <summary>
    /// A simple console sink that writes log entries to the standard output with a timestamp
    /// and color-coded severity.
    /// </summary>
    /// <remarks>
    /// Behavior and responsibilities:
    /// - Prepares a compact, human-friendly line prefixed with the <see cref="LogLevel"/> and timestamp.
    /// - Applies console foreground color via <c>Colors.ConsoleColorManager</c> before writing
    ///   and resets the color afterwards.
    /// - Writes exception details (type, message, stack trace) if an <paramref name="exception"/> is provided.
    /// 
    /// Notes:
    /// - The sink is intended for local development and small tools. For production usage,
    ///   use a file or remote sink that supports batching and durable storage.
    /// - The implementation is minimal and focuses on clarity of output rather than structured logging.
    /// </remarks>
    public sealed class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Emit a log entry to the console.
        /// </summary>
        /// <param name="level">Severity level.</param>
        /// <param name="message">Text message to emit.</param>
        /// <param name="exception">Optional exception to print after the message.</param>
        public void Log(LogLevel level, string message, Exception? exception = null)
        {
            try
            {
                SetColor(level);

                var ts = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Console.WriteLine($"[{level}] {ts}: {message}");

                if (exception is not null)
                {
                    // Write exception details on subsequent lines to keep the main line compact.
                    Console.WriteLine(exception.ToString());
                }
            }
            catch
            {
                // Swallow internal errors to avoid impacting callers; fail silently.
            }
            finally
            {
                Colors.ConsoleColorManager.Reset();
            }
        }

        /// <summary>
        /// Map <see cref="LogLevel"/> to the appropriate console color via <c>Colors.ConsoleColorManager</c>.
        /// </summary>
        /// <param name="level">Level to map.</param>
        private static void SetColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Information:
                    Colors.ConsoleColorManager.Info();
                    break;
                case LogLevel.Success:
                    Colors.ConsoleColorManager.Success();
                    break;
                case LogLevel.Warning:
                    Colors.ConsoleColorManager.Warning();
                    break;
                case LogLevel.Error:
                case LogLevel.Critical:
                    Colors.ConsoleColorManager.Error();
                    break;
                default:
                    Colors.ConsoleColorManager.Info();
                    break;
            }
        }
    }
}
