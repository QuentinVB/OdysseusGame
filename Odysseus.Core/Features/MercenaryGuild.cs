using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public class MercenaryGuild : Feature
    {
        double _price;

        public MercenaryGuild(GameCore core) : base(core)
        {
            _price = Math.Round(Core.Random.NextDouble() * 200);

            Choices = new string[2]
            {
                $"Hire 1 crewmate for {_price}",
                "Leave",
            };
            Results = new string[2]
            {
                "You leave the bar.",
                "You leave the bar with a new comerade/employee on board !"
            };
        }

        public override string Display => "A bar with available crew and adventurer-for-rent, they looks awsome but it's not free... \n Your oxygen is refilled while you talk with theses wanabe space cowboy";

        public override void Answer(int answer)
        {
            Core.PlayerShip.FillOxygen();

            if (answer == 0) {
                ResultIndex = 1;
                Core.PlayerShip.BoardCrew(1);
                Core.PlayerShip.LoseMoney(Math.Round(_price));
            }
            if (answer >= 0) Active = false;
        }

       
    }
}
