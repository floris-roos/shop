using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class ShoppingCart
    {
        public List<CartItem> items;
        private float shippingFee;
        public bool containsPhysicalProduct = false;

        public ShoppingCart()
        {
            items = new List<CartItem>();
        }

        public float GetPrice()
        {
            float totalPrice = shippingFee;
            foreach(CartItem item in items)
            {
                totalPrice += item.quantity * (item.product.price);
            }
            return totalPrice;
        }

        public int GetQuantity()
        {
            int totalQuantity = 0;
            foreach (CartItem item in items)
            {
                totalQuantity += item.quantity;
            }
            return totalQuantity;
        }

        public void AddNewItem(Product product, int amount)
        {
            bool added = false;
            
            foreach(CartItem item in items)
            {
                if(item.product.id == product.id)
                {
                    item.quantity += amount;
                    added = true;
                }
            }

            if (product.GetType().Equals(typeof(PhysicalProduct)))
            {
                containsPhysicalProduct = true;
                shippingFee = 2.0f;
            }                
            if (!added)
                items.Add(new CartItem(product, amount));
        }

        public void Cancel()
        {
            items.Clear();
            containsPhysicalProduct = false;
            shippingFee = 0;
        }
    }
}
