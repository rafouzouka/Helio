﻿using Helio.Box.Logics;
using Helio.Box.Views;

namespace Helio.Box
{
    public class Game1 : App
    {
        public Game1() : base("Promethee", 1280, 720, 1280/2, 720/2, new GameLogic(), new PlayerView())
        {

        }
    }
}
