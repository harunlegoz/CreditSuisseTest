using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CreditSuisseTest.Library;
using System.Threading.Tasks;

namespace CreditSuisseTest.Tests
{
    [TestClass]
    public class CashCardTests
    {
        Account _account = null;
        CashCard _cashCard1 = null;
        CashCard _cashCard2 = null;

        [TestInitialize]
        public void Initialize()
        {
            _account = new Account(200);
            _cashCard1 = new CashCard(_account, "1234");
            _cashCard2 = new CashCard(_account, "1234");
        }

        [TestMethod]
        public void Should_Charge_Successfully_When_PIN_Is_Correct()
        {
            // Act
            _cashCard1.EnterPIN("1234");
            _cashCard1.Charge(50);
            _cashCard2.EnterPIN("1234");
            _cashCard2.Charge(50);

            // Assert
            Assert.AreEqual(100, _account.Balance);
        }

        [ExpectedException(typeof(InvalidAmountException))]
        [TestMethod]
        public void Should_Fail_When_NegativeAmountCharged()
        {
            // Act
            _cashCard1.EnterPIN("1234");
            _cashCard1.Charge(-50);
        }

        [ExpectedException(typeof(UnauthorizedCardException))]
        [TestMethod]
        public void Should_Fail_When_PIN_Is_Not_Provided()
        {
            // Act
            _cashCard1.Charge(50);
        }

        [ExpectedException(typeof(UnauthorizedCardException))]
        [TestMethod]
        public void Should_Fail_When_PIN_Is_Incorrect()
        {
            // Act
            _cashCard1.EnterPIN("5678");
            _cashCard1.Charge(50);
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughBalanceException))]
        public void Should_Fail_When_Not_Enough_Balance_In_Account()
        {
            // Act
            _cashCard1.EnterPIN("1234");
            _cashCard1.Charge(250);
        }

        [TestMethod]
        public void Should_Charge_Successfully_When_Parallel_Called_And_PIN_Is_Correct()
        {
            // Act
            Parallel.Invoke(
                () =>
                {
                    _cashCard1.EnterPIN("1234");
                    _cashCard1.Charge(50);
                },
                () =>
                {
                    _cashCard2.EnterPIN("1234");
                    _cashCard2.Charge(50);
                }
            );

            // Assert
            Assert.AreEqual(100, _account.Balance);
        }
    }
}
