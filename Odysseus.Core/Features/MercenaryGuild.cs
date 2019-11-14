using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    class MercenaryGuild : Feature
    {
        double _price;

        public MercenaryGuild(GameCore core) : base(core)
        {
            _price = Math.Round(Core.Random.NextDouble() * 200);
        }

        public override string Display => "A bar with available crew and adventurer-for-rent, they looks awsome but it's not free... \n Your oxygen is refilled while you talk with theses wanabe space cowboy";

        public override string Choices => $" 1. Hire 1 crew for {_price} \n 2. Leave";

        public override void Answer(string answer)
        {
            Core.PlayerShip.FillOxygen();

            if (answer == "1") {
                Core.PlayerShip.BoardCrew(1);
                Core.PlayerShip.LoseMoney(Math.Round(_price));
            }
            Active = false;
        }

       
    }
}
