using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.Screens.Base
{
    internal class ScreenFactory
    {
        internal T Create<T>(GraphicsDevice graphicsDevice, ContentManager content, GameWindow window) where T : IScreen, new()
        {
            var t = new T();
            t.Initialize(graphicsDevice, content, window);
            return t;
        }
    }
}
