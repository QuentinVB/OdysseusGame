using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    class ShopCargo : Feature
    {
        readonly List<Cargo> _cargoBay;
        double _sellFactor;
        double _buyFactor;

        public ShopCargo(GameCore core) : base(core)
        {
            _cargoBay = new List<Cargo>();

            _sellFactor = Core.Random.NextDouble() * 2;
            _buyFactor = Core.Random.NextDouble() * 2;

            for (int i = 0; i < core.Random.Next(1,5); i++)
            {
                _cargoBay.Add(core.GenerateCargo());
            }

            
            Results = new string[3]
            {
                "You leave the noisy market",
                $"You load the goods and leave",
                $"You transfert the cargo and leave",

            };
        }

        public override string Display => "An shop space station, your oxygen is refilled while you peek to the traders cargos";  
        public override string[] Choices
        {
            get { 
                 string[] table=new string[_cargoBay.Count + Core.PlayerShip.CargoIdx+1];

                for (int i = 0; i < _cargoBay.Count; i++)
                {
                    table[i] = $"Buy {_cargoBay[i]} for {Math.Round(_cargoBay[i].Price * _sellFactor)}";
                }

                //TODO: optimization
                for (int j = 0; j < Core.PlayerShip.Cargo.Length; j++)
                {
                    if (Core.PlayerShip.Cargo[j].Quantity > 0)
                        table[_cargoBay.Count + j] = $"Sell {Core.PlayerShip.Cargo[j]} for {Math.Round(Core.PlayerShip.Cargo[j].Price * _buyFactor)}";
                }
                table[table.Length - 1] = "Leave";
                return table;
            }
        }
        public override void Answer(int answer)
        {
            Core.PlayerShip.FillOxygen();
            
            if (answer >= 0 && answer < _cargoBay.Count)
            {
                ResultIndex = 1;
                Core.PlayerShip.LoadCargo(_cargoBay[answer]);
                Core.PlayerShip.LoseMoney(Math.Round(_cargoBay[answer].Price * _sellFactor));
            }

            if (answer >= _cargoBay.Count && answer < _cargoBay.Count+Core.PlayerShip.Cargo.Length)
            {
                ResultIndex = 2;

                Core.PlayerShip.GainMoney(Math.Round(Core.PlayerShip.Cargo[answer - _cargoBay.Count].Price * _buyFactor));
                Core.PlayerShip.UnLoadCargo(answer - _cargoBay.Count);
            }

            ResultIndex = 0;

            Active = false;
        }
    }
}
