using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace EternalEvolution
{
    public class Player : Entity
    {
        public Player()
        {
            Velocity = Vector2.Zero;
            HP = 99;
        }

        public void LoadContent()
        {
            base.LoadContent();
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            Image.IsActive = true;

            if (ableToMove)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    MoveSpeed = 200;
                }
                else
                {
                    MoveSpeed = 100;
                }

                if (Velocity.X == 0)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
                    {
                        Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        Image.SpriteSheetEffect.CurrentFrame.Y = 0;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
                    {
                        Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        Image.SpriteSheetEffect.CurrentFrame.Y = 3;
                    }
                    else
                    {
                        Velocity.Y = 0;
                    }
                }

                if (Velocity.Y == 0)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
                    {
                        Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        Image.SpriteSheetEffect.CurrentFrame.Y = 2;
                    }
                    else if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
                    {
                        Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        Image.SpriteSheetEffect.CurrentFrame.Y = 1;
                    }
                    else
                    {
                        Velocity.X = 0;
                    }
                }

                if (Velocity.X == 0 && Velocity.Y == 0)
                {
                    Image.IsActive = false;
                }
            }

            Image.Update(gameTime);
            Image.Position += Velocity;
            hitBox = new Rectangle((int)Image.Position.X, (int)Image.Position.Y, (int)Image.SourceRect.Width, (int)Image.SourceRect.Height);
            center.X = hitBox.X + Image.SourceRect.Width / 2;
            center.Y = hitBox.Y + Image.SourceRect.Height / 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
