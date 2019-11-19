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
    public class TextBox : TextComponent
    {
        #region Methods
        public TextBox(string name, GraphicsDeviceManager graphics, SpriteFont font, Rectangle position) 
            :base(name, graphics, font,position)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture??MonoColorRect, Box, BGColour);

            if (!string.IsNullOrEmpty(Text))
            {
                //Centering ? 
                //Adaptation
                var x = (Box.X + (Box.Width / 2)) - (Font.MeasureString(Text).X / 2);
                var y = (Box.Y + (Box.Height / 2)) - (Font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(Font, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update(GameTime gameTime)
        {
        }

        #endregion
    }
}
