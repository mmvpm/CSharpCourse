using System;

namespace ImmutableType
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var pointA = new ImmutablePoint(1, 2);
            Console.WriteLine("pointA.X = {0}, pointA.Y = {1}", pointA.X, pointA.Y); // pointA.X = 1, pointA.Y = 2

            // pointA.X = 1; // not allowed
            var pointB = pointA.ChangeX(5);
            var pointC = pointB.ChangeY(7);
            Console.WriteLine("pointA = " + pointA); // pointA = ImmutablePoint(1, 2)
            Console.WriteLine("pointB = " + pointB); // pointB = ImmutablePoint(5, 2)
            Console.WriteLine("pointC = " + pointC); // pointC = ImmutablePoint(5, 7)
        }
    }
}