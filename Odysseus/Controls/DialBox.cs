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

        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }


        public Rectangle Rectangle { get; private set; }
        
        public Feature FeatureAttached { get; set; }

        private string Display { get => FeatureAttached.Display; }
        private string[] Choices { get => FeatureAttached.Choices; }
        private string Result { get => FeatureAttached.Result; }
        public bool IsFeatureActive { get => FeatureAttached.Active; }

        #endregion

        #region Methods

        public DialBox(string name, Texture2D texture, SpriteFont font, Rectangle rectangle) :base(name)
        {
            _texture = texture;

            this.Rectangle = rectangle;

            _font = font;

            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (_isHovering)
                colour = Color.Gray;

            spriteBatch.Draw(_texture, Rectangle, colour);
            /*
            if (!string.IsNullOrEmpty(DisplayText))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(DisplayText).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(DisplayText).Y / 2);

                spriteBatch.DrawString(_font, DisplayText, new Vector2(x, y), PenColour);
            }*/
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}
