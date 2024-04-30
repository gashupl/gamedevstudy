using Microsoft.Xna.Framework;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    internal class Screen3 : ScreenBase
    {
        public Screen3(MyGame game) : base(game)
        {
        }

        public void Draw(GameTime gameTime)
        {
            game.graphics.GraphicsDevice.Clear(Color.Orange);

            game.spriteBatch.Begin();
            game.spriteBatch.DrawString(game.defaultFont, "-- Screen 3 -- ", new Vector2(20, 20), Color.Black);
            game.spriteBatch.End();
        }

    }
}
