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
        readonly int _systemMaxAmount;

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
                new Quest(gameCore, QuestType.Start)//new AsteroidField(gameCore)//
            );          

            return root;
        }

        public StellarSystem GetStellarSystem()
        {
            _systemCount++;
            StellarObject type = (StellarObject)gameCore.Random.Next(0, 11);
            StellarSystem item = new StellarSystem(
                type,
                gameCore.Random.NextDouble() * 100,
                new Vector2(
                    (gameCore.Random.NextDouble() * gameCore.GalaxyWidth ) - gameCore.GalaxyWidth/2, 
                    (gameCore.Random.NextDouble() * gameCore.GalaxyHeight) - gameCore.GalaxyHeight/2
                    ),
                (_systemCount < _systemMaxAmount) ? GetFeature(type) : new Quest(gameCore, QuestType.End)
            );
         
            return item;
        }

        private Feature GetFeature(StellarObject type)
        {
            //TODO : generate feature according to the star type
            /*
            switch (type)
            {
                case StellarObject.BrownDwarf:
                    break;
                case StellarObject.WhiteDwarf:
                    break;
                case StellarObject.RedDwarf:
                    break;
                case StellarObject.YellowDwarf:
                    break;
                case StellarObject.RedGiant:
                    break;
                case StellarObject.RedSuperGiant:
                    break;
                case StellarObject.BlueSuperGiant:
                    break;
                case StellarObject.BinaryStar:
                    break;
                case StellarObject.NeutronStar:
                    break;
                case StellarObject.BlackHole:
                    break;
                case StellarObject.RoguePlanet:
                    break;
                default:
                    break;
            }
            */
            /*
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
            */
            
            return new Gift(gameCore);
        }
    }
}
