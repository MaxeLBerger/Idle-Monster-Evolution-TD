# Max's Phase 1 Issues — Weeks 5-8

**Focus:** Gacha System, Hub Meta-Progression, Endless Mode, Supabase Backend

---

## Phase 1 Issue Summary (14 issues)

| # | Title | Priority | Status |
|---|-------|----------|--------|
| #51 | [Gacha] Create GachaBannerConfigSO | Critical | ⬜ |
| #52 | [Gacha] Implement IGachaService | Critical | ⬜ |
| #53 | [Gacha] Implement monster shard system | High | ⬜ |
| #57 | [VFX] Summon reveal animations | Medium | ⬜ |
| #58 | [Hub] Create BuildingConfigSO | High | ⬜ |
| #59 | [Hub] Create ResearchTreeSO | High | ⬜ |
| #65 | [Endless] Create EndlessWaveGeneratorSO | High | ⬜ |
| #72 | [Monster] Implement Evolution Stage 2 | High | ⬜ |
| #73 | [Backend] Set up Supabase project | Critical | ⬜ |
| #74 | [Backend] Implement cloud save sync | Critical | ⬜ |
| #75 | [Backend] Implement account auth | High | ⬜ |
| #78 | [QA] Phase 1 integration testing | Critical | ⬜ |
| #79 | [Docs] Phase 1 completion documentation | Medium | ⬜ |

---

## Issue #51: [Gacha] Create GachaBannerConfigSO

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `monetization`, `priority-critical`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Create the ScriptableObject that defines gacha banner configurations including drop rates, pity system, and featured monsters.

---

### 📋 Requirements

- Configurable drop rates per rarity (Common → Legendary)
- Pity system with soft/hard pity thresholds
- Featured monster boost rates
- Banner duration and scheduling
- Cost per pull (single/10x)
 - Use `GlobalBalanceConfigSO` for global gacha tuning parameters (e.g., base rarity multipliers, soft/hard pity curve multipliers) instead of hard-coded constants.
 - Use `ILoggingService` to log gacha pulls (banner, rarity, featured flag, currency spent, shards awarded) and errors (missing configs, invalid drop tables).

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Gacha/GachaBannerConfigSO.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.Gacha
{
    [Serializable]
    public class RarityDropRate
    {
        public MonsterRarity Rarity;
        [Range(0f, 100f)] public float BaseRate;
        [Range(0f, 100f)] public float PityBoostRate; // Added after soft pity
    }

    [Serializable]
    public class FeaturedMonster
    {
        public string MonsterId;
        [Range(0f, 100f)] public float RateUpPercent; // % of rarity pool
    }

    [CreateAssetMenu(menuName = "IdleMonsterTD/Gacha/Banner Config")]
    public class GachaBannerConfigSO : ScriptableObject
    {
        [Header("Banner Info")]
        public string BannerId;
        public string BannerName;
        public Sprite BannerImage;
        
        [Header("Schedule")]
        public DateTime StartDate;
        public DateTime EndDate;
        public bool IsPermanent;
        
        [Header("Costs")]
        public int SinglePullCost = 160;
        public int TenPullCost = 1440; // 10% discount
        public CurrencyType CurrencyType = CurrencyType.Premium;
        
        [Header("Drop Rates")]
        [Tooltip("Must sum to 100%")]
        public List<RarityDropRate> DropRates = new()
        {
            new() { Rarity = MonsterRarity.Common, BaseRate = 60f },
            new() { Rarity = MonsterRarity.Uncommon, BaseRate = 30f },
            new() { Rarity = MonsterRarity.Rare, BaseRate = 7f },
            new() { Rarity = MonsterRarity.Epic, BaseRate = 2.5f },
            new() { Rarity = MonsterRarity.Legendary, BaseRate = 0.5f }
        };
        
        [Header("Pity System")]
        public int SoftPityStart = 70;  // Start boosting rates
        public int HardPity = 90;       // Guaranteed legendary
        public float SoftPityRateIncrease = 5f; // +5% per pull after soft pity
        
        [Header("Featured Units")]
        public List<FeaturedMonster> FeaturedMonsters;
        public bool HasGuaranteedFeatured = true;
        public int GuaranteedFeaturedPity = 180; // Every 180 pulls
        
        [Header("Monster Pool")]
        public List<string> AvailableMonsterIds;

        /// <summary>
        /// Calculate effective drop rate considering pity.
        /// </summary>
        public float GetEffectiveRate(MonsterRarity rarity, int currentPity)
        {
            var rateConfig = DropRates.Find(r => r.Rarity == rarity);
            if (rateConfig == null) return 0f;

            float rate = rateConfig.BaseRate;

            // Apply soft pity boost for legendary
            if (rarity == MonsterRarity.Legendary && currentPity >= SoftPityStart)
            {
                int pityPulls = currentPity - SoftPityStart;
                rate += pityPulls * SoftPityRateIncrease;
            }

            // Hard pity guarantee
            if (rarity == MonsterRarity.Legendary && currentPity >= HardPity - 1)
            {
                rate = 100f;
            }

            return Mathf.Clamp(rate, 0f, 100f);
        }

        /// <summary>
        /// Check if banner is currently active.
        /// </summary>
        public bool IsActive()
        {
            if (IsPermanent) return true;
            var now = DateTime.UtcNow;
            return now >= StartDate && now <= EndDate;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            float total = 0f;
            foreach (var rate in DropRates)
                total += rate.BaseRate;
            
            if (Mathf.Abs(total - 100f) > 0.01f)
                Debug.LogWarning($"[{BannerName}] Drop rates sum to {total}%, should be 100%");
        }
#endif
    }

    public enum CurrencyType { Premium, Standard, Ticket }
    public enum MonsterRarity { Common, Uncommon, Rare, Epic, Legendary }
}
```

**Integration with Global Balance Config**

- Inject `GlobalBalanceConfigSO` (or an `IBalanceConfigProvider`) into `GachaService`.
- Use global fields (e.g. `GachaLegendaryBaseRateMult`, `GachaSoftPityRateMult`) to scale per-banner `GachaBannerConfigSO` values so global rebalance is a config change, not a code change.

**Logging**

- Inject `ILoggingService` into `GachaService`.
- On each pull:
    - Log an info-level event with category `Gacha` containing banner ID, pull type (single/10x), rarity, featured flag, shards awarded, and currency cost.
- On errors (e.g. banner not found, invalid drop table sums):
    - Log an error-level event with category `Gacha`, including relevant context objects.

---

### ✅ Definition of Done
- [ ] GachaBannerConfigSO created with all fields
- [ ] Drop rate validation in OnValidate
- [ ] Pity calculation method works correctly
- [ ] Create 2 test banners: "Standard" (permanent) and "Featured" (limited)
- [ ] Banner assets in `Assets/_Project/ScriptableObjects/Gacha/`
 - [ ] Gacha uses `GlobalBalanceConfigSO` for global rarity/pity tuning
 - [ ] All gacha logs go through `ILoggingService` (no direct `Debug.Log`)

---

---

## Issue #52: [Gacha] Implement IGachaService

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `monetization`, `priority-critical`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Implement the gacha pull logic with proper randomization, pity tracking, and result handling.

---

### 📋 Requirements

- Single and 10x pull support
- Pity counter persistence (per banner)
- Weighted random selection
- Featured unit rate-up logic
- Currency deduction integration
- Pull history logging
 - Shard unlock thresholds and upgrade cost multipliers must be configurable via `GlobalBalanceConfigSO` to allow global progression rebalance.
 - Shard-related events (large shard grants, unlocks, upgrades) must log via `ILoggingService`.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Services/IGachaService.cs`

