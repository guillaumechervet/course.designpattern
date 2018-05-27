using System;

namespace Basket
{
    public interface ILogger
    {
        void LogInformation(string message);
        void LogError(Exception exception, string message);
    }
}
