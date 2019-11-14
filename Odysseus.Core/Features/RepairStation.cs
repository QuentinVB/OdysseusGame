using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    class RepairStation : Feature
    {
        double _price;

        public RepairStation(GameCore core) : base(core)
        {
            _price = Math.Round(Core.Random.NextDouble() * 50);
            Choices = new string[2]
            {
                $"Repair 20 hull points for {_price}.",
                "Leave",
            };
            Results = new string[2]
            {
                "You left the robots in their lair and fly away",
                $"Your ship hull is repaired",              
            };
        }

        public override string Display => "An automated repair station, but it's not free...";

        public override void Answer(int answer)
        {
            if (answer ==0) {
                ResultIndex = 1;
                Core.PlayerShip.RepairDamage(20);
                Core.PlayerShip.LoseMoney(Math.Round(_price));
            }

            if (answer >= 0) Active = false;
        }

       
    }
}
