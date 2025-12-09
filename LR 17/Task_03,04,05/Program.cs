using P03_SalesDatabase.Data;
using Task_03_04_05;
using P03_Seeder;

namespace P03_SalesDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalesContext db = new SalesContext();
            //Seeder.Seed(db);
        }
    }
}
