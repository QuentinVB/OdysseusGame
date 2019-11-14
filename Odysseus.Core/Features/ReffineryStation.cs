using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    class ReffineryStation : Feature
    {
        double _price;
        int _cargoIdx=-1;

        public ReffineryStation(GameCore core) : base(core)
        {
            _price = Math.Round(Core.Random.NextDouble() * 50);

            
            
        }

        private bool HasRightCargo { get {
                _cargoIdx = -1;
                foreach (Cargo cargo in Core.PlayerShip.Cargo)
                {
                    _cargoIdx++;
                    if (cargo.Type == Core.PlayerShip.FuelType) { return true;  }
                }
                return false;
            } }

        public override string Display => "An automated fuel reffinery station, just plug the right element and it refill your tanks (at half the rate) !";

        public override string Choices => HasRightCargo ? $" 1. Refuel using {Core.PlayerShip.FuelType} aboard. \n 2. Leave"  : $" 1. Leave";

        public override void Answer(string answer)
        {
            if(HasRightCargo && answer == "1" )
            {
                if((Core.PlayerShip.Cargo[_cargoIdx].Quantity / 2) +Core.PlayerShip.Fuel > Core.PlayerShip.FUELMAX)
                {
                    double fuelDifference = Core.PlayerShip.FUELMAX - Core.PlayerShip.Fuel;
                    Core.PlayerShip.Cargo[_cargoIdx].Quantity -= 2 * fuelDifference;

                    Core.PlayerShip.Refuel(Core.PlayerShip.FUELMAX);
                }
                else
                {
                    Core.PlayerShip.Refuel(Core.PlayerShip.Cargo[_cargoIdx].Quantity / 2);
                    Core.PlayerShip.UnLoadCargo(_cargoIdx);
                }   
            }
            
            Active = false;
        }

       
    }
}
