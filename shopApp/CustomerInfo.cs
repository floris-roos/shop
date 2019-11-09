using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class CustomerInfo
    {
        public enum PaymentMethod
        {
            DebitCard,
            CreditCard
        }
        
        public string name;
        public string email;
        public string city;
        public string street;
        public string zipcode;
        public PaymentMethod payment;

        public void SetInfo(string name, string email, PaymentMethod paymentMethod, string city, string street, string zipcode)
        {
            this.name = name;
            this.email = email;
            this.payment = paymentMethod;
            this.city = city;
            this.street = street;
            this.zipcode = zipcode;
        }
    }
}
