using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    internal class ScreenManager
    {
        private readonly List<ScreenBase> _screens = new List<ScreenBase>();
        public ScreenBase CurrentScreen { get; private set; }

        internal ScreenManager(MyGame game)
        {
            _screens = new List<ScreenBase>
            {
                new Screen1(game),
                new Screen2(game),
                new Screen3(game)
            };

            CurrentScreen = _screens.First(); 
            game.Components.Add(CurrentScreen);
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
