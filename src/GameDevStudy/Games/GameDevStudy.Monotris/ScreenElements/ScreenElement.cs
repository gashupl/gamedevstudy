using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.ScreenElements
{
    internal abstract class ScreenElement
    {
        public abstract void Draw(SpriteBatch _spriteBatch, GameTime gameTime); 
    }
}
