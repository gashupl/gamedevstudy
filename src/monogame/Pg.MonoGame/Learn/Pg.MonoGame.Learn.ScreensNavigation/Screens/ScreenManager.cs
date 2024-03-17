using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    internal class ScreenManager
    {
        private readonly List<IScreen> _screens = new List<IScreen>();
        public IScreen CurrentScreen { get; private set; }

        internal ScreenManager(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont defaultFont)
        {
            _screens = new List<IScreen>
            {
                new Screen1(graphics, spriteBatch, defaultFont, this),
                new Screen2(graphics, spriteBatch, defaultFont, this),
                new Screen3(graphics, spriteBatch, defaultFont, this)
            };

            CurrentScreen = _screens.First(); 
        }

        internal void NavigateToNextScreen()
        {
            var currentIndex = _screens.IndexOf(CurrentScreen);
            var nextIndex = currentIndex + 1;
            if (nextIndex >= _screens.Count)
            {
                nextIndex = 0;
            }
            CurrentScreen = _screens[nextIndex];
        }   
    }
}
