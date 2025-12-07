# PRD – Idle Monster Evolution TD  
_Interner Codename: Idle Heroes Defense_

---

## 1. Überblick

### 1.1 Kurzbeschreibung

„Idle Monster Evolution TD“ ist ein **Mobile-F2P-Spiel** (Android zuerst, später iOS), das **Tower Defense**, **Idle-Mechaniken** und **RPG-/Sammelelemente** kombiniert. Der Spieler sammelt und entwickelt Monster, die als „Türme“ automatisch **endlose Wellen von Gegnern** abwehren. Durch **Idle-Erträge**, **Upgrades**, **Gacha-Summons** und **Battle-Pass-Progression** wachsen Stärke und Vielfalt des Monster-Teams stetig.

Ziel ist ein **midcore-fähiges, aber UI-einfaches** Spiel mit hohem Dopamin-Faktor (sichtbare Evolutionen, ständige Belohnungen) und einem **Hybrid-Monetarisierungsmodell**, das realistisch **dauerhafte Umsätze** erlaubt.

### 1.2 Ziele des Projekts

- **Geschäftsziel:**  
  - F2P-Mobile-Titel mit langfristig positiver Unit-Economics (LTV > CPI) aufbauen.  
  - Langfristiges, erweiterbares Produkt (Live-Ops, Events, neue Monster, neue Maps).
- **Designziel:**  
  - „Easy to start, hard to master“: Einstieg innerhalb von 1–2 Minuten, aber tiefe Meta-Progression.  
  - Klare, übersichtliche UI, stylized Grafik, keine Überforderung.
- **Techziel:**  
  - Unity-basiertes Projekt, optimiert für Mobile (Android/ARM, später iOS).  
  - Backend über Supabase oder kompatiblen BaaS, Telemetrie und Live-Ops-Config über DB.

---

## 2. Zielgruppe & Plattform

### 2.1 Zielgruppe

- **Midcore-Mobile-Spieler**, Alter ca. 18–40.  
- Erfahrung mit Games wie:  
  - AFK Arena / AFK Journey (Idle-RPG)  
  - Arknights (TD-RPG)  
  - Summoner’s Greed, Grow Castle (simplere TD/Defense)  
- Motivation:  
  - Schnelle Sessions in Pausen (3–5 Minuten)  
  - Langfristige Progression und Sammelelemente  
  - „Autoplay/Idle“ statt Pflicht zum Dauerspielen

### 2.2 Plattformen

- Phase 1: Android (Google Play – interner/geschlossener Test, dann Open Beta)  
- Phase 2: iOS (App Store)  
- Hardware-Ziel:  
  - Mittelklasse-Android (3–4 Jahre alt) als baseline  
  - 60 FPS angepeilt, 30 FPS akzeptabel

---

## 3. Geschäftsmodell & Monetarisierung

### 3.1 Monetarisierungsstrategie (High-Level)

- **Free-to-Play**, ohne Paywall im Kern-Gameplay.  
- **Hybrid-Monetarisierung**:
  - In-App-Käufe (IAP) – primäre Umsatzquelle  
  - Battle-/Season-Pass  
  - Optionale, freiwillige Rewarded Ads  
  - Optionales VIP-/Abo-Modell mit QoL-Vorteilen

### 3.2 Monetarisierungsbausteine

1. **Premiumwährung (Diamanten o. Ä.)**
   - Primärer IAP-Kaufgegenstand.  
   - Verwendung: Gacha-Summons, beschleunigte Upgrades, Event-Shops.

2. **Softwährung (Gold / „Mana“)**  
   - Hauptressource für Monster-Upgrades, Forschung, Basis-Ausbau.  
   - Primär im Spiel und durch Idle-Erträge verdient.

3. **Gacha-/Summon-System**
   - Spieler können neue Monster und Monster-Shards über Summons erhalten.  
   - Seltenheiten: Common, Rare, Epic, Legendary, ggf. Mythic.  
   - Pity-System, das nach X erfolglosen Summons eine garantierte höhere Seltenheit vergibt.  
   - Banner-Events mit erhöhten Chancen für bestimmte Monster.

4. **Battle Pass / Season Pass**
   - Saisonale Laufzeit (z. B. 4 Wochen).  
   - Zwei Spuren: kostenlose Belohnungen und Premium-Spur.  
   - Premium-Pass kostet moderaten Betrag (z. B. ~5–15 €).  
   - Belohnungen: Premiumwährung, Monster-Shards, exklusive kosmetische Items, Evo-Materialien.  
   - Pass-Missionen orientieren sich am **Core Loop** (Wellen, Upgrades, Summons).

