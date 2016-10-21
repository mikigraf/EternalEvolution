using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;

namespace EternalEvolution
{
    public class Image
    {
        public string Path;
    }

    public class SplashScreen : GameScreen
    {
        Texture2D image;
        public Image Image;
        public Vector2 Position;

        public SplashScreen()
        {

        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.Content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
            image = Content.Load<Texture2D>(path[0]);
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
            spriteBatch.Draw(image, Position, Color.White);
            //base.Draw(spriteBatch);
        }
    }
}
