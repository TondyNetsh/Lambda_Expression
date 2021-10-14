using System;
using System.Linq;

namespace Lambda_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("The square 5 is = " + square(5));
            Console.WriteLine("Difference of two numbers is = " + difference(3, 2));

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);

            Console.WriteLine(string.Join(" ,", squaredNumbers));
        }

        static Func<int, int> square = x => x * x;

        // Subtraction of two parameters
        static Func<int, int, int> difference = (y, z) => y - z;
        
    }
}
