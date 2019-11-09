using System;
using System.Collections.Generic;
using System.Text;

namespace mso_final_project
{
    class UI
    {
        List<Product> cart = new List<Product>();
        Parser parser = new Parser();
        public UI()
        {

        }
        public void AddProduct(string name)
        {
            cart.Add(parser.Parse(name));
        }

        public void ShowAllProducts()
        {
            Console.WriteLine("alle mogelijke producten");
            foreach(Product product in parser.allProducts)
            {
                Console.WriteLine(product.name);
            }
        }

        public void ShowProductDescription(string name)
        {
            Product product = parser.Parse(name);
            Console.WriteLine("Product: " + product.name);
            Console.WriteLine("Description: " + product.description);
            Console.WriteLine("Price: " + product.price);
        }
    }
}
