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
    public class Mob
    {
        public Image Image;
        public Vector2 Velocity;
        public float MoveSpeed;
        public int HP;
        int count = 0;
        char direction = 'd';


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
            Image.IsActive = true;
            
            if (count <= 50)
            {
                Move(direction, gameTime);
                count++;
            }
            else
            {
                direction = TurnLeft(direction, gameTime);
                count = 0;
            }

            if (Velocity.X == 0 && Velocity.Y == 0)
            {
                Image.IsActive = false;
            }

            Image.Update(gameTime);
            Image.Position += Velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

        private char TurnRight(char direction, GameTime gameTime)
        {
            if (direction.Equals('d'))
            {
                return 's';
            }
            else if (direction.Equals('s'))
            {
                return 'a';
            }
            else if (direction.Equals('a'))
            {
                return 'w';
            }
            else if (direction.Equals('w'))
            {
                return 'd';
            }
            return 'n';
        }

        private char TurnLeft(char direction, GameTime gameTime)
        {
            if (direction.Equals('d'))
            {
                return 'w';
            }
            else if (direction.Equals('s'))
            {
                return 'd';
            }
            else if (direction.Equals('a'))
            {
                return 's';
            }
            else if (direction.Equals('w'))
            {
                return 'a';
            }
            return 'n';
        }

        private void Move(char direction, GameTime gameTime)
        {
            
            if (direction.Equals('d'))
            {
                Velocity.X = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Image.SpriteSheetEffect.CurrentFrame.Y = 2;
            }
            else if (direction.Equals('s'))
            {
                Velocity.Y = MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Image.SpriteSheetEffect.CurrentFrame.Y = 0;
            }
            else if (direction.Equals('a'))
            {
                Velocity.X = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Image.SpriteSheetEffect.CurrentFrame.Y = 1;
            }
            else if (direction.Equals('w'))
            {
                Velocity.Y = -MoveSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Image.SpriteSheetEffect.CurrentFrame.Y = 3;
            }
        }
    }
}
