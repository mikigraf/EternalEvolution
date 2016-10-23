using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Serialization;
using System.IO;

namespace EternalEvolution
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        [XmlIgnore]
        public ContentManager Content { set; get; }
        public Vector2 Dimensions
        {
            set; get;
        }
        GameScreen currentScreen, newScreen;
        XmlManager<GameScreen> xmlGameScreenManager;
        [XmlIgnore]
        public GraphicsDevice GraphicsDevice;
        [XmlIgnore]
        public SpriteBatch SpriteBatch;
        public Image Image;
        [XmlIgnore]
        public bool isTransitioning { get; private set; }

        public ScreenManager()
        {
            Dimensions = new Vector2(640, 480);
            currentScreen = new SplashScreen();
            //currentScreen = new GameplayScreen();
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = currentScreen.Type;
            currentScreen = xmlGameScreenManager.Load("Load/SplashScreen.xml");

        }
        public static ScreenManager Instance
        {
            get
            {
                if(instance == null)
                {
                    XmlManager<ScreenManager> xml = new XmlManager<ScreenManager>();
                    instance = xml.Load("Load/ScreenManager.xml");
                }
                return instance;
            }
        }

        public void ChangeScreens(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("EternalEvolution." + screenName));
            Image.IsActive = true;
            Image.FadeEffect.Increase = true;
            Image.Alpha = 0.0f;
            isTransitioning = true;
        }

        private void Transition(GameTime gameTime)
        {
            if (isTransitioning)
            {
                Image.Update(gameTime);
                if(Image.Alpha == 1.0f)
                {
                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    xmlGameScreenManager.Type = currentScreen.Type;
                    if (File.Exists(currentScreen.XmlPath))
                        currentScreen = xmlGameScreenManager.Load(currentScreen.XmlPath);
                    currentScreen.LoadContent();
                }else if(Image.Alpha == 0.0f)
                {
                    Image.IsActive = false;
                    isTransitioning = false;
                }
            }
        }

        public void LoadContent(ContentManager content)
        {
            this.Content = new ContentManager(content.ServiceProvider, "Content");
            currentScreen.LoadContent();
            Image.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            Transition(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
            if (isTransitioning)
            {
                Image.Draw(spriteBatch);
            }
        }
    }
}
