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
        Mob mob;
        private SpriteFont font;

        public override void LoadContent()
        {
            base.LoadContent();
            XmlManager<Player> playerLoader = new XmlManager<Player>();
            XmlManager<Map> mapLoader = new XmlManager<Map>();
            XmlManager<Mob> mobLoader = new XmlManager<Mob>();
            player = playerLoader.Load("Load/Player.xml");
            mob = mobLoader.Load("Load/Mob.xml");
            map = mapLoader.Load("Load/Map.xml");
            player.LoadContent();
            mob.Image.Position.X = 150;
            mob.Image.Position.Y = 150;
            mob.LoadContent();
            map.LoadContent();
            font = Content.Load<SpriteFont>("NewSpriteFont");
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
            player.UnloadContent();
            map.UnloadContent();
            mob.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            player.Update(gameTime);
            mob.Update(gameTime);
            map.Update(gameTime, ref player, ref mob);
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            // Order to the layers. Player gets drawn on top of the map, not otherwise.
            map.Draw(spriteBatch,"Underlay");
            mob.Draw(spriteBatch);
            player.Draw(spriteBatch);
            map.Draw(spriteBatch, "Overlay");
            spriteBatch.DrawString(font, "HP: " + player.HP, new Vector2(200, 200), Color.Yellow);
        }
    }
}
