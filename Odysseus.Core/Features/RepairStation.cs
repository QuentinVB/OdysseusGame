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
        }

        public override string Display => "An automated repair station, but it's not free...";

        public override string Choices => $" 1. Repair 20 hull points for {_price} \n 2. Leave";

        public override void Answer(string answer)
        {
            if (answer == "1") {
                Core.PlayerShip.RepairDamage(20);
                Core.PlayerShip.LoseMoney(Math.Round(_price));
            }
            Active = false;
        }

       
    }
}
