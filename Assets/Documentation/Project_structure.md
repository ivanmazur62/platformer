# Project Structure

This document provides a detailed overview of the project structure, explaining the purpose and contents of each directory and subdirectory. The structure is designed to organize the project in a way that makes it easy to navigate and manage.

## Documentation

- Contains all the documentation related to the project, including this project structure description, scripts documentation, and user instructions.

## Assets

The Assets directory of the Unity project

### Assets/Data

- Stores data files used by the game, such as configuration files, scriptableObjects, game data JSONs.

#### Assets/Data/PowerUp

- Contains specific data files related to power-ups in the game, including their properties.

### Assets/Prefabs

- Prefabs directory holds pre-configured game objects that can be reused throughout the project, speeding up the development process.

#### Assets/Prefabs/UI

- Contains prefab objects for the user interface, including buttons, panels, and other UI elements.

#### Assets/Prefabs/World

- Stores prefabs related to the game world.

### Assets/Scenes

- Includes all the Unity scenes.

### Assets/Scripts

- This directory contains all the C# scripts that control the game logic, player interactions, and the overall behavior of the game.

#### Assets/Scripts/BasesClasses

- Stores base classes from which other script classes can inherit. This includes common functionalities that are shared across various game components.

#### Assets/Scripts/GameStates

- Contains scripts that manage the game states, such as menus, gameplay, pause, and game over states.

#### Assets/Scripts/UI

- Holds scripts specifically designed to control the user interface elements, including screen transitions, button behaviors, and UI updates.

#### Assets/Scripts/World

- Includes scripts that manage world-related functionalities.