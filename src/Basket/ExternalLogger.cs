using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Basket
{
    public static class ExternalLogger
    {

        private static void Write(string message)
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var assemblyDirectory = Path.GetDirectoryName(path);
            string filePath = Path.Combine(assemblyDirectory, "log.txt");
            File.AppendAllText(filePath, message, Encoding.UTF8);
        }

        public static void LogInformation(string message)
        {
            Thread.Sleep(300);
            Write($"Information: {message}{Environment.NewLine}");
        }

        public static void LogError(Exception exception,string message)
        {
            Thread.Sleep(700);
            Write($"Error: {message} {exception}");
        }

    }
}
