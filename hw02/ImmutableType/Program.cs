using System;

namespace ImmutableType
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var pointA = new ImmutablePoint(1, 2);
            Console.WriteLine("pointA.X = {0}, pointA.Y = {1}", pointA.X, pointA.Y);

            // pointA.X = 1; // not allowed
            var pointB = pointA.ChangeX(5);
            var pointC = pointB.ChangeY(7);
            Console.WriteLine("pointB = " + pointB);
            Console.WriteLine("pointC = " + pointC);
        }
    }
}