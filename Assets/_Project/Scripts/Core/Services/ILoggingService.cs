using UnityEngine;

namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Logging service interface for structured, categorized logging throughout the application.
    /// Use this instead of direct Debug.Log* calls for better control and future extensibility.
    /// </summary>
    public interface ILoggingService
    {
        /// <summary>
        /// Logs an informational message using a predefined category.
        /// </summary>
        /// <param name="category">The log category for filtering and routing.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional Unity Object context for click-to-select in Console.</param>
        void LogInfo(LogCategory category, string message, Object context = null);

        /// <summary>
        /// Logs an informational message using a custom string category.
        /// </summary>
        /// <param name="category">Custom category string for filtering and routing.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional Unity Object context for click-to-select in Console.</param>
        void LogInfo(string category, string message, Object context = null);

        /// <summary>
        /// Logs a warning message using a predefined category.
        /// </summary>
        /// <param name="category">The log category for filtering and routing.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional Unity Object context for click-to-select in Console.</param>
        void LogWarning(LogCategory category, string message, Object context = null);

        /// <summary>
        /// Logs a warning message using a custom string category.
        /// </summary>
        /// <param name="category">Custom category string for filtering and routing.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional Unity Object context for click-to-select in Console.</param>
        void LogWarning(string category, string message, Object context = null);

        /// <summary>
        /// Logs an error message using a predefined category.
        /// </summary>
        /// <param name="category">The log category for filtering and routing.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional Unity Object context for click-to-select in Console.</param>
        void LogError(LogCategory category, string message, Object context = null);

        /// <summary>
        /// Logs an error message using a custom string category.
        /// </summary>
        /// <param name="category">Custom category string for filtering and routing.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="context">Optional Unity Object context for click-to-select in Console.</param>
        void LogError(string category, string message, Object context = null);
    }
}