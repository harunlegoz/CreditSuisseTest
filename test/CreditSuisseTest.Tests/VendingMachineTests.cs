using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditSuisseTest.Library;

namespace CreditSuisseTest.Tests
{
    [TestClass]
    public class VendingMachineTests
    {
        [TestMethod]
        public void Should_Initial_Number_Be_25_When_First_Initialized()
        {
            // Arrange
            var vendingMachine = new VendingMachine();

            // Assert
            Assert.AreEqual(25, vendingMachine.Count);
        }

        [TestMethod]
        public void Should_Successfully_Charge_When_Vending_One_Item()
        {
            // Arrange
            var vendingMachine = new VendingMachine();
            var account = new Account(100);
            var cashCard = new CashCard(account, "1234");

            // Act
            vendingMachine.Vend(1, cashCard, "1234");

            // Assert
            Assert.AreEqual(24, vendingMachine.Count);
            Assert.AreEqual(50, account.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughBalanceException))]
        public void Should_Fail_When_Not_Enough_Balance()
        {
            // Arrange
            var vendingMachine = new VendingMachine();
            var account = new Account(100);
            var cashCard = new CashCard(account, "1234");

            // Act
            vendingMachine.Vend(3, cashCard, "1234");
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughItemsException))]
        public void Should_Fail_When_Not_Enough_Items()
        {
            // Arrange
            var vendingMachine = new VendingMachine();
            var account = new Account(100);
            var cashCard = new CashCard(account, "1234");

            vendingMachine.Vend(30, cashCard, "1234");
        }
    }
}
