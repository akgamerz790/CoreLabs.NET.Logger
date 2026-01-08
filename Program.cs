using CoreLabs.NET.Logger;

namespace CoreLabs.NET.Logging
{
    public static class ExampleProgram
    {
        public static void Main(string[] args)
        {
            InfoLogging.Log("App started");
WarnLogging.Log("Low disk space");
ErrorLogging.Log("Unhandled exception");
        }
    }
}