using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odysseus.Core
{
    public struct Cargo
    {
        Atom _type;
        double _quantity;

        public Cargo(Atom type, double quantity)
        {
            _type = type;
            _quantity = quantity;
        }

        public Atom Type { get => _type; set => _type = value; }
        public double Quantity { get => _quantity; set => _quantity = value; }
        public double Price { get => Math.Round(_quantity *((int)_type) +1 );  }

        public override string ToString()
        {
            if (Quantity > 0) return $"[{Math.Round(Quantity,2)} {Type}]";
            return "[]";
        }
    }
    public enum Atom
    {
        Vaccum,
        Hydrogen,
        Helium,
        Oxygen,
        Carbon,
        Silicium,
        Iron,
        Aluminium,
        Titanium,
        Tungsten,
        Copper,
        Gold,
    }
    
    public class GameCore
    {
        Ship _playerShip;
        StellarSystem _root;
        StellarSystem _nextLeft;
        StellarSystem _nextRight;
        double _galaxyWidth;
        double _galaxyHeight;
        private Random _random;

        GalaxyGenerator _galaxyGenerator;

        public GameCore(int depth)
        {
            _galaxyWidth = 100;
            _galaxyHeight = 100;

            _random =  new Random();

            _galaxyGenerator = new GalaxyGenerator(this, depth);

            _root = _galaxyGenerator.GetRoot();

            _playerShip = new Ship(_root);
        }

       

        public double GalaxyWidth { get => _galaxyWidth; }
        public double GalaxyHeight { get => _galaxyHeight; }
        public Ship PlayerShip { get => _playerShip; }
        public StellarSystem Root { get => _root; }
        public Random Random { get => _random; }
        public StellarSystem NextLeft { get => _nextLeft; private set => _nextLeft = value; }
        public StellarSystem NextRight { get => _nextRight; private set => _nextRight = value; }
        public bool NextSystemAreGenerated { get; private set; }

        public Cargo GenerateCargo()
        {
            return new Cargo((Atom)Random.Next(1, 11), Random.NextDouble() * 100);
        }

        public void GenerateNextDestinations()
        {
            if(!NextSystemAreGenerated)
            {
                NextLeft = _galaxyGenerator.GetStellarSystem();
                NextRight = _galaxyGenerator.GetStellarSystem();
                NextSystemAreGenerated = true;
            }           
        }

        public void WarpShipTo(StellarSystem destination)
        {
            _playerShip.WarpTo(destination);
            NextSystemAreGenerated = false;
        }
    }
}
