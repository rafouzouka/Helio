
// nice to see
// Two bit: https://www.youtube.com/channel/UCsCBEU7sWvEMlTzP3jE0olg/videos
// Kyle Schaub: https://www.youtube.com/watch?v=UbsIYm0mQ3Q
// Kodbold: https://www.youtube.com/watch?v=xFlAmQL4FJY
// Grashadows: https://www.youtube.com/watch?v=AF5YMfrIkuk
// AdamCYounis: https://www.youtube.com/channel/UC08QfQDLAd9D7aYPFgBUIng

// GameDev: https://www.youtube.com/watch?v=_cCGBMmMOFw&list=PLFt_AvWsXl0fnA91TcmkRyhhixX9CO3Lw
// Smart Penguins also gamedev:  https://www.youtube.com/c/SmartPenguins/videos
// Light : https://www.youtube.com/watch?v=8oy2R1OdXqQ
// Physics : https://www.youtube.com/watch?v=0LCNbsqLsFM

// Tools:
// making sound noise : https://sfxr.me/

// Create a tilset with aseprite: https://www.youtube.com/watch?v=btnH0x7_1g8

// Try to learn more about raycast and more

/*
 * Todo:
 * Friction and Restitution
 * Physics System (AABB Rect Collider only) Create Collide Event during collision (look at unity for naming conv like rigibody)
 * Debug Drawing for things like entity ID and box of collider
 * Use a QuadTree to reduce the O(n) of entity collision
 * Test if an Internal loop for physics is necessary
 * Correction the Screen System that always keep the aspect ratio of the game
 * Basic UI System based on events (Try looking at Layer to control Event propagation -> Console typing must no alterate game logic)
 * Generic Render System with animated sprites (spritesheet)
 * Level Editor when background based on tileset (Probably linked with Tiled) 
 * Read Files to load the Level
 * 
 * Create Audio System that react to Events for playing sound and music
 * Level or Scene Management that allow to change 
 * Look at GameState and what can be really done with that
 * Create Camera system that allow different Camera that can be link to a player 
 * Look at Post rendering and try to create something like a Light system or moving parts
 * Create a new View Like IA View that can control a enemy
 * Try creating the Remote View with network communication to try multiplayer
 * 
 * Use other collider than Rectangle like circle or others ...
 * Create a Logger that can print on the console and the HumanView
 */

using Helio.Box.Logics;
using Helio.Box.Views;

namespace Helio.Box
{
    public class Game1 : App
    {
        public Game1() : base("Promethee", 1280, 720)
        {

        }

        protected override void Init()
        {
            gameLogic = new GameLogic();
            views.Add(new HumanView());
        }
    }
}