5. **Rewarded Ads**
   - Nur freiwillige Ads:
     - Verdopplung von Idle-Erträgen für begrenzte Zeit  
     - Extra-Eintritt in Event-Runs  
     - kleine Menge Softwährung oder Evo-Material  
   - Keine erzwungenen Vollbild-Ads im Kern-Flow.

6. **VIP-/Abo-Modell (optional)**
   - Monatliches Abo (~4,99 €).  
   - Vorteile:
     - +x % Idle-Ertrag  
     - kleine tägliche Premiumwährungs-Belohnung  
     - kosmetische Badge/Chat-Rahmen  
     - zusätzliche Inventarplätze o. Ä.

7. **Fairness-Prinzip**
   - Keine harte „Pay-to-Win“-Dominanz.  
   - Zahlungen beschleunigen Progression, erweitern Sammlung und Komfort, verändern aber nicht die fundamentale Spielbalance im PvE.  
   - Asynchrones PvP (Leaderboards) wird so balanciert, dass F2P-Spieler durch Zeit und Skill konkurrenzfähig bleiben.

---

## 4. Design-Pillars & Spielerfantasie

### 4.1 Design-Pillars

1. **„Watch them grow“ – Evolution & Fortschritt**  
   - Monster entwickeln sich visuell und spielmechanisch.  
   - Jeder Session-Anstieg fühlt sich wie ein Sprung in Stärke an.

2. **„Always progressing“ – Idle & kurze Sessions**  
   - Auch ohne aktives Spielen sammelt der Account Ressourcen.  
   - Jede kurze Session (3–5 Minuten) bringt Fortschritt.

3. **„Easy UI, Deep Meta“ – Klarheit im UI, Tiefe in Systemen**  
   - Schlanke, intuitive Oberflächen.  
   - Tiefe entsteht durch Build-Kombinationen, Synergien, Meta-Progression.

4. **„Live & Evolving“ – Events & Seasons**  
   - Regelmäßige Events mit neuen Belohnungen.  
   - Battle-Pass-Struktur hält das Spiel „lebendig“.

### 4.2 Spielerfantasie

- Der Spieler ist ein **Beschwörer/Overlord**, der Monster aus verschiedenen Fraktionen rekrutiert und auf einem Pfad/Board platziert.  
- Die Monster kämpfen autonom, während der Spieler die optimale Kombination und Platzierung findet.  
- Mit der Zeit entsteht eine **Armee von seltenen, mächtigen und optisch spektakulären Evolutionsformen**.

---

## 5. Core Loop & Modi

### 5.1 Core Game Loop

1. **AFK-Belohnung einsammeln** (Idle-Erträge aus AFK-Chest).  
2. **Monster verbessern** (Level-Ups, Evo-Materialien, Ausrüstung).  
3. **Tower-Defense-Run starten** (Wellen-Map).  
4. **Welle(n) verteidigen**, Gold und Loot erhalten.  
5. **Belohnungen einsammeln** (Softwährung, Shards, Pass-Fortschritt).  
6. **Meta-Progession**: neue Monster beschwören (Gacha), Forschung, Basis-Ausbau.  
7. Zurück zu Schritt 1.

### 5.2 Spielmodi (Phase 1 – Vertical Slice)

- **Kampagnen-Map 1**  
  - Fester Pfad (S-förmig).  
  - 10 Wellen als Grundzyklus, danach Endlosmodus.  
- **Endlos-/Survival-Modus (einfacher Prototyp)**  
  - Wellen skalieren unendlich, Rewards nehmen mit Wellenzahl zu.  
- **AFK-/Idle-System**  
  - AFK-Chest im Hauptmenü, die basierend auf Offline-Zeit regelmäßig Ressourcen abwirft.

Spätere Modi (Phase 2+):
- Zusätzliche Kampagnen-Maps (andere Pfade, Biome, Enemy-Spezialisierungen).  
- „Daily Challenge“ mit modifizierten Regeln (z. B. nur bestimmte Fraktion, random Buffs/Debuffs).  
- Gilden-/Clan-Boss-Modus (kooperativer Schaden über mehrere Tage).

---

## 6. Gameplay-Systeme (Detail)

### 6.1 Tower-Defense / Kampf

- **Spielfeld**:  
  - Single-Path-Map mit klar definierten Wegpunkten, Gegner laufen von Start zu Ziel (Basis/Portal).  
- **Platzierung**:  
  - Bestimmte Slots entlang des Pfads, in die Monster gesetzt werden.  
  - Slots können später durch Basis-Upgrades freigeschaltet werden.
- **Monster-Logik**:  
  - Angriffsreichweite, AttackSpeed, Schaden, Zielprioritäten (nächster Gegner, stärkster, schnellster).  
  - Unterschiedliche Rollen (DPS, AoE, Slow, Support, Summoner).
