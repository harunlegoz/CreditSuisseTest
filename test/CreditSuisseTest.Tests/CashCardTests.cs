using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditSuisseTest.Library;

namespace CreditSuisseTest.Tests
{
    [TestClass]
    public class CashCardTests
    {
        [TestMethod]
        public void Should_Charge_Successfully_When_PIN_Is_Correct()
        {
            // Arrange
            var account = new Account(200);
            var cashCard1 = new CashCard(account, "1234");
            var cashCard2 = new CashCard(account, "1234");

            // Act
            cashCard1.EnterPIN("1234");
            cashCard1.Charge(50);
            cashCard2.EnterPIN("1234");
            cashCard2.Charge(50);

            // Assert
            Assert.AreEqual(100, account.Balance);
        }

        [ExpectedException(typeof(UnauthorizedCardException))]
        [TestMethod]
        public void Should_Fail_When_PIN_Is_Not_Provided()
        {
            // Arrange
            var account = new Account(100);
            var cashCard = new CashCard(account, "1234");

            // Act
            cashCard.Charge(50);
        }

        [ExpectedException(typeof(UnauthorizedCardException))]
        [TestMethod]
        public void Should_Fail_When_PIN_Is_Incorrect()
        {
            // Arrange
            var account = new Account(100);
            var cashCard = new CashCard(account, "1234");

            // Act
            cashCard.EnterPIN("5678");
            cashCard.Charge(50);
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughBalanceException))]
        public void Should_Fail_When_Not_Enough_Balance_In_Account()
        {
            // Arrange
            var account = new Account(30);
            var cashCard = new CashCard(account, "1234");

            // Act
            cashCard.EnterPIN("1234");
            cashCard.Charge(50);
        }
    }
}
