using System;
using System.Collections.Generic;
using System.Text;

namespace mso_final_project
{
    interface ShippingMethod 
    {
        void HandleOrder(Product product); 
    }

    class Payment
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
        public void HandleOrder(Product product)
        {

        }
    }

    class HandleOrderPhysical : ShippingMethod
    {
        public void HandleOrder(Product product)
        {

        }
    }

}
