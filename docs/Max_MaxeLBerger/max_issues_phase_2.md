# Max's Phase 2 Issues — Weeks 9-12

**Focus:** Battle Pass, Shop/IAP, Rewarded Ads, Events, Analytics

---

## Phase 2 Issue Summary (14 issues)

| # | Title | Priority | Status |
|---|-------|----------|--------|
| #80 | [Pass] Create SeasonConfigSO | Critical | ⬜ |
| #81 | [Pass] Implement IBattlePassService | Critical | ⬜ |
| #86 | [Shop] Create ShopOfferConfigSO | Critical | ⬜ |
| #87 | [Shop] Integrate Unity IAP | Critical | ⬜ |
| #88 | [Shop] Implement receipt validation | High | ⬜ |
| #92 | [VIP] Implement VIP subscription | Medium | ⬜ |
| #93 | [Ads] Integrate Unity Ads / AdMob | High | ⬜ |
| #95 | [Events] Create EventConfigSO | High | ⬜ |
| #100 | [Analytics] Implement funnel tracking | High | ⬜ |
| #101 | [Analytics] Implement retention cohorts | High | ⬜ |
| #102 | [Analytics] Implement revenue metrics | High | ⬜ |
| #103 | [A/B] Implement A/B test framework | Medium | ⬜ |
| #104 | [QA] Phase 2 monetization testing | Critical | ⬜ |
| #106 | [Perf] Pre-launch optimization | High | ⬜ |
| #107 | [Docs] Phase 2 completion documentation | Medium | ⬜ |

---

## Issue #80: [Pass] Create SeasonConfigSO

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `monetization`, `priority-critical`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Create ScriptableObject for Battle Pass season configuration with free and premium tracks.

---

### 📋 Requirements

- Season duration and scheduling
- Free track rewards (all players)
- Premium track rewards (paid)
- XP requirements per tier
- Mission definitions for XP
 - Battle Pass XP curve, level-up requirements, and reward value multipliers must be driven by `GlobalBalanceConfigSO` (with optional per-season overrides via remote config).

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/BattlePass/SeasonConfigSO.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.BattlePass
{
    [Serializable]
    public class PassReward
    {
        public RewardType Type;
        public string ItemId;      // Monster ID, currency type, etc.
        public int Amount;
        public Sprite Icon;
    }

    [Serializable]
    public class PassTier
    {
        public int Tier;
        public int XPRequired;      // Total XP to reach this tier
        public PassReward FreeReward;
        public PassReward PremiumReward;
    }

    [Serializable]
    public class PassMission
    {
        public string MissionId;
        public string Description;
        public MissionType Type;
        public int TargetValue;
        public int XPReward;
        public MissionRefreshType RefreshType;
    }

    [CreateAssetMenu(menuName = "IdleMonsterTD/BattlePass/Season Config")]
    public class SeasonConfigSO : ScriptableObject
    {
        [Header("Season Info")]
        public string SeasonId;
        public string SeasonName;
        public int SeasonNumber;
        public Sprite SeasonBanner;
        
        [Header("Schedule")]
        public DateTime StartDate;
        public DateTime EndDate;
        public int DurationDays = 28;
        
        [Header("Premium")]
        public string PremiumProductId;  // IAP product ID
        public int PremiumPriceCents = 999;
        
        [Header("Tiers")]
        public int MaxTier = 50;
        public int XPPerTier = 1000;     // Base XP, can scale
        public float XPScalePerTier = 1.05f;
        public List<PassTier> Tiers;
        
        [Header("Missions")]
        public List<PassMission> DailyMissions;
        public List<PassMission> WeeklyMissions;
        public List<PassMission> SeasonMissions;
        
        [Header("Catch-Up")]
        public bool AllowXPPurchase = true;
        public int XPPerPurchase = 100;
        public int XPPurchaseCost = 50; // Premium currency

        public bool IsActive()
        {
            var now = DateTime.UtcNow;
            return now >= StartDate && now <= EndDate;
        }

        public int GetDaysRemaining()
        {
            return Mathf.Max(0, (int)(EndDate - DateTime.UtcNow).TotalDays);
        }

        public int GetXPForTier(int tier)
        {
            float xp = XPPerTier * Mathf.Pow(XPScalePerTier, tier - 1);
            return Mathf.RoundToInt(xp);
        }

        public int GetTotalXPForTier(int tier)
        {
            int total = 0;
            for (int i = 1; i <= tier; i++)
                total += GetXPForTier(i);
            return total;
        }

        public PassTier GetTier(int tier)
        {
            return Tiers.Find(t => t.Tier == tier);
        }

#if UNITY_EDITOR
        [ContextMenu("Generate Default Tiers")]
        private void GenerateDefaultTiers()
        {
            Tiers = new List<PassTier>();
            int cumulativeXP = 0;
            
            for (int i = 1; i <= MaxTier; i++)
            {
                cumulativeXP += GetXPForTier(i);
                Tiers.Add(new PassTier
                {
                    Tier = i,
                    XPRequired = cumulativeXP,
                    FreeReward = GenerateReward(i, false),
                    PremiumReward = GenerateReward(i, true)
                });
            }
        }

        private PassReward GenerateReward(int tier, bool isPremium)
        {
            // Generate placeholder rewards
            if (tier % 10 == 0) // Milestone tiers
            {
                return new PassReward
                {
                    Type = isPremium ? RewardType.Monster : RewardType.Shards,
                    Amount = isPremium ? 1 : 50
                };
            }
            
            return new PassReward
            {
                Type = tier % 2 == 0 ? RewardType.Gold : RewardType.EvoMaterial,
                Amount = tier * (isPremium ? 200 : 100)
            };
        }
#endif
    }

    public enum RewardType
    {
        Gold,
        PremiumCurrency,
        EvoMaterial,
        Shards,
        Monster,
        GachaTicket,
        Cosmetic
    }

    public enum MissionType
    {
        CompleteWaves,
        DefeatEnemies,
        EarnGold,
        UpgradeMonsters,
        PerformSummons,
        CompleteResearch,
        PlayMinutes
    }

    public enum MissionRefreshType
    {
        Daily,
        Weekly,
        Season
    }
}
```

---

### ✅ Definition of Done
- [ ] SeasonConfigSO created with all fields
- [ ] PassTier and PassReward structures defined
- [ ] Mission system configured
- [ ] XP scaling formula working
- [ ] Editor tool to generate default tiers
- [ ] Create Season 1 config with 50 tiers
- [ ] Assets in `Assets/_Project/ScriptableObjects/BattlePass/`

---

---

## Issue #81: [Pass] Implement IBattlePassService

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `monetization`, `priority-critical`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Implement Battle Pass service handling progression, rewards, and premium unlock.

---

### 📋 Requirements

- Track player XP and current tier
- Claim tier rewards (free/premium)
- Mission progress tracking
- Premium purchase integration
- Season reset handling
 - Battle Pass purchases, level unlocks, and reward claims must emit analytics events that are visible in the in-game debug panel.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Services/IBattlePassService.cs`

