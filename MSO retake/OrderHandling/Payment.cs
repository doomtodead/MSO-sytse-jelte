using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
    abstract class Payment
    { 
        public abstract void HandleOrder(List<Product> products);
    }

    class DigitalPayment : Payment
    {
        public override void HandleOrder(List<Product> products)
        {
            Console.WriteLine("you will get an email with the links towards the digital products you ordered");
            //the method which will send the email with the licensing key
        }
    }

    class PhysicalPayment: Payment
    {
        public override void HandleOrder(List<Product> products)
        {
            Console.WriteLine("the physical products will be shipped to you");
            //the method which will actually call for the shipping of the product goes here
        }
    }
}
