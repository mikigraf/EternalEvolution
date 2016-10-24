using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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

        public void Update(GameTime gameTime, ref Player player, ref Mob mob)
        {
            if (state == "Solid")
            {
                Rectangle tileRect = new Rectangle((int)Position.X, (int)Position.Y, sourceRect.Width, sourceRect.Height);
                Rectangle playerRect = new Rectangle((int)player.Image.Position.X, (int)player.Image.Position.Y, (int)player.Image.SourceRect.Width, (int)player.Image.SourceRect.Height);
                Rectangle mobRect = new Rectangle((int)mob.Image.Position.X, (int)mob.Image.Position.Y, (int)mob.Image.SourceRect.Width, (int)mob.Image.SourceRect.Height);
                
                if (playerRect.Intersects(tileRect))
                {
                    
                    if(player.Velocity.X < 0)
                    {
                        player.Image.Position.X = tileRect.Right;
                    }else if(player.Velocity.X > 0)
                    {
                        player.Image.Position.X = tileRect.Left - player.Image.SourceRect.Width;
                    }
                    else if(player.Velocity.Y < 0)
                    {
                        player.Image.Position.Y = tileRect.Bottom;
                    }
                    else
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
                }

                if (mobRect.Intersects(playerRect))
                {

                    if (mob.Velocity.X < 0)
                    {
                        mob.Image.Position.X = playerRect.Right;
                    }
                    else if (mob.Velocity.X > 0)
                    {
                        mob.Image.Position.X = playerRect.Left - mob.Image.SourceRect.Width;
                    }
                    else if (mob.Velocity.Y < 0)
                    {
                        mob.Image.Position.Y = playerRect.Bottom;
                    }
                    else
                    {
                        mob.Image.Position.Y = playerRect.Top - mob.Image.SourceRect.Height;
                    }

                    mob.Velocity = Vector2.Zero;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