- **Gegner-Logik**:  
  - Standard-Gegner (HP, Speed)  
  - Schnelle, fragile Gegner  
  - Langsame, zähe Gegner  
  - Später: Schilde, Resistenzen, Spezialfähigkeiten (z. B. Heilung, Beschwörungen).
- **Sieg/Niederlage**:  
  - Gegner, die das Ziel erreichen, reduzieren „Leben/HP“ der Basis.  
  - Bei 0 HP = Run verloren, Rewards reduziert (aber nicht null, um Frust zu vermeiden).  
  - Sieg: alle Wellen abgewehrt → Bonus-Reward.

### 6.2 Monster & Evolution

- **Monster als „Towers“**:  
  - Jedes Monster ist eine Einheit mit Basiswerten (HP, ATK, Range, AttackSpeed, Fähigkeitsprofil).  
- **Level-System**:  
  - Monster-Level 1–100+ (langfristig).  
  - Level-Ups kosten Softwährung + ggf. Evo-Material.  
- **Evolutionsstufen**:  
  - z. B. 3 sichtbare Evolutionsstufen (Normal → Advanced → Ultimate).  
  - Jede Evolution verändert:  
    - Optik (größer, eindrucksvoller, neue FX)  
    - Werte (multiplikative Boosts)  
    - Fähigkeiten (z. B. zusätzlicher Kettenblitz, Flächeneffekt).
- **Rarität**:  
  - Common → schnell auf Level, aber schwächere Endwerte.  
  - Legendary/Mythic → selten im Gacha, sehr starke Endwerte.

### 6.3 Idle-/AFK-System

- **AFK-Chest** im Hauptmenü:  
  - Speichert „letzter Collect-Timestamp“.  
  - AFK-Ertrag: Softwährung + Evo-Materialien, ggf. sehr geringe Chance auf Monster-Shard.  
- **Balancing**:  
  - AFK-Ertrag skaliert mit Account-Power (z. B. Summe der Monster-Level).  
  - Hardcap für Offline-Zeit (z. B. maximale Belohnung für 8–12 h AFK).  
- **Interaktion mit Monetarisierung**:  
  - Rewarded Ads: temporäre Verdopplung des AFK-Ertrags.  
  - VIP/Abo: permanente +x % AFK-Boost.

### 6.4 Ökonomie & Ressourcen

- **Softwährung (Gold)**:
  - Hauptquelle: Kämpfe, AFK-Chest, Quests.  
  - Verwendung: Monster-Level, Basis-Upgrades.
- **Premiumwährung (Diamanten)**:
  - Quelle: IAP, Battle Pass, selten in Quests/Events.  
  - Verwendung: Gacha-Summons, Event-Shops, Speed-Ups.
- **Evo-Materialien**:
  - Bottleneck-Ressource für Monster-Evolution.  
  - Quellen: Wellenbelohnungen, Events, Pass, AFK-Chest.  
- **Eventressourcen**:
  - Temporäre Tokens für Event-Shops.

### 6.5 Meta-Progression & Basis

- **Spieler-/Account-Level**:
  - XP aus Kämpfen und Quests.  
  - Account-Level schaltet neue Funktionen frei (neue Modi, zusätzliche Monster-Slots, Feature-Gates).
- **Basis-Ausbau**:
  - Gebäude/„Rooms“ im Hub:  
    - Monster-Lab (Monsterverwaltung)  
    - AFK-Chest (Idle-Bereich)  
    - Forschung (Globale Buffs)  
    - Summon-Arena (Gacha)  
  - Upgrades: kürzere AFK-Maxzeit-Limit, mehr Monster-Slots, globaler DMG-Bonus etc.
- **Prestige/Rebirth (optional, später)**:
  - „Seasonal Reset“ mit dauerhaften Meta-Boni.  
  - Bietet langfristige Motivation für High-End-Spieler.

---

## 7. UX, UI & Artstyle

### 7.1 UX-Prinzipien

- **Einstieg**:
  - Erstes Spiel innerhalb von 60–120 Sekunden nach App-Start.  
  - Geführtes Tutorial (kontextsensitive Tooltips), kein harter „Textblock“-Onboarding.
- **Navigation**:
  - Haupt-Hub mit maximal 4–5 primären Buttons:  
    - Battle, Monsters, Summon, AFK-Chest, Shop (später).  
- **Lesbarkeit**:
  - Große Icons, klare Farbkontraste.  
  - Gegner-, Monster-, Projektil-Silhouetten klar unterscheidbar.

### 7.2 UI-Elemente

- **In-Battle HUD**:
  - Wellenanzeige  
  - Basis-Leben  
  - Gold/AFK-Chest-Indikator  
  - Geschwindigkeit (1x/2x, ggf. 4x)
