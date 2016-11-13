using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EternalEvolution
{
    public class Tile
    {

        Vector2 position;
        Rectangle sourceRect;
        string state;

        public Rectangle SourceRect
        {
            get
            {
                return sourceRect;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public void LoadContent(Vector2 position, Rectangle sourceRect, string state)
        {
            this.position = position;
            this.sourceRect = sourceRect;
            this.state = state;
        }

        public void UnloadContent()
        {

        }

        public void Update(GameTime gameTime, ref Player player, ref List<Mob> mobs)
        {
            if (state == "Solid")
            {
                List<Rectangle> rectangleList = new List<Rectangle>();
                List<Entity> entityList = new List<Entity>();
                //Tile
                rectangleList.Add(new Rectangle((int)Position.X, (int)Position.Y, sourceRect.Width, sourceRect.Height));

                //Player
                rectangleList.Add(new Rectangle((int)player.Image.Position.X, (int)player.Image.Position.Y, (int)player.Image.SourceRect.Width, (int)player.Image.SourceRect.Height));
                entityList.Add(player);

                //Mobs
                foreach (Mob mob in mobs)
                {
                    rectangleList.Add(new Rectangle((int)mob.Image.Position.X, (int)mob.Image.Position.Y, (int)mob.Image.SourceRect.Width, (int)mob.Image.SourceRect.Height));
                    entityList.Add(mob);
                }

                for (int i = 0; i < rectangleList.Count; i++)
                {
                    for (int j = 0; j < rectangleList.Count; j++)
                    {
                        if (rectangleList[i] != rectangleList[j])
                        {
                            PreventCollision(rectangleList[j], rectangleList[i], entityList[j]);
                        }
                    }
                }
                
                /*if (playerRect.Intersects(tileRect))
                {
                    
                    if(player.Velocity.X < 0)
                    {
                        player.Image.Position.X = tileRect.Right;
                    }else if(player.Velocity.X > 0)
                    {
                        player.Image.Position.X = tileRect.Left - player.Image.SourceRect.Width;
                    }else if(player.Velocity.Y < 0)
                    {
                        player.Image.Position.Y = tileRect.Bottom;
                    }else
                    {
                        player.Image.Position.Y = tileRect.Top - player.Image.SourceRect.Height;
                    }

                    player.Velocity = Vector2.Zero;
                }

                if (mobRect.Intersects(tileRect))
                {

                    if (mob.Velocity.X < 0)
                    {
                        mob.Image.Position.X = tileRect.Right;
                    }
                    else if (mob.Velocity.X > 0)
                    {
                        mob.Image.Position.X = tileRect.Left - mob.Image.SourceRect.Width;
                    }
                    else if (mob.Velocity.Y < 0)
                    {
                        mob.Image.Position.Y = tileRect.Bottom;
                    }
                    else
                    {
                        mob.Image.Position.Y = tileRect.Top - mob.Image.SourceRect.Height;
                    }

                    mob.Velocity = Vector2.Zero;
                }*/
            }
        }

        private void PreventCollision(Rectangle rec1, Rectangle rec2, Entity e)
        {
            if (rec1.Intersects(rec2))
            {

                if (e.Velocity.X < 0)
                {
                    e.Image.Position.X = rec2.Right;
                }
                else if (e.Velocity.X > 0)
                {
                    e.Image.Position.X = rec2.Left - e.Image.SourceRect.Width;
                }
                else if (e.Velocity.Y < 0)
                {
                    e.Image.Position.Y = rec2.Bottom;
                }
                else
                {
                    e.Image.Position.Y = rec2.Top - e.Image.SourceRect.Height;
                }

                e.Velocity = Vector2.Zero;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