```csharp
using System;
using System.Collections.Generic;

namespace IdleMonsterTD.Core.Services
{
    public struct GachaPullResult
    {
        public string MonsterId;
        public MonsterRarity Rarity;
        public bool IsFeatured;
        public bool IsNew;        // First time getting this monster
        public int ShardsAwarded; // If duplicate
    }

    public interface IGachaService
    {
        /// <summary>
        /// Perform a single pull on a banner.
        /// </summary>
        GachaPullResult Pull(string bannerId);

        /// <summary>
        /// Perform a 10x pull on a banner.
        /// </summary>
        List<GachaPullResult> PullTen(string bannerId);

        /// <summary>
        /// Check if player can afford a pull.
        /// </summary>
        bool CanAffordPull(string bannerId, bool isTenPull = false);

        /// <summary>
        /// Get current pity count for a banner.
        /// </summary>
        int GetPityCount(string bannerId);

        /// <summary>
        /// Get pull history for a banner.
        /// </summary>
        List<GachaPullResult> GetPullHistory(string bannerId, int count = 10);

        event Action<GachaPullResult> OnPullComplete;
        event Action<List<GachaPullResult>> OnTenPullComplete;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/GachaService.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Services
{
    public class GachaService : IGachaService
    {
        private readonly ISaveService _saveService;
        private readonly IInventoryService _inventoryService;
        private readonly ICurrencyService _currencyService;
        private readonly MonsterDatabase _monsterDatabase;
        private readonly GachaBannerDatabase _bannerDatabase;

        private Dictionary<string, int> _pityCounters = new();
        private Dictionary<string, int> _featuredPityCounters = new();
        private Dictionary<string, List<GachaPullResult>> _pullHistory = new();

        public event Action<GachaPullResult> OnPullComplete;
        public event Action<List<GachaPullResult>> OnTenPullComplete;

        [Inject]
        public GachaService(
            ISaveService saveService,
            IInventoryService inventoryService,
            ICurrencyService currencyService,
            MonsterDatabase monsterDatabase,
            GachaBannerDatabase bannerDatabase)
        {
            _saveService = saveService;
            _inventoryService = inventoryService;
            _currencyService = currencyService;
            _monsterDatabase = monsterDatabase;
            _bannerDatabase = bannerDatabase;

            LoadPityData();
        }

        public GachaPullResult Pull(string bannerId)
        {
            var banner = _bannerDatabase.GetById(bannerId);
            if (banner == null)
                throw new ArgumentException($"Banner not found: {bannerId}");

            if (!CanAffordPull(bannerId, false))
                throw new InvalidOperationException("Cannot afford pull");

            // Deduct currency
            _currencyService.Spend(banner.CurrencyType, banner.SinglePullCost);

            // Perform pull
            var result = ExecutePull(banner);

            // Update pity
            IncrementPity(bannerId, result);

            // Add to history
            AddToHistory(bannerId, result);

            // Save state
            SavePityData();

            OnPullComplete?.Invoke(result);
            return result;
        }

        public List<GachaPullResult> PullTen(string bannerId)
        {
            var banner = _bannerDatabase.GetById(bannerId);
            if (banner == null)
                throw new ArgumentException($"Banner not found: {bannerId}");

            if (!CanAffordPull(bannerId, true))
                throw new InvalidOperationException("Cannot afford 10x pull");

            // Deduct currency
            _currencyService.Spend(banner.CurrencyType, banner.TenPullCost);

            var results = new List<GachaPullResult>();
            bool hasRareOrBetter = false;

            for (int i = 0; i < 10; i++)
            {
                var result = ExecutePull(banner);
                
                // Guarantee at least Rare on 10th pull if none yet
                if (i == 9 && !hasRareOrBetter)
                {
                    result = ExecutePullWithMinRarity(banner, MonsterRarity.Rare);
                }

                if (result.Rarity >= MonsterRarity.Rare)
                    hasRareOrBetter = true;

                IncrementPity(bannerId, result);
                AddToHistory(bannerId, result);
                results.Add(result);
            }

            SavePityData();
            OnTenPullComplete?.Invoke(results);
            return results;
        }

        public bool CanAffordPull(string bannerId, bool isTenPull = false)
        {
            var banner = _bannerDatabase.GetById(bannerId);
            if (banner == null) return false;

            int cost = isTenPull ? banner.TenPullCost : banner.SinglePullCost;
            return _currencyService.GetAmount(banner.CurrencyType) >= cost;
        }

        public int GetPityCount(string bannerId)
        {
            return _pityCounters.TryGetValue(bannerId, out int count) ? count : 0;
        }

        public List<GachaPullResult> GetPullHistory(string bannerId, int count = 10)
        {
            if (!_pullHistory.TryGetValue(bannerId, out var history))
                return new List<GachaPullResult>();

            int start = Mathf.Max(0, history.Count - count);
            return history.GetRange(start, Mathf.Min(count, history.Count));
        }

        private GachaPullResult ExecutePull(GachaBannerConfigSO banner)
        {
            int pity = GetPityCount(banner.BannerId);
            
            // Determine rarity
            MonsterRarity rarity = RollRarity(banner, pity);
            
            // Select monster from pool
            string monsterId = SelectMonster(banner, rarity);
            
            // Check if featured
            bool isFeatured = banner.FeaturedMonsters.Exists(f => f.MonsterId == monsterId);
            
            // Check if new and handle duplicates
            bool isNew = !_inventoryService.HasMonster(monsterId);
            int shards = 0;
            
            if (isNew)
            {
                _inventoryService.AddMonster(monsterId);
            }
            else
            {
                shards = GetDuplicateShards(rarity);
                _inventoryService.AddShards(monsterId, shards);
            }

            return new GachaPullResult
            {
                MonsterId = monsterId,
                Rarity = rarity,
                IsFeatured = isFeatured,
                IsNew = isNew,
                ShardsAwarded = shards
            };
        }

        private MonsterRarity RollRarity(GachaBannerConfigSO banner, int pity)
        {
            float roll = UnityEngine.Random.Range(0f, 100f);
            float cumulative = 0f;

            // Check from highest to lowest rarity
            for (int i = banner.DropRates.Count - 1; i >= 0; i--)
            {
                var rate = banner.DropRates[i];
                float effectiveRate = banner.GetEffectiveRate(rate.Rarity, pity);
                cumulative += effectiveRate;

                if (roll <= cumulative)
                    return rate.Rarity;
            }

            return MonsterRarity.Common;
        }

        private string SelectMonster(GachaBannerConfigSO banner, MonsterRarity rarity)
        {
            // Get all monsters of this rarity in the pool
            var pool = new List<string>();
            foreach (var id in banner.AvailableMonsterIds)
            {
                var config = _monsterDatabase.GetById(id);
                if (config != null && config.Rarity == rarity)
                    pool.Add(id);
            }

            if (pool.Count == 0)
            {
                Debug.LogError($"No monsters of rarity {rarity} in banner pool!");
                return banner.AvailableMonsterIds[0];
            }

            // Check featured rate-up
            foreach (var featured in banner.FeaturedMonsters)
            {
                if (pool.Contains(featured.MonsterId))
                {
                    float featuredRoll = UnityEngine.Random.Range(0f, 100f);
                    if (featuredRoll <= featured.RateUpPercent)
                        return featured.MonsterId;
                }
            }

            // Random from pool
            return pool[UnityEngine.Random.Range(0, pool.Count)];
        }

        private int GetDuplicateShards(MonsterRarity rarity)
        {
            return rarity switch
            {
                MonsterRarity.Common => 5,
                MonsterRarity.Uncommon => 10,
                MonsterRarity.Rare => 20,
                MonsterRarity.Epic => 50,
                MonsterRarity.Legendary => 100,
                _ => 5
            };
        }

        private void IncrementPity(string bannerId, GachaPullResult result)
        {
            if (!_pityCounters.ContainsKey(bannerId))
                _pityCounters[bannerId] = 0;

            _pityCounters[bannerId]++;

            // Reset pity on legendary
            if (result.Rarity == MonsterRarity.Legendary)
                _pityCounters[bannerId] = 0;
        }

        private void AddToHistory(string bannerId, GachaPullResult result)
        {
            if (!_pullHistory.ContainsKey(bannerId))
                _pullHistory[bannerId] = new List<GachaPullResult>();

            _pullHistory[bannerId].Add(result);

            // Keep only last 100 pulls
            if (_pullHistory[bannerId].Count > 100)
                _pullHistory[bannerId].RemoveAt(0);
        }

        private void LoadPityData()
        {
            var data = _saveService.Load<GachaSaveData>("gacha");
            if (data != null)
            {
                _pityCounters = data.PityCounters ?? new();
                _featuredPityCounters = data.FeaturedPityCounters ?? new();
            }
        }

        private void SavePityData()
        {
            var data = new GachaSaveData
            {
                PityCounters = _pityCounters,
                FeaturedPityCounters = _featuredPityCounters
            };
            _saveService.Save("gacha", data);
        }

        private GachaPullResult ExecutePullWithMinRarity(GachaBannerConfigSO banner, MonsterRarity minRarity)
        {
            var result = ExecutePull(banner);
            if (result.Rarity < minRarity)
            {
                string monsterId = SelectMonster(banner, minRarity);
                bool isNew = !_inventoryService.HasMonster(monsterId);
                int shards = isNew ? 0 : GetDuplicateShards(minRarity);

                if (isNew)
                    _inventoryService.AddMonster(monsterId);
                else
                    _inventoryService.AddShards(monsterId, shards);

                return new GachaPullResult
                {
                    MonsterId = monsterId,
                    Rarity = minRarity,
                    IsFeatured = banner.FeaturedMonsters.Exists(f => f.MonsterId == monsterId),
                    IsNew = isNew,
                    ShardsAwarded = shards
                };
            }
            return result;
        }
    }

    [Serializable]
    public class GachaSaveData
    {
        public Dictionary<string, int> PityCounters;
        public Dictionary<string, int> FeaturedPityCounters;
    }
}
```

---

### ✅ Definition of Done
- [ ] IGachaService interface defined
- [ ] GachaService implementation complete
- [ ] Pity system working (soft pity, hard pity)
- [ ] 10x guaranteed Rare+ on last pull
- [ ] Duplicate → shards conversion working
- [ ] Pull history tracked
- [ ] Registered in GameLifetimeScope
- [ ] Unit tests for drop rate calculations

---

---

## Issue #53: [Gacha] Implement monster shard system

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `monetization`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Implement the shard collection and monster unlock/upgrade system for duplicate pulls.

---

### 📋 Requirements

- Track shards per monster
- Unlock new monsters via shard threshold
- Upgrade existing monsters with additional shards
- Shard UI display integration
- Persistence via ISaveService

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Services/IShardService.cs`

```csharp
using System;

namespace IdleMonsterTD.Core.Services
{
    public interface IShardService
    {
        int GetShards(string monsterId);
        int GetShardsToUnlock(string monsterId);
        int GetShardsToUpgrade(string monsterId, int currentLevel);
        bool CanUnlock(string monsterId);
        bool CanUpgrade(string monsterId);
        void AddShards(string monsterId, int amount);
        bool TryUnlock(string monsterId);
        bool TryUpgrade(string monsterId);
        
