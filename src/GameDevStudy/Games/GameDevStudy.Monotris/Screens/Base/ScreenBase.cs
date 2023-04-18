using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.Screens
{
    internal class ScreenBase
    {
        protected GraphicsDevice graphicsDevice { get; set; }
        protected Texture2D _backgroundTexture { get; set; }
    }
}