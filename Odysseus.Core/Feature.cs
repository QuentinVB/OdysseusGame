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
        private string[] _choices;
        private string[] _results ;
        private int _resultIndex=0;

        public abstract string Display { get; }
        public virtual string[] Choices { get { return _choices ?? new string[0]; } protected set => _choices = value; }
        public bool Active { get => _active; protected set => _active = value; }
        protected GameCore Core => _core;

        public string Result => _results[ResultIndex] ?? "" ;
        protected string[] Results { get => _results ?? new string[1] { "Continue" };  set => _results = value; }
        internal int ResultIndex { get=> _resultIndex; set => _resultIndex=value; }

        public abstract void Answer(int choiceIndex);

        public Feature(GameCore core)
        {
            _core = core;
            if (_results == null) { _results = new string[1] { "Continue" }; }
        }
    }
}
