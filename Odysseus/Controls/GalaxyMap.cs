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
    /*
    public class GalaxyMap : Component
    {
        #region Fields

        private MouseState _currentMouse;

        private SpriteFont _font;

        private bool _isHovering;

        private MouseState _previousMouse;

        private Texture2D _texture;

        private GameCore _core;

        private Button[] _destinations;


        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Rectangle Box { get; private set; }



        public GameCore CoreAttached { get=> _core; set
            {
                _core = value;
                Destinations = new Button[2];

                Destinations[0] = new Button("0", _texture, _font)
                {
                    Position = new Vector2(Box.X, Box.Y),
                    Text = _core.NextRight.ToString()
                };
                Destinations[0].Click += Destination_Click;  
            }
        }

        private Button CloseButton { get; set; }

        public Button[] Destinations { get => _destinations ?? new Button[0]; set => _destinations = value; }

        #endregion

        #region Methods

        public GalaxyMap(string name, Texture2D texture, SpriteFont font, Rectangle rectangle) :base(name)
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

        private void Destination_Click(object sender, EventArgs e)
        {
            if(sender is Button buttonCliked)
            {
                Console.WriteLine(buttonCliked.Name);
                //jump to            
            }
        }

        public override void Update(GameTime gameTime)
        {

            foreach (var component in Destinations)
                component.Update(gameTime);
            
            CloseButton.Update(gameTime);

        }



        public override void Draw(GameTime gameTime, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            if(IsVisible)
            {
                var colour = Color.White;
                spriteBatch.Draw(_texture, Box, colour);

                if (CoreAttached != null)
                {
                    spriteBatch.DrawString(_font, this.CoreAttached.PlayerShip.Orbiting.ToString(), new Vector2(Box.X+10, Box.Y+10), PenColour);
                    
                    foreach (var component in Destinations)
                        component.Draw(gameTime, graphics, spriteBatch);
                   
                }  
            }   
            CloseButton.Draw(gameTime, graphics, spriteBatch);

        }



        #endregion
    }
    */
}
