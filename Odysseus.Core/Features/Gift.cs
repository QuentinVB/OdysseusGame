using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public class Gift : Feature
    {
        private Cargo _cargo;

        public Gift(GameCore core) : base(core)
        {
            _cargo = Core.GenerateCargo();

            Choices = new string[2]
            {
                "Search the ruins for cargo.",
                "Leave",
            };
            Results = new string[2]
            {
                "You left the damaged graveyard forever alone in space...",
                $"You gain a cargo of  {Math.Round(_cargo.Quantity)} {_cargo.Type}s"
            };
        }

        public override string Display => $"An abandonned space station is slowly drifting in space, a scan reveal {Math.Round(_cargo.Quantity)} of {_cargo.Type}";

        public override void Answer(int answer)
        {
            if (answer == 0)
            {
                ResultIndex = 1;
                Core.PlayerShip.LoadCargo(_cargo);
            }
            if (answer >= 0) Active = false;
        }
    }
}
