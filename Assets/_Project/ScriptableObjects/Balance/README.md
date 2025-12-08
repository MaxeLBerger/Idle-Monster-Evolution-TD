# Balance ScriptableObjects

This folder contains global balance configuration assets.

## Required Asset: GlobalBalanceConfig

**To create the GlobalBalanceConfig asset:**

1. In Unity Editor, right-click in this folder (`Assets/_Project/ScriptableObjects/Balance/`)
2. Select **Create → IdleMonsterTD → Config → Global Balance Config**
3. Name it `GlobalBalanceConfig`
4. Configure the initial values as needed

**To use in GameLifetimeScope:**

1. Open the Boot scene
2. Select the GameObject with `GameLifetimeScope` component
3. Drag the `GlobalBalanceConfig` asset into the "Global Balance Config" field

## Default Values

The `GlobalBalanceConfigSO` includes sensible defaults:

### AFK Rewards
- Base Gold Per Hour: 100
- Base Materials Per Hour: 10
- Cap Hours: 12

### Shards & Evolution
- Shard Thresholds: Common=10, Rare=20, Epic=50, Legendary=100, Mythic=200
- Evolution Cost Multipliers: Stage 1=1x, Stage 2=1.5x, Stage 3=2x, Stage 4=3x, Stage 5=5x

### Combat / Endless
- Enemy HP Multiplier Per Chapter: +15%
- Enemy Damage Multiplier Per Chapter: +10%
- Global Gold/XP Multipliers: 1x

### Monetization
- All value multipliers default to 1x