```csharp
using System;
using System.Collections.Generic;

namespace IdleMonsterTD.Core.Services
{
    public interface IBattlePassService
    {
        string CurrentSeasonId { get; }
        int CurrentTier { get; }
        int CurrentXP { get; }
        int XPToNextTier { get; }
        bool HasPremium { get; }
        
        void AddXP(int amount);
        bool CanClaimReward(int tier, bool premium);
        bool TryClaimReward(int tier, bool premium);
        List<int> GetClaimableTiers(bool premium);
        
        // Missions
        List<MissionProgress> GetActiveMissions();
        void UpdateMissionProgress(MissionType type, int amount);
        bool TryClaimMission(string missionId);
        
        // Premium
        void UnlockPremium();
        bool TryPurchaseXP(int amount);
        
        event Action<int> OnTierReached;
        event Action<int, bool> OnRewardClaimed;
        event Action<string, int> OnMissionProgress;
        event Action OnPremiumUnlocked;
    }

    public struct MissionProgress
    {
        public string MissionId;
        public string Description;
        public MissionType Type;
        public int CurrentValue;
        public int TargetValue;
        public int XPReward;
        public bool IsComplete;
        public bool IsClaimed;
        public MissionRefreshType RefreshType;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/BattlePassService.cs`

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Services
{
    public class BattlePassService : IBattlePassService
    {
        private readonly ISaveService _saveService;
        private readonly IInventoryService _inventoryService;
        private readonly ICurrencyService _currencyService;
        private readonly SeasonConfigSO _currentSeason;

        private BattlePassSaveData _data;

        public string CurrentSeasonId => _currentSeason?.SeasonId ?? "";
        public int CurrentTier => _data.CurrentTier;
        public int CurrentXP => _data.CurrentXP;
        public bool HasPremium => _data.HasPremium;

        public int XPToNextTier
        {
            get
            {
                if (CurrentTier >= _currentSeason.MaxTier) return 0;
                int required = _currentSeason.GetTotalXPForTier(CurrentTier + 1);
                return required - CurrentXP;
            }
        }

        public event Action<int> OnTierReached;
        public event Action<int, bool> OnRewardClaimed;
        public event Action<string, int> OnMissionProgress;
        public event Action OnPremiumUnlocked;

        [Inject]
        public BattlePassService(
            ISaveService saveService,
            IInventoryService inventoryService,
            ICurrencyService currencyService,
            SeasonConfigSO currentSeason)
        {
            _saveService = saveService;
            _inventoryService = inventoryService;
            _currencyService = currencyService;
            _currentSeason = currentSeason;
            
            LoadData();
            CheckSeasonReset();
            RefreshMissions();
        }

        public void AddXP(int amount)
        {
            _data.CurrentXP += amount;
            
            // Check for tier ups
            while (_data.CurrentTier < _currentSeason.MaxTier)
            {
                int requiredXP = _currentSeason.GetTotalXPForTier(_data.CurrentTier + 1);
                if (_data.CurrentXP >= requiredXP)
                {
                    _data.CurrentTier++;
                    OnTierReached?.Invoke(_data.CurrentTier);
                }
                else break;
            }
            
            SaveData();
        }

        public bool CanClaimReward(int tier, bool premium)
        {
            if (tier > CurrentTier) return false;
            if (premium && !HasPremium) return false;
            
            var claimed = premium ? _data.ClaimedPremiumTiers : _data.ClaimedFreeTiers;
            return !claimed.Contains(tier);
        }

        public bool TryClaimReward(int tier, bool premium)
        {
            if (!CanClaimReward(tier, premium)) return false;

            var tierConfig = _currentSeason.GetTier(tier);
            var reward = premium ? tierConfig.PremiumReward : tierConfig.FreeReward;
            
            GrantReward(reward);

            var claimed = premium ? _data.ClaimedPremiumTiers : _data.ClaimedFreeTiers;
            claimed.Add(tier);
            
            SaveData();
            OnRewardClaimed?.Invoke(tier, premium);
            return true;
        }

        public List<int> GetClaimableTiers(bool premium)
        {
            var claimed = premium ? _data.ClaimedPremiumTiers : _data.ClaimedFreeTiers;
            var claimable = new List<int>();
            
            for (int i = 1; i <= CurrentTier; i++)
            {
                if (!claimed.Contains(i))
                {
                    if (!premium || HasPremium)
                        claimable.Add(i);
                }
            }
            
            return claimable;
        }

        public List<MissionProgress> GetActiveMissions()
        {
            var missions = new List<MissionProgress>();
            
            AddMissionsToList(missions, _currentSeason.DailyMissions, _data.DailyMissionProgress);
            AddMissionsToList(missions, _currentSeason.WeeklyMissions, _data.WeeklyMissionProgress);
            AddMissionsToList(missions, _currentSeason.SeasonMissions, _data.SeasonMissionProgress);
            
            return missions;
        }

        private void AddMissionsToList(List<MissionProgress> list, List<PassMission> configs, Dictionary<string, MissionSaveData> progress)
        {
            foreach (var config in configs)
            {
                progress.TryGetValue(config.MissionId, out var save);
                list.Add(new MissionProgress
                {
                    MissionId = config.MissionId,
                    Description = config.Description,
                    Type = config.Type,
                    CurrentValue = save?.Progress ?? 0,
                    TargetValue = config.TargetValue,
                    XPReward = config.XPReward,
                    IsComplete = (save?.Progress ?? 0) >= config.TargetValue,
                    IsClaimed = save?.Claimed ?? false,
                    RefreshType = config.RefreshType
                });
            }
        }

        public void UpdateMissionProgress(MissionType type, int amount)
        {
            UpdateMissionList(_currentSeason.DailyMissions, _data.DailyMissionProgress, type, amount);
            UpdateMissionList(_currentSeason.WeeklyMissions, _data.WeeklyMissionProgress, type, amount);
            UpdateMissionList(_currentSeason.SeasonMissions, _data.SeasonMissionProgress, type, amount);
            SaveData();
        }

        private void UpdateMissionList(List<PassMission> configs, Dictionary<string, MissionSaveData> progress, MissionType type, int amount)
        {
            foreach (var config in configs.Where(m => m.Type == type))
            {
                if (!progress.ContainsKey(config.MissionId))
                    progress[config.MissionId] = new MissionSaveData();

                var save = progress[config.MissionId];
                if (!save.Claimed)
                {
                    save.Progress = Mathf.Min(save.Progress + amount, config.TargetValue);
                    OnMissionProgress?.Invoke(config.MissionId, save.Progress);
                }
            }
        }

        public bool TryClaimMission(string missionId)
        {
            var mission = FindMission(missionId, out var progressDict);
            if (mission == null) return false;

            if (!progressDict.TryGetValue(missionId, out var save))
                return false;

            if (save.Progress < mission.TargetValue || save.Claimed)
                return false;

            save.Claimed = true;
            AddXP(mission.XPReward);
            SaveData();
            return true;
        }

        private PassMission FindMission(string missionId, out Dictionary<string, MissionSaveData> progressDict)
        {
            var daily = _currentSeason.DailyMissions.Find(m => m.MissionId == missionId);
            if (daily != null) { progressDict = _data.DailyMissionProgress; return daily; }

            var weekly = _currentSeason.WeeklyMissions.Find(m => m.MissionId == missionId);
            if (weekly != null) { progressDict = _data.WeeklyMissionProgress; return weekly; }

            var season = _currentSeason.SeasonMissions.Find(m => m.MissionId == missionId);
            if (season != null) { progressDict = _data.SeasonMissionProgress; return season; }

            progressDict = null;
            return null;
        }

        public void UnlockPremium()
        {
            _data.HasPremium = true;
            SaveData();
            OnPremiumUnlocked?.Invoke();
        }

        public bool TryPurchaseXP(int amount)
        {
            if (!_currentSeason.AllowXPPurchase) return false;

            int batches = Mathf.CeilToInt((float)amount / _currentSeason.XPPerPurchase);
            int cost = batches * _currentSeason.XPPurchaseCost;

            if (!_currencyService.CanAfford(CurrencyType.Premium, cost))
                return false;

            _currencyService.Spend(CurrencyType.Premium, cost);
            AddXP(batches * _currentSeason.XPPerPurchase);
            return true;
        }

        private void CheckSeasonReset()
        {
            if (_data.SeasonId != _currentSeason.SeasonId)
            {
                // New season, reset progress
                _data = new BattlePassSaveData { SeasonId = _currentSeason.SeasonId };
                SaveData();
            }
        }

        private void RefreshMissions()
        {
            var now = DateTime.UtcNow;
            
            // Daily reset
            if (now.Date > _data.LastDailyReset.Date)
            {
                _data.DailyMissionProgress.Clear();
                _data.LastDailyReset = now;
            }
            
            // Weekly reset (Monday)
            var lastMonday = now.AddDays(-(int)now.DayOfWeek + 1);
            if (_data.LastWeeklyReset < lastMonday)
            {
                _data.WeeklyMissionProgress.Clear();
                _data.LastWeeklyReset = now;
            }
            
            SaveData();
        }

        private void GrantReward(PassReward reward)
        {
            switch (reward.Type)
            {
                case RewardType.Gold:
                    _currencyService.Add(CurrencyType.Gold, reward.Amount);
                    break;
                case RewardType.PremiumCurrency:
                    _currencyService.Add(CurrencyType.Premium, reward.Amount);
                    break;
                case RewardType.EvoMaterial:
                    _currencyService.Add(CurrencyType.EvoMaterial, reward.Amount);
                    break;
                case RewardType.Monster:
                    _inventoryService.AddMonster(reward.ItemId);
                    break;
                // Handle other types...
            }
        }

        private void LoadData()
        {
            _data = _saveService.Load<BattlePassSaveData>("battlepass") ?? new BattlePassSaveData();
        }

        private void SaveData()
        {
            _saveService.Save("battlepass", _data);
        }
    }

    [Serializable]
    public class BattlePassSaveData
    {
        public string SeasonId;
        public int CurrentTier = 0;
        public int CurrentXP = 0;
        public bool HasPremium = false;
        public List<int> ClaimedFreeTiers = new();
        public List<int> ClaimedPremiumTiers = new();
        public Dictionary<string, MissionSaveData> DailyMissionProgress = new();
        public Dictionary<string, MissionSaveData> WeeklyMissionProgress = new();
        public Dictionary<string, MissionSaveData> SeasonMissionProgress = new();
        public DateTime LastDailyReset;
        public DateTime LastWeeklyReset;
    }

    [Serializable]
    public class MissionSaveData
    {
        public int Progress;
        public bool Claimed;
    }
}
```

**Global Balance & Remote Config**

- Read base XP and reward multipliers from `GlobalBalanceConfigSO` (e.g., `BattlePassBaseXpMult`, `BattlePassRewardValueMult`).
- Allow remote config keys (e.g., `bp_xp_mult`, `bp_reward_mult`) to override per-season values for softlaunch experiments.

**Logging & Analytics**

- Use `ILoggingService` (category `Monetization`) to log purchase attempts, successes, and failures.
- Emit analytics events for Battle Pass funnel steps (view pass, purchase attempt, purchase success, reward claimed) so they appear in the debug panel.

---

### ✅ Definition of Done
- [ ] IBattlePassService interface defined
- [ ] BattlePassService implementation complete
- [ ] XP progression and tier-up working
- [ ] Free and premium reward claiming
- [ ] Mission progress tracking
- [ ] Daily/weekly mission reset
- [ ] Premium unlock integration
- [ ] Season reset on new season
- [ ] Registered in GameLifetimeScope

---

<!-- Continue in next batch: #86, #87, #88 -->

---

## Issue #86: [Shop] Create ShopOfferConfigSO

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `monetization`, `priority-critical`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Create ScriptableObject for shop offers including IAP products, bundles, and timed deals.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Shop/ShopOfferConfigSO.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.Shop
{
    public enum OfferType
    {
        IAP,            // Real money purchase
        PremiumCurrency,// Buy with gems
        SoftCurrency,   // Buy with gold
        Ad              // Watch ad for reward
    }

    public enum OfferCategory
    {
        Featured,
        Currency,
        Bundle,
        Daily,
        Weekly,
        Starter,
        VIP
    }

    [Serializable]
    public class ShopReward
    {
        public RewardType Type;
        public string ItemId;
        public int Amount;
        public Sprite Icon;
    }

    [CreateAssetMenu(menuName = "IdleMonsterTD/Shop/Offer Config")]
    public class ShopOfferConfigSO : ScriptableObject
    {
        [Header("Basic Info")]
        public string OfferId;
        public string OfferName;
        [TextArea] public string Description;
        public Sprite BannerImage;
        public OfferType Type;
        public OfferCategory Category;
        
        [Header("Pricing")]
        public string IAPProductId;         // For real money
        public int PriceCents = 99;         // Fallback display price
        public int PremiumCurrencyCost;     // For gem purchases
        public int SoftCurrencyCost;        // For gold purchases
        
        [Header("Contents")]
        public List<ShopReward> Rewards;
        
        [Header("Value Display")]
        public int OriginalValue;           // "Worth $X" display
        public float DiscountPercent;       // "50% OFF" banner
        public bool ShowBestValue;
        
        [Header("Availability")]
        public bool IsOneTime = false;      // Can only buy once ever
        public int PurchaseLimit = -1;      // -1 = unlimited
        public bool RequireAccountLevel;
        public int RequiredAccountLevel;
        
        [Header("Timed Offer")]
        public bool IsTimed;
        public DateTime StartTime;
        public DateTime EndTime;
        public int DurationHours;           // For daily/refresh offers
        
        [Header("Refresh")]
        public bool RefreshDaily;
        public bool RefreshWeekly;
        public int RefreshCostPremium;      // Manual refresh cost

        public bool IsAvailable(int accountLevel, int purchaseCount)
        {
            if (RequireAccountLevel && accountLevel < RequiredAccountLevel)
                return false;
            
            if (IsOneTime && purchaseCount > 0)
                return false;
            
            if (PurchaseLimit > 0 && purchaseCount >= PurchaseLimit)
                return false;
            
            if (IsTimed)
            {
                var now = DateTime.UtcNow;
                if (now < StartTime || now > EndTime)
                    return false;
            }
            
            return true;
        }

        public string GetDisplayPrice()
        {
            return Type switch
            {
                OfferType.IAP => $"${PriceCents / 100f:F2}",
                OfferType.PremiumCurrency => $"{PremiumCurrencyCost} 💎",
                OfferType.SoftCurrency => $"{SoftCurrencyCost} 🪙",
                OfferType.Ad => "Watch Ad",
                _ => "???"
            };
        }
    }
}
```

