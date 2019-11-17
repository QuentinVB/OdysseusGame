﻿using Microsoft.Xna.Framework;
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

        Texture2D _planetBG;
        Texture2D _ship;
        SpriteFont _font;
        Vector2 _shipPos;

        readonly int screenW;
        readonly int screenH;

        GameCore core;

        private Color _backgroundColour = Color.Black;

        private List<Component> _gameComponents;

        public GraphicsDeviceManager Graphics { get => _graphics;  }
        public SpriteBatch SpriteBatch { get => _spriteBatch;  }
        public GameCore Core { get => core; set => core = value; }

        public OdysseusUI()
        {
            //https://gamedev.stackexchange.com/questions/140275/how-to-change-screen-resolution-in-xna
            _graphics = new GraphicsDeviceManager(this);
            screenW= 1280;
            screenH= 720;
            
            _graphics.PreferredBackBufferWidth = screenW;
            _graphics.PreferredBackBufferHeight = screenH;
            //_graphics.ToggleFullScreen();

            _graphics.ApplyChanges();

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
            _planetBG = Content.Load<Texture2D>("Sprites/planet1");
            _ship = Content.Load<Texture2D>("Sprites/ship");
            _font = Content.Load<SpriteFont>("Fonts/Font");
            var _button = Content.Load<Texture2D>("Controls/Button");

            var nextButton = new Button(
                "StarMap", 
                Graphics,
                _font,
                new Rectangle(0, 180,64,64)
                )
            {
                Texture= _button,
                Text = "Star Map",
                IsVisible = false
            };
            nextButton.Click += StarMapOpen;

            var quitButton = new Button(
                "quit",
                Graphics,
                _font,
                new Rectangle(0, screenW - 64,64,64)
                )
            {
                Texture = _button,
                Text = "Quit",
                IsVisible = true
            };
            quitButton.Click += QuitButton_Click;

            var shipConsole = new TextBox(
                "shipConsole", 
                Graphics,
                _font,
                new Rectangle(0,0,350,180)
                )
            {
                PenColour = Color.Lime,
                Text = "ShipConsole",
                IsVisible = true
            };


            var dialBox = new DialBox(
                "dialbox",
                Graphics,
                _font,
                new Rectangle(
                    (int)(screenW * 0.6),
                    (int)(screenH * 0.3),
                    450,
                    250
                    )
                )
            {
                Texture = _button
            };

            /*
            var galaxyMap = new GalaxyMap(
                "galaxyMap",
                Content.Load<Texture2D>("Sprites/galaxy"),
                Content.Load<SpriteFont>("Fonts/Font"),
                new Rectangle(
                    (int)(screenW * 0.25),
                    (int)(screenH * 0.1),
                    (int)(screenW * 0.5),
                    (int)(screenH * 0.5)

                    )

                )
            {
                IsVisible = true
             };
             */
            _gameComponents = new List<Component>()
            {
                nextButton,
                quitButton,
                shipConsole,
                dialBox,
                //galaxyMap
            };
        }
        private void QuitButton_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        
        private void StarMapOpen(object sender, System.EventArgs e)
        {
            _gameComponents.Find(x => x.Name == "galaxyMap").IsVisible = true;
            //Core.PlayerShip.UpdateGameTurn();
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
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (Core.PlayerShip.IsAlive)
            {
                Core.GenerateNextDestinations();
                ((TextBox)(_gameComponents.Find(x=>x.Name == "shipConsole"))).Text= Core.PlayerShip.ToString();

                var dialbox = ((DialBox)(_gameComponents.Find(x => x.Name == "dialbox")));
                if (Core.PlayerShip.Orbiting.Feature.Active)
                {
                    dialbox.IsVisible = true;
                    if (dialbox.FeatureAttached==null)
                    {
                        dialbox.FeatureAttached = Core.PlayerShip.Orbiting.Feature;
                    }
                }
                else
                {
                    if(!dialbox.IsVisible)
                    {
                       _gameComponents.Find(x => x.Name == "StarMap").IsVisible = true;

                    }
                }
                /*
                else
                {
                    Console.WriteLine($" 1. {Core.NextLeft}");
                    Console.WriteLine($" 2. {Core.NextRight}");
                    Console.Write("jump to : ");
                }

                
                if (Core.PlayerShip.Orbiting.Feature.Active)
                {
                    Core.PlayerShip.Orbiting.Feature.Answer(answer);
                }

                else
                {
                    switch (answer)
                    {
                        case "1":

                            Core.WarpShipTo(Core.NextLeft);
                            break;
                        case "2":
                            Core.WarpShipTo(Core.NextRight);
                            break;
                        default:
                            break;
                    }
                }
                */
            }
            else
            {
                //Console.ReadLine();
            }

            foreach (var component in _gameComponents)
                if(component.IsVisible)component.Update(gameTime);

            // TODO: Add your update logic here
            _shipPos = new Vector2(screenW / 3, (screenH / 2)+ 2*(float)Math.Cos(gameTime.TotalGameTime.TotalMilliseconds * 0.001));

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
            GraphicsDevice.Clear(_backgroundColour);
            //GraphicsDevice.Clear(Color.DarkCyan);

            // TODO: Add your drawing code here
            SpriteBatch.Begin();
            SpriteBatch.Draw(_planetBG, new Rectangle(Point.Zero, new Point(screenW,screenH)), Color.White);
            SpriteBatch.Draw(_ship, _shipPos, Color.White);
            
            foreach (var component in _gameComponents)
                if (component.IsVisible) component.Draw(gameTime, SpriteBatch);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
