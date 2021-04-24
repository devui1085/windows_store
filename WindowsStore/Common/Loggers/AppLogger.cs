using System;
using System.Text;
using NLog;

namespace Store.Common.Loggers
{
    public static class AppLogger
    {
        private static Logger Logger { get; }

        static AppLogger()
        {
            Logger = LogManager.GetCurrentClassLogger();
        }

        public static void Debug(string message, Exception ex, string serviceName, string operationName)
        {
            Logger.Debug(ex, FormatLogEntry(message, serviceName, operationName));
        }

        public static void Info(string message, Exception ex, string serviceName, string operationName)
        {
            Logger.Info(ex, FormatLogEntry(message, serviceName, operationName));
        }

        public static void Warn(string message, Exception ex, string serviceName, string operationName)
        {
            Logger.Warn(ex, FormatLogEntry(message, serviceName, operationName));
        }

        public static void Error(string message, Exception ex, string serviceName, string operationName)
        {
            Logger.Error(ex, FormatLogEntry(message, serviceName, operationName));
        }

        public static void Error(Exception ex)
        {
            Logger.Error(ex, string.Empty);
        }

        public static void Fatal(string message, Exception ex, string serviceName, string operationName)
        {
            Logger.Fatal(ex, FormatLogEntry(message, serviceName, operationName));
        }

        private static string FormatLogEntry(string message, string serviceName, string operationName)
        {
            StringBuilder logEntry = new StringBuilder();

            logEntry.Append("<LOGENTRY>");
            logEntry.AppendFormat("<TIMESTAMP>{0}</TIMESTAMP>", DateTime.Now);
            logEntry.AppendFormat("<Service>{0}</Controller>", serviceName);
            logEntry.AppendFormat("<Operation>{0}</Action>", operationName);
            logEntry.AppendFormat("<MSG>{0}</MSG></LOGENTRY>", message);
            logEntry.AppendLine();

            return logEntry.ToString();
        }
    }
}
