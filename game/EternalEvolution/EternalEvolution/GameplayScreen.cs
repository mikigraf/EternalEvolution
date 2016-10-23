using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace EternalEvolution
{
    public class GameplayScreen : GameScreen
    {
        Player player, mob;
        Map map;
        private SpriteFont font;
        XmlManager<Player> playerLoader;
        XmlManager<Map> mapLoader;

        public override void LoadContent()
        {
            base.LoadContent();
            playerLoader = new XmlManager<Player>();
            mapLoader = new XmlManager<Map>();
            player = playerLoader.Load("Load/Player.xml");
            map = mapLoader.Load("Load/Map.xml");
            player.LoadContent();
            //mob = playerLoader.Load("Load/Player.xml");
            //mob.Image.Position.X = 25;
            //mob.Image.Position.Y = 25;
            //mob.LoadContent();
            map.LoadContent();
            font = Content.Load<SpriteFont>("NewSpriteFont");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
            map.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            player.Update(gameTime);
            map.Update(gameTime, ref player);
            /* SHOWCASE FOR LEVEL LOADING.
            if (player.Image.Position.X > 100)
            {
                map = mapLoader.Load("Load/Map2.xml");
                map.LoadContent();
            }else if(player.Image.Position.X < 100)
            {
                map = mapLoader.Load("Load/Map.xml");
                map.LoadContent();
            } */
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            // Order to the layers. Player gets drawn on top of the map, not otherwise.
            map.Draw(spriteBatch,"Underlay");
            player.Draw(spriteBatch);
            //mob.Draw(spriteBatch);
            map.Draw(spriteBatch, "Overlay");
            spriteBatch.DrawString(font, "HP: " + player.HP, new Vector2(200, 200), Color.Yellow);
        }
    }
}
