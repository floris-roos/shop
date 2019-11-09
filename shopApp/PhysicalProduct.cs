using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class PhysicalProduct : Product
    {
        public Tuple<float, float, float> size;
        public float weight;

        public PhysicalProduct(string title, float price, string description, Tuple<float, float, float> size, float weight)
        {
            this.id = Guid.NewGuid().ToString();
            this.title = title;
            this.price = price;
            this.description = description;
            this.size = size;
            this.weight = weight;
        }
    }
}
