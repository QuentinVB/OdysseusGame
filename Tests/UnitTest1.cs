using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odysseus.Core;

namespace Tests
{
    [TestClass]
    public class GalaxyTests
    {
        [TestMethod]
        public void GetSystems()
        {
            //arrange
            GameCore core = new GameCore(10);
            GalaxyGenerator sut = new GalaxyGenerator(core,10);
            //act
            var stellarSystem = sut.GetRoot();
            //assert
            Console.WriteLine("test");
        }
    }
}
