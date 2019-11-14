using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public class MetallicAsteroid : Feature
    {
        Cargo _cargo;


        public MetallicAsteroid(GameCore core) : base(core)
        {
            _cargo = new Cargo((Atom)Core.Random.Next(6,11), Core.Random.NextDouble()*100);
            Choices = new string[2]
            {
                $"Load a tank with {Math.Round(_cargo.Quantity)} of {_cargo.Type}",
                "Leave",
            };
            Results = new string[2]
            {
                "You leave the asteroid.",
                "You leave the asteroid with some rich metal aboard !"
            };
        }

        public override string Display => $"A very rich metallic Asteroid, you can manually harvest some {_cargo.Type}. ";

        public override void Answer(int answer)
        {
            if (answer == 0)
            {
                ResultIndex = 1;
                Core.PlayerShip.LoadCargo(_cargo);
                Core.PlayerShip.LoseMoney(Math.Round(_cargo.Price * 0.1));
            }
            if (answer > 0) Active = false;
        }
    }
}
