using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Odysseus.Core;

namespace Tests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void TestLoadShip()
        {
            //arrange
            GameCore sut = new GameCore(10);
            Cargo cargo = sut.GenerateCargo();
            //act

            sut.PlayerShip.LoadCargo(cargo);

            //assert

            Assert.AreEqual(sut.PlayerShip.Cargo[0], cargo);
        }
        [TestMethod]
        public void TestUnLoadShip()
        {
            //arrange
            GameCore sut = new GameCore(10);
            Cargo cargo = sut.GenerateCargo();
            sut.PlayerShip.LoadCargo(cargo);

            //act
            sut.PlayerShip.UnLoadCargo(0);

            //assert

            Assert.AreNotEqual(sut.PlayerShip.Cargo[0], cargo);
        }
        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        public void TestLoadUnloadMany(int amount)
        {
            //arrange
            GameCore sut = new GameCore(10);

            Cargo[] cargos = new Cargo[amount];
            for (int i = 0; i < amount; i++)
            {
                cargos[i] = sut.GenerateCargo();
            }





            //act
            for (int i = 0; i < amount; i++)
            {
                sut.PlayerShip.LoadCargo(cargos[i]);
            }

            for (int i = 0; i < amount; i++)
            {
                sut.PlayerShip.UnLoadCargo(0); ;
            }

            

            //assert
            
            Assert.AreNotEqual(sut.PlayerShip.Cargo[0], cargos[0]);
        }
    }
}
