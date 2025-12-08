using System;

namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Represents the rewards earned while the player was away.
    /// </summary>
    public struct AFKRewards
    {
        public float Gold;
        public float Materials;
        public TimeSpan TimeAway;
        public TimeSpan CappedTime;
    }

    /// <summary>
    /// Service that tracks offline time and calculates AFK rewards.
    /// Uses ISaveService to persist last logout time.
    /// </summary>
    public interface IAFKRewardService
    {
        /// <summary>
        /// Records the current time as the logout time.
        /// Call this when the player exits the game or goes to background.
        /// </summary>
        void RecordLogoutTime();

        /// <summary>
        /// Calculates rewards based on time away since last logout.
        /// Does not claim the rewards, just calculates them.
        /// </summary>
        /// <returns>The calculated AFK rewards.</returns>
        AFKRewards CalculateRewards();

        /// <summary>
        /// Claims the AFK rewards and resets the timer.
        /// Returns the rewards that were claimed.
        /// </summary>
        /// <returns>The claimed rewards.</returns>
        AFKRewards ClaimRewards();

        /// <summary>
        /// Gets the time since last logout.
        /// </summary>
        TimeSpan GetTimeAway();

        /// <summary>
        /// Event raised when AFK rewards are ready to be claimed.
        /// </summary>
        event Action<AFKRewards> OnRewardsReady;
    }
}