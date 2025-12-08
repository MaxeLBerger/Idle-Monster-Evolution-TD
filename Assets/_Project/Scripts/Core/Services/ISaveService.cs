using System;

namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Service for saving and loading player data.
    /// Phase 0 uses PlayerPrefs/file, later phases plug into cloud save.
    /// </summary>
    public interface ISaveService
    {
        /// <summary>
        /// Saves data to persistent storage.
        /// </summary>
        /// <typeparam name="T">The type of data to save (must be serializable).</typeparam>
        /// <param name="key">Unique key to identify the data.</param>
        /// <param name="data">The data to save.</param>
        void Save<T>(string key, T data);

        /// <summary>
        /// Loads data from persistent storage.
        /// </summary>
        /// <typeparam name="T">The type of data to load.</typeparam>
        /// <param name="key">Unique key to identify the data.</param>
        /// <returns>The loaded data, or default if not found.</returns>
        T Load<T>(string key);

        /// <summary>
        /// Attempts to load data from persistent storage.
        /// </summary>
        /// <typeparam name="T">The type of data to load.</typeparam>
        /// <param name="key">Unique key to identify the data.</param>
        /// <param name="data">The loaded data if successful.</param>
        /// <returns>True if data was found and loaded, false otherwise.</returns>
        bool TryLoad<T>(string key, out T data);

        /// <summary>
        /// Checks if data exists for the given key.
        /// </summary>
        /// <param name="key">The key to check.</param>
        /// <returns>True if data exists.</returns>
        bool HasKey(string key);

        /// <summary>
        /// Deletes data for the given key.
        /// </summary>
        /// <param name="key">The key to delete.</param>
        void Delete(string key);

        /// <summary>
        /// Deletes all saved data. Use with caution.
        /// </summary>
        void DeleteAll();
    }
}