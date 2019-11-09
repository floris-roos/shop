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
        public void AddCartItem_ShippingFee_ChangesBool()
        {
            // Arrange

            // Act

            // Assert

        }
    }
}