using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class DigitalProduct : Product
    {
        public string licenseKey;
        public string downloadLink;

        public DigitalProduct(string title, float price, string description, string downloadLink)
        {
            this.id = Guid.NewGuid().ToString(); 
            this.title = title;
            this.price = price;
            this.description = description;
            // generate license key at runtime 
            this.licenseKey = Guid.NewGuid().ToString();
            this.downloadLink = downloadLink;
        }
    }
}
