using CoreLabs.NET.Logger.SystemBackends;
using CoreLabs.NET.Logger.SystemBackends.LoggerAPI;

namespace CoreLabs.NET.Logger
{
    /// <summary>
    /// Static façade exposing a lightweight logging surface for applications and tests.
    /// </summary>
    /// <remarks>
    /// This façade delegates to an internal <c>CoreLogger</c> instance which manages sinks
    /// and options. It provides convenience methods for common levels and a simple extension
    /// point via <see cref="AddSink(ILogger)"/>.
    /// 
    /// Usage recommendations:
    /// - For small applications and tests, the static façade is convenient and minimal.
    /// - For libraries intended to be embedded in other software, prefer accepting an
    ///   <see cref="ILogger"/> in constructors to allow consumers to inject their own sinks.
    /// - Register additional sinks at application startup (before heavy logging occurs).
    /// </remarks>
    public static class Log
    {
        /// <summary>
        /// Internal core logger instance used by the façade. Holds sinks and options.
        /// </summary>
        private static readonly CoreLogger _logger = new CoreLogger()
            .AddSink(new ConsoleLogger());

        /// <summary>
        /// Expose logger options from the underlying core logger for run-time inspection.
        /// </summary>
        public static LoggerOptions Options => _logger.Options;

        /// <summary>
        /// Register an additional logging sink (for example, file or remote collector).
        /// </summary>
        /// <param name="sink">Implementation of <see cref="ILogger"/> to add.</param>
        /// <remarks>
        /// Add sinks early during application initialization. Duplicate sinks are allowed,
        /// and ordering follows the order of registration.
        /// </remarks>
        public static void AddSink(ILogger sink) => _logger.AddSink(sink);

        /// <summary>
        /// Write a log entry with optional exception information.
        /// </summary>
        /// <param name="level">Severity level.</param>
        /// <param name="message">Message text.</param>
        /// <param name="ex">Optional exception to include details for.</param>
        public static void Write(LogLevel level, string message, Exception? ex = null)
            => _logger.Log(level, message, ex);

        /// <summary>Write a Trace-level message.</summary>
        public static void Trace(string message) => _logger.Trace(message);

        /// <summary>Write a Debug-level message.</summary>
        public static void Debug(string message) => _logger.Debug(message);

        /// <summary>Write an Information-level message.</summary>
        public static void Info(string message) => _logger.Info(message);

        /// <summary>Write a Success-level message.</summary>
        public static void Success(string message) => _logger.Success(message);

        /// <summary>Write a Warning-level message.</summary>
        public static void Warn(string message) => _logger.Warn(message);

        /// <summary>Write an Error-level message with optional exception.</summary>
        public static void Error(string message, Exception? ex = null) => _logger.Error(message, ex);

        /// <summary>Write a Critical-level message with optional exception.</summary>
        public static void Critical(string message, Exception? ex = null) => _logger.Critical(message, ex);
    }
}
