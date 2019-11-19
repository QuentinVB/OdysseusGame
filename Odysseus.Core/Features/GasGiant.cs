using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public class GasGiant : Feature
    {
        GameCore _core;
        Cargo _cargo;


        public GasGiant(GameCore core) : base(core)
        {
            this._core = core;
            _cargo = new Cargo((Atom)Core.Random.Next(1,3), Core.Random.NextDouble()*100);


            Choices = new string[2]
            {
                $"Load a tank with {Math.Round(_cargo.Quantity)} of {_cargo.Type} for the price of {Math.Round(_cargo.Price * 0.1)}",
                "Leave"
            }; 
            Results = new string[2]
            {
                "You left the harvesting station.",
                $"Your ship cargo gained a tank with {Math.Round(_cargo.Quantity)} of {_cargo.Type}"
            };
        }

        public override string Display => $"A gas giant with automated mining station harversting {_cargo.Type}. ";

        public override void Answer(int answer)
        {
            if (answer == 0)
            {
                ResultIndex = 1;
                Core.PlayerShip.LoadCargo(_cargo);
                Core.PlayerShip.LoseMoney(Math.Round(_cargo.Price * 0.1));
            }

            if (answer >= 0) Active = false;
        }
    }
}