        event Action<string, int> OnShardsChanged;
        event Action<string> OnMonsterUnlocked;
        event Action<string, int> OnMonsterUpgraded;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/ShardService.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Services
{
    public class ShardService : IShardService
    {
        private readonly ISaveService _saveService;
        private readonly IInventoryService _inventoryService;
        private readonly MonsterDatabase _monsterDatabase;

        private Dictionary<string, int> _shards = new();

        // Shards needed per rarity to unlock
        private static readonly Dictionary<MonsterRarity, int> UnlockThresholds = new()
        {
            { MonsterRarity.Common, 10 },
            { MonsterRarity.Uncommon, 20 },
            { MonsterRarity.Rare, 40 },
            { MonsterRarity.Epic, 80 },
            { MonsterRarity.Legendary, 160 }
        };

        // Shards needed per level (multiplier)
        private static readonly int[] UpgradeCostPerLevel = { 0, 10, 20, 40, 80, 160, 320 };

        public event Action<string, int> OnShardsChanged;
        public event Action<string> OnMonsterUnlocked;
        public event Action<string, int> OnMonsterUpgraded;

        [Inject]
        public ShardService(
            ISaveService saveService,
            IInventoryService inventoryService,
            MonsterDatabase monsterDatabase)
        {
            _saveService = saveService;
            _inventoryService = inventoryService;
            _monsterDatabase = monsterDatabase;
            LoadShards();
        }

        public int GetShards(string monsterId)
        {
            return _shards.TryGetValue(monsterId, out int count) ? count : 0;
        }

        public int GetShardsToUnlock(string monsterId)
        {
            var config = _monsterDatabase.GetById(monsterId);
            if (config == null) return int.MaxValue;
            
            return UnlockThresholds.TryGetValue(config.Rarity, out int threshold) 
                ? threshold 
                : 100;
        }

        public int GetShardsToUpgrade(string monsterId, int currentLevel)
        {
            var config = _monsterDatabase.GetById(monsterId);
            if (config == null) return int.MaxValue;

            int baseIdx = Mathf.Clamp(currentLevel, 0, UpgradeCostPerLevel.Length - 1);
            int baseCost = UpgradeCostPerLevel[baseIdx];

            // Rarity multiplier
            float rarityMult = config.Rarity switch
            {
                MonsterRarity.Common => 1f,
                MonsterRarity.Uncommon => 1.5f,
                MonsterRarity.Rare => 2f,
                MonsterRarity.Epic => 3f,
                MonsterRarity.Legendary => 5f,
                _ => 1f
            };

            return Mathf.RoundToInt(baseCost * rarityMult);
        }

        public bool CanUnlock(string monsterId)
        {
            if (_inventoryService.HasMonster(monsterId))
                return false;
            
            return GetShards(monsterId) >= GetShardsToUnlock(monsterId);
        }

        public bool CanUpgrade(string monsterId)
        {
            if (!_inventoryService.HasMonster(monsterId))
                return false;

            int level = _inventoryService.GetMonsterLevel(monsterId);
            int maxLevel = 6; // Max upgrade level
            
            if (level >= maxLevel)
                return false;

            return GetShards(monsterId) >= GetShardsToUpgrade(monsterId, level);
        }

        public void AddShards(string monsterId, int amount)
        {
            if (!_shards.ContainsKey(monsterId))
                _shards[monsterId] = 0;

            _shards[monsterId] += amount;
            SaveShards();
            
            OnShardsChanged?.Invoke(monsterId, _shards[monsterId]);
        }

        public bool TryUnlock(string monsterId)
        {
            if (!CanUnlock(monsterId))
                return false;

            int cost = GetShardsToUnlock(monsterId);
            _shards[monsterId] -= cost;
            
            _inventoryService.AddMonster(monsterId);
            SaveShards();
            
            OnShardsChanged?.Invoke(monsterId, _shards[monsterId]);
            OnMonsterUnlocked?.Invoke(monsterId);
            
            return true;
        }

        public bool TryUpgrade(string monsterId)
        {
            if (!CanUpgrade(monsterId))
                return false;

            int level = _inventoryService.GetMonsterLevel(monsterId);
            int cost = GetShardsToUpgrade(monsterId, level);
            
            _shards[monsterId] -= cost;
            _inventoryService.UpgradeMonster(monsterId);
            
            SaveShards();
            
            OnShardsChanged?.Invoke(monsterId, _shards[monsterId]);
            OnMonsterUpgraded?.Invoke(monsterId, level + 1);
            
            return true;
        }

        private void LoadShards()
        {
            var data = _saveService.Load<ShardSaveData>("shards");
            if (data != null)
                _shards = data.Shards ?? new();
        }

        private void SaveShards()
        {
            _saveService.Save("shards", new ShardSaveData { Shards = _shards });
        }
    }

    [Serializable]
    public class ShardSaveData
    {
        public Dictionary<string, int> Shards;
    }
}
```

**Register in GameLifetimeScope:**

```csharp
// Add to Configure method
builder.Register<ShardService>(Lifetime.Singleton).As<IShardService>();
builder.Register<GachaService>(Lifetime.Singleton).As<IGachaService>();
```

**Global Balance Integration**

- Read per-rarity base unlock thresholds and upgrade multipliers from `GlobalBalanceConfigSO` (e.g., `CommonShardUnlock`, `EpicShardUpgradeMult`).
- Use these as inputs when computing `UnlockThresholds` and `UpgradeCostPerLevel` so designers can tune shard progression centrally.

**Logging**

- Inject `ILoggingService` into `ShardService`.
- Log with category `Progression` or `Gacha` when shards are added in significant amounts, a monster is unlocked or upgraded, or an unexpected configuration/state issue prevents unlock/upgrade.

---

### ✅ Definition of Done
- [ ] IShardService interface defined
- [ ] ShardService implementation complete
- [ ] Unlock thresholds per rarity configured
- [ ] Upgrade costs scale with level and rarity
- [ ] Persistence working
- [ ] Events fire correctly
- [ ] Registered in GameLifetimeScope
- [ ] Integration with GachaService verified
 - [ ] Shard thresholds and upgrade curves can be tuned via `GlobalBalanceConfigSO`
 - [ ] Shard/unlock/upgrade events use `ILoggingService` for diagnostics

---

<!-- Continue in next batch: #57, #58, #59 -->

---

## Issue #57: [VFX] Summon reveal animations

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `polish`, `priority-medium`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Create rarity-based reveal animations for gacha summons with escalating visual impact.

---

### 📋 Requirements

- Different VFX intensity per rarity
- Skip animation option
- Batch reveal for 10x pulls
- Sound integration hooks
- Mobile-optimized particles

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/UI/Gacha/SummonRevealController.cs`

```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace IdleMonsterTD.UI.Gacha
{
    public class SummonRevealController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _cardContainer;
        [SerializeField] private SummonCard _cardPrefab;
        [SerializeField] private CanvasGroup _skipButton;
        
        [Header("VFX by Rarity")]
        [SerializeField] private ParticleSystem _commonVFX;
        [SerializeField] private ParticleSystem _uncommonVFX;
        [SerializeField] private ParticleSystem _rareVFX;
        [SerializeField] private ParticleSystem _epicVFX;
        [SerializeField] private ParticleSystem _legendaryVFX;
        
        [Header("Timing")]
        [SerializeField] private float _cardRevealDelay = 0.3f;
        [SerializeField] private float _legendaryBuildupTime = 2f;
        [SerializeField] private float _skipHoldTime = 0.5f;
        
        [Header("Colors")]
        [SerializeField] private Color _commonColor = Color.gray;
        [SerializeField] private Color _uncommonColor = Color.green;
        [SerializeField] private Color _rareColor = Color.blue;
        [SerializeField] private Color _epicColor = Color.magenta;
        [SerializeField] private Color _legendaryColor = Color.yellow;

        private bool _skipRequested;
        private List<SummonCard> _activeCards = new();

        public event Action OnRevealComplete;
        public event Action<GachaPullResult> OnCardRevealed;

        public void RevealSingle(GachaPullResult result)
        {
            StartCoroutine(RevealSingleCoroutine(result));
        }

        public void RevealMultiple(List<GachaPullResult> results)
        {
            StartCoroutine(RevealMultipleCoroutine(results));
        }

        public void RequestSkip()
        {
            _skipRequested = true;
        }

        private IEnumerator RevealSingleCoroutine(GachaPullResult result)
        {
            _skipRequested = false;
            ClearCards();

            // Create card
            var card = CreateCard(result);
            
            // Buildup based on rarity
            yield return StartCoroutine(PlayBuildup(result.Rarity));

            // Reveal
            yield return StartCoroutine(RevealCard(card, result));
            
            // Wait for tap or auto-continue
            yield return new WaitForSeconds(1f);
            
            OnRevealComplete?.Invoke();
        }

        private IEnumerator RevealMultipleCoroutine(List<GachaPullResult> results)
        {
            _skipRequested = false;
            ClearCards();

            // Sort by rarity (reveal best last)
            results.Sort((a, b) => a.Rarity.CompareTo(b.Rarity));

            // Find highest rarity for initial buildup
            var highestRarity = results[^1].Rarity;
            
            // Quick buildup
            if (highestRarity >= MonsterRarity.Epic && !_skipRequested)
            {
                yield return StartCoroutine(PlayBuildup(highestRarity, shortened: true));
            }

            // Reveal cards one by one
            foreach (var result in results)
            {
                if (_skipRequested)
                {
                    // Instant reveal remaining
                    var card = CreateCard(result);
                    card.RevealInstant(result);
                    PlayVFX(result.Rarity, instant: true);
                    OnCardRevealed?.Invoke(result);
                }
                else
                {
                    var card = CreateCard(result);
                    yield return StartCoroutine(RevealCard(card, result, fast: true));
                    yield return new WaitForSeconds(_cardRevealDelay);
                }
            }

            yield return new WaitForSeconds(0.5f);
            OnRevealComplete?.Invoke();
        }

        private SummonCard CreateCard(GachaPullResult result)
        {
            var card = Instantiate(_cardPrefab, _cardContainer);
            card.Setup(result);
            _activeCards.Add(card);
            return card;
        }

        private IEnumerator PlayBuildup(MonsterRarity rarity, bool shortened = false)
        {
            float duration = shortened ? 0.5f : GetBuildupDuration(rarity);
            
            if (rarity >= MonsterRarity.Legendary)
            {
                // Screen shake, dramatic lighting
                Camera.main.DOShakePosition(duration, 0.1f, 10);
            }
            
            if (!_skipRequested)
                yield return new WaitForSeconds(duration);
        }

        private IEnumerator RevealCard(SummonCard card, GachaPullResult result, bool fast = false)
        {
            float revealTime = fast ? 0.3f : 0.6f;
            
            // Play rarity VFX
            PlayVFX(result.Rarity);
            
            // Animate card flip
            card.Reveal(result, revealTime);
            
            yield return new WaitForSeconds(revealTime);
            
            OnCardRevealed?.Invoke(result);
        }

        private void PlayVFX(MonsterRarity rarity, bool instant = false)
        {
            var vfx = rarity switch
            {
                MonsterRarity.Common => _commonVFX,
                MonsterRarity.Uncommon => _uncommonVFX,
                MonsterRarity.Rare => _rareVFX,
                MonsterRarity.Epic => _epicVFX,
                MonsterRarity.Legendary => _legendaryVFX,
                _ => _commonVFX
            };

            if (vfx != null)
            {
                if (instant)
                    vfx.Emit(vfx.main.maxParticles);
                else
                    vfx.Play();
            }
        }

        private float GetBuildupDuration(MonsterRarity rarity)
        {
            return rarity switch
            {
                MonsterRarity.Legendary => _legendaryBuildupTime,
                MonsterRarity.Epic => 1f,
                MonsterRarity.Rare => 0.5f,
                _ => 0.2f
            };
        }

        public Color GetRarityColor(MonsterRarity rarity)
        {
            return rarity switch
            {
                MonsterRarity.Common => _commonColor,
                MonsterRarity.Uncommon => _uncommonColor,
                MonsterRarity.Rare => _rareColor,
                MonsterRarity.Epic => _epicColor,
                MonsterRarity.Legendary => _legendaryColor,
                _ => Color.white
            };
        }

        private void ClearCards()
        {
            foreach (var card in _activeCards)
            {
                if (card != null)
                    Destroy(card.gameObject);
            }
            _activeCards.Clear();
        }
    }
}
```

**File:** `Assets/_Project/Scripts/UI/Gacha/SummonCard.cs`

```csharp
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace IdleMonsterTD.UI.Gacha
{
    public class SummonCard : MonoBehaviour
    {
        [SerializeField] private Image _cardBack;
        [SerializeField] private Image _cardFront;
        [SerializeField] private Image _monsterImage;
        [SerializeField] private Image _rarityGlow;
        [SerializeField] private TMP_Text _monsterName;
        [SerializeField] private TMP_Text _newLabel;
        [SerializeField] private TMP_Text _shardLabel;
        [SerializeField] private Transform _cardTransform;

        private GachaPullResult _result;

        public void Setup(GachaPullResult result)
        {
            _result = result;
            _cardBack.gameObject.SetActive(true);
            _cardFront.gameObject.SetActive(false);
            _cardTransform.localScale = Vector3.one;
            _cardTransform.rotation = Quaternion.identity;
        }

        public void Reveal(GachaPullResult result, float duration)
        {
            // Flip animation
            Sequence seq = DOTween.Sequence();
            
            seq.Append(_cardTransform.DORotate(new Vector3(0, 90, 0), duration / 2));
            seq.AppendCallback(() =>
            {
                _cardBack.gameObject.SetActive(false);
                _cardFront.gameObject.SetActive(true);
                PopulateCard(result);
            });
            seq.Append(_cardTransform.DORotate(Vector3.zero, duration / 2));
            seq.Append(_cardTransform.DOPunchScale(Vector3.one * 0.1f, 0.2f));
        }

        public void RevealInstant(GachaPullResult result)
        {
            _cardBack.gameObject.SetActive(false);
            _cardFront.gameObject.SetActive(true);
            PopulateCard(result);
        }

        private void PopulateCard(GachaPullResult result)
        {
            _monsterName.text = result.MonsterId; // Replace with actual name lookup
            _newLabel.gameObject.SetActive(result.IsNew);
            
            if (!result.IsNew && result.ShardsAwarded > 0)
            {
                _shardLabel.gameObject.SetActive(true);
                _shardLabel.text = $"+{result.ShardsAwarded} Shards";
            }
            else
            {
                _shardLabel.gameObject.SetActive(false);
            }

            // Set rarity glow color
            var controller = GetComponentInParent<SummonRevealController>();
            if (controller != null)
            {
                _rarityGlow.color = controller.GetRarityColor(result.Rarity);
            }
        }
    }
}
```

---

### ✅ Definition of Done
- [ ] SummonRevealController implemented
- [ ] SummonCard flip animation working
- [ ] 5 rarity VFX particle systems created
- [ ] Skip functionality working
- [ ] 10x batch reveal with sorting
- [ ] Mobile performance verified (<2ms frame impact)
- [ ] Prefabs created in `Assets/_Project/Prefabs/UI/Gacha/`

---

---

## Issue #58: [Hub] Create BuildingConfigSO

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `gameplay`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Create ScriptableObject for hub building definitions including upgrade costs, unlock requirements, and bonuses.

---

### 📋 Requirements

- Building types: Monster Lab, AFK Chest, Research, Summon Arena
- Level-based upgrade costs (gold + materials)
- Unlock requirements (account level, other buildings)
- Bonus per level configuration
- Visual state references
 - Global cost scaling factors and bonus caps (e.g., building level cost multipliers) must come from `GlobalBalanceConfigSO` where appropriate.
 - Meta-progression actions (building upgrades) should log key events via `ILoggingService`.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Hub/BuildingConfigSO.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.Hub
{
    public enum BuildingType
    {
        MonsterLab,     // Monster upgrades, evolution
        AFKChest,       // Idle rewards collection
        Research,       // Global buffs
        SummonArena,    // Gacha access
        TrainingGround, // Monster XP
        Treasury        // Gold storage/generation
    }

    [Serializable]
    public class BuildingLevel
    {
        public int Level;
        public int GoldCost;
        public int EvoMaterialCost;
        public int PremiumCurrencyCost; // Optional speed-up
        public float UpgradeTimeSeconds;
        
        [Header("Bonuses")]
        public float BonusValue;        // Main bonus (%, flat, etc.)
        public string BonusDescription; // "AFK rewards +10%"
        
        [Header("Unlocks")]
        public List<string> UnlockedFeatures; // Feature IDs unlocked at this level
    }

    [Serializable]
    public class BuildingUnlockRequirement
    {
        public int RequiredAccountLevel;
        public BuildingType RequiredBuilding;
        public int RequiredBuildingLevel;
    }

    [CreateAssetMenu(menuName = "IdleMonsterTD/Hub/Building Config")]
    public class BuildingConfigSO : ScriptableObject
    {
        [Header("Basic Info")]
        public string BuildingId;
        public string BuildingName;
        public BuildingType Type;
        [TextArea] public string Description;
        public Sprite Icon;
        
        [Header("Unlock Requirements")]
        public int UnlockAccountLevel = 1;
        public List<BuildingUnlockRequirement> AdditionalRequirements;
        
        [Header("Level Configuration")]
        public int MaxLevel = 20;
        public List<BuildingLevel> Levels;
        
        [Header("Visuals")]
        public List<GameObject> VisualPrefabsByLevel; // Different looks per level range
        
        [Header("Bonus Type")]
        public BonusStat BonusStat;
        public bool IsPercentage = true;

        /// <summary>
        /// Get config for a specific level.
        /// </summary>
        public BuildingLevel GetLevel(int level)
        {
            level = Mathf.Clamp(level, 1, MaxLevel);
            return Levels.Find(l => l.Level == level) ?? Levels[0];
        }

        /// <summary>
        /// Get upgrade cost to next level.
        /// </summary>
        public BuildingLevel GetUpgradeCost(int currentLevel)
        {
            if (currentLevel >= MaxLevel) return null;
            return GetLevel(currentLevel + 1);
        }

        /// <summary>
        /// Get total bonus at a level.
        /// </summary>
        public float GetTotalBonus(int level)
        {
            float total = 0f;
            for (int i = 1; i <= level; i++)
            {
                var lvl = GetLevel(i);
                total += lvl.BonusValue;
            }
            return total;
        }

        /// <summary>
        /// Get visual prefab for level.
        /// </summary>
        public GameObject GetVisualPrefab(int level)
        {
            if (VisualPrefabsByLevel == null || VisualPrefabsByLevel.Count == 0)
                return null;

            // Map level to visual index (e.g., every 5 levels = new visual)
            int index = Mathf.Clamp((level - 1) / 5, 0, VisualPrefabsByLevel.Count - 1);
            return VisualPrefabsByLevel[index];
        }

        /// <summary>
        /// Check if building can be unlocked.
        /// </summary>
        public bool CanUnlock(int accountLevel, Func<BuildingType, int> getBuildingLevel)
        {
            if (accountLevel < UnlockAccountLevel)
                return false;

            foreach (var req in AdditionalRequirements)
            {
                if (getBuildingLevel(req.RequiredBuilding) < req.RequiredBuildingLevel)
                    return false;
            }

            return true;
        }

#if UNITY_EDITOR
        [ContextMenu("Generate Default Levels")]
        private void GenerateDefaultLevels()
        {
            Levels = new List<BuildingLevel>();
            for (int i = 1; i <= MaxLevel; i++)
            {
                Levels.Add(new BuildingLevel
                {
                    Level = i,
                    GoldCost = 100 * i * i,
                    EvoMaterialCost = 10 * i,
                    UpgradeTimeSeconds = 60 * i,
                    BonusValue = Type switch
                    {
                        BuildingType.AFKChest => 5f,     // +5% per level
                        BuildingType.Research => 2f,     // +2% per level
                        BuildingType.MonsterLab => 3f,   // +3% per level
                        _ => 5f
                    },
                    BonusDescription = $"+{GetLevel(i).BonusValue}% {BonusStat}"
                });
            }
        }
#endif
    }

    public enum BonusStat
    {
        AFKRewardRate,
        MonsterDamage,
        MonsterHealth,
        GoldEarned,
        ExpGained,
        EvolutionCostReduction,
        ResearchSpeed
    }
}
```

**Global Balance Integration**

- For costs that follow a global curve (e.g., exponential growth), read curve parameters from `GlobalBalanceConfigSO`.
- Individual buildings still define base values, but the curve shape and soft caps are tuned centrally from the global config.

**Logging**

- Inject `ILoggingService` into the hub service responsible for upgrades.
- Log with category `Meta` when a building is upgraded or when an invalid dependency/state prevents an upgrade.

---

### ✅ Definition of Done
- [ ] BuildingConfigSO created with all fields
- [ ] BuildingLevel struct with costs and bonuses
- [ ] Unlock requirement system working
- [ ] Visual prefab mapping implemented
- [ ] Create configs for: MonsterLab, AFKChest, Research, SummonArena
- [ ] Editor context menu for default level generation
- [ ] Assets in `Assets/_Project/ScriptableObjects/Hub/Buildings/`
 - [ ] Hub building cost and bonus curves respond to `GlobalBalanceConfigSO` parameters
 - [ ] Building upgrade actions log via `ILoggingService`

---

---

## Issue #59: [Hub] Create ResearchTreeSO

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `gameplay`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Create a research tree system for permanent global buffs unlocked by spending resources.

---

### 📋 Requirements

- Tree structure with nodes and dependencies
- Multiple research categories
- Permanent stat bonuses
- Level-based progression per node
- Persistence via save system
 - Global cost scaling factors and bonus caps (e.g., research exponential factors) must come from `GlobalBalanceConfigSO` where appropriate.
 - Meta-progression actions (research completions) should log key events via `ILoggingService`.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Hub/ResearchNodeSO.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.Hub
{
    [Serializable]
    public class ResearchNodeLevel
    {
        public int Level;
        public int ResearchPointCost;
        public int GoldCost;
        public float ResearchTimeSeconds;
        public float BonusValue;
    }

    [CreateAssetMenu(menuName = "IdleMonsterTD/Hub/Research Node")]
    public class ResearchNodeSO : ScriptableObject
    {
        [Header("Node Info")]
        public string NodeId;
        public string NodeName;
        [TextArea] public string Description;
        public Sprite Icon;
        public ResearchCategory Category;
        
        [Header("Position in Tree")]
        public Vector2 TreePosition; // For UI layout
        public List<ResearchNodeSO> Prerequisites;
        
        [Header("Levels")]
        public int MaxLevel = 10;
        public List<ResearchNodeLevel> Levels;
        
        [Header("Bonus")]
        public BonusStat BonusStat;
        public bool IsPercentage = true;

        public ResearchNodeLevel GetLevel(int level)
        {
            level = Mathf.Clamp(level, 1, MaxLevel);
            return Levels.Find(l => l.Level == level);
        }

        public float GetTotalBonus(int currentLevel)
        {
            float total = 0f;
            for (int i = 1; i <= currentLevel; i++)
            {
                var lvl = GetLevel(i);
                if (lvl != null)
                    total += lvl.BonusValue;
            }
            return total;
        }

        public bool CanResearch(int currentLevel, Func<string, int> getNodeLevel)
        {
            if (currentLevel >= MaxLevel)
                return false;

            foreach (var prereq in Prerequisites)
            {
                if (getNodeLevel(prereq.NodeId) < 1)
                    return false;
            }

            return true;
        }
    }

    public enum ResearchCategory
    {
        Combat,     // Damage, crit, attack speed
        Defense,    // Health, armor, regen
        Economy,    // Gold, AFK, rewards
        Utility     // Speed, slots, QoL
    }
}
```

**File:** `Assets/_Project/Scripts/Gameplay/Hub/ResearchTreeSO.cs`

```csharp
using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.Hub
{
    [CreateAssetMenu(menuName = "IdleMonsterTD/Hub/Research Tree")]
    public class ResearchTreeSO : ScriptableObject
    {
        [Header("Tree Info")]
        public string TreeId;
        public string TreeName;
        
        [Header("Nodes")]
        public List<ResearchNodeSO> AllNodes;
        
        [Header("Categories")]
        public List<ResearchCategoryInfo> Categories;

        public ResearchNodeSO GetNode(string nodeId)
        {
            return AllNodes.Find(n => n.NodeId == nodeId);
        }

        public List<ResearchNodeSO> GetNodesByCategory(ResearchCategory category)
        {
            return AllNodes.FindAll(n => n.Category == category);
        }

        public List<ResearchNodeSO> GetAvailableNodes(Func<string, int> getNodeLevel)
        {
            var available = new List<ResearchNodeSO>();
            foreach (var node in AllNodes)
            {
                int level = getNodeLevel(node.NodeId);
                if (node.CanResearch(level, getNodeLevel))
                    available.Add(node);
            }
            return available;
        }
    }

    [System.Serializable]
    public class ResearchCategoryInfo
    {
        public ResearchCategory Category;
        public string DisplayName;
        public Sprite Icon;
        public Color Color;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/IResearchService.cs`

```csharp
using System;

namespace IdleMonsterTD.Core.Services
{
    public interface IResearchService
    {
        int GetNodeLevel(string nodeId);
        bool CanResearch(string nodeId);
        bool TryStartResearch(string nodeId);
        void CompleteResearch(string nodeId);
        float GetResearchProgress(string nodeId);
        float GetTotalBonus(BonusStat stat);
        
        event Action<string, int> OnResearchComplete;
        event Action<string, float> OnResearchProgress;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/ResearchService.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Services
{
    public class ResearchService : IResearchService
    {
        private readonly ISaveService _saveService;
        private readonly ICurrencyService _currencyService;
        private readonly ResearchTreeSO _researchTree;

        private Dictionary<string, int> _nodeLevels = new();
        private Dictionary<string, float> _researchProgress = new();
        private string _activeResearchNode;
        private float _activeResearchStartTime;

        public event Action<string, int> OnResearchComplete;
        public event Action<string, float> OnResearchProgress;

        [Inject]
        public ResearchService(
            ISaveService saveService,
            ICurrencyService currencyService,
            ResearchTreeSO researchTree)
        {
            _saveService = saveService;
            _currencyService = currencyService;
            _researchTree = researchTree;
            LoadProgress();
        }

        public int GetNodeLevel(string nodeId)
        {
            return _nodeLevels.TryGetValue(nodeId, out int level) ? level : 0;
        }

        public bool CanResearch(string nodeId)
        {
            var node = _researchTree.GetNode(nodeId);
            if (node == null) return false;

            int currentLevel = GetNodeLevel(nodeId);
            if (!node.CanResearch(currentLevel, GetNodeLevel))
                return false;

            var nextLevel = node.GetLevel(currentLevel + 1);
            if (nextLevel == null) return false;

            // Check costs
            if (!_currencyService.CanAfford(CurrencyType.ResearchPoints, nextLevel.ResearchPointCost))
                return false;
            if (!_currencyService.CanAfford(CurrencyType.Gold, nextLevel.GoldCost))
                return false;

            return true;
        }

        public bool TryStartResearch(string nodeId)
        {
            if (!CanResearch(nodeId))
                return false;

            if (!string.IsNullOrEmpty(_activeResearchNode))
                return false; // Already researching

            var node = _researchTree.GetNode(nodeId);
            int currentLevel = GetNodeLevel(nodeId);
            var nextLevel = node.GetLevel(currentLevel + 1);

            // Deduct costs
            _currencyService.Spend(CurrencyType.ResearchPoints, nextLevel.ResearchPointCost);
            _currencyService.Spend(CurrencyType.Gold, nextLevel.GoldCost);

            _activeResearchNode = nodeId;
            _activeResearchStartTime = Time.time;
            _researchProgress[nodeId] = 0f;

            SaveProgress();
            return true;
        }

        public void CompleteResearch(string nodeId)
        {
            if (_activeResearchNode != nodeId) return;

            if (!_nodeLevels.ContainsKey(nodeId))
                _nodeLevels[nodeId] = 0;

            _nodeLevels[nodeId]++;
            _activeResearchNode = null;
            _researchProgress.Remove(nodeId);

            SaveProgress();
            OnResearchComplete?.Invoke(nodeId, _nodeLevels[nodeId]);
        }

        public float GetResearchProgress(string nodeId)
        {
            if (_activeResearchNode != nodeId)
                return _nodeLevels.ContainsKey(nodeId) ? 1f : 0f;

            var node = _researchTree.GetNode(nodeId);
            int currentLevel = GetNodeLevel(nodeId);
            var nextLevel = node.GetLevel(currentLevel + 1);

            float elapsed = Time.time - _activeResearchStartTime;
            return Mathf.Clamp01(elapsed / nextLevel.ResearchTimeSeconds);
        }

        public float GetTotalBonus(BonusStat stat)
        {
            float total = 0f;
            foreach (var node in _researchTree.AllNodes)
            {
                if (node.BonusStat == stat)
                {
                    int level = GetNodeLevel(node.NodeId);
                    total += node.GetTotalBonus(level);
                }
            }
            return total;
        }

        public void UpdateResearch(float deltaTime)
        {
            if (string.IsNullOrEmpty(_activeResearchNode))
                return;

            float progress = GetResearchProgress(_activeResearchNode);
            OnResearchProgress?.Invoke(_activeResearchNode, progress);

            if (progress >= 1f)
            {
                CompleteResearch(_activeResearchNode);
            }
        }

        private void LoadProgress()
        {
            var data = _saveService.Load<ResearchSaveData>("research");
            if (data != null)
            {
                _nodeLevels = data.NodeLevels ?? new();
                _activeResearchNode = data.ActiveNode;
                _activeResearchStartTime = data.StartTime;
            }
        }

        private void SaveProgress()
        {
            _saveService.Save("research", new ResearchSaveData
            {
                NodeLevels = _nodeLevels,
                ActiveNode = _activeResearchNode,
                StartTime = _activeResearchStartTime
            });
        }
    }

    [Serializable]
    public class ResearchSaveData
    {
        public Dictionary<string, int> NodeLevels;
        public string ActiveNode;
        public float StartTime;
    }
}
```

**Global Balance Integration**

- For costs that follow a global curve, read curve parameters from `GlobalBalanceConfigSO` and apply them when computing research point/gold requirements.
- Individual nodes still define base values, but growth shape and caps are controlled centrally.

**Logging**

- Inject `ILoggingService` into `ResearchService`.
- Log with category `Research` when a research node is started or completed, or when prerequisites/state prevent starting a node.

---

### ✅ Definition of Done
- [ ] ResearchNodeSO created with levels and bonuses
- [ ] ResearchTreeSO with all nodes reference
- [ ] IResearchService interface defined
- [ ] ResearchService implementation complete
- [ ] Prerequisites system working
- [ ] Progress tracking and persistence
- [ ] Create example tree with 4 categories, 3 nodes each
- [ ] Assets in `Assets/_Project/ScriptableObjects/Hub/Research/`
 - [ ] Research cost and bonus curves respond to `GlobalBalanceConfigSO` parameters
 - [ ] Research start/complete events log via `ILoggingService`

---

<!-- Continue in next batch: #65, #72 -->

---

## Issue #65: [Endless] Create EndlessWaveGeneratorSO

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `gameplay`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Create a procedural wave generator for endless/survival mode with scaling difficulty and rewards.

---

### 📋 Requirements

- Infinite wave scaling formula
- Enemy composition rules
- Boss wave intervals
- Reward scaling curve
- Difficulty modifiers per wave
 - Enemy HP/damage/speed and gold/material reward multipliers must read their global scaling factors from `GlobalBalanceConfigSO`.
 - Endless difficulty/reward curves must be tunable without code changes by editing `GlobalBalanceConfigSO`.
 - Wave-generation anomalies (e.g. 0 enemies, invalid spawn weights) must be logged via `ILoggingService`.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Wave/EndlessWaveGeneratorSO.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.Wave
{
    [Serializable]
    public class EnemySpawnWeight
    {
        public EnemyConfigSO Enemy;
        [Range(0f, 100f)] public float Weight;
        public int MinWave;          // First wave this enemy appears
        public int MaxWave = -1;     // -1 = no limit
    }

    [Serializable]
    public class EndlessDifficultyTier
    {
        public int StartWave;
        public float HealthMultiplier;
        public float DamageMultiplier;
        public float SpeedMultiplier;
        public float GoldMultiplier;
        public Color TierColor;
        public string TierName; // "Normal", "Hard", "Nightmare", etc.
    }

    [CreateAssetMenu(menuName = "IdleMonsterTD/Wave/Endless Wave Generator")]
    public class EndlessWaveGeneratorSO : ScriptableObject
    {
        [Header("Base Configuration")]
        public int BaseEnemyCount = 5;
        public float BaseSpawnInterval = 1.5f;
        public float MinSpawnInterval = 0.3f;
        
        [Header("Scaling Formulas")]
        [Tooltip("Enemies per wave = Base + (Wave * LinearScale) + (Wave^2 * QuadraticScale)")]
        public float EnemyCountLinearScale = 0.5f;
        public float EnemyCountQuadraticScale = 0.02f;
        public int MaxEnemiesPerWave = 100;
        
        [Tooltip("Health multiplier = 1 + (Wave * Scale)^Power")]
        public float HealthScalePerWave = 0.1f;
        public float HealthScalePower = 1.2f;
        
        [Header("Enemy Pool")]
        public List<EnemySpawnWeight> EnemyPool;
        
        [Header("Boss Waves")]
        public int BossWaveInterval = 10;
        public List<EnemyConfigSO> BossEnemies;
        public float BossHealthMultiplier = 5f;
        public int BossCount = 1;
        
        [Header("Difficulty Tiers")]
        public List<EndlessDifficultyTier> DifficultyTiers;
        
        [Header("Rewards")]
        public int BaseGoldReward = 100;
        public float GoldScalePerWave = 0.15f;
        public int BaseEvoMaterialReward = 5;
        public float EvoMaterialScalePerWave = 0.1f;

        /// <summary>
        /// Generate a wave configuration for the given wave number.
        /// </summary>
        public GeneratedWave GenerateWave(int waveNumber)
        {
            var wave = new GeneratedWave
            {
                WaveNumber = waveNumber,
                IsBossWave = waveNumber % BossWaveInterval == 0,
                DifficultyTier = GetDifficultyTier(waveNumber)
            };

            if (wave.IsBossWave)
            {
                GenerateBossWave(wave, waveNumber);
            }
            else
            {
                GenerateNormalWave(wave, waveNumber);
            }

            CalculateRewards(wave, waveNumber);
            return wave;
        }

        private void GenerateNormalWave(GeneratedWave wave, int waveNumber)
        {
            int enemyCount = CalculateEnemyCount(waveNumber);
            float healthMult = CalculateHealthMultiplier(waveNumber);
            float interval = CalculateSpawnInterval(waveNumber);

            var availableEnemies = GetAvailableEnemies(waveNumber);
            var entries = new List<WaveEntry>();

            // Distribute enemies based on weights
            float totalWeight = 0f;
            foreach (var e in availableEnemies)
                totalWeight += e.Weight;

            foreach (var enemyWeight in availableEnemies)
            {
                float ratio = enemyWeight.Weight / totalWeight;
                int count = Mathf.Max(1, Mathf.RoundToInt(enemyCount * ratio));

                entries.Add(new WaveEntry
                {
                    Enemy = enemyWeight.Enemy,
                    Count = count,
                    SpawnInterval = interval,
                    HealthMultiplier = healthMult * wave.DifficultyTier.HealthMultiplier,
                    SpeedMultiplier = wave.DifficultyTier.SpeedMultiplier
                });
            }

            wave.Entries = entries;
            wave.TotalEnemies = enemyCount;
        }

        private void GenerateBossWave(GeneratedWave wave, int waveNumber)
        {
            float healthMult = CalculateHealthMultiplier(waveNumber) * BossHealthMultiplier;
            
            // Select boss
            int bossIndex = (waveNumber / BossWaveInterval - 1) % BossEnemies.Count;
            var boss = BossEnemies[bossIndex];

            // Boss + minions
            wave.Entries = new List<WaveEntry>
            {
                new WaveEntry
                {
                    Enemy = boss,
                    Count = BossCount,
                    SpawnInterval = 0f, // Spawn immediately
                    HealthMultiplier = healthMult * wave.DifficultyTier.HealthMultiplier,
                    SpeedMultiplier = 0.7f, // Bosses are slower
                    IsBoss = true
                }
            };

            // Add some minions
            int minionCount = CalculateEnemyCount(waveNumber) / 2;
            var availableEnemies = GetAvailableEnemies(waveNumber);
            if (availableEnemies.Count > 0)
            {
                var minion = availableEnemies[UnityEngine.Random.Range(0, availableEnemies.Count)];
                wave.Entries.Add(new WaveEntry
                {
                    Enemy = minion.Enemy,
                    Count = minionCount,
                    SpawnInterval = CalculateSpawnInterval(waveNumber),
                    HealthMultiplier = CalculateHealthMultiplier(waveNumber),
                    DelayBeforeSpawn = 2f // Spawn after boss
                });
            }

            wave.TotalEnemies = BossCount + minionCount;
        }

        private int CalculateEnemyCount(int wave)
        {
            float count = BaseEnemyCount + 
                          (wave * EnemyCountLinearScale) + 
                          (wave * wave * EnemyCountQuadraticScale);
            return Mathf.Clamp(Mathf.RoundToInt(count), 1, MaxEnemiesPerWave);
        }

        private float CalculateHealthMultiplier(int wave)
        {
            return 1f + Mathf.Pow(wave * HealthScalePerWave, HealthScalePower);
        }

        private float CalculateSpawnInterval(int wave)
        {
            float interval = BaseSpawnInterval - (wave * 0.02f);
            return Mathf.Max(interval, MinSpawnInterval);
        }

        private List<EnemySpawnWeight> GetAvailableEnemies(int waveNumber)
        {
            var available = new List<EnemySpawnWeight>();
            foreach (var e in EnemyPool)
            {
                if (waveNumber >= e.MinWave && (e.MaxWave == -1 || waveNumber <= e.MaxWave))
                    available.Add(e);
            }
            return available;
        }

        private EndlessDifficultyTier GetDifficultyTier(int waveNumber)
        {
            EndlessDifficultyTier current = DifficultyTiers[0];
            foreach (var tier in DifficultyTiers)
            {
                if (waveNumber >= tier.StartWave)
                    current = tier;
            }
            return current;
        }

        private void CalculateRewards(GeneratedWave wave, int waveNumber)
        {
            float goldMult = 1f + (waveNumber * GoldScalePerWave);
            float evoMult = 1f + (waveNumber * EvoMaterialScalePerWave);

            wave.GoldReward = Mathf.RoundToInt(BaseGoldReward * goldMult * wave.DifficultyTier.GoldMultiplier);
            wave.EvoMaterialReward = Mathf.RoundToInt(BaseEvoMaterialReward * evoMult);

            // Bonus for boss waves
            if (wave.IsBossWave)
            {
                wave.GoldReward *= 3;
                wave.EvoMaterialReward *= 2;
            }
        }
    }

    [Serializable]
    public class GeneratedWave
    {
        public int WaveNumber;
        public bool IsBossWave;
        public EndlessDifficultyTier DifficultyTier;
        public List<WaveEntry> Entries;
        public int TotalEnemies;
        public int GoldReward;
        public int EvoMaterialReward;
    }

    [Serializable]
    public class WaveEntry
    {
        public EnemyConfigSO Enemy;
        public int Count;
        public float SpawnInterval;
        public float HealthMultiplier = 1f;
        public float SpeedMultiplier = 1f;
        public float DelayBeforeSpawn = 0f;
        public bool IsBoss = false;
    }
}
```

**Global Balance Integration**

- Inject `GlobalBalanceConfigSO` into wave-generation logic.
- Use fields like `EndlessBaseHealthMult`, `EndlessBaseDamageMult`, `EndlessGoldRewardMult` to shape base curves.
- Keep per-enemy ScriptableObject stats intact, but apply global multipliers from `GlobalBalanceConfigSO` on top.

**Logging**

- Inject `ILoggingService` into the system that calls `EndlessWaveGeneratorSO`.
- Log with category `Endless` when a generated wave has suspicious configurations (e.g., too few enemies, no bosses when expected) or when config data is missing or corrupt.

---

### ✅ Definition of Done
- [ ] EndlessWaveGeneratorSO created
- [ ] Enemy count scaling formula working
- [ ] Health/speed multiplier scaling
- [ ] Boss wave generation every N waves
- [ ] Difficulty tiers implemented
- [ ] Reward scaling configured
- [ ] Create test generator with 3 difficulty tiers
- [ ] Verified wave 1, 10, 50, 100 feel appropriate
 - [ ] Endless difficulty and rewards respond to changes in `GlobalBalanceConfigSO`
 - [ ] Endless-related anomalies are logged via `ILoggingService`

---

---

## Issue #72: [Monster] Implement Evolution Stage 2

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `gameplay`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Implement monster evolution system that upgrades monsters to Stage 2 with new visuals and enhanced stats.

---

### 📋 Requirements

- Level threshold for evolution eligibility
- Material cost (evo materials + gold)
- Stat multipliers on evolution
- Visual prefab swap
- Ability unlocks
- Persistence of evolution state

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Monster/EvolutionConfigSO.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.Monster
{
    [Serializable]
    public class EvolutionStage
    {
        public int Stage;
        public string StageName;
        
        [Header("Requirements")]
        public int RequiredLevel;
        public int RequiredShards;
        public int EvoMaterialCost;
        public int GoldCost;
        
        [Header("Stat Bonuses")]
        public float AttackMultiplier = 1f;
        public float HealthMultiplier = 1f;
        public float RangeBonus = 0f;
        public float AttackSpeedBonus = 0f;
        
        [Header("Visuals")]
        public GameObject EvolutionPrefab;
        public Sprite EvolutionIcon;
        public RuntimeAnimatorController Animator;
        
        [Header("Abilities")]
        public List<AbilityConfigSO> UnlockedAbilities;
    }

    [CreateAssetMenu(menuName = "IdleMonsterTD/Monster/Evolution Config")]
    public class EvolutionConfigSO : ScriptableObject
    {
        public string MonsterId;
        public List<EvolutionStage> Stages;

        public EvolutionStage GetStage(int stage)
        {
            return Stages.Find(s => s.Stage == stage);
        }

        public EvolutionStage GetNextStage(int currentStage)
        {
            return Stages.Find(s => s.Stage == currentStage + 1);
        }

        public int MaxStage => Stages.Count > 0 ? Stages[^1].Stage : 1;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/IEvolutionService.cs`

```csharp
using System;

namespace IdleMonsterTD.Core.Services
{
    public interface IEvolutionService
    {
        int GetEvolutionStage(string monsterId);
        bool CanEvolve(string monsterId);
        EvolutionRequirement GetEvolutionRequirements(string monsterId);
        bool TryEvolve(string monsterId);
        float GetStatMultiplier(string monsterId, StatType statType);
        
        event Action<string, int> OnMonsterEvolved;
    }

    public struct EvolutionRequirement
    {
        public int RequiredLevel;
        public int CurrentLevel;
        public int RequiredShards;
        public int CurrentShards;
        public int EvoMaterialCost;
        public int CurrentEvoMaterials;
        public int GoldCost;
        public int CurrentGold;
        public bool MeetsAllRequirements;
    }

    public enum StatType
    {
        Attack,
        Health,
        Range,
        AttackSpeed
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/EvolutionService.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Services
{
    public class EvolutionService : IEvolutionService
    {
        private readonly ISaveService _saveService;
        private readonly IInventoryService _inventoryService;
        private readonly IShardService _shardService;
        private readonly ICurrencyService _currencyService;
        private readonly MonsterDatabase _monsterDatabase;
        private readonly EvolutionDatabase _evolutionDatabase;

        private Dictionary<string, int> _evolutionStages = new();

        public event Action<string, int> OnMonsterEvolved;

        [Inject]
        public EvolutionService(
            ISaveService saveService,
            IInventoryService inventoryService,
            IShardService shardService,
            ICurrencyService currencyService,
            MonsterDatabase monsterDatabase,
            EvolutionDatabase evolutionDatabase)
        {
            _saveService = saveService;
            _inventoryService = inventoryService;
            _shardService = shardService;
            _currencyService = currencyService;
            _monsterDatabase = monsterDatabase;
            _evolutionDatabase = evolutionDatabase;
            
            LoadEvolutionData();
        }

        public int GetEvolutionStage(string monsterId)
        {
            return _evolutionStages.TryGetValue(monsterId, out int stage) ? stage : 1;
        }

        public bool CanEvolve(string monsterId)
        {
            var req = GetEvolutionRequirements(monsterId);
            return req.MeetsAllRequirements;
        }

        public EvolutionRequirement GetEvolutionRequirements(string monsterId)
        {
            var evoConfig = _evolutionDatabase.GetById(monsterId);
            int currentStage = GetEvolutionStage(monsterId);
            var nextStage = evoConfig?.GetNextStage(currentStage);

            if (nextStage == null)
            {
                return new EvolutionRequirement { MeetsAllRequirements = false };
            }

            int currentLevel = _inventoryService.GetMonsterLevel(monsterId);
            int currentShards = _shardService.GetShards(monsterId);
            int currentEvo = _currencyService.GetAmount(CurrencyType.EvoMaterial);
            int currentGold = _currencyService.GetAmount(CurrencyType.Gold);

            var req = new EvolutionRequirement
            {
                RequiredLevel = nextStage.RequiredLevel,
                CurrentLevel = currentLevel,
                RequiredShards = nextStage.RequiredShards,
                CurrentShards = currentShards,
                EvoMaterialCost = nextStage.EvoMaterialCost,
                CurrentEvoMaterials = currentEvo,
                GoldCost = nextStage.GoldCost,
                CurrentGold = currentGold
            };

            req.MeetsAllRequirements = 
                currentLevel >= nextStage.RequiredLevel &&
                currentShards >= nextStage.RequiredShards &&
                currentEvo >= nextStage.EvoMaterialCost &&
                currentGold >= nextStage.GoldCost;

            return req;
        }

        public bool TryEvolve(string monsterId)
        {
            if (!CanEvolve(monsterId))
                return false;

            var evoConfig = _evolutionDatabase.GetById(monsterId);
            int currentStage = GetEvolutionStage(monsterId);
            var nextStage = evoConfig.GetNextStage(currentStage);

            // Deduct costs
            _shardService.AddShards(monsterId, -nextStage.RequiredShards);
            _currencyService.Spend(CurrencyType.EvoMaterial, nextStage.EvoMaterialCost);
            _currencyService.Spend(CurrencyType.Gold, nextStage.GoldCost);

            // Upgrade stage
            _evolutionStages[monsterId] = currentStage + 1;
            SaveEvolutionData();

            OnMonsterEvolved?.Invoke(monsterId, currentStage + 1);
            return true;
        }

        public float GetStatMultiplier(string monsterId, StatType statType)
        {
            var evoConfig = _evolutionDatabase.GetById(monsterId);
            if (evoConfig == null) return 1f;

            int currentStage = GetEvolutionStage(monsterId);
            float multiplier = 1f;

            // Accumulate multipliers from all evolved stages
            for (int i = 1; i <= currentStage; i++)
            {
                var stage = evoConfig.GetStage(i);
                if (stage == null) continue;

                multiplier *= statType switch
                {
                    StatType.Attack => stage.AttackMultiplier,
                    StatType.Health => stage.HealthMultiplier,
                    StatType.Range => 1f + stage.RangeBonus,
                    StatType.AttackSpeed => 1f + stage.AttackSpeedBonus,
                    _ => 1f
                };
            }

            return multiplier;
        }

        private void LoadEvolutionData()
        {
            var data = _saveService.Load<EvolutionSaveData>("evolution");
            if (data != null)
                _evolutionStages = data.Stages ?? new();
        }

        private void SaveEvolutionData()
        {
            _saveService.Save("evolution", new EvolutionSaveData
            {
                Stages = _evolutionStages
            });
        }
    }

    [Serializable]
    public class EvolutionSaveData
    {
        public Dictionary<string, int> Stages;
    }
}
```

**Integration with Monster Component:**

```csharp
// In Monster.cs, add evolution support:
public class Monster : MonoBehaviour, IMonster
{
    private IEvolutionService _evolutionService;
    
    [Inject]
    public void Construct(IEvolutionService evolutionService, /* other deps */)
    {
        _evolutionService = evolutionService;
    }

    public float GetAttack()
    {
        float baseAttack = _config.BaseDamage;
        float evoMult = _evolutionService.GetStatMultiplier(_config.MonsterId, StatType.Attack);
        return baseAttack * evoMult;
    }

    public void ApplyEvolution()
    {
        int stage = _evolutionService.GetEvolutionStage(_config.MonsterId);
        var evoConfig = _evolutionDatabase.GetById(_config.MonsterId);
        var stageConfig = evoConfig?.GetStage(stage);
        
        if (stageConfig?.EvolutionPrefab != null)
        {
            // Swap visual
            UpdateVisual(stageConfig.EvolutionPrefab);
        }
    }
}
```

---

### ✅ Definition of Done
- [ ] EvolutionConfigSO created
- [ ] IEvolutionService interface defined
- [ ] EvolutionService implementation complete
- [ ] Level/shard/material requirements checking
- [ ] Stat multipliers applied correctly
- [ ] Visual prefab swap working
- [ ] Create evolution configs for 3 starter monsters
- [ ] Evolution UI button functional
- [ ] Persistence verified

---

<!-- Continue in next batch: #73, #74, #75, #78, #79 -->

---

## Issue #73: [Backend] Set up Supabase project

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `backend`, `priority-critical`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Set up Supabase project with database schema for player data, save sync, and analytics.

---

### 📋 Requirements

- Supabase project creation
- Database tables for: players, save_data, analytics_events
- Row Level Security (RLS) policies
- API keys configuration in Unity
- Edge functions for validation
 - All backend requests/responses must log via `ILoggingService` (no direct `Debug.Log*`), with care not to log secrets or PII.

---

### 📝 Implementation

**Step 1: Create Supabase Project**
1. Go to https://supabase.com
2. Create new project: `idle-monster-td`
3. Note down: Project URL, anon key, service role key

**Step 2: Database Schema**

```sql
-- Players table
CREATE TABLE players (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    device_id TEXT UNIQUE,
    display_name TEXT,
    account_level INTEGER DEFAULT 1,
    created_at TIMESTAMPTZ DEFAULT NOW(),
    last_login TIMESTAMPTZ DEFAULT NOW(),
    is_banned BOOLEAN DEFAULT FALSE
);

-- Save data table
CREATE TABLE save_data (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    player_id UUID REFERENCES players(id) ON DELETE CASCADE,
    save_key TEXT NOT NULL,
    data JSONB NOT NULL,
    version INTEGER DEFAULT 1,
    updated_at TIMESTAMPTZ DEFAULT NOW(),
    UNIQUE(player_id, save_key)
);

-- Analytics events
CREATE TABLE analytics_events (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    player_id UUID REFERENCES players(id),
    event_type TEXT NOT NULL,
    event_data JSONB,
    session_id TEXT,
    created_at TIMESTAMPTZ DEFAULT NOW()
);

-- Remote config
CREATE TABLE remote_config (
    key TEXT PRIMARY KEY,
    value JSONB NOT NULL,
    description TEXT,
    updated_at TIMESTAMPTZ DEFAULT NOW()
);

-- Create indexes
CREATE INDEX idx_save_data_player ON save_data(player_id);
CREATE INDEX idx_analytics_player ON analytics_events(player_id);
CREATE INDEX idx_analytics_type ON analytics_events(event_type);
CREATE INDEX idx_analytics_created ON analytics_events(created_at);
```

**Step 3: Row Level Security**

```sql
-- Enable RLS
ALTER TABLE players ENABLE ROW LEVEL SECURITY;
ALTER TABLE save_data ENABLE ROW LEVEL SECURITY;
ALTER TABLE analytics_events ENABLE ROW LEVEL SECURITY;

-- Players: users can only read their own data
CREATE POLICY "Users can view own player data" ON players
    FOR SELECT USING (id = auth.uid()::uuid);

CREATE POLICY "Users can update own player data" ON players
    FOR UPDATE USING (id = auth.uid()::uuid);

-- Save data: users can only access their own saves
CREATE POLICY "Users can read own saves" ON save_data
    FOR SELECT USING (player_id = auth.uid()::uuid);

CREATE POLICY "Users can insert own saves" ON save_data
    FOR INSERT WITH CHECK (player_id = auth.uid()::uuid);

CREATE POLICY "Users can update own saves" ON save_data
    FOR UPDATE USING (player_id = auth.uid()::uuid);

-- Analytics: users can insert their own events
CREATE POLICY "Users can insert own events" ON analytics_events
    FOR INSERT WITH CHECK (player_id = auth.uid()::uuid);

-- Remote config: anyone can read
CREATE POLICY "Anyone can read config" ON remote_config
    FOR SELECT TO anon USING (true);
```

**File:** `Assets/_Project/Scripts/Core/Backend/SupabaseConfig.cs`

```csharp
using UnityEngine;

namespace IdleMonsterTD.Core.Backend
{
    [CreateAssetMenu(menuName = "IdleMonsterTD/Backend/Supabase Config")]
    public class SupabaseConfig : ScriptableObject
    {
        [Header("Project Settings")]
        public string ProjectUrl;
        public string AnonKey;
        
        [Header("Options")]
        public float RequestTimeout = 30f;
        public int MaxRetries = 3;
        public bool EnableLogging = true;
        
        public string RestUrl => $"{ProjectUrl}/rest/v1";
        public string AuthUrl => $"{ProjectUrl}/auth/v1";
        public string StorageUrl => $"{ProjectUrl}/storage/v1";
    }
}
```

**Logging**

- Inject `ILoggingService` into backend-related services.
- For each REST call to Supabase:
    - Log info-level with category `Backend` including endpoint name, method, and duration.
- On failures:
    - Log warning or error-level with category `Backend`, including status code and safe error details (no tokens or sensitive payloads).

---

### ✅ Definition of Done
- [ ] Supabase project created
- [ ] All tables created with proper schema
- [ ] RLS policies enabled and tested
- [ ] Indexes created for performance
- [ ] SupabaseConfig.asset created (DO NOT commit keys!)
- [ ] Test connection from Unity Editor
- [ ] Document API endpoints in README
 - [ ] Backend debug output goes through `ILoggingService`; no direct `Debug.Log*`

---

---

## Issue #74: [Backend] Implement cloud save sync

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `backend`, `priority-critical`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Implement bidirectional save synchronization between local and cloud storage.

---

### 📋 Requirements

- Upload local saves to cloud
- Download cloud saves on login
- Conflict resolution (newer wins + prompt option)
- Offline support with queue
- Compression for large saves

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Backend/ICloudSaveService.cs`

```csharp
using System;
using System.Threading.Tasks;

namespace IdleMonsterTD.Core.Backend
{
    public enum SyncResult
    {
        Success,
        Conflict,
        NetworkError,
        AuthError
    }

