using UnityEngine;

namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Default logging service implementation using Unity's Debug.unityLogger.
    /// In development builds, logs with rich context.
    /// Future phases can route selected categories to external sinks (analytics, files, backend).
    /// </summary>
    public class LoggingService : ILoggingService
    {
        private readonly ILogger _logger;

        public LoggingService()
        {
            _logger = Debug.unityLogger;
        }

        public void LogInfo(LogCategory category, string message, Object context = null)
        {
            LogInfo(category.ToString(), message, context);
        }

        public void LogInfo(string category, string message, Object context = null)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            var formattedMessage = FormatMessage(category, message);
            _logger.Log(LogType.Log, formattedMessage, context);
#endif
        }

        public void LogWarning(LogCategory category, string message, Object context = null)
        {
            LogWarning(category.ToString(), message, context);
        }

        public void LogWarning(string category, string message, Object context = null)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            var formattedMessage = FormatMessage(category, message);
            _logger.Log(LogType.Warning, formattedMessage, context);
#else
            // Always log warnings in release builds, but without category prefix
            _logger.Log(LogType.Warning, message, context);
#endif
        }

        public void LogError(LogCategory category, string message, Object context = null)
        {
            LogError(category.ToString(), message, context);
        }

        public void LogError(string category, string message, Object context = null)
        {
            // Always log errors in all builds
            var formattedMessage = FormatMessage(category, message);
            _logger.Log(LogType.Error, formattedMessage, context);
        }

        private static string FormatMessage(string category, string message)
        {
            return $"[{category}] {message}";
        }
    }
}