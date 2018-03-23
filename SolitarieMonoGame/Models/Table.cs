using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SolitaireMonoGame.Models;
using SolitarieMonoGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitarieMonoGame.Models
{
    public class Table
    {
        protected Texture2D CardBack, SlotTexture;
        protected SpriteBatch SpriteBatch;

        public Deck TableDeck { get; set; }
        public List<CardStack> Stacks = new List<CardStack>();

        public bool isSetup { get; set; }

        public Table(SpriteBatch spriteBatch, Texture2D cardBack, Texture2D slotTex, int stackOffsetH, int stackOffsetV)
        {
            isSetup = true;

            TableDeck = new Deck(cardBack, slotTex, spriteBatch, stackOffsetH, stackOffsetV) { StackType = StackType.Deck };
            TableDeck.NewDeck();

            this.SpriteBatch = spriteBatch;
            this.CardBack = cardBack;
            this.SlotTexture = slotTex;
        }

        public void SetupTable()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            foreach (var stack in Stacks) stack.Update(gameTime);

            int startX = 0;
            int startY = 0;
            if (!isSetup)
            {
                foreach (var card in TableDeck.Cards)
                {
                    if (!card.IsFaceUp)
                        card.FlipCard();
                    Vector2 newPos = new Vector2(startX, startY);
                    card.Position = newPos;
                    SpriteBatch.Draw(card.Texture, card.Position, null, Color.White, 0f, new Vector2(card.Texture.Width / 2, card.Texture.Height / 2), .5f, SpriteEffects.None, 0f);
                    card.Draw(gameTime);
                    //Thread.Sleep(1);
                    startX += 20;
                    startY += 5;
                }
            }
            // fixes the z-ordering stuff
            //var items = dragonDrop.dragItems.OrderBy(z => z.ZIndex).ToList();
            //foreach (var item in )
            //{
            //    var type = item.GetType();
            //    if (type == typeof(PlayingCard)) item.Update(gameTime);
            //}
        }

        public void Draw(GameTime gameTime)
        {

            foreach (var stack in Stacks) stack.Draw(gameTime);

            // fixes the z-ordering stuff
            //var items = dragonDrop.dragItems.OrderBy(z => z.ZIndex).ToList();
            //foreach (var item in items)
            //{
            //    var type = item.GetType();
            //    if (type == typeof(Card)) item.Draw(gameTime);
            //}

        }
    }
}