    public struct SyncStatus
    {
        public SyncResult Result;
        public DateTime LocalTimestamp;
        public DateTime CloudTimestamp;
        public bool RequiresResolution;
    }

    public interface ICloudSaveService
    {
        bool IsOnline { get; }
        DateTime LastSyncTime { get; }
        
        Task<SyncStatus> SyncAll();
        Task<SyncResult> Upload(string saveKey, object data);
        Task<T> Download<T>(string saveKey);
        Task<SyncStatus> CheckStatus(string saveKey);
        void ResolveConflict(string saveKey, bool useCloud);
        
        event Action<string, SyncResult> OnSyncComplete;
        event Action<string> OnConflictDetected;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Backend/CloudSaveService.cs`

```csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using VContainer;
using Newtonsoft.Json;

namespace IdleMonsterTD.Core.Backend
{
    public class CloudSaveService : ICloudSaveService
    {
        private readonly SupabaseConfig _config;
        private readonly ISaveService _localSave;
        private readonly IAuthService _authService;

        private Queue<PendingSync> _syncQueue = new();
        private bool _isSyncing;

        public bool IsOnline => Application.internetReachability != NetworkReachability.NotReachable;
        public DateTime LastSyncTime { get; private set; }

        public event Action<string, SyncResult> OnSyncComplete;
        public event Action<string> OnConflictDetected;

