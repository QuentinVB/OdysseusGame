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
    public abstract class DialBox : TextComponent
    {
        #region Fields



        #endregion

        #region Properties

        

        protected Button CloseButton { get; set; }

        #endregion

        #region Methods

        public DialBox(string name, GraphicsDeviceManager graphics, SpriteFont font, Rectangle rectangle) 
            :base(name, graphics, font, rectangle)
        {


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
        #endregion
    }
}
