﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    internal interface IScreen
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
    }
}
