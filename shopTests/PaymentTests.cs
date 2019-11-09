using Microsoft.VisualStudio.TestTools.UnitTesting;
using shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shop.CustomerInfo;
using static shop.Payment;

namespace shop.Tests
{
    [TestClass()]
    public class PaymentTests
    {
        // method name syntax: 'subject'_'condition'_'event'

        // opdr: an order should only be fulfilled if payment is successful
        [TestMethod()]
        public void Commit_ChangingPaymentState_Failed()
        {
            // Arrange
            Payment.state = PaymentState.Pending;
            PaymentMethod betaalwijze = PaymentMethod.DebitCard;

            // Act
            Payment.Commit(betaalwijze, 69f, false);
            var value = Payment.state;

            // Assert
            Assert.AreEqual(PaymentState.Failed, value);
        }

        [TestMethod()]
        public void Commit_ChangingPaymentState_Completed()
        {
            // Arrange
            Payment.state = PaymentState.Pending;
            PaymentMethod betaalwijze = PaymentMethod.DebitCard;

            // Act
            Payment.Commit(betaalwijze, 69f, true);
            var value = Payment.state;

            // Assert
            Assert.AreEqual(PaymentState.Completed, value);
        }
    }
}