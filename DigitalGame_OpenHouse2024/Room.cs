using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DigitalGame_OpenHouse2024
{
    public class Room
    {
        public bool IsEmpty = true;
        static public List<string> DirectionInThisRoom = new List<string>();
        private Vector2 position = Vector2.Zero;
        public Texture2D texture, first_texture;
        public Rectangle hitbox;
        private SpriteFont font;
        public string direction;
        public Room(Vector2 position, Texture2D texture, SpriteFont font)
        {
            this.position = position;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 175, 45);
            first_texture = texture;
            this.texture = first_texture;
            this.font = font;
        }

        public void Restart()
        {
            texture = first_texture;
            IsEmpty = true;
            direction = "";
        }
        public void fill_code(CodeBlock code)
        {
            direction = code.GetDirection();
            texture = code.texture;
            DirectionInThisRoom.Add(code.GetDirection());
            IsEmpty = false;
        }

        public void Draw_room(SpriteBatch _batch)
        {
            if (!IsEmpty)
            {
                _batch.Draw(texture, hitbox, Color.White);
                _batch.DrawString(font, "Player." + direction + "();", new Vector2(position.X + 18, position.Y + 14), Color.DarkCyan);
            }
        }

        

    }
}
