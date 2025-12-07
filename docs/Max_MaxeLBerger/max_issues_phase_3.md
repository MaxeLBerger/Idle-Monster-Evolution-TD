# Phase 3 Issues - Release & Post-Launch
**Assignee:** @MaxeLBerger  
**Total Issues:** 10 (Issues #108-122)

---

## Issue #108: [Build] Prepare release builds

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `release`, `priority-critical`  
**Milestone:** Phase 3 - Release

---

### 🎯 Goal
Prepare production-ready builds for Android and iOS submission.

---

### 📋 Android Build Checklist

```
1. Project Settings
   - [ ] Company/Product name correct
   - [ ] Bundle ID: com.yourcompany.idlemonstertd
   - [ ] Version: 1.0.0 (1)
   - [ ] Minimum API Level: 24 (Android 7.0)
   - [ ] Target API Level: 34 (Android 14)
   - [ ] Scripting Backend: IL2CPP
   - [ ] Target Architectures: ARMv7 + ARM64

2. Signing
   - [ ] Keystore created and secured
   - [ ] Key alias configured
   - [ ] Passwords stored securely (not in repo)

3. Build Settings
   - [ ] Development Build: OFF
   - [ ] Script Debugging: OFF
   - [ ] Build App Bundle (AAB)
   - [ ] Split APKs by target architecture

4. Proguard/R8
   - [ ] Custom rules for Unity
   - [ ] Keep rules for reflection
```

---

### 📋 iOS Build Checklist

```
1. Project Settings
   - [ ] Bundle Identifier correct
   - [ ] Version: 1.0.0 (1)
   - [ ] Signing Team ID
   - [ ] Provisioning Profile (Distribution)
   - [ ] Target iOS Version: 14.0+
   - [ ] Architecture: ARM64

2. Capabilities
   - [ ] Push Notifications (if used)
   - [ ] In-App Purchase
   - [ ] Game Center (if used)

3. Info.plist
   - [ ] ATT tracking description
   - [ ] Camera/Photo usage (if applicable)

4. Xcode Archive
   - [ ] Bitcode: OFF
   - [ ] DSYM uploaded to crash service
```

---

### 📝 Build Script

**File:** `BuildTools/build_release.sh`

```bash
#!/bin/bash
# Usage: ./build_release.sh [android|ios] [version]

PLATFORM=$1
VERSION=${2:-"1.0.0"}
BUILD_NUM=$(date +%Y%m%d%H)

UNITY="/Applications/Unity/Hub/Editor/2022.3.xx/Unity.app/Contents/MacOS/Unity"
PROJECT_PATH="$(pwd)"
BUILD_PATH="$PROJECT_PATH/Builds"

echo "Building $PLATFORM version $VERSION ($BUILD_NUM)"

if [ "$PLATFORM" = "android" ]; then
    $UNITY -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.BuildAndroid \
        -buildTarget Android \
        -logFile "$BUILD_PATH/android_build.log" \
        -version "$VERSION" \
        -buildNumber "$BUILD_NUM"
elif [ "$PLATFORM" = "ios" ]; then
    $UNITY -quit -batchmode \
        -projectPath "$PROJECT_PATH" \
        -executeMethod BuildScript.BuildiOS \
        -buildTarget iOS \
        -logFile "$BUILD_PATH/ios_build.log" \
        -version "$VERSION" \
        -buildNumber "$BUILD_NUM"
fi

echo "Build complete. Check $BUILD_PATH"
```

**File:** `Assets/Editor/BuildScript.cs`

```csharp
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System;
using System.Linq;

public class BuildScript
{
    private static string[] GetScenes()
    {
        return EditorBuildSettings.scenes
            .Where(s => s.enabled)
            .Select(s => s.path)
            .ToArray();
    }

    public static void BuildAndroid()
    {
        string version = GetArg("-version") ?? "1.0.0";
        string buildNum = GetArg("-buildNumber") ?? "1";

        PlayerSettings.bundleVersion = version;
        PlayerSettings.Android.bundleVersionCode = int.Parse(buildNum);

        var buildOptions = new BuildPlayerOptions
        {
            scenes = GetScenes(),
            locationPathName = $"Builds/Android/IdleMonsterTD_{version}.aab",
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        EditorUserBuildSettings.buildAppBundle = true;

        var report = BuildPipeline.BuildPlayer(buildOptions);
        if (report.summary.result != BuildResult.Succeeded)
            throw new Exception($"Build failed: {report.summary.totalErrors} errors");

        Debug.Log($"Android build successful: {report.summary.outputPath}");
    }

    public static void BuildiOS()
    {
        string version = GetArg("-version") ?? "1.0.0";
        string buildNum = GetArg("-buildNumber") ?? "1";

        PlayerSettings.bundleVersion = version;
        PlayerSettings.iOS.buildNumber = buildNum;

        var buildOptions = new BuildPlayerOptions
        {
            scenes = GetScenes(),
            locationPathName = "Builds/iOS",
            target = BuildTarget.iOS,
            options = BuildOptions.None
        };

        var report = BuildPipeline.BuildPlayer(buildOptions);
        if (report.summary.result != BuildResult.Succeeded)
            throw new Exception($"Build failed: {report.summary.totalErrors} errors");

        Debug.Log($"iOS Xcode project generated: {report.summary.outputPath}");
    }

    private static string GetArg(string name)
    {
        var args = Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length - 1; i++)
        {
            if (args[i] == name)
                return args[i + 1];
        }
        return null;
    }
}
```

---

### ✅ Definition of Done
- [ ] Android AAB builds successfully
- [ ] iOS Xcode project exports
- [ ] Both signed with production certs
- [ ] Build script automated
- [ ] DSYMs/symbols archived
- [ ] Builds tested on real devices

---

---

## Issue #109: [Store] Prepare store listings

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `release`, `priority-high`  
**Milestone:** Phase 3 - Release

---

### 🎯 Goal
Complete store listings for Google Play and Apple App Store.

---

### 📋 Assets Required

**Screenshots (per platform):**
- [ ] 1242x2688 (iPhone 14 Pro Max)
- [ ] 2048x2732 (iPad Pro 12.9")
- [ ] 1080x1920 (Phone Portrait) - Play Store
- [ ] 1920x1080 (Tablet Landscape) - Play Store

**Screenshots Content:**
1. Title screen with monster showcase
2. Gameplay with tower defense action
3. Gacha/summon system
4. Evolution/fusion screen
5. Hub/base building
6. Battle Pass/Rewards
7. Special event/boss fight
8. Multiplayer/social (if applicable)

**Videos:**
- [ ] 15-30 second gameplay preview
- [ ] App preview video (iOS)

**Graphics:**
- [ ] App icon (1024x1024 layered)
- [ ] Feature graphic (1024x500) - Play Store
- [ ] TV Banner (1280x720) - Play Store (if applicable)

---

### 📝 Store Copy

**Short Description (80 chars):**
```
Summon epic monsters, evolve them, and defend in this idle tower defense RPG!
```

**Full Description:**
```
🎮 SUMMON. EVOLVE. DEFEND.

Build your ultimate monster army in Idle Monster Evolution TD - the perfect blend of gacha collection, evolution mechanics, and strategic tower defense!

🐲 COLLECT & EVOLVE
• Summon over 100 unique monsters from the gacha
• Evolve your favorites through fusion and upgrades
• Unlock powerful abilities and alternate forms

🏰 STRATEGIC DEFENSE
• Place monsters on the battlefield to defend your base
• Master element types and synergies
• Tackle endless waves for ultimate rewards

📈 IDLE PROGRESSION
• Earn resources even while away
• Unlock permanent upgrades in your hub
• Research powerful bonuses

🎁 DAILY REWARDS
• Complete daily missions for gems
• Climb the Battle Pass for exclusive rewards
• Participate in limited-time events

⚔️ COMPETITIVE
• Challenge other players in PvP leagues
• Join guilds and tackle raid bosses
• Climb global leaderboards

Download now and start your monster evolution journey!
```

**Keywords (100 chars):**
```
idle game, tower defense, gacha, monster, evolution, RPG, TD, collect, summon, fantasy
```

---

### ✅ Definition of Done
- [ ] All screenshots captured
- [ ] App preview video created
- [ ] Store descriptions localized (EN, DE, ES, FR, PT, JA, KO, ZH)
- [ ] Age ratings completed
- [ ] Privacy policy URL live
- [ ] Content rating questionnaire done
- [ ] App icon finalized

---

---

## Issue #110: [Legal] Privacy policy and GDPR compliance

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `legal`, `priority-critical`  
**Milestone:** Phase 3 - Release

---

### 🎯 Goal
Ensure legal compliance for data collection and privacy regulations.

---

### 📋 Requirements

**Privacy Policy Must Cover:**
- [ ] What data is collected (device ID, gameplay, purchases)
- [ ] How data is used (analytics, personalization)
- [ ] Third-party services (Supabase, Unity Analytics, Ad networks)
- [ ] Data retention period
- [ ] User rights (access, deletion, portability)
- [ ] Contact information
- [ ] Children's privacy (COPPA if applicable)

**GDPR Requirements:**
- [ ] Consent banner for EU users
- [ ] Opt-out mechanism for analytics
- [ ] Data deletion request flow
- [ ] Cookie policy (web services)

**CCPA Requirements:**
- [ ] "Do Not Sell" option for California users
- [ ] Data disclosure on request

---

### 📝 Implementation

**File:** `Assets/_Project/Scripts/Core/Privacy/ConsentManager.cs`

```csharp
using System;
using UnityEngine;
using VContainer;

namespace IdleMonsterTD.Core.Privacy
{
    public class ConsentManager
    {
        private const string CONSENT_KEY = "privacy_consent";
        private const string CONSENT_DATE_KEY = "privacy_consent_date";

        public bool HasConsent => PlayerPrefs.GetInt(CONSENT_KEY, 0) == 1;
        public bool AnalyticsEnabled { get; private set; } = true;
        public bool PersonalizedAdsEnabled { get; private set; } = true;

        public event Action OnConsentUpdated;

        public void Initialize()
        {
            if (!HasConsent)
            {
                // Show consent dialog on first launch
                ShowConsentDialog();
            }
            else
            {
                LoadPreferences();
            }
        }

        public void SetConsent(bool analytics, bool personalizedAds)
        {
            AnalyticsEnabled = analytics;
            PersonalizedAdsEnabled = personalizedAds;

            PlayerPrefs.SetInt(CONSENT_KEY, 1);
            PlayerPrefs.SetString(CONSENT_DATE_KEY, DateTime.UtcNow.ToString("O"));
            PlayerPrefs.SetInt("consent_analytics", analytics ? 1 : 0);
            PlayerPrefs.SetInt("consent_personalized_ads", personalizedAds ? 1 : 0);
            PlayerPrefs.Save();

            OnConsentUpdated?.Invoke();
        }

        public void RevokeConsent()
        {
            PlayerPrefs.DeleteKey(CONSENT_KEY);
            PlayerPrefs.DeleteKey(CONSENT_DATE_KEY);
            PlayerPrefs.Save();

            // Show consent dialog again
            ShowConsentDialog();
        }

        public void RequestDataDeletion()
        {
            // Trigger data deletion request to backend
            Debug.Log("[Privacy] Data deletion requested - implement backend call");
            // TODO: Call Supabase edge function for data deletion
        }

        private void ShowConsentDialog()
        {
            // Trigger UI to show consent popup
            Debug.Log("[Privacy] Show consent dialog");
        }

        private void LoadPreferences()
        {
            AnalyticsEnabled = PlayerPrefs.GetInt("consent_analytics", 1) == 1;
            PersonalizedAdsEnabled = PlayerPrefs.GetInt("consent_personalized_ads", 1) == 1;
        }
    }
}
```

**ATT for iOS (App Tracking Transparency):**

```csharp
#if UNITY_IOS
using Unity.Advertisement.IosSupport;

public class ATTHandler : MonoBehaviour
{
    void Start()
    {
        if (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() ==
            ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
        {
            ATTrackingStatusBinding.RequestAuthorizationTracking();
        }
    }
}
#endif
```

---

### ✅ Definition of Done
- [ ] Privacy policy published online
- [ ] Terms of service published
- [ ] ConsentManager implementation
- [ ] GDPR consent flow working
- [ ] ATT dialog for iOS
- [ ] Data deletion endpoint
- [ ] Tested in EU region

---

---

## Issue #113: [QA] Soft launch monitoring

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `qa`, `priority-critical`  
**Milestone:** Phase 3 - Soft Launch

---

### 🎯 Goal
Monitor key metrics during soft launch to identify critical issues.

---

### 📋 Key Metrics Dashboard

**Stability:**
- Crash-free rate (target: >99%)
- ANR rate (target: <0.5%)
- Error rate in logs

**Engagement:**
- DAU/MAU trend
- D1 retention (target: >40%)
- D7 retention (target: >15%)
- Session length avg
- Sessions per day

**Monetization:**
- Conversion rate (target: >2%)
- ARPDAU
- ARPPU
- Ad eCPM

**Funnels:**
- FTUE completion rate (target: >70%)
- First summon rate
- Shop visit rate

---

### 📝 Monitoring Setup

**Supabase Dashboard Queries:**

```sql
-- Daily Active Users
SELECT DATE(created_at) as day, COUNT(DISTINCT player_id) as dau
FROM analytics_events
WHERE event_type = 'session_start'
AND created_at > NOW() - INTERVAL '30 days'
GROUP BY DATE(created_at)
ORDER BY day DESC;

-- Retention Cohort
SELECT 
    install_date,
    COUNT(DISTINCT CASE WHEN day_number = 0 THEN player_id END) as d0,
    COUNT(DISTINCT CASE WHEN day_number = 1 THEN player_id END) as d1,
    COUNT(DISTINCT CASE WHEN day_number = 7 THEN player_id END) as d7
FROM retention_events
WHERE install_date > NOW() - INTERVAL '14 days'
GROUP BY install_date
ORDER BY install_date DESC;

-- Funnel Completion
SELECT 
    step_name,
    COUNT(DISTINCT player_id) as users,
    LAG(COUNT(DISTINCT player_id)) OVER (ORDER BY step) as prev_step,
    ROUND(COUNT(DISTINCT player_id)::numeric / 
          LAG(COUNT(DISTINCT player_id)) OVER (ORDER BY step) * 100, 2) as conversion_pct
FROM analytics_events
WHERE event_type = 'funnel_step'
AND event_data->>'funnel_name' = 'ftue'
GROUP BY step, step_name
ORDER BY step;
```

**Alerting Rules:**

```yaml
alerts:
  crash_rate_high:
    condition: crash_free_rate < 98%
    severity: critical
    action: pause_rollout

  retention_low:
    condition: d1_retention < 30%
    severity: high
    action: investigate_ftue

  revenue_anomaly:
    condition: daily_revenue < 50% of 7day_avg
    severity: medium
    action: check_iap_integration

**Feedback Loop: Panel + Global Config**

- During softlaunch:
    - Use analytics dashboards for aggregate KPIs (retention, ARPDAU, conversion).
    - Use the in-game analytics/debug panel on real devices to spot-check that critical events (onboarding, progression, monetization) fire correctly and that A/B variants and remote config values are applied as expected.
- When KPIs indicate issues (e.g., high early churn, low conversion):
    - Adjust relevant parameters in `GlobalBalanceConfigSO` and/or remote config (e.g., early-game difficulty, AFK caps, gacha rates, entry costs).
    - Validate the new configuration via the debug panel and dashboards before rolling out widely.
```

---

### ✅ Definition of Done
- [ ] Dashboard created in Supabase
- [ ] All key metrics tracked
- [ ] Alert thresholds defined
- [ ] Daily monitoring routine established
- [ ] Escalation process documented
- [ ] Week 1 soft launch report template

---

---

## Issue #114: [Live] Soft launch event calendar

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `live-ops`, `priority-high`  
**Milestone:** Phase 3 - Soft Launch

---

### 🎯 Goal
Plan and configure events for soft launch period.

---

### 📋 Week 1-4 Event Calendar

**Week 1: Launch Week**
```
- Day 1-7: Welcome Event
  - Free 10x summon for all players
  - Double XP on all activities
  - Bonus gems for first purchase
```

**Week 2: Engagement Push**
```
- Day 8-14: Monster Hunt Event
  - Special event currency
  - Exclusive monster in event shop
  - Community goal: Kill 1M enemies
```

**Week 3: Monetization Test**
```
- Day 15-21: Battle Pass Season 1 Start
  - 50 tiers of rewards
  - Premium pass 50% off
  - Limited cosmetic set
```

**Week 4: Retention Focus**
```
- Day 22-28: Comeback Campaign
  - Returning player bonuses
  - Daily login streak rewards
  - VIP trial for all players
```

---

### 📝 Event Configuration

**File:** `Assets/_Project/Configs/Events/LaunchWeekEvent.asset`

```csharp
[CreateAssetMenu(fileName = "LaunchWeek", menuName = "Events/Launch Week")]
public class LaunchWeekEventConfig : EventConfigSO
{
    // Base config
    public override string EventId => "launch_week_2024";
    public override string EventName => "Welcome Celebration!";
    public override EventType Type => EventType.Limited;
    
    // Schedule (UTC)
    public override DateTime StartTime => new DateTime(2024, 6, 1, 0, 0, 0, DateTimeKind.Utc);
    public override DateTime EndTime => new DateTime(2024, 6, 8, 0, 0, 0, DateTimeKind.Utc);

    // Bonuses
    public float XPMultiplier = 2f;
    public int FreeSummons = 10;
    public float FirstPurchaseBonus = 0.5f; // +50% value
    
    // Milestones
    public EventMilestone[] Milestones = new[]
    {
        new EventMilestone { PointsRequired = 100, Reward = "gems_100" },
        new EventMilestone { PointsRequired = 500, Reward = "summon_ticket_5" },
        new EventMilestone { PointsRequired = 1000, Reward = "monster_legendary_random" },
    };
}
```

---

### ✅ Definition of Done
- [ ] 4-week event calendar planned
- [ ] Event configs created for Week 1-4
- [ ] Events tested in staging
- [ ] Remote config for hot-updates
- [ ] Community goals integrated
- [ ] Push notification templates ready

---

---

## Issue #117: [Hotfix] Critical bug response process

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `process`, `priority-critical`  
**Milestone:** Phase 3 - Soft Launch

---

### 🎯 Goal
Establish process for identifying and deploying critical fixes.

---

### 📋 Hotfix Workflow

```
1. DETECT
   ↓ Crash reports / Player reports / Analytics anomaly
   
2. TRIAGE (< 30 min)
   ↓ Severity assessment: P0 (critical) / P1 (high) / P2 (medium)
   
3. INVESTIGATE (P0: < 2 hours)
   ↓ Reproduce → Root cause → Fix strategy
   
4. FIX & TEST
   ↓ Code fix → QA verification → Staging deploy
   
5. DEPLOY
   ↓ Build → Store submission → Staged rollout
   
6. MONITOR
   ↓ Verify fix in production → Close issue
```

---

### 📝 Severity Definitions

| Priority | Impact | Response Time | Examples |
|----------|--------|---------------|----------|
| P0 | Game unplayable | < 2 hours | Crash on startup, data loss |
| P1 | Major feature broken | < 4 hours | IAP not working, save corruption |
| P2 | Minor feature broken | < 24 hours | UI glitch, balance issue |
| P3 | Cosmetic/minor | Next update | Typo, minor visual bug |

---

### 📝 Remote Kill Switch

**For critical issues before store update:**

```csharp
// Remote config check on app start
public class MaintenanceChecker
{
    public async UniTask<bool> CheckMaintenance()
    {
        var config = await _remoteConfig.FetchAsync();
        
        if (config.GetBool("force_maintenance"))
        {
            ShowMaintenanceScreen(config.GetString("maintenance_message"));
            return true;
        }
        
        if (config.GetBool("force_update"))
        {
            var minVersion = config.GetString("min_version");
            if (CompareVersions(Application.version, minVersion) < 0)
            {
                ShowForceUpdateScreen();
                return true;
            }
        }
        
        return false;
    }
}
```

**Remote Config Keys:**
- `force_maintenance`: bool - Show maintenance screen
- `maintenance_message`: string - Message to display
- `force_update`: bool - Require app update
- `min_version`: string - Minimum version allowed

---

### ✅ Definition of Done
- [ ] Hotfix process documented
- [ ] On-call rotation established
- [ ] Remote kill switch implemented
- [ ] Force update flow working
- [ ] Rollback procedure documented
- [ ] Communication templates ready

---

---

## Issue #119: [Analytics] Soft launch metrics evaluation

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `analytics`, `priority-high`  
**Milestone:** Phase 3 - Evaluation

---

### 🎯 Goal
Analyze soft launch data to determine global launch readiness.

---

### 📋 Go/No-Go Criteria

| Metric | Target | Minimum | Status |
|--------|--------|---------|--------|
| Crash-free rate | >99.5% | >98% | |
| D1 Retention | >45% | >35% | |
| D7 Retention | >20% | >12% | |
| FTUE Completion | >75% | >60% | |
| Payer Conversion | >3% | >1.5% | |
| ARPDAU | >$0.10 | >$0.05 | |
| Session Length | >15 min | >8 min | |
| Sessions/Day | >3 | >2 | |

---

### 📝 Analysis Report Template

```markdown
# Soft Launch Evaluation Report
**Period:** [Date Range]
**Region:** [Countries]
**Users:** [Total / DAU / MAU]

## Executive Summary
[2-3 sentence summary of results and recommendation]

## Key Metrics

### Stability
- Crash-free rate: X% (target: 99.5%)
- ANR rate: X%
- Critical bugs: X resolved, Y outstanding

### Engagement
| Metric | Week 1 | Week 2 | Week 3 | Week 4 | Target |
|--------|--------|--------|--------|--------|--------|
| DAU    |        |        |        |        |        |
| D1 Ret |        |        |        |        | 45%    |
| D7 Ret |        |        |        |        | 20%    |

### Monetization
| Metric | Value | Target | Status |
|--------|-------|--------|--------|
| Conversion | | 3% | |
| ARPDAU | | $0.10 | |
| ARPPU | | | |

### Funnels
[Funnel visualization and drop-off analysis]

## Issues Identified
1. [Issue + impact + resolution status]
2. [...]

## Recommendations
- [ ] [Action item with owner and deadline]
- [ ] [...]

**KPI → Tuning Lever Mapping**

- For each key KPI (D1/D7/D30 retention, ARPDAU, conversion), document which analytics events drive the metric and which `GlobalBalanceConfigSO` / remote config parameters are the primary tuning levers.
- Ensure that all events used for KPI calculations can be spot-checked from the in-game analytics/debug panel.

## Go/No-Go Decision
**Recommendation:** [GO / CONDITIONAL GO / NO-GO]
**Rationale:** [Explanation]
```

---

### ✅ Definition of Done
- [ ] All metrics collected
- [ ] Report template filled
- [ ] Trend analysis complete
- [ ] Issues prioritized
- [ ] Go/No-Go decision documented
- [ ] Action items assigned

---

---

## Issue #120: [Balance] Post-soft launch tuning

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `balance`, `priority-high`  
**Milestone:** Phase 3 - Evaluation

---

### 🎯 Goal
Adjust game balance based on soft launch player data.

---

### 📋 Areas to Analyze

**Progression Speed:**
- [ ] Average player level over time
- [ ] Gold/gem income vs. spending
- [ ] Stage completion rates
- [ ] Idle earnings balance

**Gacha Economy:**
- [ ] Summon frequency
- [ ] Pity rates hit percentage
- [ ] Shard accumulation speed
- [ ] Monster diversity in player rosters

**Difficulty Curve:**
- [ ] Wave failure rates by stage
- [ ] Boss defeat rates
- [ ] Player power vs. expected power
- [ ] Endless mode distribution

**Monetization:**
- [ ] IAP purchase patterns
- [ ] Ad engagement rates
- [ ] Battle Pass progression speed
- [ ] Shop offer conversion

---

### 📝 Balancing Tools

**Remote Config Tuning:**

```json
{
  "balance_v1": {
    "gold_per_wave_multiplier": 1.0,
    "gem_daily_login": [10, 20, 30, 50, 75, 100, 150],
    "idle_earnings_rate": 0.5,
    "gacha_pity_threshold": 90,
    "wave_difficulty_scale": 1.05,
    "boss_hp_multiplier": 1.0,
    "ad_reward_gems": 25
  }
}
```

**A/B Test Configurations:**

```csharp
// Test harder or easier early game
var tutorialDifficulty = _abTest.GetValue("tutorial_difficulty", "wave_count", 5);

// Test gacha pity rates
var pityThreshold = _abTest.GetValue("gacha_pity", "threshold", 90);

// Test idle earnings
var idleMultiplier = _abTest.GetValue("idle_balance", "multiplier", 0.5f);
```

**Config-Driven Live Ops**

- Apply recurring balance adjustments (difficulty tweaks, reward buffs, AFK caps, monetization multipliers) primarily via `GlobalBalanceConfigSO` and remote config rather than code changes.
- Use the analytics/debug panel and dashboards to verify that new values are applied and that resulting behavior and metrics trend in the expected direction.

---

### ✅ Definition of Done
- [ ] Data analysis complete
- [ ] Balance adjustments identified
- [ ] Changes validated in A/B tests
- [ ] Remote config updated
- [ ] Patch notes prepared
- [ ] Community feedback addressed

---

---

## Issue #121: [Release] Global launch preparation

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `release`, `priority-critical`  
**Milestone:** Phase 3 - Global Launch

---

### 🎯 Goal
Final preparations for worldwide release.

---

### 📋 Pre-Launch Checklist

**Technical:**
- [ ] Final build with all soft launch fixes
- [ ] Server capacity scaled
- [ ] CDN configured for global distribution
- [ ] All regions enabled in store
- [ ] Localization complete (8+ languages)

**Store:**
- [ ] Store listings updated with final assets
- [ ] Featured placement requests submitted
- [ ] Press kit distributed
- [ ] Social media scheduled
- [ ] Influencer outreach complete

**Operations:**
- [ ] Launch event configured
- [ ] Welcome rewards set up
- [ ] Support team briefed
- [ ] Monitoring dashboards ready
- [ ] On-call schedule for launch week

**Contingency:**
- [ ] Rollback procedure tested
- [ ] Kill switch tested
- [ ] Emergency contacts documented
- [ ] Escalation matrix defined

---

### 📝 Launch Day Timeline

```
T-24h: Final build submitted
T-12h: Store pages go live
T-4h:  Marketing push starts
T-0:   Global availability
T+1h:  First metrics check
T+4h:  Stability review
T+24h: Day 1 report
T+48h: Early retention review
```

---

### ✅ Definition of Done
- [ ] All checklist items complete
- [ ] Go decision confirmed
- [ ] Launch communications sent
- [ ] Store pages live
- [ ] App available worldwide
- [ ] Day 1 metrics positive

---

---

## Issue #122: [Post] Post-launch monitoring and support

**Assignee:** @MaxeLBerger  
**Labels:** `phase-3`, `live-ops`, `priority-critical`  
**Milestone:** Phase 3 - Global Launch

---

### 🎯 Goal
Monitor game health and respond to issues in first 2 weeks post-launch.

---

### 📋 Daily Monitoring Routine

**Morning Check (9:00 AM):**
- [ ] Crash dashboard review
- [ ] Store reviews summary
- [ ] Support ticket overview
- [ ] Key metrics vs. targets

**Midday Check (1:00 PM):**
- [ ] DAU trending
- [ ] Revenue tracking
- [ ] Social media sentiment
- [ ] Any hotfix needed?

**Evening Check (6:00 PM):**
- [ ] Full day metrics
- [ ] Issues logged and prioritized
- [ ] Next day planning
- [ ] Stakeholder update

---

### 📝 Week 1-2 Priorities

**Week 1: Stability Focus**
- Rapid response to crashes
- Server scaling as needed
- Player support response <24h
- Daily status reports

**Week 2: Optimization**
- Retention improvement experiments
- Monetization optimization
- Community feedback integration
- First content update planning

---

### 📋 Success Metrics (Week 1)

| Metric | Day 1 | Day 3 | Day 7 | Target |
|--------|-------|-------|-------|--------|
| Downloads | | | | 100K |
| DAU | | | | 50K |
| Revenue | | | | $5K |
| Crash-free | | | | 99.5% |
| Store rating | | | | 4.5★ |

---

### ✅ Definition of Done
- [ ] Week 1 report complete
- [ ] Week 2 report complete
- [ ] All P0/P1 issues resolved
- [ ] Store rating maintained
- [ ] Retention targets met
- [ ] Revenue targets met
- [ ] Content roadmap defined

---

<!-- End of Phase 3 -->
