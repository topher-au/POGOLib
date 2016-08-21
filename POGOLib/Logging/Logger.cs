using System;
using System.Runtime.Remoting.Channels;

namespace POGOLib.Logging
{
    public static class Logger
    {
        public static void Custom(LogLevel logLevel, string customLogLevel, string message, params object[] args)
        {
            Output(logLevel, string.Format(message, args), customLogLevel);
        }

		public static void Debug(string message, params object[] args)
        {
			Output(LogLevel.Debug, string.Format(message, args));
        }

		public static void Info(string message, params object[] args)
        {
			Output(LogLevel.Info, string.Format(message, args));
        }

		public static void Notice(string message, params object[] args)
        {
			Output(LogLevel.Notice, string.Format(message, args));
        }

		public static void Warn(string message, params object[] args)
        {
			Output(LogLevel.Warn, string.Format(message, args));
        }

		public static void Error(string message, params object[] args)
        {
			Output(LogLevel.Error, string.Format(message, args));
        }

        private static void Output(LogLevel logLevel, string message, string customLogLevel = null)
        {
            if (logLevel < LoggerConfiguration.MinimumLogLevel) return;

            var foregroundColor = LoggerConfiguration.DefaultForegroundColor;
            var backgroundColor = LoggerConfiguration.DefaultBackgroundColor;
            var timestamp = DateTime.Now.ToString("HH:mm:ss");
            var logLevelText = customLogLevel ?? logLevel.ToString();

            if (LoggerConfiguration.LogLevelColors.ContainsKey(logLevel))
            {
                var colors = LoggerConfiguration.LogLevelColors[logLevel];

                foregroundColor = colors.ForegroundColor;
                backgroundColor = colors.BackgroundColor;
            }

            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
			Console.WriteLine(string.Format("{0,-10}{1,-10}{2}", timestamp, logLevelText, message));
            Console.ResetColor();
        }
    }
}
