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
        readonly string  _name;
        public Component(string name)
        {
            this._name = name;
        }

        public string Name => _name;

        public abstract void Draw(GameTime gameTime, GraphicsDeviceManager graphics, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
    }
}
