using System;
using System.Collections.Generic;
using System.Linq;
using static Lambda_Expression.VariablesScopeWithLambdas;

namespace Lambda_Expression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("The square 5 is = " + square(5));
            Console.WriteLine("Difference of two numbers is = " + difference(3, 2));

            int[] number = { 2, 3, 4, 5 };
            var squaredNumbers = number.Select(x => x * x);
                        
            greet("Tondy");
            Console.WriteLine();

            var numbers = (2, 3, 4);
            var doubleNumbers = doubleThem(numbers);

            Console.WriteLine($"The set {numbers} doubled: {doubleNumbers}");

            Console.WriteLine(string.Join(", ", squaredNumbers));

            var numberSets = new List<int[]>
            {
                new[] {1,2,3,4,5},
                new[] { 0, 0, 0 },
                new[] {9,8},
                new[] {1,0,1,0,1,0,1,0}
            };
            var setsWithManyPositives =
                from numberSet in numberSets
                where numberSet.Count(n => n > 0) > 3
                select numberSet;

            foreach (var numberSet in setsWithManyPositives)
            {
                Console.WriteLine(string.Join(" ", numberSet));
            }

            var game = new VariableCaptureGame();
            int gameInput = 5;
            game.Run(gameInput);

            int jTry = 10;
            bool result = game.isEqualToCapturedLocalVariable(jTry);
            Console.WriteLine($"Captured local variable is equal to {jTry}: {result}");

            int anotherJ = 3;
            game.updateCapturedLocalVariable(anotherJ);

            bool equalToAnother = game.isEqualToCapturedLocalVariable(anotherJ);
            Console.WriteLine($"Another lambda observes a new value of captured variable: {equalToAnother}");
            //Output
        }

        static Func<int, int> square = x => x * x;

        // Subtraction of two parameters
        static Func<int, int, int> difference = (y, z) => y - z;

        static Action<string> greet = name =>
        {
            string greeting = $"Hello {name}!";
            Console.WriteLine(greeting);
        };

        static Func<(int, int, int), (int, int, int)> doubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);    
    }
    public static class VariablesScopeWithLambdas
    {
        public class VariableCaptureGame
        {
            internal Action<int> updateCapturedLocalVariable;
            internal Func<int, bool> isEqualToCapturedLocalVariable;

            public void Run(int input)
            {
                int j = 0;

                updateCapturedLocalVariable = x =>
                {
                    j = x;
                    bool result = j > input;
                    Console.WriteLine($"{j} is greater than {input} : {result}");
                };
                isEqualToCapturedLocalVariable = x => x == j;

                Console.WriteLine($"Local variables before lambda invocation: {j}");
                updateCapturedLocalVariable(10);
                Console.WriteLine($"Local variable after lambda invocation: {j}");
            }
        }
    }
}