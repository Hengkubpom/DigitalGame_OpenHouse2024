using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace DigitalGame_OpenHouse2024
{
    public class CodeBlock
    {
        string direction;
        public Vector2 origin = Vector2.Zero;
        public Vector2 position = Vector2.Zero;
        public Rectangle hitbox = new Rectangle();
        public Texture2D texture;
        public SpriteFont font;
        public bool follow_ms = false;
        public CodeBlock(string direction, Vector2 position, Texture2D texture, SpriteFont font)
        {
            this.direction = direction;
            this.origin = position;
            this.position = origin;
            this.texture = texture;
            this.font = font;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 175, 45);
        }

        public void Code_Update(GameTime gameTime)
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, 175, 45);
            if (follow_ms)
            {
                position = new Vector2(Game1.mouse_state.X, Game1.mouse_state.Y);
            }
            else
            {
                position = origin;
            }
        }

        public void Code_draw(SpriteBatch _batch)
        {
            _batch.Draw(texture, hitbox, Color.White);
            _batch.DrawString(font, "Player." + direction + "();", new Vector2(position.X+18,position.Y+14), Color.DarkCyan);
        }
        public string GetDirection() { return this.direction;}
    }
}
