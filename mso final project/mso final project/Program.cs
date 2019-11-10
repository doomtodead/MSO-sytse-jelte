using System;

namespace mso_final_project
{
    class Program
    {     
        public static void Main(string[] args)
        {
            var UI = new UI();
            //Console.WriteLine(Environment.CurrentDirectory);
            UI.ShowAllProducts();
            //theUI.ShowProductDescription("boom");
            ProductSelection(UI);
        }

        public static void ProductSelection(UI ui)
        {
            int productNumber = 0;
            Console.WriteLine("Select a product with the corresponding number or type cart to check your cart");
            string response = Console.ReadLine();
            if (response == "cart")
            {
                ui.ShowCart();
                string response2 = Console.ReadLine();

                if (response2 == "back")
                {
                    ProductSelection(ui);
                }
                else if (response2 == "checkout")
                {
                    ui.DoPayment();
                    ui.ShowAllProducts();
                    ProductSelection(ui);
                }
                else
                {
                    Console.WriteLine("unknown command, you've been returned to the shop");
                    ProductSelection(ui);
                }

            }
            else if(int.TryParse(response, out productNumber))
            {
                ui.SelectProduct(productNumber);
                ProductSelection(ui);
            }
            else
            {
                Console.WriteLine("Please respond correctly");
                ProductSelection(ui);
            }
        }

        static void Update()
        {

        }
    }
}
