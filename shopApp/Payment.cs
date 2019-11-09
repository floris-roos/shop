using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static shop.CustomerInfo;

namespace shop
{
    public static class Payment
    {
        public enum PaymentState
        {
            NotStarted,
            Pending,
            Completed,
            Failed
        }

        public static PaymentState state = PaymentState.NotStarted;
        public static void Commit(PaymentMethod method, float price, bool isSuccess)
        {
            if (isSuccess)
            {
                CardFactory.GetCard(method).CommitTransaction(price);
                state = PaymentState.Completed;
            } else
            {
                state = PaymentState.Failed;
            }
        }
    }
}
