using System;

namespace Rupendra.Assignment.Middleware
{
    /// <summary>
    /// This class be extend in future if any new logging mechanism needs to implement
    /// </summary>
    public class LoggerManager : ILoggerManager
    {
        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}
