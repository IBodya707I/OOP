using P01_StudentSystem.Data;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new StudentSystemContext();
            /*Seeder.Seed(db);*/
            foreach (var student in db.Students)
            {
                Console.WriteLine("Name " + student.Name + "\nPhone number " + student.PhoneNumber 
                    + "\nBirthday" + student.Birthday + "\nRegister on " + student.RegisteredOn);
            }
            foreach(var course in db.Courses)
            {
                Console.WriteLine("\nCourse " + course.Name + "\nDescription " + course.Description + "\nPrice " 
                    + course.Price + "\nStart date: " + course.StartDate + "\nEnd date: " + course.EndDate);
            }
        }
    }
}
