/*******************************
 *                             *
 *  Кофф Даниил ПИ-221         *
 *  Лаборторная работа 1-1     *
 *                             *
 *******************************/

using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int aNaturalNumber;
            int nPower;
            int result = 1;

            Console.WriteLine("Enter value for variable a: ");
            aNaturalNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter value for power variable n: ");
            nPower = Convert.ToInt32(Console.ReadLine());

            for (int index = 0; index < nPower; ++index)
            {
                result *= aNaturalNumber;
            }

            Console.WriteLine("\n" + aNaturalNumber + " in power of " + nPower + " equals: " + result);
            Console.ReadKey();
        }
    }
}