using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    class AlienTemple : Feature
    {
        int _state=0;
        Cargo _reward;
        int _loss;

        public AlienTemple(GameCore core) : base(core)
        {
            _reward = new Cargo((Atom)Core.Random.Next(6, 11), Core.Random.NextDouble() * 50 +50);
            //_price = Math.Round(Core.Random.NextDouble() * 200);
            _loss = Core.Random.Next(1, 5);
        }

        public override string Display
        {
            get
            {
                if (_state == 0) {return "An alien temple lies down beneath the surface of this planet."; }
                if (_state == 1) {return $"Your crew found some {Math.Round(_reward.Quantity)} of {_reward.Type}";}
                if (_state == 2) {return $"The temple was full of traps, you lost {_loss} crewmate."; }
                return "Nothing ??";
            }
        }

        public override string Choices => _state == 0?$" 1. Send 4 crew to investigate. \n 2. Leave":" 1. Continue";

        public override void Answer(string answer)
        {
            if (answer == "1"&&_state==0) {

                if(Core.Random.NextDouble()>0.6)
                {
                    _state = 1;
                    Core.PlayerShip.LoadCargo(_reward);
                }
                else
                {
                    _state = 2;
                    Core.PlayerShip.RemoveCrew(_loss);
                }
            }
            else
            {
                Active = false;
            }
            
            
        }

       
    }
}
