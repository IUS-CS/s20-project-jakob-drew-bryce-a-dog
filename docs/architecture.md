# Architecture

## Introduction

This document serves to give a high-level overview of how the game will be designed and played from application start through to its highest difficulty level. 

## Game State Flow

As this is an endless survival game, there is no win-state for the player to achieve. The difficulty of the game will steadily ramp up over time until it reaches a peak where only the most skilled players can continue to survive. When the player is defeated, the game restarts. 

Difficulty is determined by the length of time the player survives, and there will be five difficulty levels: 

* Very Easy - 0 to 60 seconds
* Easy - 60 to 120 seconds
* Normal - 120 to 300 seconds
* Hard - 300 to 600 seconds
* Very Hard - >600 seconds

![TimerController](/docs/TimerControllerDiagram.svg)

Difficulty will determine how quickly enemies spawn and how fast they move around the arena or toward the player. Each enemy either has 1 health point, or has infinite health and must be knocked off the arena platform via physics interactions to be defeated.

### Tutorial Phase

On app start, the player enters the arena in VR with tutorial hints on their virtual controllers which teach them how to teleport around and snap-turn left or right. Once the player has both teleported and snap turned twice each, a pedestal holding the Longbow rises in the middle of the arena. The player teleports over to it and grabs it with the assistance of their specific VR controllers' grabbing hints. Once the Longbow is in hand, the pedestal sinks into the ground again and the player must shoot an arrow toward an archery target in the distance in order to start the game. 

![Tutorial](/docs/TutorialDiagram.svg)

### Game Start

Once the game starts, the timer begins and rotating obstacle enemies spawn. These enemies move around the arena in a set pattern and are destroyed when hit by an arrow. When all obstacle enemies are cleared, four physics enemies spawn and begin moving toward the player. These enemies do not die when struck by the player, but must be knocked off the platform using the arrow's physics properties in order to be defeated, and are destroyed when they hit an invisible kill-box below the arena. When all four are defeated, the rotating enemies spawn again.

To prevent the player from "stalling" for time, the physics enemies will speed up toward the player over time, and other types of physics enemies will spawn at random locations during the rotating-enemies phase. At the end of each difficulty level, a "boss" physics enemy will spawn in the middle of the arena which will have a high amount of mass and will be difficult to push off the arena.

![Game Phase Flow](/docs/GamePhaseFlowDiagram.svg)

### Enemy Types:
* Physics Enemies:
  * Box Enemies
  * Boss Enemies
* On-hit-death Enemies:
  * Rotating Enemies
  * Randomly Spawning Enemies

## Script Interactions

The primary script controlling the phases and states of the game is GameStateController. TimerController communicates with GameStateController to tell it what the current difficulty should be, and GameStateController in turn communicates with RotatingEnemiesController, PhysicsEnemiesController, RandomEnemiesControlller, and BossEnemiesController to control what enemies spawn and when, and how fast the enemies should move. The arrow shot from the bow calls an OnTakeDamage() event in any collider that it hits to determine if that object needs to be destroyed and notify its controller or just have physics applied to it. Physics enemies will be destroyed when they hit the kill-box below the arena and then notify their controllers. 

![Script Interactions](/docs/ScriptInteractionsDiagram.svg)

## Further Concerns

Some stretch goals for this project are:
* Adding power-ups, e.g. adding an exploding arrow to your next shot to take out groups of enemies, or making your teleport ability have a longer range
* Adding a scoring system for players to achieve a point-based high score. Each enemy would be worth a certain amount of points once defeated, with perhaps multiplier bonuses awarded for multiple enemies being defeated quickly, or long-range shots
* Animated enemies, polished visuals and effects, sound effects and music