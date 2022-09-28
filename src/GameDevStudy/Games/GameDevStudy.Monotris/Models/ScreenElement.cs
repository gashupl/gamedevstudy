using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevStudy.Monotris.Models
{
    internal abstract class ScreenElement
    {
        public abstract void Draw(SpriteBatch _spriteBatch, GameTime gameTime); 
    }
}
