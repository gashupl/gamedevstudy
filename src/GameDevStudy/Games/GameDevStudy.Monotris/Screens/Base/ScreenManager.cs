using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.Screens.Base
{
    internal class ScreenManager
    {
        private IScreen _currentScreen;
        private IScreen _mainScreenCache;
        private IScreen _gameOverScreenCache;
        private IScreen _highScoreScreen;
        private ScreenFactory _screenFactory;
        private GraphicsDevice _graphicsDevice;
        private ContentManager _content;

        public ScreenManager(Screen initialScreen, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _screenFactory = new ScreenFactory();
            _graphicsDevice = graphicsDevice;
            _content = content;
            SwitchScreen(initialScreen);
        }

        internal IScreen CurrentScreen
        {
            get { return _currentScreen; }         
        }

        internal void SwitchScreen(Screen screen)
        {
            _currentScreen?.Cleanup();

            if (screen == Screen.MainScreen)
            {
                if (_mainScreenCache == null)
                {
                    _mainScreenCache = _screenFactory.Create<MainScreen>(_graphicsDevice, _content);
                }
                _currentScreen = _mainScreenCache;
            }
            else if (screen == Screen.GameplayScreen)
            {
                _currentScreen = _screenFactory.Create<GameplayScreen>(_graphicsDevice, _content);
            }
            else if (screen == Screen.HighScoreScreen)
            {
                if (_highScoreScreen == null)
                {
                    _highScoreScreen = _screenFactory.Create<HighScoreScreen>(_graphicsDevice, _content);
                }
                _currentScreen = _highScoreScreen;
            }
            else if (screen == Screen.GameOverScreen)
            {
                if (_gameOverScreenCache == null)
                {
                    _gameOverScreenCache = _screenFactory.Create<GameOverScreen>(_graphicsDevice, _content);
                }
                _currentScreen = _gameOverScreenCache;
            }

            _currentScreen?.OnStart();

        }
    }
}
