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
    public class SimpleTextDisplay : Component
    {
        #region Fields


        private SpriteFont _font;

        private static Texture2D rect;


        #endregion

        #region Properties



        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Width,Height);
            }
        }

        public string Text { get; set; }
        public int Width { get;  set; }
        public int Height { get;  set; }

        #endregion

        #region Methods

        public SimpleTextDisplay(string name,SpriteFont font) : base(name)
        {
            Width = 10;
            Height = 10;
            _font = font;

            

            PenColour = Color.Black;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
        {
            if(rect==null)
            {
                rect = new Texture2D(graphics.GraphicsDevice, 1, 1);
                rect.SetData(new[] { Color.White });
            }
            spriteBatch.Draw(rect, Rectangle, Color.Black);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        

        public override void Update(GameTime gameTime)
        {
            
        }

        #endregion
    }
}
