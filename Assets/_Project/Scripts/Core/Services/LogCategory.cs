namespace IdleMonsterTD.Core.Services
{
    /// <summary>
    /// Standard log categories for structured logging.
    /// Used to filter and route logs to appropriate sinks.
    /// </summary>
    public enum LogCategory
    {
        /// <summary>Core systems, DI, initialization.</summary>
        Core,
        
        /// <summary>AFK reward calculations and state.</summary>
        AFK,
        
        /// <summary>Combat, targeting, damage, projectiles.</summary>
        Combat,
        
        /// <summary>Gacha pulls, pity system, rewards.</summary>
        Gacha,
        
        /// <summary>Meta progression, evolution, upgrades.</summary>
        Meta,
        
        /// <summary>Backend communication, cloud save, remote config.</summary>
        Backend,
        
        /// <summary>Shop, IAP, battle pass, VIP.</summary>
        Monetization,
        
        /// <summary>Analytics events, funnels, A/B tests.</summary>
        Analytics,
        
        /// <summary>Performance metrics, profiling.</summary>
        Performance,
        
        /// <summary>Wave spawning, enemy management.</summary>
        Wave,
        
        /// <summary>UI transitions, popups, HUD.</summary>
        UI,
        
        /// <summary>Save/load operations.</summary>
        Save,
        
        /// <summary>Events, seasons, limited-time content.</summary>
        LiveOps
    }
}