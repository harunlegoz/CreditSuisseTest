using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditSuisseTest.Library;

namespace CreditSuisseTest.Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        VendingMachine _vendingMachine;

        [TestInitialize]
        public void Initialize()
        {
            _vendingMachine = new VendingMachine();
        }

        [TestMethod]
        public void Should_Initial_Number_Be_25_When_First_Initialized()
        {
            // Assert
            Assert.AreEqual(25, _vendingMachine.Count);
        }

        [TestMethod]
        public void Should_Successfully_Charge_When_Vending_One_Item()
        {
            // Arrange
            var account = new Account(100);
            var cashCard = new CashCard(account, "1234");

            // Act
            _vendingMachine.Vend(1, cashCard, "1234");

            // Assert
            Assert.AreEqual(24, _vendingMachine.Count);
            Assert.AreEqual(50, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughBalanceException))]
        public void Should_Fail_When_Not_Enough_Balance()
        {
            // Arrange
            var account = new Account(100);
            var cashCard = new CashCard(account, "1234");

            // Act
            _vendingMachine.Vend(3, cashCard, "1234");
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughItemsException))]
        public void Should_Fail_When_Not_Enough_Items()
        {
            // Arrange
            var account = new Account(100);
            var cashCard = new CashCard(account, "1234");

            _vendingMachine.Vend(30, cashCard, "1234");
        }
    }
}
