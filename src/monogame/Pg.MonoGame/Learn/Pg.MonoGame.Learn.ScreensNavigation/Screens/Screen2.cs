using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    internal class Screen2 : ScreenBase, IScreen
    {
        internal Screen2(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont defaultFont, ScreenManager screenManager)
            : base(graphics, spriteBatch, defaultFont, screenManager)
        {
        }

        public void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
