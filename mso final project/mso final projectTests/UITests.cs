using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace mso_final_project.Tests
{
    [TestClass()]
    public class UITests
    {
        [TestMethod()]
        public void ShowCartTest()
        {
            double total = UI.totalPrice;
            double expected = 40;
            List<Product> newcart = new List<Product> {new Product("something",  "blabla", 10), new Product("else", "bllablabla", 30) };
            // act
            UI.cart = newcart;
            UI.ShowCart();

            // assert
            Assert.AreEqual(expected, UI.totalPrice);
        }

        [TestMethod()]
        public void SelectProduct()
        {
            List<Product> newcart = new List<Product> { new Product("something", "blabla", 10), new Product("else", "bllablabla", 30) };
            int index = newcart.Count + 1;
            bool expected = false;
            bool result;
            // act
            result = (index < newcart.Count);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}