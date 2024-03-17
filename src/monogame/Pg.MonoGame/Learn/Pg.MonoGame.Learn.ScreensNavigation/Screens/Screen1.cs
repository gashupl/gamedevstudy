using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    internal class Screen1 : ScreenBase, IScreen
    {
        internal Screen1(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, SpriteFont defaultFont, ScreenManager screenManager) 
            : base(graphics, spriteBatch, defaultFont, screenManager)
        {
        }

        public void Draw(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
        }

        public void Update(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.DrawString(defaultFont, "-- Screen 1 -- ", new Vector2(0,0), Color.Black);

            spriteBatch.End();
        }
    }
}
