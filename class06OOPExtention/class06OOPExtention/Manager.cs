using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace class06OOPExtention
{
    internal class Manager:Employee
    {
        public string Department { get; set; }
        public override void Salarydesplay()
        {
            Console.WriteLine($"name:{name}");
            Console.WriteLine($"Salary:{Salary}");
            Console.WriteLine($"Department:{Department}");
        }
    }
}
