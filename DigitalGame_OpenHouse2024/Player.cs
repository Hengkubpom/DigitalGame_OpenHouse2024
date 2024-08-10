using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace DigitalGame_OpenHouse2024
{
    public class Player
    {
        private int speed = 60;
        public string name = "";
        private string Direction = "";
        private int numberDirection;
        private SpriteFont font;
        public bool allow_walking = false;
        public Vector2 position = new Vector2(500,100);
        public Rectangle hitbox;
        AnimatedTexture Player_Texture = new AnimatedTexture(Vector2.Zero, 0, 1, 0);
        public Player(Texture2D Texture,int frameCount, int frameRow, int framesPerSec, SpriteFont nameFont)
        {
            Player_Texture.Load(Texture, frameCount, frameRow, framesPerSec, 1);
            hitbox = new Rectangle((int)position.X, (int)position.Y, 16, 32);
            font = nameFont;
            numberDirection = -1;
        }


        public void Player_Update(GameTime gameTime)
        {
            Player_Texture.UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            hitbox = new Rectangle((int)position.X, (int)position.Y, 16, 32);

            Console.WriteLine(numberDirection);


            //test player
            if (Game1.walltest.Intersects(hitbox))
            {
                allow_walking = false;
                switch (Direction)
                {
                    case "Left":
                        position.X += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                        break;
                    case "Right":
                        position.X -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                        break;
                    case "Up":
                        position.Y += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                        break;
                    case "Down":
                        position.Y -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                        break;
                    default:
                        break;
                }
            }
            if (allow_walking)
            {
                if(Room.DirectionInThisRoom.Count > 0)
                {
                    Direction = Room.DirectionInThisRoom[0];
                    switch (Direction)
                    {
                        case "Left":
                            position.X -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            break;
                        case "Right":
                            position.X += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            break;
                        case "Up":
                            position.Y -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            break;
                        case "Down":
                            position.Y += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if(Room.DirectionInThisRoom.Count > 0)
                {
                    Room.DirectionInThisRoom.RemoveAt(0);
                }
                allow_walking = true;

            }

            
            
        }

        
        public void Player_draw(SpriteBatch _batch)
        {
            Player_Texture.DrawFrame(_batch, position);
            _batch.DrawString(font, name, new Vector2(position.X, position.Y - 10),Color.Black);
        }
    }
}
