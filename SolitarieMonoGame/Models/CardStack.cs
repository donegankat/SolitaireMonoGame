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
    public class CardStack
    {
        protected SpriteBatch SpriteBatch;
        public Texture2D CardBack;

        private int _offsetHorizontal = 5;
        private int _offsetVertical = 5;
        public StackType StackType { get; set; }
        public StackMethod StackMethod { get; set; }

        public StackSlot Slot;
        public List<PlayingCard> Cards = new List<PlayingCard>();

        public CardStack(Texture2D cardBack, Texture2D slotTex, SpriteBatch spriteBatch, int stackOffsetH, int stackOffsetV)
        {
            Slot = new StackSlot(slotTex, spriteBatch) { Stack = this };
            this.CardBack = cardBack;
            this.SpriteBatch = spriteBatch;
            _offsetHorizontal = stackOffsetH;
            _offsetVertical = stackOffsetV;
        }

        public Vector2 CardOffset
        {
            get
            {
                if (StackMethod == StackMethod.Horizontal)
                {
                    return new Vector2(_offsetHorizontal, 0);
                }
                else if (StackMethod == StackMethod.Vertical)
                {
                    return new Vector2(0, _offsetVertical);
                }
                return Vector2.Zero; // Default
            }
        }

        public void AddCard(PlayingCard newCard)
        {
            Cards.Add(newCard);
        }

        public void RemoveTopCard()
        {
            Cards.Remove(Cards.LastOrDefault());
        }

        /// <summary>
        /// just picks the top card on the stack and returns it
        /// </summary>
        /// <returns></returns>
        public PlayingCard drawCard()
        {

            if (Cards.Count > 0)
            {

                var topCard = Cards[Cards.Count - 1];
                Cards.RemoveAt(Cards.Count - 1);
                return topCard;

            }
            return null;
        }


        public void Update(GameTime gameTime)
        {

            //foreach (var card in cards)
            //  if (card.stack != this) cards.Remove(card);

            Slot.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            Slot.Draw(gameTime);
        }
    }
}
