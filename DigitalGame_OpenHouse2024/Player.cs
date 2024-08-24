using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalGame_OpenHouse2024
{
    public class Player
    {
        public int speed = 60, level = 0;
        public string name = "";
        private string Direction = "";
        private SpriteFont font;
        public bool allow_walking = false;
        private Vector2 origin = new Vector2(400,450);
        //private Vector2 origin = new Vector2(300, 200);
        public Vector2 position, MapPosition;
        public Rectangle hitbox, walltest, victory;
        private Rectangle[] wall = new Rectangle[100];
        private Rectangle[] way = new Rectangle[2];
        AnimatedTexture Player_Texture = new AnimatedTexture(Vector2.Zero, 0, 1, 0);
        private Texture2D Map2;
        public bool IsWin = false;
        public Player(Texture2D Texture,int frameCount, int frameRow, int framesPerSec, SpriteFont nameFont, Texture2D map2, int level)
        {
            Player_Texture.Load(Texture, frameCount, frameRow, framesPerSec, 1);
            position = origin;
            hitbox = new Rectangle((int)position.X+16, (int)position.Y+32, 32, 32);
            font = nameFont;
            Map2 = map2;
            this.level = level;
            IsWin = false;
            switch (level)
            {
                case 1:
                    MapPosition = new Vector2(position.X, position.Y);
                    break;
                case 2:
                    MapPosition = new Vector2(position.X - 5, position.Y - 140);

                    //walltest = wall[14];
                    break;
                default:
                    break;
            }
        }
        public void ChangeLevel(int level)
        {


            this.level = level;
            IsWin = false;
            switch (level)
            {
                case 1:
                    MapPosition = new Vector2(position.X, position.Y);
                    victory = new Rectangle((int)MapPosition.X + 345, (int)MapPosition.Y + 95, 100, 100);
                    break;
                case 2:
                    MapPosition = new Vector2(position.X - 5, position.Y - 140);
                    victory = new Rectangle((int)MapPosition.X + 220, (int)MapPosition.Y + 272, 100, 100);

                    //walltest = wall[14];
                    break;
                default:
                    break;
            }
        }
        public void Reset()
        {
            IsWin = false;
            position = origin;
            Direction = "";
            allow_walking = false;
            switch (level)
            {
                case 1:
                    MapPosition = new Vector2(position.X, position.Y); break;
                case 2:
                    MapPosition = new Vector2(position.X - 5, position.Y - 140); break;
                default: break;
            }
            
            Player_Texture.startrow = 1;
            Room.DirectionInThisRoom.Clear();
        }

        public void Player_Update(GameTime gameTime)
        {
            Player_Texture.UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            hitbox = new Rectangle((int)position.X + 16, (int)position.Y + 32, 32, 32);

            if (victory.Intersects(hitbox))
            {
                IsWin = true;
                var instance = Game1.sEffect[3].CreateInstance();
                instance.Volume = 0.5f;
                instance.Play();
            }

            if (!IsWin)
            {
                //test player
                foreach (Rectangle miniwall in wall)
                {
                    if (miniwall.Intersects(hitbox))
                    {

                        allow_walking = false;
                        switch (Direction)
                        {
                            case "Left":
                                MapPosition.X -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                                Player_Texture.startrow = 3;
                                break;
                            case "Right":
                                MapPosition.X += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                                Player_Texture.startrow = 2;
                                break;
                            case "Up":
                                MapPosition.Y -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                                Player_Texture.startrow = 4;
                                break;
                            case "Down":
                                MapPosition.Y += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                                Player_Texture.startrow = 1;
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (allow_walking)
                {
                    if (Room.DirectionInThisRoom.Count > 0)
                    {
                        Direction = Room.DirectionInThisRoom[0];
                        switch (Direction)
                        {
                            case "Left":
                                MapPosition.X += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                                Player_Texture.startrow = 6;
                                break;
                            case "Right":
                                MapPosition.X -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                                Player_Texture.startrow = 7;
                                break;
                            case "Up":
                                MapPosition.Y += (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                                Player_Texture.startrow = 8;
                                break;
                            case "Down":
                                MapPosition.Y -= (float)(speed * gameTime.ElapsedGameTime.TotalSeconds);
                                Player_Texture.startrow = 5;
                                break;
                            default:
                                Player_Texture.startrow = 1;
                                break;
                        }
                    }
                }
                else
                {
                    if (Room.DirectionInThisRoom.Count > 0)
                    {
                        Room.DirectionInThisRoom.RemoveAt(0);
                        var instance = Game1.sEffect[1].CreateInstance();
                        instance.Volume = 0.2f;
                        instance.Play();
                    }
                    allow_walking = true;

                }

                if (level == 1)
                {
                    victory = new Rectangle((int)MapPosition.X + 345, (int)MapPosition.Y + 95, 100, 100);
                    way[0] = new Rectangle((int)MapPosition.X - 5, (int)MapPosition.Y - 5, 250, 100);
                    way[1] = new Rectangle((int)MapPosition.X + 180, (int)MapPosition.Y + 95, 250, 100);

                    wall[0] = new Rectangle((int)MapPosition.X - 5, (int)MapPosition.Y - 20, 250, 15);
                    wall[1] = new Rectangle((int)MapPosition.X - 5, (int)MapPosition.Y + 95, 185, 15);
                    wall[2] = new Rectangle((int)MapPosition.X - 15, (int)MapPosition.Y - 5, 10, 100);
                    wall[3] = new Rectangle((int)MapPosition.X + 245, (int)MapPosition.Y - 5, 10, 100);
                    wall[4] = new Rectangle((int)MapPosition.X + 245, (int)MapPosition.Y + 80, 185, 15);
                    wall[5] = new Rectangle((int)MapPosition.X + 165, (int)MapPosition.Y + 95, 15, 100);
                    wall[6] = new Rectangle((int)MapPosition.X + 165, (int)MapPosition.Y + 195, 270, 25);
                    wall[7] = new Rectangle((int)MapPosition.X + 425, (int)MapPosition.Y + 80, 15, 150);
                }
                else if (level == 2)
                {

                    victory = new Rectangle((int)MapPosition.X + 220, (int)MapPosition.Y + 272, 100, 100);
                    //room 1
                    wall[0] = new Rectangle((int)MapPosition.X, (int)MapPosition.Y, 312, 140);
                    wall[1] = new Rectangle((int)MapPosition.X, (int)MapPosition.Y, 17, 400);
                    wall[2] = new Rectangle((int)MapPosition.X, (int)MapPosition.Y + 205, 125, 155);
                    wall[3] = new Rectangle((int)MapPosition.X + 125, (int)MapPosition.Y + 225, 190, 130);
                    wall[4] = new Rectangle((int)MapPosition.X + 170, (int)MapPosition.Y + 130, 142, 55);
                    //Room2
                    wall[5] = new Rectangle((int)MapPosition.X + 310, (int)MapPosition.Y, 350, 100);
                    wall[6] = new Rectangle((int)MapPosition.X + 360, (int)MapPosition.Y + 150, 140, 75);
                    wall[7] = new Rectangle((int)MapPosition.X + 310, (int)MapPosition.Y + 260, 200, 350);
                    wall[8] = new Rectangle((int)MapPosition.X + 565, (int)MapPosition.Y + 100, 200, 120);
                    wall[14] = new Rectangle((int)MapPosition.X + 650, (int)MapPosition.Y + 200, 200, 120);
                    //Room3
                    wall[9] = new Rectangle((int)MapPosition.X + 565, (int)MapPosition.Y + 260, 180, 115);
                    wall[10] = new Rectangle((int)MapPosition.X + 745, (int)MapPosition.Y + 260, 180, 400);
                    wall[11] = new Rectangle((int)MapPosition.X + 510, (int)MapPosition.Y + 422, 125, 183);
                    //Room4
                    wall[12] = new Rectangle((int)MapPosition.X, (int)MapPosition.Y + 650, 800, 40);
                    wall[13] = new Rectangle((int)MapPosition.X, (int)MapPosition.Y + 350, 230, 300);
                }
            }

        }


        public void Player_draw(SpriteBatch _batch)
        {

            switch (level)
            {
                case 1:
                    break;
                case 2:
                    _batch.Draw(Map2, MapPosition, Color.White);
                    break;
                default:
                    break;
            }
            //foreach (Rectangle miniwall in wall)
            //{
            //    _batch.Draw(Game1.whiteblock_test, miniwall, Color.Black);
            //}
            if (level == 1)
            {
                
                foreach (Rectangle ways in way)
                {
                    _batch.Draw(Game1.whiteblock_test, ways, Color.Lime);
                }
                _batch.Draw(Game1.whiteblock_test, victory, Color.Blue);
            }
            //_batch.Draw(Game1.whiteblock_test, victory, Color.Blue);

            //_batch.Draw(Game1.whiteblock_test, hitbox, Color.White);
            Player_Texture.DrawFrame(_batch, position);
            //_batch.DrawString(font, name, new Vector2(position.X, position.Y - 10),Color.Black);
            //_batch.Draw(Game1.whiteblock_test, walltest , Color.Red);

        }
    }
}
