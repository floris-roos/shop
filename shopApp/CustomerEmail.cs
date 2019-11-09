using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class CustomerEmail : Email
    {
        public CustomerEmail(ShoppingCart cart, CustomerInfo customer)
        {
            Generate(cart, customer);
        }
        
        public override void Generate(ShoppingCart cart, CustomerInfo customer)
        {
            string confirmationHeader = "Customer email, order confirmation:";
            string confirmationData = "";
            string downloadHeader = $"{Environment.NewLine}Customer download links and license keys";
            string downloadData = "";


            foreach (CartItem item in cart.items)
            {
                if (item.product.GetType().Equals(typeof(PhysicalProduct)))
                {
                    PhysicalProduct product = item.product as PhysicalProduct;
                    confirmationData += $"{Environment.NewLine}name: {product.title}, description: {product.description}, price: {product.price}, quantity: {item.quantity}";
                }

                if (item.product.GetType().Equals(typeof(DigitalProduct)))
                {
                    DigitalProduct product = item.product as DigitalProduct;
                    confirmationData += $"{Environment.NewLine}name: {product.title}, description: {product.description}, price: {product.price}, quantity: {item.quantity}";
                    downloadData += $"{Environment.NewLine}name: {product.title}, license key: {product.licenseKey}, download: {product.downloadLink}, downloads available: {item.quantity}";
                    
                }

            }

            string finalDownloadData = (downloadHeader == "") ? "" : downloadHeader + downloadData;
            string finalData = confirmationHeader + confirmationData + finalDownloadData;

            this.Send(finalData, customer.email);
        }
    }
}
