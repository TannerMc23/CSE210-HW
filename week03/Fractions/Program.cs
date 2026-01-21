using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
       Fraction num1 = new Fraction(); 
       Console.WriteLine(num1.GetFraction());
       Console.WriteLine(num1.GetDecimal());

       Fraction num2 = new Fraction(5); 
       Console.WriteLine(num2.GetFraction());
       Console.WriteLine(num2.GetDecimal());

       Fraction num3 = new Fraction(3, 4); 
       Console.WriteLine(num3.GetFraction());
       Console.WriteLine(num3.GetDecimal());

       Fraction num4 = new Fraction(1, 3); 
       Console.WriteLine(num4.GetFraction());
       Console.WriteLine(num4.GetDecimal());
    }
}