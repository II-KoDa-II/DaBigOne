/*******************************
 *                             *
 *  Кофф Даниил ПИ-221         *
 *  Лаборторная работа 1-2     *
 *                             *
 *******************************/

using System;

namespace Lab1 {
  class Program {
    static void Main(string[] args) {
      int xNaturalNumber;
      int decimalBuffer;
      int nResult;

      xNaturalNumber = Convert.ToInt32(Console.ReadLine());

      for (decimalBuffer = 1; decimalBuffer <= xNaturalNumber; decimalBuffer *= 10);

      nResult = xNaturalNumber / (decimalBuffer / 10) * (decimalBuffer / 10)
              + xNaturalNumber % (decimalBuffer / 100) * 10
              + xNaturalNumber / (decimalBuffer / 100) % 10;

      Console.WriteLine("\n" + nResult);

      Console.ReadKey();
    }
  }
}