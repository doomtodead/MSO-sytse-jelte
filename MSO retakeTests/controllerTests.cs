using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MSO_retake;

namespace MSO_retake
{
    [TestClass]
    public class controllerTests
    {
        [TestMethod()]
        public void SetInfoTest()
        {
            Controller controller = new Controller(new ShopModel(), new CartModel(), new View(), new PaymentModel());
            double expected = new PaymentModel();
            expected.SetName("Harry Jansen");
            expected.SetAdress("decimalaan 9");
            expected.SetEmail("Harry.Jansen@gmail.com");

            // act
            controller.SetName("Harry Jansen");
            controller.SetAdress("decimalaan 9");
            controller.SetEmail("Harry.Jansen@gmail.com");

            // assert
            Assert.AreEqual(expected, controller.info);
        }

        [TestMethod()]
        public void getInfoTest()
        {
            Controller controller = new Controller(new ShopModel(), new CartModel(), new View(), new PaymentModel());
            string expectedName = "Harry Jansen";
            string expectedAdress = "decimalaan 9";
            string expectedEmail = "Harry.Jansen@gmail.com";
            string testName;
            string testAdress;
            string testEmail;
            controller.SetName("Harry Jansen");
            controller.SetAdress("decimalaan 9");
            controller.SetEmail("Harry.Jansen@gmail.com");

            // act
            testName = controller.GetName();
            testAdress = controller.GetAdress();
            testEmail = controller.GetEmail();

            // assert
            Assert.AreEqual(expectedName, testName);
            Assert.AreEqual(expectedAdress, testAdress);
            Assert.AreEqual(expectedEmail, testEmail);
        }
    }
}
