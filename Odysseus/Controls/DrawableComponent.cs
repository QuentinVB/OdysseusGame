using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Odysseus.Controls
{
    public abstract class DrawableComponent : Component
    {
        private Texture2D _texture;
        #region Properties
        public Texture2D Texture { get => _texture; set => _texture = value; }
        public Rectangle Box { get; set; }
        public int Width { get => Box.Width; }
        public int Height { get => Box.Height; }

        #endregion
        public DrawableComponent(string name, GraphicsDeviceManager graphics, Rectangle position) : base(name, graphics)
        {
            Box = position;
        }
    }
}
