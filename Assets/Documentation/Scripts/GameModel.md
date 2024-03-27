# GameModel.cs

## Overview

`GameModel.cs` serves as the data layer for the game, managing the player's stats and providing functionality to save and load these stats using Unity's `PlayerPrefs`.

## Key Components

- **PlayerStats:** Holds the player's current statistics, including coins, vitality, strength, and dexterity.
- **Constants:** Unique keys for saving and loading player stats to `PlayerPrefs`.

## Initialization

Upon creation, `GameModel` initializes `PlayerStats` with default values.

```csharp
public EntityStats PlayerStats = new(50, 10, 5);
