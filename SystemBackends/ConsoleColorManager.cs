using System;

namespace Colors
{
    /// <summary>
    /// Utility helper that centralizes color choices used by console log sinks.
    /// </summary>
    /// <remarks>
    /// Centralizing color logic allows consistent look-and-feel for console output across
    /// multiple sinks or projects. Methods set only the foreground color; call <see cref="Reset"/>
    /// when finished to restore default console colors.
    /// </remarks>
    public static class ConsoleColorManager
    {
        /// <summary>
        /// Set color for informational messages and non-critical output.
        /// </summary>
        public static void Info()
            => Console.ForegroundColor = ConsoleColor.Cyan;

        /// <summary>
        /// Set color indicating success or positive outcomes.
        /// </summary>
        public static void Success()
            => Console.ForegroundColor = ConsoleColor.Green;

        /// <summary>
        /// Set color for warnings and moderately important notices.
        /// </summary>
        public static void Warning()
            => Console.ForegroundColor = ConsoleColor.Yellow;

        /// <summary>
        /// Set color for errors and critical problems.
        /// </summary>
        public static void Error()
            => Console.ForegroundColor = ConsoleColor.Red;

        /// <summary>
        /// Reset console colors to the host defaults (both foreground and background).
        /// Call after custom color usage to avoid leaking colors to other console output.
        /// </summary>
        public static void Reset()
            => Console.ResetColor();
    }
}