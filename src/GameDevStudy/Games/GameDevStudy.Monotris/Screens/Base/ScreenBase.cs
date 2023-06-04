using GameDevStudy.Monotris.Common;
using GameDevStudy.Monotris.Screens.Base;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevStudy.Monotris.Screens
{
    internal class ScreenBase
    {
        private bool _goToMainScreen = false;

        protected GraphicsDevice graphicsDevice { get; set; }
        protected Texture2D backgroundImage { get; set; }

        protected void GoToMainScreen(KeyboardState keyboardState)
        {
            //if (Global.ScreenManager?.CurrentScreen.GetType() == typeof(MainScreen))
            //    return; 

            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                _goToMainScreen = true;
            }
            if (_goToMainScreen && keyboardState.IsKeyUp(Keys.Enter))
            {
                _goToMainScreen = false;
                Global.ScreenManager?.SwitchScreen(Screen.MainScreen);
            }
        }

    }
}