**File:** `Assets/_Project/Scripts/Gameplay/Shop/ShopCatalogSO.cs`

```csharp
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.Shop
{
    [CreateAssetMenu(menuName = "IdleMonsterTD/Shop/Catalog")]
    public class ShopCatalogSO : ScriptableObject
    {
        public List<ShopOfferConfigSO> AllOffers;

        public List<ShopOfferConfigSO> GetByCategory(OfferCategory category)
        {
            return AllOffers.Where(o => o.Category == category).ToList();
        }

        public ShopOfferConfigSO GetById(string offerId)
        {
            return AllOffers.Find(o => o.OfferId == offerId);
        }

        public List<ShopOfferConfigSO> GetAvailableOffers(int accountLevel, System.Func<string, int> getPurchaseCount)
        {
            return AllOffers.Where(o => o.IsAvailable(accountLevel, getPurchaseCount(o.OfferId))).ToList();
        }
    }
}
```

**Global Balance & Remote Config**

- Base price/value multipliers are defined in `GlobalBalanceConfigSO` (e.g., `ShopBasePriceMult`, `ShopValueMult`).
- Per-offer overrides come from remote config keys to support live experiments without client updates.

---

### ✅ Definition of Done
- [ ] ShopOfferConfigSO created
- [ ] ShopCatalogSO for organization
- [ ] Support for IAP, gem, gold, ad offers
- [ ] Timed offer system
- [ ] Purchase limits working
- [ ] Create starter pack, gem packs, daily deals
- [ ] Assets in `Assets/_Project/ScriptableObjects/Shop/`

---

---

## Issue #87: [Shop] Integrate Unity IAP

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `monetization`, `priority-critical`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Integrate Unity IAP for real money purchases on Android/iOS.

---

### 📋 Requirements

- Unity IAP package installation
- Product catalog configuration
- Purchase flow handling
- Restore purchases
- Platform-specific setup
 - Shop offer prices, discount factors, and value multipliers must be tunable via `GlobalBalanceConfigSO` and remote config.
 - Shop impressions, clicks, and purchases must send analytics events visible in the debug panel.

---

### 📝 Implementation

**Step 1: Install Unity IAP**
```
Window → Package Manager → In-App Purchasing → Install
```

**Step 2: Configure Products**

**File:** `Assets/_Project/Scripts/Core/Services/IAPProductCatalog.cs`

```csharp
using UnityEngine.Purchasing;

namespace IdleMonsterTD.Core.Services
{
    public static class IAPProductCatalog
    {
        // Consumables
        public const string GEMS_100 = "com.yourcompany.idlemonstertd.gems100";
        public const string GEMS_500 = "com.yourcompany.idlemonstertd.gems500";
        public const string GEMS_1200 = "com.yourcompany.idlemonstertd.gems1200";
        public const string GEMS_2500 = "com.yourcompany.idlemonstertd.gems2500";
        public const string GEMS_6500 = "com.yourcompany.idlemonstertd.gems6500";
        
        // Non-Consumables
        public const string STARTER_PACK = "com.yourcompany.idlemonstertd.starterpack";
        public const string BATTLE_PASS = "com.yourcompany.idlemonstertd.battlepass";
        public const string REMOVE_ADS = "com.yourcompany.idlemonstertd.removeads";
        
        // Subscriptions
        public const string VIP_MONTHLY = "com.yourcompany.idlemonstertd.vipmonthly";

        public static ProductType GetProductType(string productId)
        {
            return productId switch
            {
                STARTER_PACK or REMOVE_ADS => ProductType.NonConsumable,
                VIP_MONTHLY => ProductType.Subscription,
                _ => ProductType.Consumable
            };
        }
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/IIAPService.cs`

```csharp
using System;
using System.Threading.Tasks;

namespace IdleMonsterTD.Core.Services
{
    public enum PurchaseResult
    {
        Success,
        UserCancelled,
        PaymentDeclined,
        ProductUnavailable,
        NetworkError,
        ValidationFailed
    }

    public interface IIAPService
    {
        bool IsInitialized { get; }
        string GetLocalizedPrice(string productId);
        Task<PurchaseResult> Purchase(string productId);
        Task RestorePurchases();
        bool HasPurchased(string productId);
        
        event Action<string, PurchaseResult> OnPurchaseComplete;
        event Action OnRestoreComplete;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/IAPService.cs`

```csharp
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;
using VContainer;

namespace IdleMonsterTD.Core.Services
{
    public class IAPService : IIAPService, IDetailedStoreListener
    {
        private IStoreController _storeController;
        private IExtensionProvider _extensionProvider;
        private TaskCompletionSource<PurchaseResult> _purchaseTcs;
        
        private readonly ISaveService _saveService;
        private readonly IReceiptValidator _receiptValidator;
        private readonly ICurrencyService _currencyService;
        private readonly ShopCatalogSO _shopCatalog;

        public bool IsInitialized => _storeController != null;

        public event Action<string, PurchaseResult> OnPurchaseComplete;
        public event Action OnRestoreComplete;

        [Inject]
        public IAPService(
            ISaveService saveService,
            IReceiptValidator receiptValidator,
            ICurrencyService currencyService,
            ShopCatalogSO shopCatalog)
        {
            _saveService = saveService;
            _receiptValidator = receiptValidator;
            _currencyService = currencyService;
            _shopCatalog = shopCatalog;
            
            InitializePurchasing();
        }

        private void InitializePurchasing()
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

            // Add all products
            builder.AddProduct(IAPProductCatalog.GEMS_100, ProductType.Consumable);
            builder.AddProduct(IAPProductCatalog.GEMS_500, ProductType.Consumable);
            builder.AddProduct(IAPProductCatalog.GEMS_1200, ProductType.Consumable);
            builder.AddProduct(IAPProductCatalog.GEMS_2500, ProductType.Consumable);
            builder.AddProduct(IAPProductCatalog.GEMS_6500, ProductType.Consumable);
            builder.AddProduct(IAPProductCatalog.STARTER_PACK, ProductType.NonConsumable);
            builder.AddProduct(IAPProductCatalog.BATTLE_PASS, ProductType.NonConsumable);
            builder.AddProduct(IAPProductCatalog.REMOVE_ADS, ProductType.NonConsumable);
            builder.AddProduct(IAPProductCatalog.VIP_MONTHLY, ProductType.Subscription);

            UnityPurchasing.Initialize(this, builder);
        }

        public string GetLocalizedPrice(string productId)
        {
            if (!IsInitialized) return "---";
            
            var product = _storeController.products.WithID(productId);
            return product?.metadata.localizedPriceString ?? "---";
        }

        public async Task<PurchaseResult> Purchase(string productId)
        {
            if (!IsInitialized)
                return PurchaseResult.ProductUnavailable;

            var product = _storeController.products.WithID(productId);
            if (product == null || !product.availableToPurchase)
                return PurchaseResult.ProductUnavailable;

            _purchaseTcs = new TaskCompletionSource<PurchaseResult>();
            _storeController.InitiatePurchase(product);
            
            return await _purchaseTcs.Task;
        }

        public async Task RestorePurchases()
        {
#if UNITY_IOS
            _extensionProvider.GetExtension<IAppleExtensions>().RestoreTransactions((success, error) =>
            {
                Debug.Log($"Restore result: {success}, {error}");
                OnRestoreComplete?.Invoke();
            });
#elif UNITY_ANDROID
            _extensionProvider.GetExtension<IGooglePlayStoreExtensions>().RestoreTransactions((success, error) =>
            {
                Debug.Log($"Restore result: {success}, {error}");
                OnRestoreComplete?.Invoke();
            });
#endif
            await Task.CompletedTask;
        }

        public bool HasPurchased(string productId)
        {
            var purchases = _saveService.Load<PurchaseHistory>("purchases") ?? new PurchaseHistory();
            return purchases.PurchasedProducts.Contains(productId);
        }

        // IDetailedStoreListener
        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _storeController = controller;
            _extensionProvider = extensions;
            Debug.Log("[IAP] Initialized successfully");
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.LogError($"[IAP] Init failed: {error}");
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            Debug.LogError($"[IAP] Init failed: {error} - {message}");
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
        {
            var productId = args.purchasedProduct.definition.id;
            Debug.Log($"[IAP] Processing purchase: {productId}");

            // Validate receipt
            _ = ValidateAndGrant(args);
            
            return PurchaseProcessingResult.Complete;
        }

        private async Task ValidateAndGrant(PurchaseEventArgs args)
        {
            var productId = args.purchasedProduct.definition.id;
            var receipt = args.purchasedProduct.receipt;

            bool isValid = await _receiptValidator.ValidateReceipt(receipt);
            
            if (isValid)
            {
                GrantPurchase(productId);
                RecordPurchase(productId);
                _purchaseTcs?.TrySetResult(PurchaseResult.Success);
                OnPurchaseComplete?.Invoke(productId, PurchaseResult.Success);
            }
            else
            {
                _purchaseTcs?.TrySetResult(PurchaseResult.ValidationFailed);
                OnPurchaseComplete?.Invoke(productId, PurchaseResult.ValidationFailed);
            }
        }

        private void GrantPurchase(string productId)
        {
            var offer = _shopCatalog.AllOffers.Find(o => o.IAPProductId == productId);
            if (offer == null) return;

            foreach (var reward in offer.Rewards)
            {
                switch (reward.Type)
                {
                    case RewardType.PremiumCurrency:
                        _currencyService.Add(CurrencyType.Premium, reward.Amount);
                        break;
                    case RewardType.Gold:
                        _currencyService.Add(CurrencyType.Gold, reward.Amount);
                        break;
                    // Handle other reward types...
                }
            }
        }

        private void RecordPurchase(string productId)
        {
            var purchases = _saveService.Load<PurchaseHistory>("purchases") ?? new PurchaseHistory();
            purchases.PurchasedProducts.Add(productId);
            purchases.PurchaseCount++;
            _saveService.Save("purchases", purchases);
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
        {
            var result = reason switch
            {
                PurchaseFailureReason.UserCancelled => PurchaseResult.UserCancelled,
                PurchaseFailureReason.PaymentDeclined => PurchaseResult.PaymentDeclined,
                _ => PurchaseResult.NetworkError
            };
            
            _purchaseTcs?.TrySetResult(result);
            OnPurchaseComplete?.Invoke(product.definition.id, result);
        }

        public void OnPurchaseFailed(Product product, PurchaseFailureDescription description)
        {
            OnPurchaseFailed(product, description.reason);
        }
    }

    [Serializable]
    public class PurchaseHistory
    {
        public HashSet<string> PurchasedProducts = new();
        public int PurchaseCount;
    }
}
```

