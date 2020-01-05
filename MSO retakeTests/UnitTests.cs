using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using MSO_Retake;

namespace MSO_retake
{
    [TestClass]
    public class UnitTests
    {

        //de eerste drie test
        [TestMethod()]
        public void SetInfoTest()
        {
            //Arrange
            Controller controller = new Controller(new ShopModel(), new CartModel(), new View(), new PaymentModel());
            PaymentModel expected = new PaymentModel();
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
        //not that Adress is missing from this test, this is because we never require adress from the controller
        public void getInfoTest()
        {
            // Arrange
            Controller controller = new Controller(new ShopModel(), new CartModel(), new View(), new PaymentModel());
            string expectedName = "Harry Jansen";
            string expectedEmail = "Harry.Jansen@gmail.com";
            string testName;
            string testEmail;
            controller.SetName("Harry Jansen");
            controller.SetEmail("Harry.Jansen@gmail.com");

            // act
            testName = controller.GetName();
            testEmail = controller.GetEmail();

            // assert
            Assert.AreEqual(expectedName, testName);
            Assert.AreEqual(expectedEmail, testEmail);
        }

        [TestMethod()]
        public void TestCartDisplay()
        {
            // Arrange
            CartModel cart = new CartModel();
            View view = new View();
            Product testProduct = new Product("test", "dit is een test product", 42);
            cart.AddToCart(testProduct);
            cart.SetTotal(42);
            List<string> testString = new List<string>();
            List<string> expectedString = new List<string>();
            expectedString.Add("-------------------------------");
            expectedString.Add("Your Cart:");
            expectedString.Add("test $42");
            expectedString.Add("-------------------------------");
            expectedString.Add("Total: $42" );
            expectedString.Add("Enter back to continue shopping or checkout to go to checkout\n");


            // act
            view.PrintCart(cart);
            //the cart is suppposed to be 7 lines long
            testString.Add(Console.ReadLine());
            testString.Add(Console.ReadLine());
            testString.Add(Console.ReadLine());
            testString.Add(Console.ReadLine());
            testString.Add(Console.ReadLine());
            testString.Add(Console.ReadLine());
            testString.Add(Console.ReadLine());

            // assert
            Assert.AreEqual(testString, expectedString);

        }

        //de volgende drie test werken same om te testen of de bestellingen pas worden voldaan als er betaald is
        [TestMethod()]
        public void orderAfterPaySucceedDigital()
        {
            // Arrange
            Controller controller = new Controller(new ShopModel(), new CartModel(), new View(), new PaymentModel());
            Product testProduct = new DigitalProduct("test", "dit is een test product", 42, "www.test.nl");
            string output;

            // act
            Program.SeeIfPaymentWorked("success", controller);
            output = Console.ReadLine();

            // assert
            Assert.AreEqual(output, "you will get an email with the links towards the digital products you ordered");
        }

        [TestMethod()]
        public void orderAfterPaySucceedPhysical()
        {
            // Arrange
            Controller controller = new Controller(new ShopModel(), new CartModel(), new View(), new PaymentModel());
            Product testProduct = new PhysicalProduct("test", "dit is een test product", 42);
            string output;

            // act
            Program.SeeIfPaymentWorked("success", controller);
            output = Console.ReadLine();

            // assert
            Assert.AreEqual(output, "the physical products will be shipped to you");
        }

        [TestMethod()]
        public void orderAfterPayFailed()
        {
            // Arrange
            Controller controller = new Controller(new ShopModel(), new CartModel(), new View(), new PaymentModel());
            Product testProduct = new PhysicalProduct("test", "dit is een test product", 42);
            string output;

            // act
            Program.SeeIfPaymentWorked("dit kan elke string behalve succes zijn", controller);
            output = Console.ReadLine();

            // assert
            Assert.AreEqual(output, "\n!!Something went wrong, you have been returned to the shop page!! \n");
        }

        [TestMethod()]
        public void SeeIfSchippingAdded()
        {
            // Arrange
            Controller controller = new Controller(new ShopModel(), new CartModel(), new View(), new PaymentModel());
            Product testProduct = new DigitalProduct("test", "dit is een test product", 42,"www.test.nl");
            float expectedCosts, testCosts;

            // act
            controller.AddProduct(1, testProduct);
            controller.SetTotal();
            expectedCosts = 42f;
            testCosts = controller.GetTotal();

            // assert
            Assert.AreEqual(testCosts, expectedCosts);

        }

        [TestMethod()]
        public void quantityZeroOrder()
        {
            // Arrange
            Controller controller = new Controller(new ShopModel(), new CartModel(), new View(), new PaymentModel());
            Product testProduct = new Product("test", "dit is een test product", 42);

            // act
            controller.AddProduct(0, testProduct);

            // assert
            Assert.AreEqual(controller.GetCart(), new List<Product>());

        }


        [TestMethod()]
        public void genericTestMethod()
        {
            // Arrange

            // act

            // assert

        }
    }
}
