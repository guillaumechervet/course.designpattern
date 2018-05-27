using System;

namespace Basket
{
    public class LoggerExternal : ILogger
    {
        public void LogInformation(string message)
        {
            ExternalLogger.LogInformation(message);
        }

        public void LogError(Exception exception, string message)
        {
            ExternalLogger.LogError(exception, message);
        }
    }
}