**Logging & Analytics**

- Use `ILoggingService` (category `Shop`) to log load errors, invalid offers, and unexpected responses.
- Emit analytics events for:
    - Offer impressions
    - Offer clicks
    - Purchase attempts and outcomes

---

### ✅ Definition of Done
- [ ] Unity IAP package installed
- [ ] Product catalog defined
- [ ] IIAPService interface defined
- [ ] IAPService implementation complete
- [ ] Purchase flow working
- [ ] Restore purchases implemented
- [ ] Registered in GameLifetimeScope
- [ ] Test with sandbox accounts

---

---

## Issue #88: [Shop] Implement receipt validation

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `backend`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Server-side receipt validation via Supabase Edge Function to prevent fraud.

---

### 📝 Implementation

**Supabase Edge Function:** `supabase/functions/validate-receipt/index.ts`

```typescript
import { serve } from "https://deno.land/std@0.168.0/http/server.ts"

const GOOGLE_VERIFY_URL = "https://androidpublisher.googleapis.com/androidpublisher/v3";
const APPLE_VERIFY_URL = "https://buy.itunes.apple.com/verifyReceipt";
const APPLE_SANDBOX_URL = "https://sandbox.itunes.apple.com/verifyReceipt";

serve(async (req) => {
  try {
    const { receipt, platform, productId, userId } = await req.json();

    let isValid = false;

    if (platform === "android") {
      isValid = await validateGoogleReceipt(receipt, productId);
    } else if (platform === "ios") {
      isValid = await validateAppleReceipt(receipt);
    }

    // Log purchase for analytics
    if (isValid) {
      await logPurchase(userId, productId, platform);
    }

    return new Response(
      JSON.stringify({ valid: isValid }),
      { headers: { "Content-Type": "application/json" } }
    );
  } catch (error) {
    return new Response(
      JSON.stringify({ valid: false, error: error.message }),
      { status: 400, headers: { "Content-Type": "application/json" } }
    );
  }
});

async function validateGoogleReceipt(receipt: string, productId: string): Promise<boolean> {
  // Parse Unity IAP receipt format
  const parsed = JSON.parse(receipt);
  const googleReceipt = JSON.parse(parsed.Payload.json);
  
  const packageName = googleReceipt.packageName;
  const purchaseToken = googleReceipt.purchaseToken;
  
  // Use Google Play Developer API
  const accessToken = await getGoogleAccessToken();
  
  const response = await fetch(
    `${GOOGLE_VERIFY_URL}/applications/${packageName}/purchases/products/${productId}/tokens/${purchaseToken}`,
    {
      headers: { Authorization: `Bearer ${accessToken}` }
    }
  );
  
  if (!response.ok) return false;
  
  const data = await response.json();
  return data.purchaseState === 0; // 0 = purchased
}

async function validateAppleReceipt(receipt: string): Promise<boolean> {
  const parsed = JSON.parse(receipt);
  const appleReceipt = parsed.Payload;
  
  // Try production first, then sandbox
  let response = await fetch(APPLE_VERIFY_URL, {
    method: "POST",
    body: JSON.stringify({
      "receipt-data": appleReceipt,
      "password": Deno.env.get("APPLE_SHARED_SECRET")
    })
  });
  
  let data = await response.json();
  
  // Status 21007 = sandbox receipt sent to production
  if (data.status === 21007) {
    response = await fetch(APPLE_SANDBOX_URL, {
      method: "POST",
      body: JSON.stringify({
        "receipt-data": appleReceipt,
        "password": Deno.env.get("APPLE_SHARED_SECRET")
      })
    });
    data = await response.json();
  }
  
  return data.status === 0;
}

async function getGoogleAccessToken(): Promise<string> {
  // Use service account credentials
  const credentials = JSON.parse(Deno.env.get("GOOGLE_SERVICE_ACCOUNT") || "{}");
  // Implement JWT signing and token exchange
  // ... (use google-auth-library or manual JWT)
  return "access_token";
}

async function logPurchase(userId: string, productId: string, platform: string) {
  const supabaseUrl = Deno.env.get("SUPABASE_URL");
  const supabaseKey = Deno.env.get("SUPABASE_SERVICE_ROLE_KEY");
  
  await fetch(`${supabaseUrl}/rest/v1/purchases`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "apikey": supabaseKey,
      "Authorization": `Bearer ${supabaseKey}`
    },
    body: JSON.stringify({
      user_id: userId,
      product_id: productId,
      platform: platform,
      created_at: new Date().toISOString()
    })
  });
}
```

**Unity Client:** `Assets/_Project/Scripts/Core/Services/ReceiptValidator.cs`

```csharp
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using VContainer;
using Newtonsoft.Json;

namespace IdleMonsterTD.Core.Services
{
    public interface IReceiptValidator
    {
        Task<bool> ValidateReceipt(string receipt);
    }

    public class ReceiptValidator : IReceiptValidator
    {
        private readonly SupabaseConfig _config;
        private readonly IAuthService _authService;

        [Inject]
        public ReceiptValidator(SupabaseConfig config, IAuthService authService)
        {
            _config = config;
            _authService = authService;
        }

        public async Task<bool> ValidateReceipt(string receipt)
        {
            try
            {
                string platform = Application.platform == RuntimePlatform.IPhonePlayer ? "ios" : "android";
                
                var payload = JsonConvert.SerializeObject(new
                {
                    receipt = receipt,
                    platform = platform,
                    userId = _authService.PlayerId
                });

                using var request = new UnityWebRequest($"{_config.ProjectUrl}/functions/v1/validate-receipt", "POST");
                request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(payload));
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("Authorization", $"Bearer {_authService.AccessToken}");

                await request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    var response = JsonConvert.DeserializeObject<ValidationResponse>(request.downloadHandler.text);
                    return response?.Valid ?? false;
                }

                // If validation server unavailable, allow purchase (with logging)
                Debug.LogWarning("[Receipt] Validation server unavailable, allowing purchase");
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError($"[Receipt] Validation error: {e.Message}");
                return true; // Fail open for better UX
            }
        }

        private class ValidationResponse
        {
            [JsonProperty("valid")] public bool Valid;
        }
    }
}
```

**Logging & Analytics**

- Use `ILoggingService` (category `Backend`) to log validation requests and failures (excluding raw receipt contents).
- Emit analytics events on successful/failed validations to help detect fraud patterns; expose these in dashboards and the debug panel.

---

### ✅ Definition of Done
- [ ] Supabase Edge Function deployed
- [ ] Google Play validation working
- [ ] Apple App Store validation working
- [ ] IReceiptValidator interface defined
- [ ] ReceiptValidator implementation
- [ ] Purchase logging to database
- [ ] Fail-open behavior for server issues
- [ ] Test with test purchases

---

<!-- Continue in next batch: #92, #93, #95 -->

---

## Issue #92: [VIP] Implement VIP subscription

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `monetization`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Implement monthly VIP subscription with ongoing benefits.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Services/IVIPService.cs`

```csharp
using System;

namespace IdleMonsterTD.Core.Services
{
    public interface IVIPService
    {
        bool IsVIP { get; }
        DateTime ExpirationDate { get; }
        int DaysRemaining { get; }
        
