using Microsoft.Xna.Framework.Graphics;
using SolitaireMonoGame.Enums;
using SolitarieMonoGame.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireMonoGame.Models
{
    public class Deck : CardStack
    {
        public Deck(Texture2D cardBack, Texture2D slotTex, SpriteBatch spriteBatch, int stackOffsetH, int stackOffsetV)
            : base(cardBack, slotTex, spriteBatch, stackOffsetH, stackOffsetV)
        {
            Cards = new List<PlayingCard>();
            SpriteBatch = spriteBatch;
        }

        public void NewDeck()
        {
            Cards.Clear();
            List<PlayingCard> allCards = new List<PlayingCard>(); // Blank list to hold the cards we fetch from the enum

            foreach (CardSuit mySuit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank myRank in Enum.GetValues(typeof(CardRank)))
                {
                    PlayingCard card = new PlayingCard(myRank, mySuit, CardBack, SpriteBatch);
                    allCards.Add(card);
                }
            }

            List<PlayingCard> shuffledCards = Shuffle(ref allCards);
            Cards = shuffledCards;
            //foreach (PlayingCard card in shuffledCards)
            //{
            //    PlayingCard newCard = new PlayingCard { CardType = card };
            //    Cards.Add(newCard);
            //    Console.WriteLine(newCard.CardType);
            //}
        }

        private List<PlayingCard> Shuffle(ref List<PlayingCard> cardList)
        {
            var randomizer = new Random(DateTime.Now.Millisecond);

            List<PlayingCard> shuffledCards = new List<PlayingCard>();
            while (cardList.Any())
            {
                int cardIndex = randomizer.Next(maxValue: cardList.Count);
                PlayingCard card = cardList[cardIndex];
                shuffledCards.Add(card);
                cardList.Remove(card);
            }

            return shuffledCards;
        }
    }
}
