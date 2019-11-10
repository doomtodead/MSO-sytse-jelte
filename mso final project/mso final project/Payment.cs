using System;
using System.Collections.Generic;
using System.Text;

namespace mso_final_project
{
    interface ShippingMethod 
    {
        void HandleOrder(List<Product> products, string name); 
    }

    public class Payment
    {
        public bool handlePayment(float price)
        {
            Console.WriteLine("Price to pay is " + price);
            Console.WriteLine("Handeling the payment bliepbloep");
            Console.WriteLine("Type success or fail to make the payment either succeed or fail");
            string response = Console.ReadLine();

            if (response == "success")
            {
                return true;
            }
            else if (response == "fail")
            {
                return false;
            }
            else
            {
                Console.WriteLine("unknown command, Please try again");               
                return handlePayment(price);
            }
        }
    }

    class HandleOrderDigital : ShippingMethod
    {
        public void HandleOrder(List<Product> products, string name)
        {
            string emailAdress;
            Console.WriteLine("We have noticed a digital product in cart. Please enter your email so we can sent the licensing key(s)");
            emailAdress = Console.ReadLine();
            //the method which will send the email with the licensing key
            Console.WriteLine("the email with the key(s) has been sent");
        }
    }

    class HandleOrderPhysical : ShippingMethod
    {
        string streetName, streetNumber, zipCode, town;
        public void HandleOrder(List<Product> products, string name)
        {
            Console.WriteLine("we habe noticed you have physical product in your cart. Please enter your street name");
            streetName = Console.ReadLine();
            Console.WriteLine("your streetNumber");
            streetNumber = Console.ReadLine();
            Console.WriteLine("you zip code");
            zipCode = Console.ReadLine();
            Console.WriteLine("and the town that you live in");
            town = Console.ReadLine();
            //the method which will actually call for the shipping of the product goes here
            Console.WriteLine("the shipping order has been send to our supplier");
        }
    }

}
