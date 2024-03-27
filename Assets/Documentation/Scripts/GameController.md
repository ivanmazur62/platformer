# GameController.cs

## Overview

`GameController.cs` is a central component in the game's MVC (Model-View-Controller) architecture, responsible for managing the game's main flow, including state transitions, game initialization, and pausing/resuming the game. It utilizes the Singleton pattern to ensure only one instance exists in the game.

## Key Components

- **Singleton Pattern:** Ensures a single instance of `GameController` is active.
- **Game States:** Manages transitions between different game states (`GameState`).
- **GameView:** References the `GameView` component for UI interactions.

## Initialization

During `Awake`, the `GameController` initializes game components, sets the initial game state, and subscribes to UI button events:

- Initializes the game as paused.
- Sets up `GameView` and `GameModel`.
- Loads player stats and sets up UI interactions.

## State Management

The `ChangeState(GameState newState)` method allows transitioning between different states of the game by invoking `EnterState` on the new state and `LeaveState` on the previous state.

## Game Flow Controls

- **StartGame:** Transitions the game into the `GameplayState`, initializes the player, and subscribes to player events.
- **PauseGame/ResumeGame:** Toggles the game's pause state and switches between `PauseState` and `GameplayState`.
- **OnGameOver:** Triggers when the player dies, pausing the game and switching to `GameOverState`.

