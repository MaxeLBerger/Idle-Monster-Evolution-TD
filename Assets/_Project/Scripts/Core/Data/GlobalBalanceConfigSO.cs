using System;
using UnityEngine;

namespace IdleMonsterTD.Core.Data
{
    /// <summary>
    /// Central ScriptableObject holding global balance parameters for the entire game.
    /// Inject this via DI instead of hard-coding values throughout the codebase.
    /// </summary>
    [CreateAssetMenu(fileName = "GlobalBalanceConfig", menuName = "IdleMonsterTD/Config/Global Balance Config")]
    public class GlobalBalanceConfigSO : ScriptableObject
    {
        [Header("AFK Rewards")]
        [Tooltip("Base gold earned per hour while AFK.")]
        [SerializeField] private float _afkBaseGoldPerHour = 100f;
        
        [Tooltip("Base materials earned per hour while AFK.")]
        [SerializeField] private float _afkBaseMaterialsPerHour = 10f;
        
        [Tooltip("Maximum hours of AFK rewards that can accumulate.")]
        [SerializeField] private float _afkCapHours = 12f;

        [Header("Shards & Evolution")]
        [Tooltip("Number of shards required per rarity tier (Common, Rare, Epic, Legendary, Mythic).")]
        [SerializeField] private int[] _shardThresholdsPerRarity = { 10, 20, 50, 100, 200 };
        
        [Tooltip("Cost multipliers per evolution stage (1-5).")]
        [SerializeField] private float[] _evolutionCostMultipliers = { 1f, 1.5f, 2f, 3f, 5f };

        [Header("Combat / Endless")]
        [Tooltip("Enemy HP multiplier per chapter (additive per chapter).")]
        [SerializeField] private float _enemyHpMultiplierPerChapter = 0.15f;
        
        [Tooltip("Enemy damage multiplier per chapter (additive per chapter).")]
        [SerializeField] private float _enemyDamageMultiplierPerChapter = 0.10f;
        
        [Tooltip("Global gold multiplier applied to all gold rewards.")]
        [SerializeField] private float _globalGoldMultiplier = 1f;
        
        [Tooltip("Global XP multiplier applied to all XP rewards.")]
        [SerializeField] private float _globalXpMultiplier = 1f;

        [Header("Monetization (Phase 2+)")]
        [Tooltip("Global price/value multiplier for gacha.")]
        [SerializeField] private float _gachaValueMultiplier = 1f;
        
        [Tooltip("Global price/value multiplier for shop items.")]
        [SerializeField] private float _shopValueMultiplier = 1f;
        
        [Tooltip("Global price/value multiplier for battle pass.")]
        [SerializeField] private float _battlePassValueMultiplier = 1f;
        
        [Tooltip("Global price/value multiplier for VIP rewards.")]
        [SerializeField] private float _vipValueMultiplier = 1f;
        
        [Tooltip("Global price/value multiplier for events.")]
        [SerializeField] private float _eventValueMultiplier = 1f;

        // ============ AFK Properties ============
        public float AfkBaseGoldPerHour => _afkBaseGoldPerHour;
        public float AfkBaseMaterialsPerHour => _afkBaseMaterialsPerHour;
        public float AfkCapHours => _afkCapHours;

        // ============ Shards & Evolution Properties ============
        public ReadOnlySpan<int> ShardThresholdsPerRarity => _shardThresholdsPerRarity;
        public ReadOnlySpan<float> EvolutionCostMultipliers => _evolutionCostMultipliers;
        
        /// <summary>
        /// Gets the shard threshold for a given rarity index.
        /// </summary>
        /// <param name="rarityIndex">0 = Common, 1 = Rare, 2 = Epic, 3 = Legendary, 4 = Mythic</param>
        public int GetShardThreshold(int rarityIndex)
        {
            if (rarityIndex < 0 || rarityIndex >= _shardThresholdsPerRarity.Length)
            {
                Debug.LogError($"[GlobalBalanceConfig] Invalid rarity index: {rarityIndex}");
                return 0;
            }
            return _shardThresholdsPerRarity[rarityIndex];
        }

        /// <summary>
        /// Gets the evolution cost multiplier for a given stage.
        /// </summary>
        /// <param name="evolutionStage">1-5 evolution stage</param>
        public float GetEvolutionCostMultiplier(int evolutionStage)
        {
            int index = Mathf.Clamp(evolutionStage - 1, 0, _evolutionCostMultipliers.Length - 1);
            return _evolutionCostMultipliers[index];
        }

        // ============ Combat / Endless Properties ============
        public float EnemyHpMultiplierPerChapter => _enemyHpMultiplierPerChapter;
        public float EnemyDamageMultiplierPerChapter => _enemyDamageMultiplierPerChapter;
        public float GlobalGoldMultiplier => _globalGoldMultiplier;
        public float GlobalXpMultiplier => _globalXpMultiplier;

        /// <summary>
        /// Calculates the total enemy HP multiplier for a given chapter.
        /// </summary>
        public float CalculateEnemyHpMultiplier(int chapter)
        {
            return 1f + (chapter - 1) * _enemyHpMultiplierPerChapter;
        }

        /// <summary>
        /// Calculates the total enemy damage multiplier for a given chapter.
        /// </summary>
        public float CalculateEnemyDamageMultiplier(int chapter)
        {
            return 1f + (chapter - 1) * _enemyDamageMultiplierPerChapter;
        }

        // ============ Monetization Properties ============
        public float GachaValueMultiplier => _gachaValueMultiplier;
        public float ShopValueMultiplier => _shopValueMultiplier;
        public float BattlePassValueMultiplier => _battlePassValueMultiplier;
        public float VipValueMultiplier => _vipValueMultiplier;
        public float EventValueMultiplier => _eventValueMultiplier;
    }
}