        [Inject]
        public CloudSaveService(
            SupabaseConfig config,
            ISaveService localSave,
            IAuthService authService)
        {
            _config = config;
            _localSave = localSave;
            _authService = authService;
        }

        public async Task<SyncStatus> SyncAll()
        {
            if (!IsOnline || !_authService.IsAuthenticated)
            {
                return new SyncStatus { Result = SyncResult.NetworkError };
            }

            var saveKeys = new[] { "player", "inventory", "gacha", "research", "shards", "evolution" };
            SyncStatus overallStatus = new() { Result = SyncResult.Success };

            foreach (var key in saveKeys)
            {
                var status = await SyncSaveKey(key);
                if (status.Result != SyncResult.Success)
                {
                    overallStatus = status;
                    if (status.Result == SyncResult.Conflict)
                        break;
                }
            }

            LastSyncTime = DateTime.UtcNow;
            return overallStatus;
        }

        private async Task<SyncStatus> SyncSaveKey(string saveKey)
        {
            var status = await CheckStatus(saveKey);

            if (status.RequiresResolution)
            {
                OnConflictDetected?.Invoke(saveKey);
                return status;
            }

            if (status.LocalTimestamp > status.CloudTimestamp)
            {
                // Local is newer, upload
                var localData = _localSave.Load<object>(saveKey);
                await Upload(saveKey, localData);
            }
            else if (status.CloudTimestamp > status.LocalTimestamp)
            {
                // Cloud is newer, download
                var cloudData = await Download<object>(saveKey);
                _localSave.Save(saveKey, cloudData);
            }

            return new SyncStatus { Result = SyncResult.Success };
        }

