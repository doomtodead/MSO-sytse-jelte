﻿using System;
using System.Collections.Generic;
using System.Text;

namespace mso_final_project
{
    class UI
    {
        List<Product> cart = new List<Product>();
        Parser parser = new Parser();
        float totalPrice = 0;
        public UI()
        {

        }
        public void AddProduct(string name, int amount)
        {
            for (int i = 0; i < amount; i++) {
                cart.Add(parser.Parse(name));
            }
            Console.WriteLine(amount + " " + name + "'s is/are added to your cart");
        }
        public void SelectProduct(int number)
        {
            ShowProductDescription (parser.allProducts[number - 1].name);
           
        }
        public void ShowAllProducts()
        {
            int it = 1;
            Console.WriteLine("These are all our products:");
            foreach(Product product in parser.allProducts)
            {
                Console.WriteLine("(" + it + ") " + product.name);
                it++;
            }
        }

        public void ShowProductDescription(string name)
        {
            Product product = parser.Parse(name);
            Console.WriteLine("Product: " + product.name);
            Console.WriteLine("Description: " + product.description);
            Console.WriteLine("Price: " + product.price);

            Console.WriteLine("type add followed by a number to add that amount of the product to your cart");
            string response = Console.ReadLine();
            string[] newProduct = response.Split(' ');
            if (newProduct[0] == "add")
            {
                AddProduct(name, int.Parse(newProduct[1]));
            }
        }

        public void ShowCart()
        {
            
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Your Cart:");
            foreach (Product product in cart)
            {
                Console.WriteLine(product.name + " $" + product.price);
                totalPrice += product.price;
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Total: $" + totalPrice);
            Console.WriteLine("-------------------------------");
            Option();
        }

        public void Option()
        {
            Console.WriteLine("Enter back to continue shopping or checkout to go to checkout");
            
        }

        public void DoPayment()
        {
            Payment payment = new Payment();
            if (payment.handlePayment(totalPrice))
            {
                foreach(Product product in cart)
                {
                    if(product.GetType() == typeof(DigitalProduct))
                    {

                    } 
                    else
                    {

                    }
                }
                cart.Clear();
                totalPrice = 0;
            }
            else
            {
                Console.WriteLine("Something went wrong during payment, please try again");
            }

        }
    }
}
