using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Odysseus.Core;

namespace Odysseus.Controls
{
    public class DialBox : TextComponent
    {
        #region Fields

        private Feature _feature;

        private Button[] _actionButtons;

        #endregion

        #region Properties

        public Feature FeatureAttached { get=>_feature; set
            {
                _feature = value;
                ActionButtons = new Button[Choices.Length];
                Text = Display;

                for (int i = 0; i < Choices.Length; i++)
                {
                    ActionButtons[i] = new Button(
                        i.ToString(), 
                        Graphics, 
                        Font, 
                        new Rectangle(Box.X, Box.Y + (i * 30) + (int)TextHeight, Box.Width, 20))
                    {
                        Text = Choices[i]
                    };
                    ActionButtons[i].Click += ActionButton_Click;
                }
            }
        }

        private Button CloseButton { get; set; }

        private string Display { get => FeatureAttached.Display; }
        private string[] Choices { get => FeatureAttached.Choices; }
        private string Result { get => FeatureAttached.Result; }
        public bool IsFeatureActive { get => FeatureAttached.Active; }
        private Button[] ActionButtons { get=> _actionButtons ?? new Button[0]; set=> _actionButtons=value; }

        #endregion

        #region Methods

        public DialBox(string name, GraphicsDeviceManager graphics, SpriteFont font, Rectangle rectangle) 
            :base(name, graphics, font, rectangle)
        {

            IsVisible = false;

            CloseButton = new Button(
                "closeButton", 
                Graphics,
                Font, 
                new Rectangle(Box.X, Box.Y + Box.Height - 64,64,64))
            {
                Text = "Close"
            };
            CloseButton.Click += Close_click;
        }

        private void Close_click(object sender, EventArgs e)
        {
            if (sender is Button buttonCliked)
            {
                Console.WriteLine("close dialbox");
                IsVisible = false;
            }
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            if(sender is Button buttonCliked)
            {
                Console.WriteLine(buttonCliked.Name);
                if(FeatureAttached!=null)
                {
                    FeatureAttached.Answer(int.Parse(buttonCliked.Name));
                    Text = Result;
                }                
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (FeatureAttached.Active)
            {
                foreach (var component in ActionButtons)
                    component.Update(gameTime);
            }
            else
            {
                CloseButton.Update(gameTime);
            }
        }



        public override void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            if(IsVisible)
            {
                var colour = Color.White;
                spriteBatch.Draw(Texture??MonoColorRect, Box, colour);

                if (FeatureAttached != null)
                {
                    spriteBatch.DrawString(Font, Text, new Vector2(Box.X+10, Box.Y+10), PenColour);
                    if(FeatureAttached.Active)
                    {
                        foreach (var component in ActionButtons)
                            component.Draw(gameTime, spriteBatch);
                    }
                    else
                    {
                        CloseButton.Draw(gameTime, spriteBatch);
                    }                  
                }   
            }                     
        }

       

        #endregion
    }
}
