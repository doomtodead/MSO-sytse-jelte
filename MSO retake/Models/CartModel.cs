using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
    public class CartModel
    {
        private List<Product> cart = new List<Product>();
        private float total = 0;

        public List<Product> ReturnCart()
        {
            return cart;
        }

        public float GetTotal()
        {
            return total;
        }

        public void SetTotal(float total)
        {
            this.total = total;
        }

        public int CartSize()
        {
            return cart.Count;
        }

        public void AddToCart(Product product)
        {
            this.cart.Add(product);
        }

        public void ClearCart()
        {
            this.cart.Clear();
            this.total = 0;
        }
    }
}
