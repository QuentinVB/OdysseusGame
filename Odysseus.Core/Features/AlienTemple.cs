using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    class AlienTemple : Feature
    {
        Cargo _reward;
        int _loss;

        public AlienTemple(GameCore core) : base(core)
        {
            _reward = new Cargo((Atom)Core.Random.Next(6, 11), Core.Random.NextDouble() * 50 +50);
            //_price = Math.Round(Core.Random.NextDouble() * 200);
            _loss = Core.Random.Next(1, 5);

            Choices = new string[2]
            {
                "Send 4 crew to investigate.",
                "Leave",
            };
            Results = new string[3]
            {
                "You leave the area, too dangerous..",
                $"Your crew found some {Math.Round(_reward.Quantity)} of {_reward.Type}",
                $"The temple was full of traps, you loose {_loss} crewmate."
        };
        }

        public override string Display => "An alien temple lies down beneath the surface of this planet.";

        public override void Answer(int choiceIndex)
        {
            if (choiceIndex == 0 && ResultIndex == 0) {

                if(Core.Random.NextDouble()>0.6)
                {
                    ResultIndex = 1;
                    Core.PlayerShip.LoadCargo(_reward);
                }
                else
                {
                    ResultIndex = 2;
                    Core.PlayerShip.RemoveCrew(_loss);
                }
            }
            
             if (choiceIndex >= 0) Active = false;
             
        }  
    }
}
