using Microsoft.VisualStudio.TestTools.UnitTesting;
using shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shop.Payment;

namespace shop.Tests
{
    [TestClass()]
    public class SaleTests
    {
        // method name syntax: 'subject'_'condition'_'event'

        // opdr: an order should only be fulfilled if payment is successful
        [TestMethod()]
        public void MakeOrder_OnlyWhenPaymentIsCompleted_PaymentStateCompleted()
        {
            // Arrange
            Sale testSale = new Sale();

            Product fysiek = new PhysicalProduct("fiets", 9.99f, "dit is een fietsje", new Tuple<float, float, float>(1, 2, 3), 7);
            Product digitaal = new DigitalProduct("download", 15f, "hier mee kan je iets downloaden", "www.blah.nl");

            testSale.AddItem(fysiek, "1");
            testSale.AddItem(digitaal, "69");
            testSale.SetCustomerInfo("Floris", "f@h.com", CustomerInfo.PaymentMethod.CreditCard, "Utrecht", "Androsdreef 88", "3562XC");

            // Act
            var value = Payment.state;

            // Assert
            Assert.AreEqual(PaymentState.Completed, value);
        }


        // opdr: an order should never have products with a quantity of zero
        [DataTestMethod]
        [DataRow("0")]
        [DataRow("-1")]
        public void AddItem_QuantityMoreThen0_AddsNewCartItem(string quantity)
        {
            // Arrange
            Sale testSale = new Sale();

            Product fysiek = new PhysicalProduct("fiets", 9.99f, "dit is een fietsje", new Tuple<float, float, float>(1, 2, 3), 7);
            Product digitaal = new DigitalProduct("download", 15f, "hier mee kan je iets downloaden", "www.blah.nl");

            // Act
            testSale.AddItem(fysiek, quantity);
            testSale.AddItem(digitaal, quantity);

            // Assert
            Assert.AreEqual(false, testSale.IsFilled());
        }
    }
}