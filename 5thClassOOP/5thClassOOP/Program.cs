
namespace _5thClassOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cus cus = new Cus();
            Employee emp = new Employee();
            Salary salary=new Salary();

            cus.ID = 1;
            cus.Name = "Farhan Ahmed";
            cus.Designation = "office Worker";
            cus.Email = "farhanahmed1824@gmail.com";   
            Console.WriteLine($"ID: {cus.ID}");
            Console.WriteLine($"Name: {cus.Name}");
            Console.WriteLine($"Designation: {cus.Designation}");
            Console.WriteLine($"Email: {cus.Email}");
            salary.salary("employee");
            Console.ReadLine();
        }
    }
}
