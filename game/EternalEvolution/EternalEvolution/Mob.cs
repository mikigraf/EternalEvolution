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
    public class Mob : Entity
    {
        int count = 0;
        int attackCount = 0;
        bool attacking = false;
        public bool playerInRange = false;
        public Rectangle agroBox;
        public int victimX;
        public int victimY;


        public void LoadContent()
        {
            base.LoadContent();
            agroBox = new Rectangle((int)Image.Position.X - 200, (int)Image.Position.Y - 200, (int)Image.SourceRect.Width + 200, (int)Image.SourceRect.Height + 200);
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
                if (playerInRange)
                {
                    ToAttack(gameTime);
                }
                else
                {
                    Patrol(gameTime);
                }
            }
            else
            {
                //Console.Write("Path is bloked. turn right, old direction: " + direction);
                TurnRight(gameTime);
                //Console.WriteLine(", new drirection: " + direction);
            }

            if (Velocity.X == 0 && Velocity.Y == 0)
            {
                Image.IsActive = false;
            }

            Image.Update(gameTime);
            Image.Position += Velocity;
            hitBox = new Rectangle((int)Image.Position.X, (int)Image.Position.Y, (int)Image.SourceRect.Width, (int)Image.SourceRect.Height);
            agroBox = new Rectangle((int)Image.Position.X - 200, (int)Image.Position.Y - 200, (int)Image.SourceRect.Width + 200, (int)Image.SourceRect.Height + 200);
            center.X = hitBox.X + Image.SourceRect.Width / 2;
            center.Y = hitBox.Y + Image.SourceRect.Height / 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

        private void TurnRight(GameTime gameTime)
        {
            Velocity.X = 0;
            Velocity.Y = 0;

            if (direction.Equals('d'))
            {
                direction = 's';
            }
            else if (direction.Equals('s'))
            {
                direction = 'a';
            }
            else if (direction.Equals('a'))
            {
                direction = 'w';
            }
            else if (direction.Equals('w'))
            {
                direction = 'd';
            }
        }

        private void TurnLeft(GameTime gameTime)
        {
            Velocity.X = 0;
            Velocity.Y = 0;

            if (direction.Equals('d'))
            {
                direction = 'w';
            }
            else if (direction.Equals('s'))
            {
                direction = 'd';
            }
            else if (direction.Equals('a'))
            {
                direction = 's';
            }
            else if (direction.Equals('w'))
            {
                direction = 'a';
            }
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

        private void Patrol(GameTime gameTime)
        {
            if (count <= 50)
            {
                Move(direction, gameTime);
                count++;
            }
            else
            {
                TurnRight(gameTime);
                count = 0;
            }
        }

        private void ToAttack(GameTime gameTime)
        {
            Velocity.X = 0;
            Velocity.Y = 0;

            Random rnd = new Random();
            int rndNum = rnd.Next(0, 100);

            if (rndNum % 2 == 0)
            {
                if (victimX < hitBox.X)
                {
                    direction = 'a';
                }
                else if (victimX > hitBox.X + hitBox.Width)
                {
                    direction = 'd';
                }
                else if (victimX >= hitBox.X && victimX <= hitBox.X + hitBox.Width)
                {
                    if (victimY < hitBox.Y)
                    {
                        direction = 'w';
                    }
                    else if (victimY > hitBox.Y + hitBox.Y + hitBox.Height)
                    {
                        direction = 's';
                    }
                    else if (victimY >= hitBox.Y && victimY <= hitBox.Y + hitBox.Height)
                    {
                        attacking = true;
                    }
                }
            }
            else
            {
                if (victimY < hitBox.Y)
                {
                    direction = 'w';
                }
                else if (victimY > hitBox.Y + hitBox.Height)
                {
                    direction = 's';
                }
                else if (victimY >= hitBox.Y && victimY <= hitBox.Y + hitBox.Height)
                {
                    if (victimX < hitBox.X)
                    {
                        direction = 'a';
                    }
                    else if (victimX > hitBox.X + hitBox.X + hitBox.Width)
                    {
                        direction = 'd';
                    }
                    else if (victimX >= hitBox.X && victimX <= hitBox.X + hitBox.Width)
                    {
                        attacking = true;
                    }
                }
            }

            if (attacking)
            {
                attacking = false;
            }
            else
            {
                Move(direction, gameTime);
            }
        }
    }
}