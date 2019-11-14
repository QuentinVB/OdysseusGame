using System;

namespace Odysseus.Core
{
    public enum StellarObject
    {
        BrownDwarf,
        WhiteDwarf,
        RedDwarf,
        YellowDwarf,
        RedGiant,
        RedSuperGiant,
        BlueSuperGiant,
        BinaryStar,
        NeutronStar,
        BlackHole,
        RoguePlanet,
    }
    public class StellarSystem
    {

        private StellarObject _type;
        private double _mass;

        private Feature _feature;

        Vector2 _position;

        internal StellarSystem(StellarObject type, double mass, Vector2 position,Feature feature)
        {
            this._type = type;
            this._mass = mass;
            this._position = position;
            this._feature = feature;
        }

        public StellarObject Type { get => _type;  }
        public double Mass { get => _mass; }
        internal Vector2 Position { get => _position;  }
        public Feature Feature { get => _feature;  }

        public override string ToString()
        {
            return $"a {Type}, of {Math.Round(Mass)}Ms at {Position}";
        }
    }
}