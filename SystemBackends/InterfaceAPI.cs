using System;

namespace CoreLabs.NET.Logger.SystemBackends
{
    /// <summary>
    /// Represents the severity of a log entry.
    /// </summary>
    /// <remarks>
    /// Use these levels to indicate how important a log entry is. Consumers and sinks may
    /// filter or route messages based on this value. Values are ordered from most verbose
    /// (Trace) to most severe (Critical).
    /// 
    /// Guidance:
    /// - Trace/Debug: extremely verbose, for developer troubleshooting and diagnostics.
    /// - Information: normal runtime messages that describe high-level app behavior.
    /// - Success: an operation completed successfully (useful in CLIs or flows).
    /// - Warning: an unexpected situation that does not prevent operation.
    /// - Error: a failure that prevents a requested operation.
    /// - Critical: unrecoverable condition that requires attention.
    /// </remarks>
    public enum LogLevel
    {
        /// <summary>Very detailed diagnostic information, typically disabled in production.</summary>
        Trace = 0,
        /// <summary>Debug-level information useful for developers while diagnosing problems.</summary>
        Debug = 1,
        /// <summary>General informational messages that track high-level application flow.</summary>
        Information = 2,
        /// <summary>Indicates a successful operation or milestone worth highlighting.</summary>
        Success = 3,
        /// <summary>Indicates a potential problem or notable situation to examine.</summary>
        Warning = 4,
        /// <summary>An error that prevents an operation from completing as expected.</summary>
        Error = 5,
        /// <summary>Critical failure requiring immediate attention or process termination.</summary>
        Critical = 6
    }

    /// <summary>
    /// Abstraction for a logging sink that receives log entries.
    /// </summary>
    /// <remarks>
    /// Implementations of <see cref="ILogger"/> are responsible for formatting and
    /// persisting or emitting log messages (for example: console, file, remote collector).
    /// Sinks should aim to be robust and non-throwing; if an exception occurs they should
    /// handle it internally to avoid crashing the caller.
    /// 
    /// Thread-safety: implementors should document whether they are thread-safe. The default
    /// ConsoleLogger included in this library is safe for typical concurrent console usage.
    /// </remarks>
    public interface ILogger
    {
        /// <summary>
        /// Emit a log entry to this sink.
        /// </summary>
        /// <param name="level">Severity level for the message.</param>
        /// <param name="message">Text of the message to log. Should be non-null; empty strings are allowed.</param>
        /// <param name="exception">Optional <see cref="Exception"/> whose details should be included with the entry.</param>
        /// <example>
        /// logger.Log(LogLevel.Warning, "Cache miss for key 'user:123'", null);
        /// logger.Log(LogLevel.Error, "Failed to save record", ex);
        /// </example>
        void Log(LogLevel level, string message, Exception? exception = null);
    }
}
