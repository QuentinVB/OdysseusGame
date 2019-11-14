using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public abstract class Feature
    {
        private GameCore _core;
        private bool _active = true;

        public abstract string Display { get; }
        public abstract string Choices { get; }
        public bool Active { get => _active; protected set => _active = value; }
        protected GameCore Core {  get => _core;  }

        public abstract void Answer(string answer);

        public Feature(GameCore core)
        {
            _core = core;
        }
    }
}
