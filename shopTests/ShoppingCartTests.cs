using Microsoft.VisualStudio.TestTools.UnitTesting;
using shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Tests
{
    [TestClass()]
    public class ShoppingCartTests
    {
        //opdr: shipping should not be added if the order only contains digital products
        [TestMethod()]
        public void AddCartItem_NoShippingForDigital_ChangesBool()
        {
            // Arrange
            Sale testSale = new Sale();
            Product digitaal = new DigitalProduct("download", 15f, "hier mee kan je iets downloaden", "www.blah.nl");

             // Act
            testSale.AddItem(digitaal, "69");
            var heeftFysiek = testSale.ContainsPhysical();

            // Assert
            Assert.AreEqual(false, heeftFysiek);
        }

        [TestMethod()]
        public void AddCartItem_ShippingForPhysical_ChangesBool()
        {
            // Arrange
            Sale testSale = new Sale();
            Product fysiek = new PhysicalProduct("fiets", 9.99f, "dit is een fietsje", new Tuple<float, float, float>(1, 2, 3), 7);

            // Act
            testSale.AddItem(fysiek, "69");
            var heeftFysiek = testSale.ContainsPhysical();

            // Assert
            Assert.AreEqual(true, heeftFysiek);
        }
    }
}