        // Benefits
        float AFKBonusPercent { get; }
        int DailyGemsReward { get; }
        bool HasAdFreeExperience { get; }
        float GoldBonusPercent { get; }
        
        void ActivateVIP(DateTime expiration);
        void ClaimDailyReward();
        bool CanClaimDailyReward();
        
        event Action OnVIPActivated;
        event Action OnVIPExpired;
        event Action OnDailyRewardClaimed;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/VIPService.cs`

```csharp
using System;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Services
{
    public class VIPService : IVIPService
    {
        private readonly ISaveService _saveService;
        private readonly ICurrencyService _currencyService;
        
        private VIPSaveData _data;

        // VIP Benefits (configurable via RemoteConfig later)
        public float AFKBonusPercent => IsVIP ? 50f : 0f;
        public int DailyGemsReward => IsVIP ? 50 : 0;
        public bool HasAdFreeExperience => IsVIP;
        public float GoldBonusPercent => IsVIP ? 20f : 0f;

        public bool IsVIP => _data.ExpirationDate > DateTime.UtcNow;
        public DateTime ExpirationDate => _data.ExpirationDate;
        public int DaysRemaining => IsVIP ? Mathf.Max(0, (int)(ExpirationDate - DateTime.UtcNow).TotalDays) : 0;

        public event Action OnVIPActivated;
        public event Action OnVIPExpired;
        public event Action OnDailyRewardClaimed;

        [Inject]
        public VIPService(ISaveService saveService, ICurrencyService currencyService)
        {
            _saveService = saveService;
            _currencyService = currencyService;
            LoadData();
            CheckExpiration();
        }

        public void ActivateVIP(DateTime expiration)
        {
            bool wasVIP = IsVIP;
            _data.ExpirationDate = expiration;
            SaveData();
            
            if (!wasVIP)
                OnVIPActivated?.Invoke();
        }

        public bool CanClaimDailyReward()
        {
            if (!IsVIP) return false;
            return _data.LastDailyClaimDate.Date < DateTime.UtcNow.Date;
        }

        public void ClaimDailyReward()
        {
            if (!CanClaimDailyReward()) return;

            _currencyService.Add(CurrencyType.Premium, DailyGemsReward);
            _data.LastDailyClaimDate = DateTime.UtcNow;
            SaveData();
            
            OnDailyRewardClaimed?.Invoke();
        }

        private void CheckExpiration()
        {
            if (_data.WasVIP && !IsVIP)
            {
                _data.WasVIP = false;
                SaveData();
                OnVIPExpired?.Invoke();
            }
            else if (IsVIP)
            {
                _data.WasVIP = true;
                SaveData();
            }
        }

        private void LoadData()
        {
            _data = _saveService.Load<VIPSaveData>("vip") ?? new VIPSaveData();
        }

        private void SaveData()
        {
            _saveService.Save("vip", _data);
        }
    }

    [Serializable]
    public class VIPSaveData
    {
        public DateTime ExpirationDate;
        public DateTime LastDailyClaimDate;
        public bool WasVIP;
    }
}
```

**Integration with IAP:**

```csharp
// In IAPService.GrantPurchase, add:
if (productId == IAPProductCatalog.VIP_MONTHLY)
{
    var expiration = DateTime.UtcNow.AddDays(30);
    _vipService.ActivateVIP(expiration);
}
```

---

### ✅ Definition of Done
- [ ] IVIPService interface defined
- [ ] VIPService implementation complete
- [ ] VIP benefits applied (AFK, gems, gold, ads)
- [ ] Daily gem claim working
- [ ] Expiration handling
- [ ] Integration with IAP purchase
- [ ] VIP badge display in UI
- [ ] Registered in GameLifetimeScope

**Global Balance Integration**

- Read VIP perk multipliers and thresholds from `GlobalBalanceConfigSO` (e.g., `VipBasePerkMults`, `VipThresholds`) instead of hard-coding them in `VIPService`.
- Allow remote config keys to temporarily modify perks or pricing in specific regions/segments for experiments.

**Logging & Analytics**

- Use `ILoggingService` (category `VIP`) for subscription flow errors and state changes (activation, expiration, renewal).
- Emit analytics events for VIP start, renewal, cancellation, and benefit usage so they surface in the analytics/debug panel.

---

---

## Issue #93: [Ads] Integrate Unity Ads / AdMob

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `monetization`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Integrate rewarded video ads for optional player benefits.

---

### 📋 Requirements

- Rewarded video ads only (no forced ads)
- Double AFK rewards option
- Bonus summon currency
- Ad cooldowns
- VIP ad-free experience
 - Reward multipliers and cooldowns for ad-based rewards must be configurable via `GlobalBalanceConfigSO` and remote config.
 - Ad impressions, views, completions, and failures must emit analytics events visible in the analytics/debug panel.

---

### 📝 Implementation

**Step 1: Install Unity Ads**
```
Window → Package Manager → Advertisement → Install
```

**File:** `Assets/_Project/Scripts/Core/Services/IAdService.cs`

```csharp
using System;
using System.Threading.Tasks;

namespace IdleMonsterTD.Core.Services
{
    public enum AdPlacement
    {
        DoubleAFKReward,
        BonusSummonCurrency,
        ExtraEventEntry,
        ReviveMonster
    }

    public interface IAdService
    {
        bool IsAdReady(AdPlacement placement);
        bool CanShowAd(AdPlacement placement); // Respects cooldown & VIP
        int GetCooldownRemaining(AdPlacement placement);
        Task<bool> ShowRewardedAd(AdPlacement placement);
        
        event Action<AdPlacement> OnAdCompleted;
        event Action<AdPlacement> OnAdFailed;
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Services/AdService.cs`

```csharp
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Advertisements;
using VContainer;

namespace IdleMonsterTD.Core.Services
{
    public class AdService : IAdService, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private const string GAME_ID_ANDROID = "YOUR_ANDROID_GAME_ID";
        private const string GAME_ID_IOS = "YOUR_IOS_GAME_ID";
        private const string REWARDED_PLACEMENT = "Rewarded_Android"; // or Rewarded_iOS

        private readonly IVIPService _vipService;
        private readonly ISaveService _saveService;
        
        private Dictionary<AdPlacement, int> _cooldowns = new()
        {
            { AdPlacement.DoubleAFKReward, 300 },      // 5 min
            { AdPlacement.BonusSummonCurrency, 600 },  // 10 min
            { AdPlacement.ExtraEventEntry, 1800 },    // 30 min
            { AdPlacement.ReviveMonster, 0 }          // No cooldown
        };
        
        private Dictionary<AdPlacement, DateTime> _lastAdTime = new();
        private TaskCompletionSource<bool> _adTcs;
        private AdPlacement _currentPlacement;
        private bool _adLoaded;

        public event Action<AdPlacement> OnAdCompleted;
        public event Action<AdPlacement> OnAdFailed;

        [Inject]
        public AdService(IVIPService vipService, ISaveService saveService)
        {
            _vipService = vipService;
            _saveService = saveService;
            
            LoadCooldowns();
            InitializeAds();
        }

        private void InitializeAds()
        {
#if UNITY_ANDROID
            string gameId = GAME_ID_ANDROID;
#elif UNITY_IOS
            string gameId = GAME_ID_IOS;
#else
            string gameId = GAME_ID_ANDROID;
#endif
            Advertisement.Initialize(gameId, testMode: Debug.isDebugBuild, this);
        }

        public bool IsAdReady(AdPlacement placement)
        {
            return _adLoaded;
        }

        public bool CanShowAd(AdPlacement placement)
        {
            // VIP users don't see ads
            if (_vipService.IsVIP && placement != AdPlacement.BonusSummonCurrency)
                return false;

            // Check cooldown
            if (_lastAdTime.TryGetValue(placement, out var lastTime))
            {
                int cooldown = _cooldowns[placement];
                if ((DateTime.UtcNow - lastTime).TotalSeconds < cooldown)
                    return false;
            }

            return IsAdReady(placement);
        }

        public int GetCooldownRemaining(AdPlacement placement)
        {
            if (!_lastAdTime.TryGetValue(placement, out var lastTime))
                return 0;

            int cooldown = _cooldowns[placement];
            int elapsed = (int)(DateTime.UtcNow - lastTime).TotalSeconds;
            return Mathf.Max(0, cooldown - elapsed);
        }

        public async Task<bool> ShowRewardedAd(AdPlacement placement)
        {
            if (!CanShowAd(placement))
                return false;

            _currentPlacement = placement;
            _adTcs = new TaskCompletionSource<bool>();

            Advertisement.Show(REWARDED_PLACEMENT, this);

            bool success = await _adTcs.Task;

            if (success)
            {
                _lastAdTime[placement] = DateTime.UtcNow;
                SaveCooldowns();
            }

            return success;
        }

        // IUnityAdsLoadListener
        public void OnUnityAdsAdLoaded(string placementId)
        {
            _adLoaded = true;
            Debug.Log($"[Ads] Loaded: {placementId}");
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            _adLoaded = false;
            Debug.LogWarning($"[Ads] Load failed: {error} - {message}");
            
            // Retry after delay
            _ = RetryLoadAd();
        }

        // IUnityAdsShowListener
        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState state)
        {
            bool success = state == UnityAdsShowCompletionState.COMPLETED;
            
            if (success)
                OnAdCompleted?.Invoke(_currentPlacement);
            else
                OnAdFailed?.Invoke(_currentPlacement);

            _adTcs?.TrySetResult(success);
            
            // Preload next ad
            Advertisement.Load(REWARDED_PLACEMENT, this);
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Debug.LogError($"[Ads] Show failed: {error} - {message}");
            OnAdFailed?.Invoke(_currentPlacement);
            _adTcs?.TrySetResult(false);
        }

        public void OnUnityAdsShowStart(string placementId) { }
        public void OnUnityAdsShowClick(string placementId) { }