        public async Task<SyncResult> Upload(string saveKey, object data)
        {
            if (!IsOnline)
            {
                QueueSync(saveKey, data);
                return SyncResult.NetworkError;
            }

            try
            {
                string playerId = _authService.PlayerId;
                string json = JsonConvert.SerializeObject(new
                {
                    player_id = playerId,
                    save_key = saveKey,
                    data = data,
                    version = GetLocalVersion(saveKey) + 1,
                    updated_at = DateTime.UtcNow
                });

                using var request = new UnityWebRequest($"{_config.RestUrl}/save_data", "POST");
                request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("apikey", _config.AnonKey);
                request.SetRequestHeader("Authorization", $"Bearer {_authService.AccessToken}");
                request.SetRequestHeader("Prefer", "resolution=merge-duplicates");

                await request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    IncrementLocalVersion(saveKey);
                    OnSyncComplete?.Invoke(saveKey, SyncResult.Success);
                    return SyncResult.Success;
                }

                Debug.LogError($"Upload failed: {request.error}");
                return SyncResult.NetworkError;
            }
            catch (Exception e)
            {
                Debug.LogError($"Upload exception: {e.Message}");
                return SyncResult.NetworkError;
            }
        }

        public async Task<T> Download<T>(string saveKey)
        {
            try
            {
                string playerId = _authService.PlayerId;
                string url = $"{_config.RestUrl}/save_data?player_id=eq.{playerId}&save_key=eq.{saveKey}&select=data";

                using var request = UnityWebRequest.Get(url);
                request.SetRequestHeader("apikey", _config.AnonKey);
                request.SetRequestHeader("Authorization", $"Bearer {_authService.AccessToken}");

                await request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    var response = JsonConvert.DeserializeObject<List<SaveDataResponse>>(request.downloadHandler.text);
                    if (response != null && response.Count > 0)
                    {
                        return JsonConvert.DeserializeObject<T>(response[0].Data.ToString());
                    }
                }

                return default;
            }
            catch (Exception e)
            {
                Debug.LogError($"Download exception: {e.Message}");
                return default;
            }
        }

