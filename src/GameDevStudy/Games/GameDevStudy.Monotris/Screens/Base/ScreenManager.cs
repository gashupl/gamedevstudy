using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.Screens.Base
{
    internal class ScreenManager
    {
        private IScreen _currentScreen;
       // private TitleScreen _titleScreenCache;
        private GameplayScreen _gameScreenCache;
        private ScreenFactory _screenFactory;
        private GraphicsDevice _graphicsDevice;
        private ContentManager _content;

        public ScreenManager(Screen initialScreen, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _graphicsDevice = graphicsDevice;
            _content = content;
            _screenFactory = new ScreenFactory();

            SwitchScreen(initialScreen);
        }

        internal IScreen GetCurrent()
        {
            return _currentScreen;
        }

        internal void SwitchScreen(Screen screen)
        {
            _currentScreen?.Cleanup();

            if (screen == Screen.GameplayScreen)
            {
                if (_gameScreenCache == null)
                {
                    _gameScreenCache = _screenFactory.Create<GameplayScreen>(_graphicsDevice, _content);
                }
                _currentScreen = _gameScreenCache;
            }
            //else if (screen == Screen.TitleScreen)
            //{
            //    if (_gameScreenCache == null)
            //    {
            //        _gameScreenCache = _screenFactory.Create<GameplayScreen>(_graphicsDevice, _content);
            //    }
            //    _currentScreen = _gameScreenCache;
            //}

            _currentScreen?.OnStart();

        }
    }
}
