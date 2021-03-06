![Helio Engine Logo](/extras/helio_logo.png)

**Helio** is an free **open source** opiniated C# game engine build on top of [Monogame](https://www.monogame.net/).

> Helio is currently in very early stage. Don't consider it for production developement.

## Todo :

### Levels

- [ ] Use of JSON or XML to load data from files to load game
- [ ] Levels editor
- [ ] Level Manager with level loading and unloadind or Scene Management

### UI

- [ ] UI System with basic items like buttons panel etc... using FlexBox web logic
- [ ] UI Item shouldn't need to test thiere state at each update() but should react to Events
- [ ] A button or a input should be able to stop the propagation of basic Events

### Core

- [ ] Alternative Content managment with enum string
- [ ] Multiple Cameras that can follow an actor and that can be switched at runtime
- [ ] Advenced GameState system with injection (need to look at more into this)
- [ ] Use the command pattern to map groups of events like unique action in the game
- [ ] Use a simple XML option file to configure the game engine to avoid passing toons of parameters

### Debug

- [ ] Create a special rendering loop for debug rendering
- [ ] Guizmos for things like collider entity id...
- [ ] Profiling (with Chrome)
- [ ] Logger (should print in the debug vsterminal or in the window)
- [ ] Draw the FPS count

### Audio

- [ ] Sound/Music system that can easly react to event to play some sounds
- [ ] Music
- [ ] Sound

### Physics

- [ ] Collision (use of multiple Collider like Rectangle, Circles)
- [ ] Create Triggers with probably a delegate
- [ ] Use a QuadTree for collision detection O(log n) (actually its O(n²))
- [X] Physics Based on Event system (should report Collision on Event)
- [X] AABB Rect Collider detection
- [ ] Look if it's necessary to implement an internal physic loop that can loop at different speed

### 2D Rendering

- [ ] Shaders integration HLSL
- [ ] Animated Sprite
- [ ] Particles engine
- [ ] Scene Graph Rendering
- [ ] Post processed effects like Light System (probably use of some shaders)

### Multiplayer

- [ ] Launchine headless gamelogic in a server
- [ ] Integrated TCP / UDP communication
- [ ] Define the Remote View that allow easy multiplayer creation

### IA

- [ ] Basic IAView that allow for A* Pathfinding and easy communication with game logic

## Showcase

Incomming.

## Getting started

Incomming.

## Documentation

Incomming.

## Contributing

Incomming.
