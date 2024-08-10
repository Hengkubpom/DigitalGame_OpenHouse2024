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
        public bool follow_ms = false;
        public CodeBlock(string direction, Vector2 position, Texture2D texture)
        {
            this.direction = direction;
            this.origin = position;
            this.position = origin;
            this.texture = texture;
            hitbox = new Rectangle((int)position.X, (int)position.Y, 300, 100);
        }

        public void Code_Update(GameTime gameTime)
        {
            hitbox = new Rectangle((int)position.X, (int)position.Y, 300, 100);
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
            _batch.Draw(texture, hitbox, Color.Green);
        }
        public string GetDirection() { return this.direction;}
    }
}