        // IUnityAdsInitializationListener (implicit)
        public void OnInitializationComplete()
        {
            Debug.Log("[Ads] Initialized");
            Advertisement.Load(REWARDED_PLACEMENT, this);
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.LogError($"[Ads] Init failed: {error} - {message}");
        }

        private async Task RetryLoadAd()
        {
            await Task.Delay(30000); // 30 seconds
            Advertisement.Load(REWARDED_PLACEMENT, this);
        }

        private void LoadCooldowns()
        {
            var data = _saveService.Load<AdCooldownData>("ads");
            if (data != null)
                _lastAdTime = data.LastAdTimes ?? new();
        }

        private void SaveCooldowns()
        {
            _saveService.Save("ads", new AdCooldownData { LastAdTimes = _lastAdTime });
        }
    }

    [Serializable]
    public class AdCooldownData
    {
        public Dictionary<AdPlacement, DateTime> LastAdTimes;
    }
}
```

**Global Balance & Remote Config**

- Use `GlobalBalanceConfigSO` for baseline reward multipliers and cooldowns for ad placements (e.g., `AdAfkBoostMult`, `AdCooldownSeconds`).
- Allow remote config keys per placement (e.g., `ad_afk_mult`, `ad_endless_reward_mult`) for softlaunch tuning without client updates.

**Logging & Analytics**

- Use `ILoggingService` (category `Ads`) to log load/show failures, missing placements, and SDK initialization issues.
- Emit analytics events for:
    - Ad request
    - Ad show start
    - Ad completed / skipped / failed
    - Reward granted (with placement ID and reward values) so they appear in the debug panel.

---

### ✅ Definition of Done
- [ ] Unity Ads package installed
- [ ] IAdService interface defined
- [ ] AdService implementation complete
- [ ] Rewarded ad placements configured
- [ ] Cooldown system working
- [ ] VIP ad-free respected
- [ ] Ad completion rewards granted
- [ ] Registered in GameLifetimeScope
- [ ] Test on device

---

---

## Issue #95: [Events] Create EventConfigSO

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `live-ops`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Create ScriptableObject for limited-time events with custom content and rewards.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Gameplay/Events/EventConfigSO.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;

namespace IdleMonsterTD.Gameplay.Events
{
    public enum EventType
    {
        Challenge,      // Special battle conditions
        Collection,     // Collect event currency
        Leaderboard,    // Compete for ranking
        Login,          // Daily login bonuses
        Special         // Holiday/seasonal
    }

    [Serializable]
    public class EventMilestone
    {
        public int PointsRequired;
        public List<ShopReward> Rewards;
        public string Description;
    }

    [Serializable]
    public class EventShopItem
    {
        public string ItemId;
        public List<ShopReward> Rewards;
        public int EventCurrencyCost;
        public int PurchaseLimit;
        public Sprite Icon;
    }

    [CreateAssetMenu(menuName = "IdleMonsterTD/Events/Event Config")]
    public class EventConfigSO : ScriptableObject
    {
        [Header("Event Info")]
        public string EventId;
        public string EventName;
        [TextArea] public string Description;
        public EventType Type;
        public Sprite BannerImage;
        public Color ThemeColor;
        
        [Header("Schedule")]
        public DateTime StartDate;
        public DateTime EndDate;
        
        [Header("Event Currency")]
        public string EventCurrencyId;
        public string EventCurrencyName;
        public Sprite EventCurrencyIcon;
        
        [Header("Point Sources")]
        public int PointsPerWaveComplete = 10;
        public int PointsPerBossKill = 50;
        public int PointsPerSummon = 5;
        public float BonusPointMultiplier = 1f; // For featured content
        
        [Header("Milestones")]
        public List<EventMilestone> Milestones;
        
        [Header("Event Shop")]
        public List<EventShopItem> ShopItems;
        
        [Header("Leaderboard (if applicable)")]
        public bool HasLeaderboard;
        public List<EventMilestone> LeaderboardRewards; // By rank tier
        
        [Header("Special Rules")]
        public List<string> FeaturedMonsterIds;     // Bonus points
        public List<string> BannedMonsterIds;       // Cannot use
        public float DifficultyModifier = 1f;

        public bool IsActive()
        {
            var now = DateTime.UtcNow;
            return now >= StartDate && now <= EndDate;
        }

        public TimeSpan TimeRemaining()
        {
            return EndDate - DateTime.UtcNow;
        }

        public EventMilestone GetNextMilestone(int currentPoints)
        {
            foreach (var milestone in Milestones)
            {
                if (currentPoints < milestone.PointsRequired)
                    return milestone;
            }
            return null;
        }

        public List<EventMilestone> GetClaimableMilestones(int currentPoints, HashSet<int> claimed)
        {
            var claimable = new List<EventMilestone>();
            foreach (var milestone in Milestones)
            {
                if (currentPoints >= milestone.PointsRequired && !claimed.Contains(milestone.PointsRequired))
                    claimable.Add(milestone);
            }
            return claimable;
        }
    }
}
```

**Global Balance & Remote Config**

- Use `GlobalBalanceConfigSO` for baseline event difficulty and reward multipliers (e.g., `EventBaseDifficultyMult`, `EventRewardMult`).
- Allow remote config keys (e.g., `event_x_reward_mult`, `event_y_cost_mult`) to adjust specific events during softlaunch and live-ops.

**Logging & Analytics**

- Use `ILoggingService` (category `Events`) to log event scheduling issues and runtime anomalies.
- Emit analytics events for event entry, progression milestones, and completion so designers can inspect them in the analytics/debug panel.

**File:** `Assets/_Project/Scripts/Core/Services/IEventService.cs`

```csharp
using System;
using System.Collections.Generic;

namespace IdleMonsterTD.Core.Services
{
    public interface IEventService
    {
        EventConfigSO CurrentEvent { get; }
        bool HasActiveEvent { get; }
        int CurrentEventPoints { get; }
        int EventCurrency { get; }
        
        void AddEventPoints(int amount);
        void AddEventCurrency(int amount);
        bool TryClaimMilestone(int pointsRequired);
        bool TryPurchaseShopItem(string itemId);
        List<EventMilestone> GetClaimableMilestones();
        
        event Action<int> OnPointsChanged;
        event Action<int> OnCurrencyChanged;
        event Action<EventMilestone> OnMilestoneClaimed;
        event Action OnEventStarted;
        event Action OnEventEnded;
    }
}
```

---

### ✅ Definition of Done
- [ ] EventConfigSO created with all fields
- [ ] Event types defined (Challenge, Collection, etc.)
- [ ] Milestone system implemented
- [ ] Event shop system
- [ ] IEventService interface defined
- [ ] Point earning rules configured
- [ ] Create sample "Double XP Weekend" event
- [ ] Assets in `Assets/_Project/ScriptableObjects/Events/`

---

<!-- Continue in next batch: #100-104, #106, #107 -->

---

## Issue #100: [Analytics] Implement funnel tracking

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `analytics`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Track player progression through key game funnels to identify drop-off points.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Analytics/IAnalyticsService.cs`

```csharp
using System.Collections.Generic;

namespace IdleMonsterTD.Core.Analytics
{
    public interface IAnalyticsService
    {
        void TrackEvent(string eventName, Dictionary<string, object> parameters = null);
        void TrackFunnelStep(string funnelName, int step, string stepName);
        void TrackScreenView(string screenName);
        void SetUserProperty(string property, string value);
        void SetUserId(string userId);
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Analytics/AnalyticsService.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using VContainer;
using Newtonsoft.Json;

namespace IdleMonsterTD.Core.Analytics
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly SupabaseConfig _config;
        private readonly IAuthService _authService;
        
        private string _sessionId;
        private DateTime _sessionStart;
        private Dictionary<string, object> _userProperties = new();

        [Inject]
        public AnalyticsService(SupabaseConfig config, IAuthService authService)
        {
            _config = config;
            _authService = authService;
            
            _sessionId = Guid.NewGuid().ToString();
            _sessionStart = DateTime.UtcNow;
            
            TrackEvent("session_start");
        }

        public void TrackEvent(string eventName, Dictionary<string, object> parameters = null)
        {
            var eventData = new Dictionary<string, object>
            {
                { "event_type", eventName },
                { "session_id", _sessionId },
                { "timestamp", DateTime.UtcNow.ToString("O") },
                { "session_duration", (DateTime.UtcNow - _sessionStart).TotalSeconds }
            };

            if (parameters != null)
            {
                foreach (var kvp in parameters)
                    eventData[kvp.Key] = kvp.Value;
            }

            SendToBackend(eventData);
            
            // Also send to Unity Analytics if available
#if UNITY_ANALYTICS
            UnityEngine.Analytics.Analytics.CustomEvent(eventName, parameters);
#endif
        }

        public void TrackFunnelStep(string funnelName, int step, string stepName)
        {
            TrackEvent("funnel_step", new Dictionary<string, object>
            {
                { "funnel_name", funnelName },
                { "step", step },
                { "step_name", stepName }
            });
        }

        public void TrackScreenView(string screenName)
        {
            TrackEvent("screen_view", new Dictionary<string, object>
            {
                { "screen_name", screenName }
            });
        }

        public void SetUserProperty(string property, string value)
        {
            _userProperties[property] = value;
        }

        public void SetUserId(string userId)
        {
            _userProperties["user_id"] = userId;
        }

