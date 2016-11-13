using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalEvolution
{
    public abstract class Entity
    {
        public Image Image;
        public Vector2 Velocity;
        public float MoveSpeed;
        public int HP;
        public Rectangle hitBox;
        public Vector2 center;

        public void LoadContent()
        {
            Image.LoadContent();
            hitBox = new Rectangle((int)Image.Position.X, (int)Image.Position.Y, (int)Image.SourceRect.Width, (int)Image.SourceRect.Height);
            center.X = hitBox.X + Image.SourceRect.Width / 2;
            center.Y = hitBox.Y + Image.SourceRect.Height / 2;
        }

        public void UnloadContent()
        {
            Image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            Image.IsActive = true;
            
            

            Image.Update(gameTime);
            Image.Position += Velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }
    }
}
