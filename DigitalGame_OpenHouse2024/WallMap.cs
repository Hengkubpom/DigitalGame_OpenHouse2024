using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DigitalGame_OpenHouse2024
{
    public class WallMap
    {
        Rectangle hitbox = new Rectangle();


        public WallMap(Rectangle wall)
        {
            hitbox = wall;
        }

        public void DrawWall(SpriteBatch _batch, Texture2D testtexture)
        {
            _batch.Draw(testtexture, hitbox, Color.Black);
        }


    }
}
