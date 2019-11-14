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
        }

        public override string Display => "An shop space station, your oxygen is refilled while you peek to the traders cargos";

        public override string Choices
        {
            get
            {
                Core.PlayerShip.FillOxygen();

                string choices = "";

                

                for (int i = 0; i < _cargoBay.Count; i++)
                {
                    choices += $" {i}. Buy {_cargoBay[i]} for {Math.Round(_cargoBay[i].Price* _sellFactor)}\n";
                }

                for (int j = 0; j < Core.PlayerShip.Cargo.Length; j++)
                {
                    if(Core.PlayerShip.Cargo[j].Quantity>0) choices += $" {j+ _cargoBay.Count}. Sell {Core.PlayerShip.Cargo[j]} for {Math.Round(Core.PlayerShip.Cargo[j].Price* _buyFactor)} \n";
                }

                return choices;
            }
        }

        public override void Answer(string answer)
        {
            if(Int32.TryParse(answer, out int castAnswer))
            {
                if (castAnswer >= 0 && castAnswer < _cargoBay.Count)
                {
                    Core.PlayerShip.LoadCargo(_cargoBay[castAnswer]);
                    Core.PlayerShip.LoseMoney(Math.Round(_cargoBay[castAnswer].Price * _sellFactor));
                }

                if (castAnswer >= _cargoBay.Count && castAnswer < Core.PlayerShip.Cargo.Length)
                {
                    Core.PlayerShip.GainMoney(Math.Round(Core.PlayerShip.Cargo[castAnswer - _cargoBay.Count].Price * _buyFactor));

                    Core.PlayerShip.UnLoadCargo(castAnswer - _cargoBay.Count);

                }
            }

            

            Active = false;
        }
    }
}
