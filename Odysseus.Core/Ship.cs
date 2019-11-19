using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public class Ship
    {
        public readonly int FUELCONSUMPTION = 5;
        public readonly int FUELMAX = 100;

        double _money = 100;

        bool _isAlive = true;
        double _fuel = 100;
        double _fuelEfficiency = 0.8;
        double _hullFactor = 0.9;
        int _hull = 100;
        int _oxygenSupply = 100;
        Atom _fuelType = Atom.Hydrogen;
        double _lifeSupportFactor = 0.4;
        int _crew = 10;

        Cargo[] _cargoBay;
        int _cargoIdx=0;

        StellarSystem _orbiting;

        public Ship(StellarSystem orbiting)
        {
            _orbiting = orbiting;
            _cargoBay = new Cargo[10];
        }
        public StellarSystem Orbiting { get => _orbiting; set => _orbiting = value; }

        internal void IncreaseEngine(double ratio)
        {
            _fuelEfficiency *= 1 - ratio;
        }

        internal void RemoveCrew(int crew)
        {
            _crew -= crew;
        }

        public bool IsAlive { get => _isAlive; }
        public Cargo[] Cargo { get => _cargoBay; }
        public double Money { get => _money; }
        public Atom FuelType { get => _fuelType; }
        public double Fuel { get => _fuel; }
        internal int CargoIdx { get => _cargoIdx;  }

        internal void BoardCrew(int crew)
        {
            _crew += crew;
        }
        internal void FillOxygen()
        {
            _oxygenSupply = 100;
        }

        public void Refuel(double fuel)
        {
            _fuel = Math.Min(FUELMAX, _fuel + fuel);
        }

        public void GainMoney(double money)
        {
            _money += money;
        }

        public void LoseMoney(double money)
        {
            _money -= money;
        }

        internal int TakeDamage(int damages)
        {
            _hull -= (int)Math.Round(damages*_hullFactor);
            return damages;
        }

        internal void RepairDamage(int fix)
        {
            _hull = Math.Min( 100 , _hull + fix);
        }

        public bool LoadCargo(Cargo cargo)
        {
            if (_cargoIdx > _cargoBay.Length-1) return false;
            //TODO : out of range
            _cargoBay[_cargoIdx] = cargo;
            _cargoIdx++;
            return true;
        }

        public Cargo UnLoadCargo(int idx)
        {
            if (idx > _cargoBay.Length) throw new IndexOutOfRangeException();
            if (idx < 0) throw new InvalidOperationException();
            Cargo cargo = _cargoBay[idx] ;

            for (int i = idx; i+1 < _cargoBay.Length; i++)
            {
                _cargoBay[i] = _cargoBay[i + 1];
            }

            _cargoIdx--;
            return cargo;
        }

        public void WarpTo(StellarSystem destination)
        {
            if (!IsAlive) return;
            if( _fuel- FUELCONSUMPTION*_fuelEfficiency< 0) throw new InvalidOperationException();

            _fuel -= FUELCONSUMPTION * _fuelEfficiency;
            _orbiting = destination;
        }

        public void UpdateGameTurn()
        {
            if (_crew <= 0 || _hull<=0 || _fuel - FUELCONSUMPTION * _fuelEfficiency < 1 )
            {
                _isAlive = false;
                return;
            }

            if (_oxygenSupply - _lifeSupportFactor * _crew < 0) _crew--;
            _oxygenSupply -= (int)(_lifeSupportFactor * _crew);

        }

        public override string ToString()
        {
            string firstString = $"Space ship orbiting {_orbiting}\n" +
                $"Fuel : {Math.Round(_fuel,2)} | efficiency : {_fuelEfficiency} | using {_fuelType}\n" +
                $"Hull : {_hull} | efficiency : {_hullFactor}\n" +
                $"Oxygen : {_oxygenSupply} | efficiency : {_lifeSupportFactor}\n" +
                $"Crew alive :{_crew} with {_money} credits\n";
            string cargoString = "Cargo: ";
            for (int i = 0; i < _cargoBay.Length; i++)
            {
                cargoString += _cargoBay[i].ToString();
                if (i ==_cargoBay.Length / 2) cargoString += "\n       ";
            }
            return firstString + "\n" + cargoString+ "\n";
        }
    }
}
