using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevStudy.Monotris.Screens.Base
{
    internal interface IScreen
    {
        void Initialize(GraphicsDevice graphicsDevice, ContentManager content);

        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);

        void OnStart();
        void Cleanup();
    }
}
