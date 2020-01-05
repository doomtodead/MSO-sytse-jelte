using System;
using System.Collections.Generic;
using System.Text;

namespace MSO_Retake
{
    public class ShopModel
    {
        private List<Product> shop = new List<Product>();

        public void SetShop(List<Product> shop)
        {
            this.shop = shop;
        }

        public List<Product> GetShop()
        {
            return this.shop;
        }
               
    }
}
