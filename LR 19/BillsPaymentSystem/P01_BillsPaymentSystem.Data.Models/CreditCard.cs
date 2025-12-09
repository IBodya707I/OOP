using BillsPaymentSystem.P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_BillsPaymentSystem.Data.Models
{
    internal class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public decimal Limit { get; private set; }
        public decimal MoneyOwed { get; private set; }
        public PaymentMethod PaymentMethod { get; set; }
        [NotMapped]
        public decimal LimitLeft => Limit - MoneyOwed;
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("amount must be bigger 0");
                return;
            }
            this.MoneyOwed -= amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("amount must be bigger 0");
                return;
            }
            if (this.LimitLeft < amount)
            {
                Console.WriteLine("Limit Left < amount");
                return;
            }
            this.MoneyOwed += amount;
        }
    }
}
