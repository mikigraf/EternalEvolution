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
    public class GameScreen
    {
        protected ContentManager Content;
        [XmlIgnore]
        public Type Type;
        public string XmlPath;

        public GameScreen()
        {
            Type = this.GetType();
            XmlPath = "Load/" + Type.ToString().Replace("EternalEvolution.", "") + ".xml";
        }

        public virtual void LoadContent()
        {
            this.Content = new ContentManager(ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            Content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
