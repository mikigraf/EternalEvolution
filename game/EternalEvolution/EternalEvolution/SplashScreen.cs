using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Input;

namespace EternalEvolution
{
    public class SplashScreen : GameScreen
    {
        public Image Image;

        public SplashScreen()
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();
            Image.LoadContent();

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            Image.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Image.Update(gameTime);
            if(Keyboard.GetState().IsKeyDown(Keys.Enter) && !ScreenManager.Instance.isTransitioning)
            {
                ScreenManager.Instance.ChangeScreens("SplashScreen");
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
            //base.Draw(spriteBatch);
        }
    }
}
