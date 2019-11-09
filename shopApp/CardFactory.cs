using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shop.CustomerInfo;

namespace shop
{
    public static class CardFactory
    {
        public static Card GetCard(PaymentMethod method)
        {
            if(method == PaymentMethod.CreditCard)
            {
                return new CreditCard();
            } else
            {
                return new DebitCard();
            }

        }
    }
}
