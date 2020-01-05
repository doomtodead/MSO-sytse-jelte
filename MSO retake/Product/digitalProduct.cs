using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
    class DigitalProduct : Product
    {
        public string link;
        public DigitalProduct(string name, string description, float price, string link) : base(name, description, price)
        {
            this.link = link;
        }
    }
}
