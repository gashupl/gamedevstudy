using Microsoft.Xna.Framework;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    internal class Screen2 : ScreenBase
    {
        public Screen2(MyGame game) : base(game)
        {
        }

        public  override void Draw(GameTime gameTime)
        {
            game.graphics.GraphicsDevice.Clear(Color.Blue);

            game.spriteBatch.Begin();
            game.spriteBatch.DrawString(game.defaultFont, "-- Screen 2 -- ", new Vector2(10, 10), Color.White);
            game.spriteBatch.End();
        }
    }
}
