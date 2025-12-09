using P03_SalesDatabase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P03_SalesDatabase.Data.Models;
using System.Security.Authentication;
namespace P03_Seeder
{
    internal static class Seeder
    {
        public static void Seed(SalesContext db)
        {
            string[] customerNames = { "Alice", "Bob", "Charlie", "Diana", "Ethan" };
            string[] productNames = { "Laptop", "Smartphone", "Tablet", "Headphones", "Smartwatch",
                                    "USB Cable", "Monitor", "Keyboard", "Shampoo", "Coffee"};
            string[] storeNames = { "TechStore", "GadgetWorld", "ElectroMart", "DeviceHub", "DigitalDepot" };
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                var customer = new Customer
                {
                    Name = customerNames[rand.Next(customerNames.Length)],

                    Email = GenerateEmail(),
                    CreditsCardNumber = 4441467 + rand.Next(10000000, 99999999).ToString()
                };
                db.Customers.Add(customer);
            }
            for (int i = 0; i < 10; i++)
            {
                var product = new Product
                {
                    Name = productNames[rand.Next(productNames.Length)],
                    Price = (decimal)rand.Next(1000,150000)/10,
                    Quantity = rand.Next(1, 100)
                };
                db.Products.Add(product);
            }
            for (int i = 0; i < 5; i++)
            {
                var store = new Store
                {
                    Name = storeNames[i]
                };
                db.Stores.Add(store);
            }
            db.SaveChanges();
            for (int i = 0; i < 20; i++)
            {
                int[] indexesProducts = db.Products.Select(p => p.ProductId).ToArray();
                int[] indexesCustomers = db.Customers.Select(c => c.CustomerId).ToArray();
                int[] indexesStores = db.Stores.Select(s => s.StoreId).ToArray();
                if (indexesStores.Length > 0 && indexesProducts.Length > 0 && indexesCustomers.Length > 0)
                {
                    var sale = new Sale
                    {

                        ProductId = indexesProducts[rand.Next(indexesProducts.Length)],
                        CustomerId = indexesCustomers[rand.Next(indexesCustomers.Length)],
                        StoreId = indexesStores[rand.Next(indexesStores.Length)],
                        Date = DateTime.Now.AddDays(-rand.Next(0, 365))
                    };
                    db.Sales.Add(sale);
                }
            }
            db.SaveChanges();
        }
        public static string GenerateEmail()
        {
            Random rand = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            int length = rand.Next(6, 12);
            char[] buffer = new char[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = chars[rand.Next(chars.Length)];
            }
            string email = new string(buffer) + "@example.com";
            return email ;
        }
    }
}