        private async void SendToBackend(Dictionary<string, object> eventData)
        {
            try
            {
                // Add user properties
                eventData["player_id"] = _authService.PlayerId;
                foreach (var kvp in _userProperties)
                    eventData[$"user_{kvp.Key}"] = kvp.Value;

                string json = JsonConvert.SerializeObject(new
                {
                    player_id = _authService.PlayerId,
                    event_type = eventData["event_type"],
                    event_data = eventData,
                    session_id = _sessionId,
                    created_at = DateTime.UtcNow
                });

                using var request = new UnityWebRequest($"{_config.RestUrl}/analytics_events", "POST");
                request.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("apikey", _config.AnonKey);

                await request.SendWebRequest();
            }
            catch (Exception e)
            {
                Debug.LogWarning($"[Analytics] Failed to send: {e.Message}");
            }
        }
    }
}
```

**In-Game Analytics Debug Panel**

- Create an overlay UI (e.g., `AnalyticsDebugPanel` prefab) with:
    - Scrollable list of last N analytics events (name, key parameters, timestamp).
    - Section for current A/B experiments and assigned variants.
    - Section for key remote config keys and the effective value for this user, especially those that override `GlobalBalanceConfigSO`.
- Wire the panel to:
    - Subscribe to the analytics event stream and append entries live.
    - Query the A/B test service and remote config snapshot when the panel is opened.
- Access:
    - In editor: via a keyboard shortcut (e.g., F9) or menu item.
    - On device: via a hidden long-press gesture in a debug-only corner (dev/QA builds only).
- Guard the panel behind compile-time flags or build config so it never appears in production builds.

**Cross-System Integration**

- Ensure all Phase 1 and 2 systems emit analytics events through the shared analytics service so their events appear automatically in this panel.
- Use `ILoggingService` (category `Analytics`) to log internal errors in the panel itself.

**Funnel Definitions:**

```csharp
public static class Funnels
{
    public const string FTUE = "ftue";           // First Time User Experience
    public const string FIRST_SUMMON = "first_summon";
    public const string FIRST_PURCHASE = "first_purchase";
    public const string BATTLE_PASS_PURCHASE = "battle_pass_purchase";
    
