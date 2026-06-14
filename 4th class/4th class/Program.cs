namespace _4th_class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //atm balance
            //Console.Write("Enter Your Account Balance: ");
            //int balance=Convert.ToInt32(Console.ReadLine());
            //if (balance==1000)
            //{
            //    Console.WriteLine("Transaction SUccessFul");
            //}
            //else
            //{
            //    Console.WriteLine("In suffecient Balance");
            //}

            //voot dewar joggota

            //Console.Write("Enter Your Age: ");
            //int age=Convert.ToInt32(Console.ReadLine());

            //if (age >= 18)
            //{
            //    Console.WriteLine("you are eligable for vote");
            //}
            //else
            //{
            //    Console.WriteLine("you are not eligable for vote");
            //}


            //Employee Bonus System

            //Console.Write("enter Your Salary: ");
            //int salary = Convert.ToInt32(Console.ReadLine());
            //double salaryAmount = 0;
            //if (salary >=50000)
            //{
            //    salaryAmount = salary * 0.2;
            //    Console.WriteLine("Your Bonus will be "+ salaryAmount);
            //}
            //else
            //{
            //    salaryAmount = (salary * 0.1);
            //    Console.WriteLine("Your Bonus will be " + salaryAmount);
            //}


            //Login System


            //        for (int i = 0; i < 3; i++)
            //        {
            //    Console.Write("Enter Your userName : "); 
            //    string username = Console.ReadLine().ToLower();

            //    Console.Write("Enter Your Password : ");
            //    string password = Console.ReadLine();



            //            if (username == "admin" && password == "1234")
            //            {
            //                Console.WriteLine("Login Successfull");
            //            break;
            //            }

            //        else
            //        {
            //            Console.WriteLine("wrong username and password please try again ");
            //        }
            //    }

            //ছোত্রদের নোম ও মোর্কস সংরক্ষণ ভরোগ্রোম

            string[] studentNames = new string[5];
            int[] marks = new int[5];
            for (int i = 0; i < studentNames.Length; i++)
            {
                Console.Write("Enter the students Names : ");
                studentNames[i] = Console.ReadLine();
                Console.Write("Enter the students Marks : ");
                marks[i] = Convert.ToInt32(Console.ReadLine());

            }
            for (int j = 0; j < marks.Length; j++)
            {
                Console.WriteLine(studentNames[j]+" : " + marks[j]);
            }
            int highstMarks = 0;
            string topper = "";
            for (int k = 0; k < marks.Length; k++)
            {
            if (marks[k] > highstMarks)
                {
                    highstMarks = marks[k];
                    topper = studentNames[k];
                }
            }
            Console.WriteLine("The Highest mark holder : " + highstMarks);
            }
    }
}
