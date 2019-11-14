﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Odysseus.Utilities
{
    /// <summary>
    /// A game component, inherits to Clickable.
    /// Has associated content.
    /// Has an integer Value that is incremented by click.
    /// Draws content.
    /// </summary>
    public class Button : Clickable
    {
        #region Fields
        readonly string asset;
        Texture2D texture;
        int value;

        #region Public accessors
        public int Value { get { return value; } }
        #endregion
        #endregion

        #region Initialization
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">The Game object</param>
        /// <param name="textureName">Texture Name</param>
        /// <param name="targetRectangle">Position of the component on the screen</param>
        /// <param name="initialValue">Initial value</param>
        public Button(OdysseusUI game, string textureName, Rectangle targetRectangle, int initialValue)
            : base(game, targetRectangle)
        {
            asset = textureName;
            value = initialValue;
        }

        /// <summary>
        /// Load the button's texture
        /// </summary>
        protected override void LoadContent()
        {
            texture = Game.Content.Load<Texture2D>(asset);
            base.LoadContent();
        }
        #endregion

        #region Update and render
        /// <summary>
        /// Allows the game component to update itself
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            HandleInput();

            //hover ?

            if (IsClicked)
                ++value;
            base.Update(gameTime);
        }


        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            var color = IsTouching ? Color.Wheat : Color.White;
            Game.SpriteBatch.Begin();
            Game.SpriteBatch.Draw(texture?? new Texture2D(Game.GraphicsDevice,10,10), Rectangle, color);
            Game.SpriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion


    }
}
