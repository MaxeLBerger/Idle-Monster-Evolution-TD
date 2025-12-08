using UnityEngine;

namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Default logging service implementation using Unity's Debug class.
    /// In development builds, logs with rich context.
    /// Future phases can route selected categories to external sinks (analytics, files, backend).
    /// </summary>
    public class LoggingService : ILoggingService
    {
        public LoggingService()
        {
        }

        public void LogInfo(LogCategory category, string message, Object context = null)
        {
            LogInfo(category.ToString(), message, context);
        }

        public void LogInfo(string category, string message, Object context = null)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            var formattedMessage = FormatMessage(category, message);
            if (context != null)
                Debug.Log(formattedMessage, context);
            else
                Debug.Log(formattedMessage);
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
            if (context != null)
                Debug.LogWarning(formattedMessage, context);
            else
                Debug.LogWarning(formattedMessage);
#else
            // Always log warnings in release builds, but without category prefix
            if (context != null)
                Debug.LogWarning(message, context);
            else
                Debug.LogWarning(message);
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
            if (context != null)
                Debug.LogError(formattedMessage, context);
            else
                Debug.LogError(formattedMessage);
        }

        private static string FormatMessage(string category, string message)
        {
            return $"[{category}] {message}";
        }
    }
}