using System;
using System.Collections.Generic;
using System.Text;

namespace class06OOPExtention
{
    internal class Employee
    {
        private decimal salary;
        public string name {  get; set; }
        public decimal Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value > 0)
                {

                    salary=value;
                }
                else
                {
                    throw new ArgumentException("Nagative slary is not possible");
                }
            }
        }
        public virtual void Salarydesplay()
        {
            Console.WriteLine($"name:{name}");
            Console.WriteLine($"Salary:{Salary}");
        }
    }
   
}
