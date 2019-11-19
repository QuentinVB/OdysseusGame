using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Controls
{
    public abstract class Component
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly string _name;

        public Component(string name, GraphicsDeviceManager graphics)
        {
            this._graphics = graphics;
            this._name = name;

            MonoColorRect = new Texture2D(Graphics.GraphicsDevice, 1, 1);
            MonoColorRect.SetData(new[] { Color.White });
        }

        public string Name => _name;
        protected GraphicsDeviceManager Graphics => _graphics;

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
        public bool IsVisible { get; set; }

        protected Texture2D MonoColorRect { get; set; }

    }
}
