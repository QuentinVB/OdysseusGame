using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    class AsteroidField : Feature
    {

        public AsteroidField(GameCore core) : base(core)
        {
        }

        public override string Display => "ALERT ! This system is full of asteroids !";

        public override string Choices { get {
                Active = false;
                return $"Your ship took {Core.PlayerShip.TakeDamage(Core.Random.Next(5, 12))} damages.";
            } }

        public override void Answer(string answer)
        {
            throw new NotImplementedException();
        }
    }
}
