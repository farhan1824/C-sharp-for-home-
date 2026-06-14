using System;
using System.Collections.Generic;
using System.Text;

namespace class06OOPExtention
{
    public class Calculator
    {
        private double Add(double x, double y)
        {
            return x + y;
        }

        private double Divide(double x, double y)
        {
            return x / y;
        }

        private double Subtract(double x, double y)
        {
            return x - y;
        }

        private double Multiplication(double x, double y)
        {
            return x * y;
        }

        public Calculator(double x, double y)
        {

            Console.WriteLine($"Add: {Add(x, y)}");
            Console.WriteLine($"Subtract: {Subtract(x, y)}");
            Console.WriteLine($"Multiply: {Multiplication(x, y)}");
            Console.WriteLine($"Divide: {Divide(x, y)}");
        }
    }
}
