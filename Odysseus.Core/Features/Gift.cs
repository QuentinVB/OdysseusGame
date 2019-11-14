using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public class Gift : Feature
    {
        GameCore _core;
        private Cargo _cargo ;



        public Gift(GameCore core) : base(core)
        {
            this._core = core;
            _cargo = _core.GenerateCargo();
        }

        public override string Display => $"A cargo is slowly drifting in space, a scan reveal {Math.Round(_cargo.Quantity)} of {_cargo.Type}";

        public override string Choices => $" 1. Pick the cargo \n 2. Leave";

        public override void Answer(string answer)
        {
            if(answer =="1")_core.PlayerShip.LoadCargo(_cargo);
            Active = false;
        }
    }
}
