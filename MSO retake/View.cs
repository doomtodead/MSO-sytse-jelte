using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
    public class View
    {
        Parser parser = new Parser();
        public void PrintCart(CartModel cart)
        {
            float totalPrice = 0;
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Your Cart:");
            foreach (Product product in cart.ReturnCart())
            {
                Console.WriteLine(product.name + " $" + product.price);
                totalPrice += product.price;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Total: $" + cart.GetTotal().ToString());
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Enter back to continue shopping or checkout to go to checkout\n");
        }

        public void PrintShop(List<Product> products)
        {
            int it = 1;
            Console.WriteLine("These are all our products:");
            foreach (Product product in products)
            {
                Console.WriteLine("(" + it + ") " + product.name);
                it++;
            }
            Console.WriteLine("Select a product with the corresponding number or type cart to check your cart\n");
        }

        public void PrintProduct(Product product)
        {
            Console.WriteLine("Product: " + product.name);
            Console.WriteLine("Description: " + product.description);
            Console.WriteLine("Price: " + product.price);
            Console.WriteLine("type add followed by a number to add that amount of the product to your cart or back to select another products\n");
        }

        public void PrintInfo()
        {
            Console.WriteLine("Please enter your name, adress and email. Press enter after each piece of information\n");
        }

        public void PrintPayment(float price)
        {
            Console.WriteLine("Price to pay is " + price);
            Console.WriteLine("Handeling the payment bliepbloep");
            Console.WriteLine("Type success or fail to make the payment either succeed or fail\n");
        }

        public void PrintError()
        {
            Console.WriteLine("\n !!Something went wrong, you have been returned to the shop page!! \n");
        }
    }
}
