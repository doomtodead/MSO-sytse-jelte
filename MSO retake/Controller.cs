using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
    public class Controller
    {
        private ShopModel shop;
        private CartModel cart;
        private PaymentModel info;
        private View view;

        public Controller(ShopModel shop, CartModel cart, View view, PaymentModel info)
        {
            this.shop = shop;
            this.cart = cart;
            this.view = view;
            this.info = info;
        }

        public void AddProduct(int amount, Product product)
        {
            for (int i = 0; i < amount; i++)
            {
                cart.AddToCart(product);
            }
        }      
        
        public void ClearCart()
        {
            cart.ClearCart();
        }

        public List<Product> GetCart()
        {
           return cart.ReturnCart();
        }

        public void SetShop(List<Product> products)
        {
            shop.SetShop(products);
        }
 
        public void SetName(string name)
        {
            info.SetName(name);
        }

        public void SetAdress(string adress)
        {
            info.SetAdress(adress);
        }

        public void SetEmail(string email)
        {
            info.SetEmail(email);
        }

        public void SetTotal()
        {
            foreach (Product product in cart.ReturnCart())
            {
                Console.WriteLine(product.name + " $" + product.price);
                cart.SetTotal(cart.GetTotal() + product.price);
            }         
        }
        
        public float GetTotal()
        {
            return cart.GetTotal();
        }

        public void updateShop()
        {
            view.PrintShop(shop.GetShop());
        }

        public void updateCart()
        {
            view.PrintCart(cart.ReturnCart());
        }

        public void updateProduct(Product product)
        {
            view.PrintProduct(product);
        }

        public void updateInfo()
        {
            view.PrintInfo();
        }

        public void updatePayment(float price)
        {
            view.PrintPayment(price);
        }

        public void updateError()
        {
            view.PrintError();
        }
    }
}
