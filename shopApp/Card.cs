using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public abstract class Card
    {
        public abstract void Connect();

        public abstract void Disconnect();

        public void CommitTransaction(float price)
        {
            this.Connect();
            int cardId = this.BeginTransaction(price);
            this.EndTransaction(cardId);
        }

        public int BeginTransaction(float amount)
        {
            Console.WriteLine("Begin transaction 1 of " + amount + " EUR");
            return 1;
        }

        public void CancelTransaction(int id)
        {
            if (id != 1)
                throw new Exception("Incorrect transaction id");

            Console.WriteLine("Cancel transaction 1");
        }

        public bool EndTransaction(int id)
        {
            if (id != 1)
                return false;

            Console.WriteLine("End transaction 1");
            return true;
        }

    }

    // Mock CreditCard implementation
    public class CreditCard : Card
    {
        public override void Connect()
        {
            Console.WriteLine("Connecting to credit card reader");
        }

        public override void Disconnect()
        {
            Console.WriteLine("Disconnecting from credit card reader");
        }
    }

    // Mock DebitCard implementation
    public class DebitCard : Card
    {
        public override void Connect()
        {
            Console.WriteLine("Connecting to debit card reader");
        }

        public override void Disconnect()
        {
            Console.WriteLine("Disconnecting from debit card reader");
        }

    }
}
