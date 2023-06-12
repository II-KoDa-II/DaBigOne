using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp1;

namespace UnitTestProject1
{
  [TestMatrix]
  public class UnitTest1
  {
    [TestMethod]
    public void TestSumm()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;
      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      SquareMatrix Result = FirstTestMatrix + SecondTestMatrix;
      Assert.AreEqual("24681012141618", Result.ToString());
    }

    [TestMethod]
    public void Testmultiplication()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;
      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      SquareMatrix Result = FirstTestMatrix * SecondTestMatrix;
      Assert.AreEqual("212427424854637281", Result.ToString());
    }

    [TestMethod]
    public void TestDeterm()
    {
      int Dimension = 3;
      SquareMatrix TestMatrix = new SquareMatrix(Dimension);
      int[,] List = new int[Dimension, Dimension];
      int Summator = 1;
      for (int Row = 0; Row < Dimension; ++Row)
      {
        for (int Column = 0; Column < Dimension; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }
      TestMatrix.CreateMatrix(List);
      double Result = SquareMatrix.Detdeterminant(TestMatrix);
      Assert.AreEqual(6.66, Result, 0.01);
    }

    [TestMethod]
    public void TestInverses()
    {
      int Dimension = 3;
      SquareMatrix TestMatrix = new SquareMatrix(Dimension);
      int[,] List = new int[Dimension, Dimension];
      List[0, 0] = 1;
      List[0, 1] = 2;
      List[0, 2] = 3;
      List[1, 0] = 4;
      List[1, 1] = 5;
      List[1, 2] = 4;
      List[2, 0] = 3;
      List[2, 1] = 2;
      List[2, 2] = 1;

      TestMatrix.CreateMatrix(List);
      double[][] invers = SquareMatrix.InversesMatrix(TestMatrix);
      string Result = "";

      for (int Row = 0; Row < invers.Length; ++Row)
      {
        for (int Column = 0; Column < invers.Length; ++Column)
        {
          Result += invers[Row][Column];
        }
      }

      Console.WriteLine(Result);
      Assert.AreEqual("-0,125-0,5-0,375-0,25-0,625-0,25-0,375-0,5-0,125", Result);
    }

    [TestMethod]
    public void TestGreater()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;

      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      bool Result = FirstTestMatrix > SecondTestMatrix;
      Assert.IsFalse(Result);
    }

    [TestMethod]
    public void TestLess()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;

      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      bool Result = FirstTestMatrix < SecondTestMatrix;
      Assert.IsFalse(Result);
    }

    [TestMethod]
    public void TestEqual()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;

      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      bool Result = FirstTestMatrix == SecondTestMatrix;
      Assert.IsTrue(Result);
    }

    [TestMethod]
    public void TestGreaterOrEqual()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;

      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      bool Result = FirstTestMatrix >= SecondTestMatrix;
      Assert.IsTrue(Result);
    }

    [TestMethod]
    public void TestLessOrEqual()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;

      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      bool Result = FirstTestMatrix <= SecondTestMatrix;
      Assert.IsTrue(Result);
    }

    [TestMethod]
    public void TestNotEqual()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;

      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      bool Result = FirstTestMatrix != SecondTestMatrix;
      Assert.IsFalse(Result);
    }

    [TestMethod]
    public void TestEqual2()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;

      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      bool Result = Equals(FirstTestMatrix, SecondTestMatrix);

      Assert.IsTrue(Result);
    }

    [TestMethod]
    public void TestToString()
    {
      SquareMatrix TestMatrix = new SquareMatrix(3);

      int[,] List = new int[3, 3];
      int Summator = 1;

      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      TestMatrix.CreateMatrix(List);
      string Result = TestMatrix.ToString();

      Assert.AreEqual("123456789", Result);
    }

    [TestMethod]
    public void TestCompare()
    {
      SquareMatrix FirstTestMatrix = new SquareMatrix(3);
      SquareMatrix SecondTestMatrix = new SquareMatrix(3);
      int[,] List = new int[3, 3];
      int Summator = 1;

      for (int Row = 0; Row < 3; ++Row)
      {
        for (int Column = 0; Column < 3; ++Column)
        {
          List[Row, Column] = Summator;
          ++Summator;
        }
      }

      FirstTestMatrix.CreateMatrix(List);
      SecondTestMatrix.CreateMatrix(List);

      int Result = SecondTestMatrix.CompareTo(FirstTestMatrix);

      Assert.AreEqual(1, Result);
    }
  }
}
