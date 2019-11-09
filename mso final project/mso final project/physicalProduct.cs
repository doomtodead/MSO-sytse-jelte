using System;
using System.Collections.Generic;
using System.Text;

namespace mso_final_project
{
    class PhysicalProduct : Product
    {
        public float shippingCosts = 0.50f;
        public PhysicalProduct(string name, string description, float price) : base(name, description, price)
        {

        }
    }
}
