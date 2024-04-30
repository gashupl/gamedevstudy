using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pg.MonoGame.Learn.ScreensNavigation.Screens
{
    public class ScreenBase : DrawableGameComponent
    {
        protected MyGame game;

        public ScreenBase(MyGame game) : base(game)
        {
            this.game = game;
        }

    }
}
