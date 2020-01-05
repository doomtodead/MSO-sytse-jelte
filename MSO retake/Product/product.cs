using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
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
