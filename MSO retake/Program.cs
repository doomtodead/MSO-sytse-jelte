using System;
using System.Collections.Generic;

namespace MSO_Retake
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ongoing = true;
            int productNumber = 0;
            ShopModel shop = new ShopModel();
            CartModel cart = new CartModel();
            PaymentModel info = new PaymentModel();
            View view = new View();

            Parser parser = new Parser();
            Controller controller = new Controller(shop, cart, view, info);

            controller.SetShop(parser.allProducts);
            while (ongoing)
            {
                controller.updateShop();
                string response1 = Console.ReadLine();
                if (response1 == "cart")
                {
                    controller.updateCart();
                    string response2 = Console.ReadLine();
                    if(response2 == "back")
                    {
                        continue;
                    } else if (response2 == "checkout" && cart.CartSize() > 0)
                    {
                        controller.updateInfo();
                        string name = Console.ReadLine();
                        string adress = Console.ReadLine();
                        string email = Console.ReadLine();

                        controller.SetName(name);
                        controller.SetAdress(adress);
                        controller.SetEmail(email);
                        controller.SetTotal();
                        controller.updatePayment(controller.GetTotal());
                        string response3 = Console.ReadLine();
                        if (response3 == "success")
                        DoPayment(controller);
                        else
                        {
                            controller.updateError();
                            continue;
                        }

                    } else
                    {
                        controller.updateError();
                        continue;
                    }
                } else if (int.TryParse(response1, out productNumber))
                {
                    if (productNumber <= shop.GetShop().Count)
                    {
                        Product item = shop.GetShop()[productNumber - 1];

                        controller.updateProduct(item);
                        string response2 = Console.ReadLine();
                        string[] newProduct = response2.Split(' ');
                        if (newProduct[0] == "add")
                        {
                            controller.AddProduct(int.Parse(newProduct[1]), item);
                            continue;
                        } else
                        {
                            controller.updateError();
                            continue;
                        }
                    } else
                    {
                        controller.updateError();
                        continue;
                    }

                } else
                {
                    controller.updateError();
                    continue;
                }

            }
        }

        static void DoPayment(Controller controller)
        {
            List<Product> digitalProducts = new List<Product>();
            List<Product> physicalProducts = new List<Product>();
            
            foreach (Product product in controller.GetCart())
            {
                if (product.GetType() == typeof(DigitalProduct))
                {
                    digitalProducts.Add(product);
                }
                else if (product.GetType() == typeof(PhysicalProduct))
                {
                    physicalProducts.Add(product);
                }
            }
            EMail baseMail = new EMail(controller.GetName(), controller.GetEmail());
            if (digitalProducts.Count != 0) {
                DigitalPayment digital = new DigitalPayment();
                DigitalMail mail = new DigitalMail(baseMail); 
                digital.HandleOrder(digitalProducts);
                mail.SetKeys(digitalProducts);
                mail.Display();
            }
            if (physicalProducts.Count != 0) {
                PhysicalPayment physical = new PhysicalPayment();
                PhysicalMail mail = new PhysicalMail(baseMail);
                physical.HandleOrder(physicalProducts);
                mail.Display();
            }
           controller.ClearCart();
        }
    }
}
