using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SolitaireMonoGame.Models;
using SolitarieMonoGame.Models;
using System;
using System.Threading;

namespace SolitarieMonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Solitaire : Game
    {
        // Auto-generated
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Manually added
        private Table _table;
        Deck deck;

        //Texture2D cardTexture;
        Texture2D cardBack;
        Texture2D cardSlot;
        Vector2 cardPosition;
        float cardSpeed;
        float cardScale = .5f;

        public Solitaire()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 1000;
            graphics.PreferredBackBufferWidth = 1200;

            Window.Title = "Solitaire";
            Window.AllowUserResizing = true;

            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            cardPosition = new Vector2(graphics.PreferredBackBufferWidth / 2,
            graphics.PreferredBackBufferHeight / 2);
            cardSpeed = 100f;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //cardTexture = Content.Load<Texture2D>("Cards/clubs_10");
            cardBack = Content.Load<Texture2D>("Cards/back_green");
            cardSlot = Content.Load<Texture2D>("Cards/back_green");

            _table = new Table(spriteBatch, cardBack, cardSlot, 20, 30);

            // load up the card assets for the new deck
            foreach (var card in _table.TableDeck.Cards)
            {

                var location = "Cards/" + card.Suit.ToString() + card.Rank.ToString();
                card.SetTexture(Content.Load<Texture2D>(location));

            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                cardPosition.Y -= cardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                cardPosition.Y += cardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                cardPosition.X -= cardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                cardPosition.X += cardSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //cardPosition.X = Math.Min(Math.Max(cardTexture.Width / 2, cardPosition.X), graphics.PreferredBackBufferWidth - cardTexture.Width / 2);
            //cardPosition.Y = Math.Min(Math.Max(cardTexture.Height / 2, cardPosition.Y), graphics.PreferredBackBufferHeight - cardTexture.Height / 2);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            _table.Update(gameTime);
            _table.isSetup = false;

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
