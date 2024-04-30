using Microsoft.Xna.Framework;

namespace Pg.MonoGame.Learn.ScreensNavigation
{
    internal class MyGameComponent : DrawableGameComponent
    {
        private MyGame _game; 
        public MyGameComponent(MyGame game) : base(game)
        {
            _game = game;
        }

        public void Initialize()
        {
 
        }

        public override void Draw(GameTime gameTime)
        {
            _game.spriteBatch.Begin();

            _game.spriteBatch.DrawString(_game.defaultFont, "-- Screen 1 -- ", new Vector2(0, 0), Color.White);

            _game.spriteBatch.End();
        }
    }
}