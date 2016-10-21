using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EternalEvolution
{
    public class SplashScreen : GameScreen
    {
        Texture2D image;
        public string Path;

        public SplashScreen()
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.Content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            image = Content.Load<Texture2D>(Path);
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Vector2.Zero, Color.White);
            //base.Draw(spriteBatch);
        }
    }
}
