using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static shop.CustomerInfo;
using static shop.Payment;

namespace shop
{
    public class Sale
    {
        private ShoppingCart cart = new ShoppingCart();
        private CustomerInfo customer = new CustomerInfo();

        public float GetPrice()
        {
            return cart.GetPrice();
        }

        public int GetQuantity()
        {
            return cart.GetQuantity();
        }

        public List<CartItem> getCartItems()
        {
            return cart.items;
        }

        public void SetCustomerInfo(string name, string email, PaymentMethod paymentMethod, string city = null, string street = null, string zipcode = null)
        {
            if (!IsFilled())
            {
                MessageBox.Show("You can not pay for an empty shopping cart");
            }
            else if (ContainsPhysical() && name.Length > 0 && email.Length > 0 && city!=null && city.Length>0 && street!=null && street.Length>0 && zipcode!=null && zipcode.Length>0)
            {
                customer.SetInfo(name, email, paymentMethod, city, street, zipcode);
                MakePayment();
            } else if (!ContainsPhysical() && name.Length > 0 && email.Length > 0)
            {
                customer.SetInfo(name, email, paymentMethod, city, street, zipcode);
                MakePayment();
            } else
            {
                MessageBox.Show("Please fill in all the required data");
            }
        }
            
        public bool IsFilled()
        {
            return (cart.items.Count > 0);
        }

        public void MakePayment()
        {
            Payment.state = PaymentState.Pending;

            DialogResult dialogResult = MessageBox.Show("Was the payment a success?", "Payment", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Payment.Commit(customer.payment, cart.GetPrice(), true);
                MessageBox.Show("Order complete");
            }
            else if (dialogResult == DialogResult.No)
            {
                Payment.Commit(customer.payment, cart.GetPrice(), false);
                MessageBox.Show("Payment failed");
            }

            if (Payment.state == PaymentState.Completed)
                MakeEmail();
            else
                MessageBox.Show("The payment is still not completed, please try again");
        }
      
        public void MakeEmail()
        {
            new CustomerEmail(cart, customer);

            if (cart.containsPhysicalProduct)
                new CompanyEmail(cart, customer);
        }
        public void AddItem(Product product, string quantity)
        {
            if (!int.TryParse(quantity, out int x))
            {
                MessageBox.Show("Quantity is a integer number");
            }
            else if (x <= 0)
            {
                MessageBox.Show("Please give a positive quantity");
            }
            else
            {
                cart.AddNewItem(product, x);
            }
        }

        public void Cancel()
        {
            cart.items.Clear();
            cart.containsPhysicalProduct = false;
        }

        public bool ContainsPhysical()
        {
            return cart.containsPhysicalProduct;
        }
    }
}
