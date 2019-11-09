using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class CartItem
    {
        public Product product;
        public int quantity; 
        
        public CartItem(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
    }
}
