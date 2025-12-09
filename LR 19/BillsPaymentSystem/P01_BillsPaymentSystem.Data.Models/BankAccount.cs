using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.P01_BillsPaymentSystem.Data.Models
{
    internal class BankAccount
    {
        public int BankAccountId { get; set; }
        public decimal Balance { get; private set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("amount must be bigger 0");
                return;
            }
            this.Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("amount must be bigger 0");
                return;
            }
            if (this.Balance < amount)
            {
                Console.WriteLine("Not enough money");
                return;
            }
            this.Balance -= amount;
        }
    }
}
