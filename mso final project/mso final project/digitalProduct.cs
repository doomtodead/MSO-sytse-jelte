using System;
using System.Collections.Generic;
using System.Text;

namespace mso_final_project
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
