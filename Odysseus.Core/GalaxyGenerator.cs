using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public class GalaxyGenerator
    {
        private GameCore gameCore;
        int _systemCount;
        int _systemMaxAmount;

        public GalaxyGenerator(GameCore gameCore, int systemMaxDepth)
        {
            this._systemCount = 0;
            this._systemMaxAmount = systemMaxDepth * 2;
            this.gameCore = gameCore;
        }
   
        public StellarSystem GetRoot()
        {
            StellarSystem root = new StellarSystem(
                StellarObject.YellowDwarf,
                gameCore.Random.NextDouble() * 100,
                new Vector2(0, 0),
                new GasGiant(gameCore)//new Quest(gameCore, QuestType.Start)
            );          

            return root;
        }

        public StellarSystem GetStellarSystem()
        {
            _systemCount++;
            StellarSystem item = new StellarSystem(
                (StellarObject)gameCore.Random.Next(0, 11),
                gameCore.Random.NextDouble() * 100,
                new Vector2(gameCore.Random.NextDouble() * gameCore.GalaxyWidth, gameCore.Random.NextDouble() * gameCore.GalaxyHeight),
                (_systemCount < _systemMaxAmount) ? GetFeature(): new Quest(gameCore, QuestType.End)
            );
         
            return item;
        }

        private Feature GetFeature()
        {

            switch (gameCore.Random.Next(0, 11))
            {
                case 0: return new Gift(gameCore);
                case 1: return new Nothing(gameCore);
                case 2: return new ShopCargo(gameCore);
                case 3: return new AsteroidField(gameCore);
                case 4: return new RepairStation(gameCore);
                case 5: return new ReffineryStation(gameCore);
                case 6: return new GasGiant(gameCore);
                case 7: return new MercenaryGuild(gameCore);
                case 8: return new AlienTech(gameCore);
                case 9: return new MetallicAsteroid(gameCore);
                case 10: return new AlienTemple(gameCore);
                default:
                    break;
            }
            
            
            return new Nothing(gameCore);
        }
    }
}
