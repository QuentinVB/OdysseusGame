using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public class AlienTech : Feature
    {
        GameCore _core;

        public AlienTech(GameCore core) : base(core)
        {
            this._core = core;
            //enum for target (hull/fuel eff/etc)
            //_price = Math.Round(Core.Random.NextDouble() * 50);

        }

        public override string Display => $"A strange alien equipement, the scans reveals it will increase the engine fuel consumption by 10%";

        public override string Choices => $" 1. Plug the equipement to the engine \n 2. Leave";

        public override void Answer(string answer)
        {
            if(answer =="1")_core.PlayerShip.IncreaseEngine(0.1);
            Active = false;
        }
    }
}
