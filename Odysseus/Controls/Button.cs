using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Odysseus.Controls
{
    public class Button : TextComponent
    {
        #region Fields

        private MouseState _currentMouse;

        private bool _isHovering;

        private MouseState _previousMouse;

        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        #endregion

        #region Methods

        public Button(string name, GraphicsDeviceManager graphics, SpriteFont font, Rectangle position) 
            :base(name, graphics, font, position)
        {


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = BGColour;

            if (_isHovering)
                //TODO : BG COLOUR / 2
                colour = Color.Gray;

            spriteBatch.Draw(Texture ?? MonoColorRect, Box, colour);

            if (!string.IsNullOrEmpty(Text))
            {
                //text centering problem
                var x = (Box.X + (Box.Width / 2)) - (Font.MeasureString(Text).X / 2);
                var y = (Box.Y + (Box.Height / 2)) - (Font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(Font, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();
            

           var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Box))
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
