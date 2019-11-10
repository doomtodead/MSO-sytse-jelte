using System;
using System.Collections.Generic;
using System.Text;

namespace mso_final_project
{
    public class Product
    {
        public string name;
        public string description;
        public float price;
        public Product (string name, string description, float price)
        {
            this.description = description;
            this.price = price;
            this.name = name;
        }
    }
}
