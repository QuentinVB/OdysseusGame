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
    public class DialBox : Component
    {
        #region Fields

        private MouseState _currentMouse;

        private SpriteFont _font;

        private bool _isHovering;

        private MouseState _previousMouse;

        private Texture2D _texture;

        private Feature _feature;

        private Button[] _actionButtons;


        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Rectangle Box { get; private set; }



        public Feature FeatureAttached { get=>_feature; set
            {
                _feature = value;
                ActionButtons = new Button[Choices.Length];
                for (int i = 0; i < Choices.Length; i++)
                {
                    ActionButtons[i] = new Button(i.ToString(), _texture, _font)
                    {
                        Position = new Vector2(Box.X, Box.Y + (i * 64) +40),
                        Text = Choices[i]
                    };
                    ActionButtons[i].Click += ActionButton_Click;
                }
                Text = Display;
            }
        }

        private Button CloseButton { get; set; }

        private string Display { get => FeatureAttached.Display; }
        private string[] Choices { get => FeatureAttached.Choices; }
        private string Result { get => FeatureAttached.Result; }
        public bool IsFeatureActive { get => FeatureAttached.Active; }
        private Button[] ActionButtons { get=> _actionButtons ?? new Button[0]; set=> _actionButtons=value; }
        public string Text { get; private set; }

        #endregion

        #region Methods

        public DialBox(string name, Texture2D texture, SpriteFont font, Rectangle rectangle) :base(name)
        {
            _texture = texture;

            this.Box = rectangle;

            IsVisible = false;

            _font = font;

            PenColour = Color.White;

            CloseButton = new Button("closeButton", _texture, _font)
            {
                Position = new Vector2(Box.X, Box.Y+Box.Height-64),
                Text = "Close"
            };
            CloseButton.Click += Close_click;
        }

        private void Close_click(object sender, EventArgs e)
        {
            if (sender is Button buttonCliked)
            {
                Console.WriteLine("close");
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



        public override void Draw(GameTime gameTime, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            if(IsVisible)
            {
                var colour = Color.White;
                spriteBatch.Draw(_texture, Box, colour);

                if (FeatureAttached != null)
                {
                    spriteBatch.DrawString(_font, Text, new Vector2(Box.X+10, Box.Y+10), PenColour);
                    if(FeatureAttached.Active)
                    {
                        foreach (var component in ActionButtons)
                            component.Draw(gameTime, graphics, spriteBatch);
                    }
                    else
                    {
                        CloseButton.Draw(gameTime, graphics, spriteBatch);
                    }
                    
                }


                
            }                     
        }

       

        #endregion
    }
}
