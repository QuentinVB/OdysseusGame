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
    public abstract class TextComponent : DrawableComponent
    {
        #region Fields
        private SpriteFont _font;
        private string _text;
        #endregion

        #region Properties
        public Color PenColour { get; set; }
        public Color BGColour { get; set; }
        public string Text { get => WrapText(_text, Box.Width); set{ _text = value;} }
        protected SpriteFont Font { get => _font; }
        public float TextHeight
        {
            get
            {

                return CountStringOccurrences(Text, "\n")* Font.MeasureString(" ").Y*1.3f + Font.MeasureString(" ").Y*1.8f;
                
            }
        }
        #endregion

        #region Methods
        public TextComponent(string name, GraphicsDeviceManager graphics, SpriteFont font, Rectangle position)
            : base(name, graphics, position)
        {
            _font = font;

            PenColour = Color.White;
            BGColour = Color.Black;
        }

        public string WrapText(string text, float maxLineWidth)
        {
            return WrapText(Font, text, maxLineWidth);
        }

        public string WrapText(SpriteFont font, string text, float maxLineWidth)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = font.MeasureString(" ").X;
            foreach (string word in words)
            {
                Vector2 size = font.MeasureString(word);

                if (word.Contains("\r"))
                {
                    lineWidth = 0f;
                    sb.Append("\r \r");
                }

                if (lineWidth + size.X < maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }

                else
                {
                    if (size.X > maxLineWidth)
                    {
                        if (sb.ToString() == " ")
                        {
                            sb.Append(WrapText(font, word.Insert(word.Length / 2, " ") + " ", maxLineWidth));
                        }
                        else
                        {
                            sb.Append("\n" + WrapText(font, word.Insert(word.Length / 2, " ") + " ", maxLineWidth));
                        }
                    }
                    else
                    {
                        sb.Append("\n" + word + " ");
                        lineWidth = size.X + spaceWidth;
                    }
                }
            }


            return sb.ToString();
        }

        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
        #endregion
    }
}
