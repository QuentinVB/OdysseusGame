using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public class AlienTech : Feature
    {

        public AlienTech(GameCore core) : base(core)
        {
            //enum for target (hull/fuel eff/etc)
            //_price = Math.Round(Core.Random.NextDouble() * 50);
            Choices = new string[2]
            {
                "Plug the equipement to the engine",
                "Leave"
            };
            Results = new string[2]
            {
                "The artifact drift by in to darkness",
                "The ship fuel consumption is increased"
            };
        }

        public override string Display => $"A strange alien equipement, the scans reveals it will increase the engine fuel consumption by 10%";

        public override void Answer(int choiceIndex)
        {
            if (choiceIndex == 0)
            {
                ResultIndex = 1;

                Core.PlayerShip.IncreaseEngine(0.1);
            }
            if (choiceIndex >=0)  Active = false;
        }
    }
}
