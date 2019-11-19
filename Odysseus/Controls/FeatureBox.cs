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
    public class FeatureBox : DialBox
    {
        #region Fields

        private Feature _feature;

        private Button[] _actionButtons;

        #endregion

        #region Properties

        public Feature FeatureAttached { get=>_feature; private set {_feature = value;}}

        public  void AttachFeature(Feature feature)
        {
            FeatureAttached = feature;
            ActionButtons = new Button[Choices.Length];
            Text = Display;

            for (int i = 0; i < Choices.Length; i++)
            {
                ActionButtons[i] = new Button(
                    i.ToString(),
                    Graphics,
                    Font,
                    new Rectangle(Box.X, Box.Y + (i * 30) + (int)TextHeight*2, Box.Width, 20))
                {
                    Text = Choices[i]
                };
                ActionButtons[i].Click += ActionButton_Click;
            }
        }


        private string Display { get => FeatureAttached.Display; }
        private string[] Choices { get => FeatureAttached.Choices; }
        private string Result { get => FeatureAttached.Result; }
        public bool IsFeatureActive { get => FeatureAttached.Active; }
        private Button[] ActionButtons { get=> _actionButtons ?? new Button[0]; set=> _actionButtons=value; }

        #endregion

        #region Methods

        public FeatureBox(string name, GraphicsDeviceManager graphics, SpriteFont font, Rectangle rectangle) 
            :base(name, graphics, font, rectangle)
        {

            IsVisible = false;

          
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
            if (FeatureAttached!=null&&FeatureAttached.Active)
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

        internal void DetachFeature()
        {
            _feature = null;
            _actionButtons = null;
        }



        #endregion
    }
}
