using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.Screens.Base
{
    internal class ScreenFactory
    {
        internal T Create<T>(GraphicsDevice graphicsDevice, ContentManager content) where T : IScreen, new()
        {
            var t = new T();
            t.Initialize(graphicsDevice, content);
            return t;
        }
    }
}
