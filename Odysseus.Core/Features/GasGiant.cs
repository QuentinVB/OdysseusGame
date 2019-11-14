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
        }

        public override string Display => $"A gas giant with automated mining station harversting {_cargo.Type}. ";

        public override string Choices => $" 1. Load a tank with {Math.Round(_cargo.Quantity)} of {_cargo.Type} for the price of {Math.Round(_cargo.Price * 0.1)} \n 2. Leave";

        public override void Answer(string answer)
        {
            if (answer == "1")
            {
                Core.PlayerShip.LoadCargo(_cargo);
                Core.PlayerShip.LoseMoney(Math.Round(_cargo.Price * 0.1));
            }
            Active = false;
        }
    }
}
