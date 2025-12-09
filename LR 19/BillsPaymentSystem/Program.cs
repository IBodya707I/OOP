using BillsPaymentSystem.P01_BillsPaymentSystem.Data;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data.Models;
namespace BillsPaymentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new BillsPaymentContext();
            //Seeder.Seed(context);
            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Display User Payment Methods");
            Console.WriteLine("2. Pay Bills");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:

                    while (true)
                    {
                        Console.Write("Enter id user: ");
                        int id = int.Parse(Console.ReadLine());
                        var user = context.Users.Include(u => u.PaymentMethods).ThenInclude(pm => pm.BankAccount)
                            .Include(u => u.PaymentMethods).ThenInclude(pm => pm.CreditCard).Where(u => u.UserId == id).FirstOrDefault();
                        if (user != null)
                        {
                            Console.WriteLine($"User: {user.LastName}  {user.FirstName}");
                            var bankAccounts = user.PaymentMethods
                                .Where(pm => pm.BankAccount != null)
                                .Select(pm => pm.BankAccount)
                                .ToList();
                            if (bankAccounts.Count != 0)
                            {
                                Console.WriteLine("Bank Accounts:");
                                foreach (var ba in bankAccounts)
                                {
                                    Console.WriteLine($"-- ID: {ba.BankAccountId}");
                                    Console.WriteLine($"--- Balance: {ba.Balance.ToString("F2")}");
                                    Console.WriteLine($"--- Bank: {ba.BankName}");
                                    Console.WriteLine($"--- SWIFT: {ba.SwiftCode}");
                                }
                            }
                            var creditCards = user.PaymentMethods
                                .Where(pm => pm.CreditCard != null)
                                .Select(pm => pm.CreditCard)
                                .ToList();
                            if (creditCards.Count != 0)
                            {
                                Console.WriteLine("Credit Cards:");
                                foreach (var cc in creditCards)
                                {
                                    Console.WriteLine($"-- ID: {cc.CreditCardId}");
                                    Console.WriteLine($"--- Limit: {cc.Limit.ToString("F2")}");
                                    Console.WriteLine($"--- Money Owed: {cc.MoneyOwed.ToString("F2")}");
                                    Console.WriteLine($"--- Limit Left: {cc.LimitLeft.ToString("F2")}");
                                    Console.WriteLine($"--- Expiration Date: {cc.ExpirationDate.ToString("yyyy/MM")}");
                                }
                            }
                        }
                        else
                            Console.WriteLine("Dont found user");
                    }
                break;
            case 2:
                Console.Write("Enter id user: ");
                int userId = int.Parse(Console.ReadLine());
                Console.Write("Enter amount to pay: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                PayBills(context, userId, amount);
                break;
            }
        }
        public static void PayBills(BillsPaymentContext context, int userId, decimal amount)
        {
            var user = context.Users.Include(u => u.PaymentMethods).ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods).ThenInclude(pm => pm.CreditCard).Where(u => u.UserId == userId).FirstOrDefault();
            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }
            decimal totalAvailable = 0;
            var bankAccounts = user.PaymentMethods
                .Where(pm => pm.BankAccount != null)
                .Select(pm => pm.BankAccount)
                .ToList().OrderBy(ba => ba.BankAccountId);
            foreach (var ba in bankAccounts)
            {
                totalAvailable += ba.Balance;
            }
            var creditCards = user.PaymentMethods
                .Where(pm => pm.CreditCard != null)
                .Select(pm => pm.CreditCard)
                .ToList().OrderBy(cc => cc.CreditCardId);
            foreach (var cc in creditCards)
            {
                totalAvailable += cc.LimitLeft;
            }
            if (totalAvailable < amount)
            {
                Console.WriteLine("Insufficient funds to pay the bills.");
                return;
            }
            decimal amountToPay = amount;
            foreach (var ba in bankAccounts)
            {
                if (amountToPay <= 0) break;
                decimal withdrawAmount = Math.Min(ba.Balance, amountToPay);
                ba.Withdraw(withdrawAmount);
                amountToPay -= withdrawAmount;
            }
            foreach (var cc in creditCards)
            {
                if (amountToPay <= 0) break;
                decimal withdrawAmount = Math.Min(cc.LimitLeft, amountToPay);
                cc.Withdraw(withdrawAmount);
                amountToPay -= withdrawAmount;
            }
            context.SaveChanges();
            Console.WriteLine("Bills paid successfully.");
        }

    }
}
