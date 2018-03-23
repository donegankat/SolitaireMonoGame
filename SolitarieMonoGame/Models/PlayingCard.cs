using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SolitaireMonoGame.Enums;
using SolitarieMonoGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireMonoGame.Models
{
    public class PlayingCard
    {
        private readonly SpriteBatch _spriteBatch;

        public CardRank Rank;
        public CardSuit Suit;
        private bool _isFaceUp;
        private bool _isPlayable;

        public CardStack Stack;
        public PlayingCard Child { get; set; } = null;

        //private readonly SpriteBatch _spriteBatch;
        private Vector2 _position;
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;

                if (Child != null)
                {

                    Vector2 pos = new Vector2(_position.X + Stack.CardOffset.X, _position.Y + Stack.CardOffset.Y);

                    Child.Position = pos;
                    //Child.snapPosition = pos;
                    //Child.ZIndex = ZIndex + 1;

                }

            }
        }

        protected Texture2D _cardBack;
        protected Texture2D _texture;
        public Texture2D Texture => _isFaceUp ? _texture : _cardBack;
        public Rectangle Border => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);


        public PlayingCard(CardRank rank, CardSuit suit, Texture2D cardBack, SpriteBatch spriteBatch)
        {
            this.Rank = rank;
            this.Suit = suit;
            this._cardBack = cardBack;
            this._spriteBatch = spriteBatch;
        }

        #region Card Graphics

        public void SetTexture(Texture2D newTexture)
        {
            _texture = newTexture;
        }

        public void SetCardBack(Texture2D newBack)
        {
            _cardBack = newBack;
        }

        public bool ContainsMouse(Vector2 pointToCheck)
        {
            var mouse = new Point((int)pointToCheck.X, (int)pointToCheck.Y);
            return Border.Contains(mouse);
        }

        #endregion

        #region Card Properties

        /// <summary>
        /// Gets the card color.
        /// </summary>
        /// <value>The card color.</value>
        public CardColor Color
        {
            get
            {
                if (Suit.Equals(CardSuit.Hearts) || Suit.Equals(CardSuit.Diamonds))
                    return CardColor.Red;
                else
                    return CardColor.Black;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is face up.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is face up;
        ///     otherwise, <c>false</c>.
        /// </value>
        public bool IsFaceUp
        {
            get { return _isFaceUp; }
            set { _isFaceUp = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is playable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance
        ///    is playable; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlayable
        {
            get { return _isPlayable; }
            set { _isPlayable = value; }
        }

        #endregion

        #region Card Functions

        public void FlipCard()
        {
            _isFaceUp = !_isFaceUp;
        }

        public void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(Texture, Position, Microsoft.Xna.Framework.Color.White);
        }

        #endregion
    }
}
