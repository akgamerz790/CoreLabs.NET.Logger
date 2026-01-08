using System;
using System.Collections;
using System.Collections.Generic;

namespace Colors
{
    public static class ConsoleColorManager
    {
        public static void Info()
            => Console.ForegroundColor = ConsoleColor.Cyan;

        public static void Success()
            => Console.ForegroundColor = ConsoleColor.Green;

        public static void Warning()
            => Console.ForegroundColor = ConsoleColor.Yellow;

        public static void Error()
            => Console.ForegroundColor = ConsoleColor.Red;

        public static void Reset()
            => Console.ResetColor();
    }
}