        public async Task<SyncStatus> CheckStatus(string saveKey)
        {
            var localTime = _localSave.GetLastModified(saveKey);
            var cloudTime = await GetCloudTimestamp(saveKey);

            var timeDiff = Math.Abs((localTime - cloudTime).TotalSeconds);
            bool conflict = timeDiff < 60 && localTime != cloudTime; // Within 1 minute = potential conflict

            return new SyncStatus
            {
                LocalTimestamp = localTime,
                CloudTimestamp = cloudTime,
                RequiresResolution = conflict,
                Result = conflict ? SyncResult.Conflict : SyncResult.Success
            };
        }

        public void ResolveConflict(string saveKey, bool useCloud)
        {
            if (useCloud)
            {
                _ = DownloadAndApply(saveKey);
            }
            else
            {
                var localData = _localSave.Load<object>(saveKey);
                _ = Upload(saveKey, localData);
            }
        }

        private async Task DownloadAndApply(string saveKey)
        {
            var data = await Download<object>(saveKey);
            _localSave.Save(saveKey, data);
            OnSyncComplete?.Invoke(saveKey, SyncResult.Success);
        }

        private async Task<DateTime> GetCloudTimestamp(string saveKey)
        {
            try
            {
                string playerId = _authService.PlayerId;
                string url = $"{_config.RestUrl}/save_data?player_id=eq.{playerId}&save_key=eq.{saveKey}&select=updated_at";

                using var request = UnityWebRequest.Get(url);
                request.SetRequestHeader("apikey", _config.AnonKey);
                request.SetRequestHeader("Authorization", $"Bearer {_authService.AccessToken}");

                await request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    var response = JsonConvert.DeserializeObject<List<TimestampResponse>>(request.downloadHandler.text);
                    if (response != null && response.Count > 0)
                    {
                        return response[0].UpdatedAt;
                    }
                }
            }
            catch { }

