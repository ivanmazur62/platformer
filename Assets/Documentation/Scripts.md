# Scripts Documentation

This document serves as an index for the detailed documentation of script files used within the project.

- **BaseClasses**. Base classes provide foundational functionality that other classes can extend or implement. 
- [BaseClasses/GameState.cs](Scripts/BaseClasses/GameState.md).`GameState.cs` is responsible for managing the overall state of the game, such as tracking whether the game is in the main menu, in-play, or in a paused state.
- [BaseClasses/IPanel.cs](Scripts/BaseClasses/IPanel.md). `IPanel.cs` defines an interface for UI panels, ensuring a consistent method for showing and hiding UI elements across the game.


- [GameController.cs](Scripts/GameController.md). The `GameController.cs` script is central to managing game flow, handling player inputs, and coordinating between different components of the game.
- [GameModel.cs](Scripts/GameModel.md). `GameModel.cs` contains the game's data model, representing the state of the game, including player stats, game settings, and other persistent data.
- [GameView.cs](Scripts/GameView.md). `GameView.cs` is tasked with managing the visual representation of the game state, updating the UI in response to changes in the game model.
