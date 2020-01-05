using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
    class PhysicalProduct : Product
    {
        public float shippingCosts = 0.50f;
        public PhysicalProduct(string name, string description, float price) : base(name, description, price)
        {

        }
    }
}
