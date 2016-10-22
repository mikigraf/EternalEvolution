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
    public class Player
    {
        public Image Image;
        public Vector2 Velocity;
        public float MoveSpeed;

        public Player()
        {
            Velocity = Vector2.Zero;
        }

        public void LoadContent()
        {
            Image.LoadContent();
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            if(Velocity.X == 0)
            {
                if (InputManager.Instance.KeyDown(Keys.Down) || InputManager.Instance.KeyDown(Keys.S))
                {
                    Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (InputManager.Instance.KeyDown(Keys.Up) || InputManager.Instance.KeyDown(Keys.W))
                {
                    Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    Velocity.Y = 0;
                }
            }

            if(Velocity.Y == 0)
            {
                if (InputManager.Instance.KeyDown(Keys.Right) || InputManager.Instance.KeyDown(Keys.D))
                {
                    Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else if (InputManager.Instance.KeyDown(Keys.Left) || InputManager.Instance.KeyDown(Keys.A))
                {
                    Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                else
                {
                    Velocity.X = 0;
                }
            }

            Image.Position += Velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
