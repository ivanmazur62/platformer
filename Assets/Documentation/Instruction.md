# Instruction Guide

This document describes instructions for adding various elements to the game

## Adding and Configuring PowerUps

### 1. Creating a New PowerUp

To add a new PowerUp to your game, follow these steps:

1. **Create a Prefab:**
   - Design your PowerUp in a graphics editor and import the assets into Unity.
   - In Unity, create a new GameObject in the scene and add your PowerUp's graphic as a sprite.
   - Add a `Collider2D` component to the GameObject to allow interaction with the player. `Collider2D` must be with the trigger enabled
   - Choose one of the inherited PowerUp scripts (`Coin.cs`, `DexterityPowerUp.cs`, `HealthPowerUp.cs`, `StrengthPowerUp.cs`) and add it to the GameObject.

2. **Create PowerUp Data:**
   - Navigate to `Create->GameItems->PowerUpData` to create a new scriptableObject for storing the PowerUp's data.
   - Save this scriptableObject in the `Data/PowerUp` directory.
   - In the PowerUp GameObject's `PowerUp` component, assign the newly created `PowerUpData` to the PowerUpData field.

### 2. Configuring an Existing PowerUp

To adjust the settings of an existing PowerUp:

- Create or modify a `PowerUpData` scriptableObject in the `Data/PowerUp` directory.
- Update the existing PowerUp GameObject by assigning the new or modified `PowerUpData` to the PowerUpData field in the PowerUp component.

### 3. Configuring PowerUpData

`PowerUpData` scriptableObject contains two main fields:

- **Duration:** Specifies the duration of the effect. This field does not apply to `Coin` and `Health` PowerUps.
- **Amount:** Determines the magnitude of the PowerUp's effect. For `Coin`, it specifies the exact quantity to increase. For other PowerUps, it indicates the percentage increase.

#### Instructions for PowerUpData Configuration:

- **For Duration-Based PowerUps:** Set the `Duration` field to the desired effect length in seconds.
- **For Amount-Based PowerUps:** Input the value in the `Amount` field to define how much the PowerUp will modify the player's attribute. Use a fixed number for Coins or a percentage for other types.

By following these guidelines, you can effectively add new PowerUps to your game or modify existing ones to enhance gameplay and provide varied experiences to players.
