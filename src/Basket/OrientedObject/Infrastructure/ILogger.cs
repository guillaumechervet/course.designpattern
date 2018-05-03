using System;

namespace Basket.OrientedObject.Infrastructure
{
    public interface ILogger
    {
        void LogInformation(string message);
        void LogError(Exception exception, string message);
    }
}
