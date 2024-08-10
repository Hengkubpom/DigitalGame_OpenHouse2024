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
        public Texture2D texture;
        public Rectangle hitbox;
        public Room(Vector2 position, Texture2D texture)
        {
            this.position = position;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 300, 100);
            this.texture = texture;
        }

        public void fill_code(CodeBlock code)
        {
            texture = code.texture;
            DirectionInThisRoom.Add(code.GetDirection());
            IsEmpty = false;
        }

        public void Draw_room(SpriteBatch _batch)
        {
            _batch.Draw(texture, hitbox, Color.White);
        }

        

    }
}
