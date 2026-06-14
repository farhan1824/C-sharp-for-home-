using System;
using System.Collections.Generic;
using System.Text;

namespace _5thClassOOP
{
    public class Salary
    {
        double sal = 0;
        public void salary(string type)
        {
            if (type == "customer")
            {
                sal = 100000;
                Console.WriteLine("The customer salary is " + sal);
            }


            if (type == "employee")
            {
                sal = 800000;
                Console.WriteLine("The employee salary is " + sal);
            }

        }
    }
}
