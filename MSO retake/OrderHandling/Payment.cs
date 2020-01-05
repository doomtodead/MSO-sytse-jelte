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
            //the method which will send the email with the licensing key
        }
    }

    class PhysicalPayment: Payment
    {
        public override void HandleOrder(List<Product> products)
        {
            //the method which will actually call for the shipping of the product goes here
        }
    }
}
