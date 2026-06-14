//int num1 = 0;
//int num2 = 0;
//int result = 0;
//Console.Write("Enter the 1st number");
//num1 = Convert.ToInt32(Console.ReadLine());
//Console.Write("Enter the 2nd number");
//num2 = Convert.ToInt32(Console.ReadLine());

//result = num1 + num2;
//Console.WriteLine("The Resutant is", result);


//string name = "something";
//string name = " ";
//string phoneNumber = " ";
////string name = " ";
//Console.Write("Enter your name: ");
//name=Console.ReadLine();

//Console.Write("Enter your phone Number: ");
//phoneNumber = Console.ReadLine();
//Console.WriteLine("this is the value of string : "+ name);
//Console.WriteLine($"The phone number is : {phoneNumber}");



Console.Write("Enter the 1st number:");
int numb01 = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the Operator:");
string operators = Console.ReadLine();


Console.Write("Enter the 2nd number:");
int numb02 = Convert.ToInt32(Console.ReadLine());


if (operators =="+")
{
   Console.WriteLine("The Result is :"+( numb01 + numb02));
}
else if (operators == "-")
{
    Console.WriteLine("The Result is :"+ (numb01 - numb02));
}
else if (operators == "/")
{
    Console.WriteLine("The Result is :"+ (numb01 / numb02));
}
else if (operators == "*")
{
    Console.WriteLine("The Result is :"+ (numb01 * numb02));
}

Console.ReadKey();