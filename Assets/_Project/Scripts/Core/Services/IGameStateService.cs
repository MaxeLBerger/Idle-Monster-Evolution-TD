using System;

namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Central service for managing high-level game state and scene transitions.
    /// Single source of truth for Hub/Battle/Victory/Defeat states.
    /// </summary>
    public interface IGameStateService
    {
        /// <summary>
        /// The current game state.
        /// </summary>
        GameState CurrentState { get; }

        /// <summary>
        /// The previous game state before the current transition.
        /// </summary>
        GameState PreviousState { get; }

        /// <summary>
        /// Event raised when the game state changes.
        /// </summary>
        event Action<GameState, GameState> OnStateChanged;

        /// <summary>
        /// Starts a battle by loading the battle scene.
        /// Transitions: Hub -> Loading -> Battle
        /// </summary>
        void StartBattle();

        /// <summary>
        /// Returns to the hub from any state.
        /// </summary>
        void ReturnToHub();

        /// <summary>
        /// Called when the player wins the battle.
        /// Transitions to Victory state.
        /// </summary>
        void OnBattleWon();

        /// <summary>
        /// Called when the player loses the battle (base HP reaches zero).
        /// Transitions to Defeat state.
        /// </summary>
        void OnBattleLost();

        /// <summary>
        /// Pauses the game.
        /// </summary>
        void Pause();

        /// <summary>
        /// Resumes the game from pause.
        /// </summary>
        void Resume();

        /// <summary>
        /// Checks if the game is currently in a playable battle state.
        /// </summary>
        bool IsInBattle { get; }

        /// <summary>
        /// Checks if the game is paused.
        /// </summary>
        bool IsPaused { get; }
    }
}