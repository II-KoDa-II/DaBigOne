/***************************
 *                         *
 *  Кофф Даниил ПИ-221     *
 *  Лабораторная работа 2  *
 *                         *
 ***************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
  class SquareMatrix: ICloneable {
    private int Dimension;
    public SquareMatrix(int Dimension) {
      if (Dimension <= 0) {
        throw new InvalidMatrixException(Dimension.ToString());
      } else {
        this.Dimension = Dimension;
      }
    }

    public int[,] Matrix = new int[100, 100];

    public void CreateMatrix() {
      Random RandomNumber = new Random();
      for (int RowIndex1 = 0; RowIndex1 < Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < Dimension; ++ClolumnIndex) {
          Matrix[RowIndex1, ClolumnIndex] = RandomNumber.Next(0, 10);
        }
      }
    }

    public object Clone() {
      SquareMatrix DeepCloneMatrix = new SquareMatrix(this.Dimension);
      return DeepCloneMatrix;
    }

    public static SquareMatrix operator +(SquareMatrix MatrixA, SquareMatrix MatrixB) {
      SquareMatrix Answer = new SquareMatrix(MatrixA.Dimension);
      for (int RowIndex1 = 0; RowIndex1 < MatrixA.Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < MatrixA.Dimension; ++ClolumnIndex) {
          Answer.Matrix[RowIndex1, ClolumnIndex] = MatrixA.Matrix[RowIndex1, ClolumnIndex] + MatrixB.Matrix[RowIndex1, ClolumnIndex];
        }
      }
      return Answer;
    }

    public static SquareMatrix operator *(SquareMatrix MatrixA, SquareMatrix MatrixB) {
      SquareMatrix Answer = new SquareMatrix(MatrixA.Dimension);
      for (int RowIndex1 = 0; RowIndex1 < MatrixA.Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < MatrixA.Dimension; ++ClolumnIndex) {
          for (int MultiplicationIndex = 0; MultiplicationIndex < MatrixA.Dimension; ++MultiplicationIndex) {
            Answer.Matrix[RowIndex1, ClolumnIndex] = MatrixA.Matrix[RowIndex1, MultiplicationIndex] * MatrixB.Matrix[MultiplicationIndex, ClolumnIndex];
          }
        }
      }
      return Answer;
    }

    public static explicit operator double[][](SquareMatrix MatrixA) {
      double[][] Answer = new double[MatrixA.Dimension][];
      for (int RowIndex1 = 0; RowIndex1 < MatrixA.Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < MatrixA.Dimension; ++ClolumnIndex) {
          Answer[RowIndex1][ClolumnIndex] = MatrixA.Matrix[RowIndex1, ClolumnIndex];
        }
      }
      return Answer;
    }

    public static bool operator >(SquareMatrix MatrixA, SquareMatrix MatrixB) {
      double[][] doubleMatrix1 = (double[][])MatrixA;
      double[][] doubleMatrix2 = (double[][])MatrixB;
      double detA = ConsoleApp2.Gaus.MatrixDeterminant(doubleMatrix1);
      double detB = ConsoleApp2.Gaus.MatrixDeterminant(doubleMatrix2);

      return (detA > detB);
    }

    public static bool operator <(SquareMatrix MatrixA, SquareMatrix MatrixB) {
      double[][] doubleMatrix1 = (double[][])MatrixA;
      double[][] doubleMatrix2 = (double[][])MatrixB;
      double detA = ConsoleApp2.Gaus.MatrixDeterminant(doubleMatrix1);
      double detB = ConsoleApp2.Gaus.MatrixDeterminant(doubleMatrix2);

      return (detA < detB);
    }

    public static bool operator >=(SquareMatrix MatrixA, SquareMatrix MatrixB) {
      double[][] doubleMatrix1 = (double[][])MatrixA;
      double[][] doubleMatrix2 = (double[][])MatrixB;
      double detA = ConsoleApp2.Gaus.MatrixDeterminant(doubleMatrix1);
      double detB = ConsoleApp2.Gaus.MatrixDeterminant(doubleMatrix2);

      return (detA >= detB);
    }

    public static bool operator <=(SquareMatrix MatrixA, SquareMatrix MatrixB) {
      double[][] doubleMatrix1 = (double[][])MatrixA;
      double[][] doubleMatrix2 = (double[][])MatrixB;
      double detA = ConsoleApp2.Gaus.MatrixDeterminant(doubleMatrix1);
      double detB = ConsoleApp2.Gaus.MatrixDeterminant(doubleMatrix2);

      return (detA <= detB);
    }

    public static bool operator ==(SquareMatrix MatrixA, SquareMatrix MatrixB) {
      for (int RowIndex1 = 0; RowIndex1 < MatrixA.Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < MatrixA.Dimension; ++ClolumnIndex) {
          if (MatrixA.Matrix[RowIndex1, ClolumnIndex] != MatrixB.Matrix[RowIndex1, ClolumnIndex]) {
            return false;
          }
        }
      }
      return true;
    }

    public static bool operator !=(SquareMatrix MatrixA, SquareMatrix MatrixB) {
      for (int RowIndex1 = 0; RowIndex1 < MatrixA.Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < MatrixA.Dimension; ++ClolumnIndex) {
          if (MatrixA.Matrix[RowIndex1, ClolumnIndex] == MatrixB.Matrix[RowIndex1, ClolumnIndex]) {
            return false;
          }
        }
      }
      return true;
    }

    public static bool operator true(SquareMatrix MatrixA) {
      for (int RowIndex1 = 0; RowIndex1 < MatrixA.Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < MatrixA.Dimension; ++ClolumnIndex) {
          if (MatrixA.Matrix[RowIndex1, ClolumnIndex] == 0) {
            return false;
          }
        }
      }
      return true;
    }

    public static bool operator false(SquareMatrix MatrixA) {
      for (int RowIndex1 = 0; RowIndex1 < MatrixA.Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < MatrixA.Dimension; ++ClolumnIndex) {
          if (MatrixA.Matrix[RowIndex1, ClolumnIndex] != 0) {
            return false;
          }
        }
      }
      return true;
    }

    public static double Detdeterminant(SquareMatrix MatrixA) {
      double Answer;
      double[][] mat = (double[][])MatrixA;
      Answer = ConsoleApp2.Gaus.MatrixDeterminant(mat);
      return Answer;
    }

    public static double[][] InversesMatrix(SquareMatrix MatrixA) {
      double[][] Answer = new double[MatrixA.Dimension][];
      for (int RowIndex1 = 0; RowIndex1 < MatrixA.Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < MatrixA.Dimension; ++ClolumnIndex) {
          Answer[RowIndex1][ClolumnIndex] = MatrixA.Matrix[ClolumnIndex, RowIndex1];
        }
      }

      double Detdeterminant = ConsoleApp2.Gaus.MatrixDeterminant(Answer);

      for (int RowIndex1 = 0; RowIndex1 < MatrixA.Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < MatrixA.Dimension; ++ClolumnIndex) {
          Answer[RowIndex1][ClolumnIndex] /= Detdeterminant;
        }
      }
      return Answer;
    }

    public override bool Equals(Object obj1) {
      if (obj1 is SquareMatrix) {
        return true;
      } else {
        return false;
      }
    }

    public override int GetHashCode() {
      return (int)this.Dimension;
    }

    public override string ToString() {
      string strResult = "";

      for (int RowIndex1 = 0; RowIndex1 < Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < Dimension; ++ClolumnIndex) {
          strResult += Matrix[RowIndex1, ClolumnIndex].ToString();
        }
      }
      return strResult;
    }

    public int CompareTo(object other) {
      if (other is SquareMatrix) {
        if (Matrix[0, 0] > Matrix[1, 0])
          return -1;
        if (Matrix[0, 0] == Matrix[1, 0])
          return 0;
        if (Matrix[0, 0] < Matrix[1, 0])
          return 1;
      }
      return -1;
    }

    public void Display() {
      for (int RowIndex1 = 0; RowIndex1 < Dimension; ++RowIndex1) {
        for (int ClolumnIndex = 0; ClolumnIndex < Dimension; ++ClolumnIndex) {
          Console.Write(Matrix[RowIndex1, ClolumnIndex] + " ");
        }
        Console.WriteLine("\n");
      }
    }
  }
  public class InvalidMatrixException: System.Exception {
    public InvalidMatrixException(string WrongDimension)
        : base("Incorrect matrix size " + WrongDimension) { }
  }

  public class Singleton {
    public static Singleton Instance {
      get {
        if (instance == null)
          instance = new Singleton();
        return instance;
      }
    }
    public void MatrixCalculator() {
      int Dimension;
      bool Key = true;
      string Operation;

      Console.WriteLine("Choose matrix size ");
      Dimension = Convert.ToInt32(Console.ReadLine());

      while (Key) {
        Key = false;
        try {
          SquareMatrix TextMatrix = new SquareMatrix(Dimension);
        } catch (InvalidMatrixException Error) {
          Console.WriteLine("Error: " + Error.Message);
          Key = true;
          Dimension = Convert.ToInt32(Console.ReadLine());
        }
      }

      Console.WriteLine("First matrix");
      SquareMatrix matrix1 = new SquareMatrix(Dimension);

      matrix1.CreateMatrix();
      matrix1.Display();

      Console.WriteLine("Second matrix");
      SquareMatrix matrix2 = (SquareMatrix)matrix1.Clone();

      matrix2.CreateMatrix();
      matrix2.Display();

      Console.WriteLine("Choose operation" +
                        "\n1 +" +
                        "\n2 *" +
                        "\n3 determinant" +
                        "\n4 inversion" +
                        "\n5 >" +
                        "\n6 <" +
                        "\n7 >=" +
                        "\n8 <=" +
                        "\n9 ==" +
                        "\n10 !=" +
                        "\n11 true" +
                        "\n12 false" +
                        "\n13 equals" +
                        "\n14 hash" +
                        "\n15 string" +
                        "\n16 compare");
      Operation = Convert.ToString(Console.ReadLine());

      switch (Operation) {
        case "1":
        SquareMatrix SumMatrix = matrix1 + matrix2;
        SumMatrix.Display();
        break;

        case "2":
        SquareMatrix MultipliedMatrix = matrix1 * matrix2;
        MultipliedMatrix.Display();
        break;

        case "3":
        double det1 = SquareMatrix.Detdeterminant(matrix1);
        Console.WriteLine(det1);
        break;

        case "4":
        double[][] invers = SquareMatrix.InversesMatrix(matrix1);
        for (int RowIndex1 = 0; RowIndex1 < Dimension; ++RowIndex1) {
          for (int ClolumnIndex = 0; ClolumnIndex < Dimension; ++ClolumnIndex) {
            Console.Write(invers[RowIndex1][ClolumnIndex] + " ");
          }
          Console.WriteLine("\n");
        }
        break;

        case "5":
        Console.WriteLine(matrix1 > matrix2);
        break;

        case "6":
        Console.WriteLine(matrix1 < matrix2);
        break;

        case "7":
        Console.WriteLine(matrix1 >= matrix2);
        break;

        case "8":
        Console.WriteLine(matrix1 <= matrix2);
        break;

        case "9":
        Console.WriteLine(matrix1 == matrix2);
        break;

        case "10":
        Console.WriteLine(matrix1 != matrix2);
        break;

        case "11":
        if (matrix1) {
          Console.WriteLine(true);
        } else {
          Console.WriteLine(false);
        }
        break;

        case "12":
        if (matrix1) {
          Console.WriteLine(false);
        } else {
          Console.WriteLine(true);
        }
        break;

        case "13":
        Console.WriteLine(Equals(matrix1));
        break;

        case "14":
        Console.WriteLine(GetHashCode());
        break;

        case "15":
        Console.WriteLine(matrix1.ToString());
        break;

        case "16":
        Console.WriteLine(matrix2.CompareTo(matrix1));
        break;

        default:
        Console.WriteLine("Incorrect operation");
        break;
      }
    }
    private Singleton() { }
    private static Singleton instance;
  }

  class Program {
    static void Main(string[] args) {
      Singleton.Instance.MatrixCalculator();
      Console.ReadKey();
    }
  }
}