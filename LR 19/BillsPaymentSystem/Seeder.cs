using BillsPaymentSystem.P01_BillsPaymentSystem.Data;
using BillsPaymentSystem.P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillsPaymentSystem
{
    internal static class Seeder
    {
        static public void Seed(BillsPaymentContext context)
        {
            var user1 = new User
            {
                FirstName = "Іван",
                LastName = "Іваненко",
                Email = "ivan@test.com",
                Password = "password123"
            };
            var user2 = new User
            {
                FirstName = "Петро",
                LastName = "Петренко",
                Email = "petro@test.com",
                Password = "securePass!"
            };
            var user3 = new User
            {
                FirstName = "Марія",
                LastName = "Коваль",
                Email = "maria@test.com",
                Password = "maria_pass"
            };
            var creditCard1 = new CreditCard
            {
                //Limit = 10000,
                //MoneyOwed = 0,
                ExpirationDate = DateOnly.FromDateTime(DateTime.Now).AddYears(2)
            };
            var creditCard2 = new CreditCard
            {
                //Limit = 5000,
                //MoneyOwed = 200,
                ExpirationDate = DateOnly.FromDateTime(DateTime.Now).AddYears(1)
            };
            var bankAccount1 = new BankAccount
            {
                //Balance = 500.50m,
                BankName = "PrivatBank",
                SwiftCode = "PBNKUA2X"
            };
            var bankAccount2 = new BankAccount
            {
                //Balance = 12000m,
                BankName = "Universal Bank (Monobank)",
                SwiftCode = "UVSBUA2X"
            };
            var paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod
                {
                    User = user1,
                    Type = PaymentMethodType.CreditCard,
                    CreditCard = creditCard1,
                    BankAccount = null 
                },
                new PaymentMethod
                {
                    User = user1,
                    Type = PaymentMethodType.BankAccount,
                    CreditCard = null,
                    BankAccount = bankAccount1
                },
                new PaymentMethod
                {
                    User = user2,
                    Type = PaymentMethodType.CreditCard,
                    CreditCard = creditCard2,
                    BankAccount = null
                },
                new PaymentMethod
                {
                    User = user3,
                    Type = PaymentMethodType.BankAccount,
                    CreditCard = null,
                    BankAccount = bankAccount2
                }
            };
            context.Users.AddRange(user1, user2, user3);
            context.BankAccounts.AddRange(bankAccount1, bankAccount2 );
            context.CreditCards.AddRange(creditCard1, creditCard2 );
            context.PaymentMethods.AddRange(paymentMethods);
            context.SaveChanges();
        }
    }
}
