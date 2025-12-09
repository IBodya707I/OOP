using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem.P01_BillsPaymentSystem.Data.Models
{
    public enum PaymentMethodType
    {
        BankAccount,
        CreditCard
    }
    internal class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        [ForeignKey("BankAccount")]
        public int? BankAccountId { get; set; }
        [ForeignKey("CreditCard")]
        public int? CreditCardId { get; set; }
        public PaymentMethodType Type { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public BankAccount? BankAccount { get; set; }
        public CreditCard? CreditCard { get; set; }
    }
}
