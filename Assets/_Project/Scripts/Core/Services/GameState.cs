namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// High-level game states for scene and flow management.
    /// </summary>
    public enum GameState
    {
        /// <summary>Initial loading state.</summary>
        Loading,
        
        /// <summary>Player is in the hub/menu.</summary>
        Hub,
        
        /// <summary>Player is in an active battle.</summary>
        Battle,
        
        /// <summary>Battle won, showing victory screen.</summary>
        Victory,
        
        /// <summary>Battle lost, showing defeat screen.</summary>
        Defeat,
        
        /// <summary>Game is paused.</summary>
        Paused
    }
}