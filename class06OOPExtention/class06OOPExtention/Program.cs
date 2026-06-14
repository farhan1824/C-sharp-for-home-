 namespace class06OOPExtention
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Developer dev=new Developer();
            //dev.name = "Test";
            //dev.Salary = 500000;
            //dev.ProgramingLanguage = "c sharp";
            //dev.Department = "CSE";

            //Manager mana=new Manager();
            //mana.Department = "sales";
            //mana.Salary = 80000;
            //mana.name = "sales person";

            //dev.Salarydesplay();
            //mana.Salarydesplay();
            //Console.ReadLine();
            Calculator calc=new Calculator(8,10);
            List<Student> students = new List<Student>
{
    new Student
    {
        id = 1,
        Age = 20,
        Dob = Convert.ToDateTime("2003-12-12"),
        Name = "Chandu",
        Subject = "maths",
        Mark = 20
    }
};
            Console.WriteLine("Hello, World!");
        }
    }
}
