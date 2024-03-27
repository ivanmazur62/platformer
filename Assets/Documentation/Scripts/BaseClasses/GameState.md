# GameState.cs

## Overview

`GameState.cs` is an abstract class designed to manage the different states within the game, such as menu, play, pause, and game over states. It serves as a base for state-specific classes, providing a structured approach to state management and transitions.

## Key Features

- **Controller Access:** Each state has access to the `GameController` instance, allowing it to communicate with the central game controller.
- **State Transitions:** Defines how the game transitions into and out of states, with `EnterState` and `LeaveState` methods.

