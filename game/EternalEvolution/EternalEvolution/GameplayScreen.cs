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
        Player player;
        Map map;
        List<Mob> mobs;
        private SpriteFont font;

        public override void LoadContent()
        {
            base.LoadContent();
            XmlManager<Player> playerLoader = new XmlManager<Player>();
            XmlManager<Map> mapLoader = new XmlManager<Map>();
            XmlManager<Mob> mobLoader = new XmlManager<Mob>();
            mobs = new List<Mob>();
            player = playerLoader.Load("Load/Player.xml");
            map = mapLoader.Load("Load/Map.xml");
            player.LoadContent();
            map.LoadContent();

            for (int i = 0; i < 5; i++)
            {
                Mob mob = mobLoader.Load("Load/Mob.xml");
                mob.Image.Position.X = 100 + (i * 100);
                mob.Image.Position.Y = 180;
                mob.LoadContent();
                mobs.Add(mob);
            }

            font = Content.Load<SpriteFont>("NewSpriteFont");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
            map.UnloadContent();
            foreach (Mob mob in mobs)
            {
                mob.UnloadContent();
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            player.Update(gameTime);
            foreach (Mob mob in mobs)
            {
                mob.Update(gameTime);
            }
            map.Update(gameTime, ref player, ref mobs);
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            // Order to the layers. Player gets drawn on top of the map, not otherwise.
            map.Draw(spriteBatch,"Underlay");
            foreach (Mob mob in mobs)
            {
                mob.Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            map.Draw(spriteBatch, "Overlay");
            spriteBatch.DrawString(font, "HP: " + player.HP, new Vector2(200, 200), Color.Yellow);
        }
    }
}
