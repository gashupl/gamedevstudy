using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    internal class ScreenBase
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected ScreenManager screenManager;
        protected SpriteFont defaultFont;

        internal ScreenBase(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont defaultFont, ScreenManager screenManager)
        {
            this.graphics = graphics;
            this.spriteBatch = spriteBatch;
            this.defaultFont = defaultFont;
            this.screenManager = screenManager; 
        }
    }
}