            return DateTime.MinValue;
        }

        private void QueueSync(string saveKey, object data)
        {
            _syncQueue.Enqueue(new PendingSync { SaveKey = saveKey, Data = data });
        }

        private int GetLocalVersion(string saveKey) => 
            PlayerPrefs.GetInt($"save_version_{saveKey}", 0);

        private void IncrementLocalVersion(string saveKey) =>
            PlayerPrefs.SetInt($"save_version_{saveKey}", GetLocalVersion(saveKey) + 1);

        private class SaveDataResponse { public object Data; }
        private class TimestampResponse { public DateTime UpdatedAt; }
        private struct PendingSync { public string SaveKey; public object Data; }
    }
}
```

---

### ✅ Definition of Done
- [ ] ICloudSaveService interface defined
- [ ] CloudSaveService implementation complete
- [ ] Upload/download working
- [ ] Conflict detection implemented
- [ ] Offline queue for pending syncs
- [ ] Sync on app focus/pause
- [ ] Registered in GameLifetimeScope
- [ ] Test with airplane mode on/off

---

---

## Issue #75: [Backend] Implement account auth

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `backend`, `priority-high`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Implement anonymous authentication with optional account linking.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Backend/IAuthService.cs`

```csharp
using System;
using System.Threading.Tasks;

namespace IdleMonsterTD.Core.Backend
{
    public interface IAuthService
    {
        bool IsAuthenticated { get; }
        string PlayerId { get; }
        string AccessToken { get; }
        
        Task<bool> SignInAnonymously();
        Task<bool> LinkEmail(string email, string password);
        Task<bool> SignInWithEmail(string email, string password);
        Task SignOut();
        
        event Action OnSignedIn;
        event Action OnSignedOut;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Backend/AuthService.cs`

```csharp
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using VContainer;
using Newtonsoft.Json;

namespace IdleMonsterTD.Core.Backend
{
    public class AuthService : IAuthService
    {
        private readonly SupabaseConfig _config;
        
        public bool IsAuthenticated { get; private set; }
        public string PlayerId { get; private set; }
        public string AccessToken { get; private set; }
        
        public event Action OnSignedIn;
        public event Action OnSignedOut;

        [Inject]
        public AuthService(SupabaseConfig config)
        {
            _config = config;
            LoadSession();
        }

        public async Task<bool> SignInAnonymously()
        {
            try
            {
                string deviceId = SystemInfo.deviceUniqueIdentifier;
                string json = JsonConvert.SerializeObject(new { device_id = deviceId });

                using var request = new UnityWebRequest($"{_config.AuthUrl}/signup", "POST");
                request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("apikey", _config.AnonKey);

                await request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    var response = JsonConvert.DeserializeObject<AuthResponse>(request.downloadHandler.text);
                    SetSession(response);
                    return true;
                }

                // If signup fails, try signin (user exists)
                return await SignInWithDeviceId(deviceId);
            }
            catch (Exception e)
            {
                Debug.LogError($"Anonymous sign-in failed: {e.Message}");
                return false;
            }
        }

        private async Task<bool> SignInWithDeviceId(string deviceId)
        {
            // Custom sign-in logic for existing anonymous users
            // This would use a Supabase Edge Function
            return false;
        }

        public async Task<bool> LinkEmail(string email, string password)
        {
            // Link anonymous account to email for recovery
            try
            {
                string json = JsonConvert.SerializeObject(new { email, password });

                using var request = new UnityWebRequest($"{_config.AuthUrl}/user", "PUT");
                request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("apikey", _config.AnonKey);
                request.SetRequestHeader("Authorization", $"Bearer {AccessToken}");

                await request.SendWebRequest();
                return request.result == UnityWebRequest.Result.Success;
            }
            catch (Exception e)
            {
                Debug.LogError($"Link email failed: {e.Message}");
                return false;
            }
        }

        public async Task<bool> SignInWithEmail(string email, string password)
        {
            try
            {
                string json = JsonConvert.SerializeObject(new { email, password });

                using var request = new UnityWebRequest($"{_config.AuthUrl}/token?grant_type=password", "POST");
                request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("apikey", _config.AnonKey);

                await request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    var response = JsonConvert.DeserializeObject<AuthResponse>(request.downloadHandler.text);
                    SetSession(response);
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Debug.LogError($"Email sign-in failed: {e.Message}");
                return false;
            }
        }

        public Task SignOut()
        {
            IsAuthenticated = false;
            PlayerId = null;
            AccessToken = null;
            ClearSession();
            OnSignedOut?.Invoke();
            return Task.CompletedTask;
        }

        private void SetSession(AuthResponse response)
        {
            PlayerId = response.User.Id;
            AccessToken = response.AccessToken;
            IsAuthenticated = true;
            SaveSession();
            OnSignedIn?.Invoke();
        }

        private void SaveSession()
        {
            PlayerPrefs.SetString("auth_player_id", PlayerId);
            PlayerPrefs.SetString("auth_token", AccessToken);
            PlayerPrefs.Save();
        }

        private void LoadSession()
        {
            PlayerId = PlayerPrefs.GetString("auth_player_id", null);
            AccessToken = PlayerPrefs.GetString("auth_token", null);
            IsAuthenticated = !string.IsNullOrEmpty(PlayerId) && !string.IsNullOrEmpty(AccessToken);
        }

        private void ClearSession()
        {
            PlayerPrefs.DeleteKey("auth_player_id");
            PlayerPrefs.DeleteKey("auth_token");
        }

        private class AuthResponse
        {
            [JsonProperty("access_token")] public string AccessToken;
            [JsonProperty("user")] public UserInfo User;
        }

        private class UserInfo
        {
            [JsonProperty("id")] public string Id;
        }
    }
}
```

---

### ✅ Definition of Done
- [ ] IAuthService interface defined
- [ ] AuthService with anonymous auth
- [ ] Session persistence (token stored)
- [ ] Email linking for account recovery
- [ ] Sign out functionality
- [ ] Registered in GameLifetimeScope
- [ ] Test on device with fresh install

---

---

## Issue #78: [QA] Phase 1 integration testing

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `testing`, `priority-critical`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Comprehensive testing of all Phase 1 features working together.

---

### 📋 Test Checklist

**Gacha System:**
- [ ] Single pull deducts correct currency
- [ ] 10x pull gives guaranteed Rare+
- [ ] Pity counter increments correctly
- [ ] Hard pity at 90 pulls guarantees Legendary
- [ ] Duplicate monsters convert to shards
- [ ] Pull history displays correctly
- [ ] Skip animation works

**Shard/Evolution System:**
- [ ] Shards accumulate from duplicates
- [ ] Unlock threshold per rarity correct
- [ ] Evolution requirements check properly
- [ ] Evolution applies stat multipliers
- [ ] Visual swap on evolution
- [ ] Persistence across sessions

**Hub Buildings:**
- [ ] Buildings unlock at correct account level
- [ ] Upgrade costs deducted
- [ ] Upgrade bonuses apply
- [ ] Visual changes per level tier

**Research:**
- [ ] Prerequisites checked
- [ ] Research progress tracks
- [ ] Bonuses apply to stats
- [ ] Multiple nodes can be completed

**Endless Mode:**
- [ ] Waves scale correctly
- [ ] Boss waves spawn
- [ ] Rewards increase per wave
- [ ] High score saves

**Backend:**
- [ ] Anonymous auth creates account
- [ ] Cloud save uploads
- [ ] Cloud save downloads
- [ ] Conflict resolution prompt appears
- [ ] Offline mode queues syncs

---

### 📝 Test Script

Create `Assets/_Project/Scripts/Editor/Phase1TestRunner.cs` with automated tests.

---

### ✅ Definition of Done
- [ ] All checklist items pass
- [ ] No critical bugs
- [ ] Performance acceptable (<16ms frame time)
- [ ] Memory stable (no leaks in 30min session)
- [ ] Test on Android device
- [ ] Bug list created for Phase 2 fixes

---

---

## Issue #79: [Docs] Phase 1 completion documentation

**Assignee:** @MaxeLBerger  
**Labels:** `phase-1`, `documentation`, `priority-medium`  
**Milestone:** Phase 1 - Feature Expansion

---

### 🎯 Goal
Document all Phase 1 systems for team reference and future maintenance.

---

### 📝 Documentation Deliverables

**1. Update README.md:**
- Add Phase 1 features list
- Backend setup instructions
- Supabase configuration guide

**2. Create GACHA_SYSTEM.md:**
- Drop rate tables
- Pity mechanics explanation
- Shard conversion rates
- Banner configuration guide

**3. Create HUB_PROGRESSION.md:**
- Building types and bonuses
- Upgrade cost formulas
- Research tree structure

**4. Create BACKEND_INTEGRATION.md:**
- Supabase schema
- API endpoints
- Authentication flow
- Cloud save sync process

**5. Update ARCHITECTURE.md:**
- New service interfaces
- DI registration for Phase 1

---

### ✅ Definition of Done
- [ ] README.md updated
- [ ] GACHA_SYSTEM.md created
- [ ] HUB_PROGRESSION.md created
- [ ] BACKEND_INTEGRATION.md created
- [ ] ARCHITECTURE.md updated
- [ ] All public APIs have XML comments
- [ ] Phase 2 handoff notes prepared

---

<!-- End of Phase 1 -->