    // FTUE Steps
    public static void TrackFTUE(IAnalyticsService analytics, int step, string name)
    {
        analytics.TrackFunnelStep(FTUE, step, name);
    }
    // Step 1: tutorial_start
    // Step 2: first_wave_complete
    // Step 3: first_monster_placed
    // Step 4: tutorial_complete
    // Step 5: first_upgrade
    // Step 6: shop_opened
}
```

---

### ✅ Definition of Done
- [ ] IAnalyticsService interface defined
- [ ] AnalyticsService implementation
- [ ] Events logged to Supabase
- [ ] Session tracking working
- [ ] Funnel step tracking
- [ ] FTUE funnel instrumented
- [ ] First purchase funnel instrumented
- [ ] Registered in GameLifetimeScope

---

---

## Issue #101: [Analytics] Implement retention cohorts

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `analytics`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Track D1, D7, D30 retention metrics and player cohorts.

---

### 📝 Implementation

**Database Schema Addition:**

```sql
-- Add to players table
ALTER TABLE players ADD COLUMN install_date TIMESTAMPTZ DEFAULT NOW();
ALTER TABLE players ADD COLUMN last_active_date TIMESTAMPTZ DEFAULT NOW();
ALTER TABLE players ADD COLUMN days_played INTEGER DEFAULT 0;
ALTER TABLE players ADD COLUMN cohort_week TEXT; -- e.g., "2024-W01"

-- Retention tracking table
CREATE TABLE retention_events (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    player_id UUID REFERENCES players(id),
    install_date DATE NOT NULL,
    event_date DATE NOT NULL,
    day_number INTEGER NOT NULL, -- 0, 1, 7, 30, etc.
    session_count INTEGER DEFAULT 1,
    UNIQUE(player_id, event_date)
);

CREATE INDEX idx_retention_install ON retention_events(install_date);
CREATE INDEX idx_retention_day ON retention_events(day_number);
```

**File:** `Assets/_Project/Scripts/Core/Analytics/RetentionTracker.cs`

```csharp
using System;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Analytics
{
    public class RetentionTracker
    {
        private readonly IAnalyticsService _analytics;
        private readonly ISaveService _saveService;
        
        private RetentionData _data;

        [Inject]
        public RetentionTracker(IAnalyticsService analytics, ISaveService saveService)
        {
            _analytics = analytics;
            _saveService = saveService;
            
            LoadData();
            TrackSession();
        }

        private void LoadData()
        {
            _data = _saveService.Load<RetentionData>("retention") ?? new RetentionData
            {
                InstallDate = DateTime.UtcNow.Date,
                CohortWeek = GetCohortWeek(DateTime.UtcNow)
            };
        }

        private void TrackSession()
        {
            var today = DateTime.UtcNow.Date;
            int daysSinceInstall = (int)(today - _data.InstallDate).TotalDays;

            // Track if this is first session of the day
            if (_data.LastActiveDate.Date < today)
            {
                _data.DaysPlayed++;
                _data.LastActiveDate = DateTime.UtcNow;
                _saveService.Save("retention", _data);

                // Send retention event
                _analytics.TrackEvent("retention_day", new()
                {
                    { "day_number", daysSinceInstall },
                    { "install_date", _data.InstallDate.ToString("yyyy-MM-dd") },
                    { "cohort_week", _data.CohortWeek },
                    { "total_days_played", _data.DaysPlayed }
                });

                // Track milestone days
                if (daysSinceInstall == 1)
                    _analytics.TrackEvent("retention_d1");
                else if (daysSinceInstall == 7)
                    _analytics.TrackEvent("retention_d7");
                else if (daysSinceInstall == 30)
                    _analytics.TrackEvent("retention_d30");
            }

            _analytics.SetUserProperty("days_since_install", daysSinceInstall.ToString());
            _analytics.SetUserProperty("cohort_week", _data.CohortWeek);
        }

        private string GetCohortWeek(DateTime date)
        {
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int week = cal.GetWeekOfYear(date, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return $"{date.Year}-W{week:D2}";
        }
    }

    [Serializable]
    public class RetentionData
    {
        public DateTime InstallDate;
        public DateTime LastActiveDate;
        public int DaysPlayed;
        public string CohortWeek;
    }
}
```

**Debug Panel Integration**

- Surface high-level retention cohort summaries (e.g., sample counts, D1/D7 rates for the current build) in a compact section of the analytics debug panel for dev/QA builds.

---

### ✅ Definition of Done
- [ ] Retention database schema created
- [ ] RetentionTracker implementation
- [ ] D1/D7/D30 milestone events
- [ ] Cohort assignment working
- [ ] Days since install tracked
- [ ] User properties set for segmentation
- [ ] Supabase dashboard query for retention

---

---

## Issue #102: [Analytics] Implement revenue metrics

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `analytics`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Track revenue events and calculate ARPU/ARPPU metrics.

---

### 📝 Implementation

**Database Schema:**

```sql
CREATE TABLE revenue_events (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    player_id UUID REFERENCES players(id),
    product_id TEXT NOT NULL,
    revenue_cents INTEGER NOT NULL,
    currency TEXT DEFAULT 'USD',
    platform TEXT,
    transaction_id TEXT UNIQUE,
    created_at TIMESTAMPTZ DEFAULT NOW()
);

CREATE INDEX idx_revenue_player ON revenue_events(player_id);
CREATE INDEX idx_revenue_date ON revenue_events(created_at);

-- Aggregation view
CREATE VIEW revenue_metrics AS
SELECT 
    DATE_TRUNC('day', created_at) as date,
    COUNT(DISTINCT player_id) as paying_users,
    SUM(revenue_cents) / 100.0 as total_revenue,
    AVG(revenue_cents) / 100.0 as avg_transaction
FROM revenue_events
GROUP BY DATE_TRUNC('day', created_at);
```

**File:** `Assets/_Project/Scripts/Core/Analytics/RevenueTracker.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Analytics
{
    public class RevenueTracker
    {
        private readonly IAnalyticsService _analytics;
        private readonly ISaveService _saveService;
        
        private RevenueData _data;

        [Inject]
        public RevenueTracker(IAnalyticsService analytics, ISaveService saveService)
        {
            _analytics = analytics;
            _saveService = saveService;
            LoadData();
        }

        public void TrackPurchase(string productId, int priceCents, string transactionId)
        {
            _data.TotalSpent += priceCents;
            _data.PurchaseCount++;
            _data.LastPurchaseDate = DateTime.UtcNow;
            
            if (_data.PurchaseCount == 1)
                _data.FirstPurchaseDate = DateTime.UtcNow;
            
            _saveService.Save("revenue", _data);

            _analytics.TrackEvent("purchase", new Dictionary<string, object>
            {
                { "product_id", productId },
                { "revenue_cents", priceCents },
                { "transaction_id", transactionId },
                { "total_spent_cents", _data.TotalSpent },
                { "purchase_count", _data.PurchaseCount },
                { "is_first_purchase", _data.PurchaseCount == 1 }
            });

            // Update user properties
            _analytics.SetUserProperty("is_payer", "true");
            _analytics.SetUserProperty("total_spent", _data.TotalSpent.ToString());
            _analytics.SetUserProperty("whale_tier", GetWhaleTier(_data.TotalSpent));
        }

        public void TrackAdRevenue(string placement, float estimatedRevenue)
        {
            _analytics.TrackEvent("ad_revenue", new Dictionary<string, object>
            {
                { "placement", placement },
                { "estimated_revenue", estimatedRevenue }
            });
        }

        private string GetWhaleTier(int totalCents)
        {
            return totalCents switch
            {
                < 500 => "minnow",        // < $5
                < 2500 => "dolphin",      // $5-$25
                < 10000 => "whale",       // $25-$100
                _ => "mega_whale"         // $100+
            };
        }

        private void LoadData()
        {
            _data = _saveService.Load<RevenueData>("revenue") ?? new RevenueData();
        }
    }

    [Serializable]
    public class RevenueData
    {
        public int TotalSpent;
        public int PurchaseCount;
        public DateTime FirstPurchaseDate;
        public DateTime LastPurchaseDate;
    }
}
```

**Debug Panel Integration**

- Add a revenue-focused subsection to the analytics debug panel to display:
    - Test-session ARPDAU/ARPPU estimates.
    - Counts of payers vs. non-payers for QA sessions.
    - Last N monetization events (shop purchases, battle pass, VIP, events).

---

### ✅ Definition of Done
- [ ] Revenue database schema created
- [ ] RevenueTracker implementation
- [ ] Purchase events tracked
- [ ] Transaction ID for deduplication
- [ ] Whale tier segmentation
- [ ] Ad revenue estimation
- [ ] ARPU query in Supabase

---

---

## Issue #103: [A/B] Implement A/B test framework

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `analytics`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Simple A/B testing framework for game balancing and monetization experiments.

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Analytics/IABTestService.cs`

```csharp
using System;
using System.Collections.Generic;

namespace IdleMonsterTD.Core.Analytics
{
    public interface IABTestService
    {
        string GetVariant(string experimentId);
        T GetValue<T>(string experimentId, string key, T defaultValue);
        bool IsInExperiment(string experimentId);
        void TrackExposure(string experimentId);
        void TrackConversion(string experimentId, string goal);
    }
}
```

**File:** `Assets/_Project/Scripts/Core/Analytics/ABTestService.cs`

```csharp
using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Analytics
{
    public class ABTestService : IABTestService
    {
        private readonly IAnalyticsService _analytics;
        private readonly ISaveService _saveService;
        private readonly IRemoteConfigService _remoteConfig;

        private Dictionary<string, string> _assignedVariants = new();
        private HashSet<string> _exposedExperiments = new();

        [Inject]
        public ABTestService(
            IAnalyticsService analytics,
            ISaveService saveService,
            IRemoteConfigService remoteConfig)
        {
            _analytics = analytics;
            _saveService = saveService;
            _remoteConfig = remoteConfig;
            
            LoadAssignments();
        }

        public string GetVariant(string experimentId)
        {
            // Check if already assigned
            if (_assignedVariants.TryGetValue(experimentId, out var variant))
                return variant;

            // Get experiment config
            var config = _remoteConfig.GetExperiment(experimentId);
            if (config == null || !config.IsActive)
                return "control";

            // Assign variant based on user hash
            variant = AssignVariant(experimentId, config);
            _assignedVariants[experimentId] = variant;
            SaveAssignments();

            return variant;
        }

        public T GetValue<T>(string experimentId, string key, T defaultValue)
        {
            var variant = GetVariant(experimentId);
            var config = _remoteConfig.GetExperiment(experimentId);
            
            if (config?.Variants.TryGetValue(variant, out var values) == true)
            {
                if (values.TryGetValue(key, out var value))
                {
                    try
                    {
                        return (T)Convert.ChangeType(value, typeof(T));
                    }
                    catch { }
                }
            }

            return defaultValue;
        }

        public bool IsInExperiment(string experimentId)
        {
            var config = _remoteConfig.GetExperiment(experimentId);
            return config?.IsActive == true;
        }

        public void TrackExposure(string experimentId)
        {
            if (_exposedExperiments.Contains(experimentId))
                return;

            _exposedExperiments.Add(experimentId);
            var variant = GetVariant(experimentId);

            _analytics.TrackEvent("experiment_exposure", new Dictionary<string, object>
            {
                { "experiment_id", experimentId },
                { "variant", variant }
            });
        }

        public void TrackConversion(string experimentId, string goal)
        {
            var variant = GetVariant(experimentId);

            _analytics.TrackEvent("experiment_conversion", new Dictionary<string, object>
            {
                { "experiment_id", experimentId },
                { "variant", variant },
                { "goal", goal }
            });
        }

        private string AssignVariant(string experimentId, ExperimentConfig config)
        {
            // Deterministic assignment based on user ID hash
            string seed = $"{_analytics.UserId}_{experimentId}";
            int hash = seed.GetHashCode();
            float normalized = (hash & 0x7FFFFFFF) / (float)int.MaxValue;

            float cumulative = 0f;
            foreach (var (variant, weight) in config.VariantWeights)
            {
                cumulative += weight;
                if (normalized <= cumulative)
                    return variant;
            }

            return "control";
        }

        private void LoadAssignments()
        {
            var data = _saveService.Load<ABTestData>("abtests");
            if (data != null)
                _assignedVariants = data.Assignments ?? new();
        }

        private void SaveAssignments()
        {
            _saveService.Save("abtests", new ABTestData { Assignments = _assignedVariants });
        }
    }

    [Serializable]
    public class ABTestData
    {
        public Dictionary<string, string> Assignments;
    }

    public class ExperimentConfig
    {
        public string ExperimentId;
        public bool IsActive;
        public Dictionary<string, float> VariantWeights; // variant -> % allocation
        public Dictionary<string, Dictionary<string, object>> Variants; // variant -> key/values
    }
}
```

**Debug Panel Integration**

- Expose current experiment assignments and key variant parameters to the analytics debug panel so designers and QA can verify they are in the expected test buckets and see effective values.

---

### ✅ Definition of Done
- [ ] IABTestService interface defined
- [ ] ABTestService implementation
- [ ] Deterministic variant assignment
- [ ] Exposure tracking
- [ ] Conversion tracking
- [ ] Remote config integration
- [ ] Create sample experiment config

---

---

## Issue #104: [QA] Phase 2 monetization testing

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `testing`, `priority-critical`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Comprehensive testing of all monetization systems before release.

---

### 📋 Test Checklist

**Battle Pass:**
- [ ] XP gains from all sources
- [ ] Tier progression correct
- [ ] Free rewards claimable
- [ ] Premium unlock works via IAP
- [ ] Premium rewards claimable after unlock
- [ ] Season reset clears progress
- [ ] Daily/weekly mission reset

**Shop/IAP:**
- [ ] All products display correct prices
- [ ] Purchase flow completes
- [ ] Rewards granted after purchase
- [ ] Receipt validation passes
- [ ] Restore purchases works
- [ ] One-time purchases tracked
- [ ] Purchase limits enforced

**VIP:**
- [ ] VIP activates on subscription
- [ ] Daily gems claimable
- [ ] AFK bonus applies
- [ ] Gold bonus applies
- [ ] Ad-free experience works
- [ ] Expiration handled

**Ads:**
- [ ] Rewarded ads load
- [ ] Rewards granted on completion
- [ ] Cooldowns enforced
- [ ] VIP skips ads
- [ ] Ad failures handled gracefully

**Events:**
- [ ] Event activates on schedule
- [ ] Points earned correctly
- [ ] Milestones claimable
- [ ] Event shop purchases work
- [ ] Event ends correctly

**Analytics:**
- [ ] All events logged to Supabase
- [ ] Funnels tracked correctly
- [ ] Retention events fire
- [ ] Revenue tracked
- [ ] A/B variants assigned

**Debug Panel Usage:**

- During QA, use the in-game analytics debug panel to:
    - Confirm funnel events for Battle Pass, shop, VIP, ads, and events.
    - Check that remote config overrides and A/B assignments are displayed correctly.
    - Spot obvious anomalies (missing events, incorrect parameters).

---

### ✅ Definition of Done
- [ ] All checklist items pass
- [ ] No payment-related bugs
- [ ] Analytics data verified in dashboard
- [ ] Test on both Android and iOS
- [ ] 1-hour play session stable

---

---

## Issue #106: [Perf] Pre-launch optimization

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `optimization`, `priority-high`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Final performance pass before release.

---

### 📋 Optimization Targets

**Frame Rate:**
- [ ] Stable 60 FPS on mid-range devices
- [ ] Minimum 30 FPS on low-end devices
- [ ] No frame drops >50ms

**Memory:**
- [ ] Peak memory <500MB
- [ ] No memory leaks in 1-hour session
- [ ] Texture memory optimized

**Loading:**
- [ ] Cold start <5 seconds
- [ ] Scene transitions <2 seconds
- [ ] No loading hitches

**Battery:**
- [ ] Reasonable drain during gameplay
- [ ] Idle mode reduces drain

---

### 📝 Optimization Checklist

```
1. Object Pooling
   - [ ] All projectiles pooled
   - [ ] All enemies pooled
   - [ ] All VFX pooled

2. Draw Calls
   - [ ] Sprite atlasing complete
   - [ ] Material batching
   - [ ] UI batching

3. Code Optimization
   - [ ] No Update() allocations
   - [ ] Cached component references
   - [ ] Async operations non-blocking

4. Asset Optimization
   - [ ] Texture compression (ASTC/ETC2)
   - [ ] Audio compression (Vorbis)
   - [ ] Mesh LODs if applicable
```

---

### ✅ Definition of Done
- [ ] All targets met
- [ ] Profiler captures clean
- [ ] Test on target low-end device
- [ ] Build size <100MB

---

---

## Issue #107: [Docs] Phase 2 completion documentation

**Assignee:** @MaxeLBerger  
**Labels:** `phase-2`, `documentation`, `priority-medium`  
**Milestone:** Phase 2 - Monetization

---

### 🎯 Goal
Document all Phase 2 systems for maintenance and live ops.

---

### 📝 Documentation Deliverables

**1. MONETIZATION_GUIDE.md:**
- Battle Pass configuration
- Shop offer setup
- IAP product catalog
- VIP benefits breakdown
- Ad placement guide

**2. ANALYTICS_INTEGRATION.md:**
- Event schema
- Funnel definitions
- Retention tracking
- Revenue metrics
- A/B test setup

**3. LIVE_OPS_GUIDE.md:**
- Event creation workflow
- Banner configuration
- Remote config usage
- A/B experiment setup

**4. Update ARCHITECTURE.md:**
- Phase 2 services
- Analytics pipeline
- Monetization flow

---

### ✅ Definition of Done
- [ ] MONETIZATION_GUIDE.md created
- [ ] ANALYTICS_INTEGRATION.md created
- [ ] LIVE_OPS_GUIDE.md created
- [ ] ARCHITECTURE.md updated
- [ ] All APIs documented
- [ ] Phase 3 handoff notes prepared

---

<!-- End of Phase 2 -->
