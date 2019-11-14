using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Odysseus.Controls;
using Odysseus.Core;
using System;
using System.Collections.Generic;

namespace Odysseus
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class OdysseusUI : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        GameCore core;
        private Color _backgroundColour = Color.CornflowerBlue;

        private List<Component> _gameComponents;

        public GraphicsDeviceManager Graphics { get => _graphics;  }
        public SpriteBatch SpriteBatch { get => _spriteBatch;  }

        public OdysseusUI()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            core = new GameCore(10);
            //button = new Button(this, "ball", new Rectangle(10, 10, 100, 50), 0);

            this.IsMouseVisible = true;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            var randomButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Microsoft.Xna.Framework.Vector2(350, 200),
                Text = "Random",
            };
            randomButton.Click += RandomButton_Click;

            var quitButton = new Button(Content.Load<Texture2D>("Controls/Button"), Content.Load<SpriteFont>("Fonts/Font"))
            {
                Position = new Microsoft.Xna.Framework.Vector2(350, 250),
                Text = "Quit",
            };

            quitButton.Click += QuitButton_Click;

            _gameComponents = new List<Component>()
            {
                randomButton,
                quitButton,
            };
        }
        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        private void RandomButton_Click(object sender, System.EventArgs e)
        {
            var random = new Random();

            _backgroundColour = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
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
            GraphicsDevice.Clear(_backgroundColour);
            

            foreach (var component in _gameComponents)
                component.Update(gameTime);

            // TODO: Add your update logic here


            //if (kstate.IsKeyDown(Keys.Left))
                //ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            MouseState mouse = Mouse.GetState();
            //http://rbwhitaker.wikidot.com/mouse-input

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.DarkCyan);

            // TODO: Add your drawing code here
            SpriteBatch.Begin();
            foreach (var component in _gameComponents)
                component.Draw(gameTime, SpriteBatch);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
