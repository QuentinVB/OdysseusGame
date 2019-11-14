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

        public override string Display => "Nothing else than the emptiness of space...";

        public override string Choices { get { Active = false; return ""; } }

        public override void Answer(string answer)
        {
            throw new NotImplementedException();
        }
    }
}
