using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitarieMonoGame.Models
{
    public class StackSlot
    {
        public Vector2 Position { get; set; }
        public bool IsSelected { get; set; } = false;
        public bool IsMouseOver { get; set; }

        public Rectangle Border => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        public string Name { get; set; } = "Slot";

        public bool IsDraggable { get; set; }
        public int ZIndex { get; set; } = -1;
        public Texture2D Texture { get; set; }

        public CardStack Stack { get; set; }

        private readonly SpriteBatch _spriteBatch;

        public StackSlot(Texture2D slotTex, SpriteBatch spriteBatch)
        {

            this._spriteBatch = spriteBatch;
            Texture = slotTex;

        }

        public void Update(GameTime gameTime)
        {


            //if (lastMouseOver != IsMouseOver)
            //{

            //    string mouseOver = IsMouseOver ? "enter" : "exit";
            //    //              Console.WriteLine("mouse: " + name + "-" + mouseOver);

            //}

            //lastMouseOver = IsMouseOver;

        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
