using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class CompanyEmail : Email
    {
        string companyEmail = "company@email.com";
        public CompanyEmail(ShoppingCart cart, CustomerInfo customer)
        {
            Generate(cart, customer);
        }
        public override void Generate(ShoppingCart cart, CustomerInfo customer)
        {
            string emailHeader = $"Company email for shipping:{Environment.NewLine}Mail to: {customer.city}, {customer.street}, {customer.zipcode}";
            string emailData = "";
            foreach (CartItem item in cart.items)
            {
                if (item.product.GetType().Equals(typeof(PhysicalProduct)))
                {
                    PhysicalProduct product = item.product as PhysicalProduct;
                    emailData += $"{Environment.NewLine}name: {product.title}, description: {product.description}, price: {product.price}, quantity: {item.quantity}{Environment.NewLine}length: {product.size.Item1}, width: {product.size.Item2}, height: {product.size.Item3}{Environment.NewLine}weight: {product.weight} kg";
                }

            }

            string finalData = emailHeader + emailData;

            this.Send(finalData, companyEmail);

        }
    }
}
