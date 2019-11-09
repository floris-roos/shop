using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public abstract class Email
    {
        public abstract void Generate(ShoppingCart cart, CustomerInfo customer);

        protected void Send(string emailData, string email)
        {
            Console.WriteLine($"Email sent to: {email}{Environment.NewLine}{emailData}");
        }
    }
}
