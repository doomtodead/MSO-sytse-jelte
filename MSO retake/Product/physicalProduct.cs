using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
    public class PhysicalProduct : Product
    {
        public static float shippingCosts = 0.50f;
        public PhysicalProduct(string name, string description, float price) : base(name, description, price)
        {

        }
    }
}
