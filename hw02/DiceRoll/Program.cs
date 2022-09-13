using System;

namespace DiceRoll
{
    internal static class Program
    {
        private static int DiceRoll(int numberOfDices, int sumOfPoints)
        {
            if (numberOfDices == 0)
            {
                return sumOfPoints == 0 ? 1 : 0;
            }

            var result = 0;
            for (var i = 1; i <= Math.Min(sumOfPoints, 6); i++)
            {
                result += DiceRoll(numberOfDices - 1, sumOfPoints - i);
            }

            return result;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(DiceRoll (2, 6));  // => 5
            Console.WriteLine(DiceRoll (2, 2));  // => 1
            Console.WriteLine(DiceRoll (1, 3));  // => 1
            Console.WriteLine(DiceRoll (2, 5));  // => 4 
            Console.WriteLine(DiceRoll (3, 4));  // => 3 
            Console.WriteLine(DiceRoll (4, 18)); // => 80
            Console.WriteLine(DiceRoll (6, 20)); // => 4221
        }
    }
}