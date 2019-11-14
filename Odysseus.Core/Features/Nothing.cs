using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    class Nothing : Feature
    {
        public Nothing(GameCore core) : base(core)
        {
        }
        //TODO : Add more depressing sentences
        public override string Display => "Nothing else than the emptiness of space...";

        public override void Answer(int answer)
        {
            Active = false;
        }
    }
}
