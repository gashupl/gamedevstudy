using Microsoft.Xna.Framework;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    public class Screen1 : ScreenBase
    { 
        public Screen1(MyGame game) : base(game)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            //game.graphics.GraphicsDevice.Clear(Color.Black);

            game.spriteBatch.Begin();
            game.spriteBatch.DrawString(game.defaultFont, "-- Screen 1 -- ", new Vector2(0, 0), Color.White);
            game.spriteBatch.End();

        }

    }
}