- **Monster-Detail-Screen**:
  - Werte (ATK, Range, Speed) mit klaren Zahlen und Bars.  
  - Evolution-Vorschau (Vorher/Nachher).  
  - Level-Up-Button, Kostenanzeige.
- **Summon-Screen**:
  - „Single Summon“ und „10x Summon“ Buttons.  
  - Drop-Rates und Pity-Info sichtbar.

### 7.3 Artstyle

- **Stil**:
  - Stylized 2D oder sehr simples 3D (Low-Poly), hohe Farbsättigung, weiche Schatten.  
  - Monster-Designs: überzeichnet, klar, leicht animierbar.  
  - Gegner: thematisch passend (z. B. „Hero-Raider“, „Slimes“, „Roboter“, abhängig vom gewählten Setting).
- **Performance**:
  - Limitierte Polygonzahl, begrenzte Partikel, Pooling für Projektile/FX.  
  - Downscaling-Optionen für Low-End-Geräte.

---

## 8. Technik & Architektur

### 8.1 Engine & Tools

- **Engine**: Unity (2022/2023 LTS)  
- **Programmiersprache**: C#  
- **Projektstruktur**:
  - `Scenes/`, `Scripts/`, `ScriptableObjects/`, `Art/`, `Configs/`.  
- **Versionierung**:
  - Git (GitHub), trunk-based oder lightweight-branching.

### 8.2 Backend

- **Supabase** (oder andere BaaS-Lösung):
  - Tabellen für:  
    - Accounts, Progress, Käufe, Events, Offers.  
  - Optionale Edge Functions für serverseitige Logic (Event-Rotation, cheatrelevante Checks).
- **Speicherung lokal**:
  - Local Save (z. B. JSON/PlayerPrefs) für Offline-Spielbarkeit.  
  - Periodischer Sync mit Backend, wenn online.

### 8.3 Analytics & Telemetrie

- Tracking von:
  - D0/D1/D7/D30-Retention  
  - Session-Längen  
  - Level-/Wave-Abbrüche  
  - IAP-Konversion, ARPU/ARPPU  
  - Nutzung von Ads und Pass

---

## 9. Non-Functional Requirements

- **Performance**:
  - Ziel: 60 FPS, minimal 30 FPS.  
  - Memory: auf Midrange-Android stabil.
- **Stabilität**:
  - Crash-Rate < 1 % aller Sessions (Langfrist-Ziel).  
- **Lokalisierbarkeit**:
  - Alle Texte via Lokalisierungs-Keys, vorbereiteter Language-Switch.

---

## 10. Roadmap (high-level)

### 10.1 Phase 0 – Konzept & Prototyp (Vertical Slice)

- Dauer: ca. 2–4 Wochen (abhängig von Umfang und Automation).  
- Ziele:
  - 1 Map, 3 Monster, 3 Gegnertypen.  
  - Grundlegendes TD-Gameplay, AFK-System, simples Monster-Leveling.  
  - Kein echtes Backend, Save lokal.

### 10.2 Phase 1 – Feature-Ausbau

- Ergänzungen:
  - Gacha-Prototyp, Basis-Hub, zusätzliche Map/Modi.  
  - Supabase-Integration für Accounts & einfache Telemetrie.

### 10.3 Phase 2 – Monetarisierung & Live-Ops

- Battle Pass, Shop-Offers, Events.  
- Tracking und A/B-Tests.

### 10.4 Phase 3 – Softlaunch

- Gezielter Softlaunch in 1–2 Märkten (z. B. Kanada, Skandinavien).  
- KPIs messen, Balancing/Monetarisierung anpassen.  

---

## 11. Risiken & Annahmen

- **Risiko: Content-Schere**  
  - Langfristige Spieler benötigen regelmäßig neuen Content → durch Idle-/Endlos-Modi und Events abzufedern.  
- **Risiko: UA-Kosten (CPI)**  
  - Steigende Werbekosten → Design auf organische Reichweite (virale Clips, starke Screenshots) achten.  
- **Annahme: Midcore-Zielgruppe**  
  - Wir gehen davon aus, dass genügend Nutzer auf ein „leichtes, aber tiefes“ TD/Idle-RPG anspringen.

---

## 12. Zusammenfassung

„Idle Monster Evolution TD“ kombiniert  
- **Mobile-F2P**,  
- **Tower Defense**,  
- **Idle & RPG-Sammelmechaniken**  
mit einer klaren, einfachen UI und einem **Hybrid-Monetarisierungsmodell**. Die 50 Design- und Monetarisierungspunkte (Mobile, Midcore-Fokus, stylized Art, Battle Pass, Gacha, Rewarded Ads, Live-Ops, Analytics) sind in diesem PRD integriert und bilden die Grundlage, um ein realistisch wirtschaftlich erfolgreiches Spiel zu entwickeln.
