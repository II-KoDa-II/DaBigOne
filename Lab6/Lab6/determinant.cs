using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
  class Gaus
  {
    static double[][] MatrixCreate(int rows, int cols)
    {
      double[][] result = new double[rows][];
      for (int index = 0; index < rows; ++index)
        result[index] = new double[cols];
      return result;
    }

    static double[][] MatrixDuplicate(double[][] matrix)
    {
      double[][] result = MatrixCreate(matrix.Length, matrix[0].Length);
      for (int row = 0; row < matrix.Length; ++row) 
        for (int column = 0; column < matrix[row].Length; ++column)
          result[row][column] = matrix[row][column];
      return result;
    }

    static double[][] MatrixDecompose(double[][] matrix,
      out int[] perm, out int toggle)
    {
      int MaxLength = matrix.Length; 
      double[][] result = MatrixDuplicate(matrix);
      perm = new int[MaxLength];
      for (int mainIndex = 0; mainIndex < MaxLength; ++mainIndex) { perm[mainIndex] = mainIndex; }
      toggle = 1;
      for (int index = 0; index < MaxLength - 1; ++index) 
      {
        double colMax = Math.Abs(result[index][index]); 
        int pRow = index;
        for (int i = index + 1; i < MaxLength; ++i)
        {
          if (result[i][index] > colMax)
          {
            colMax = result[i][index];
            pRow = i;
          }
        }
        if (pRow != index)
        {
          double[] rowPtr = result[pRow];
          result[pRow] = result[index];
          result[index] = rowPtr;
          int tmp = perm[pRow];
          perm[pRow] = perm[index];
          perm[index] = tmp;
          toggle = -toggle; 
        }
        if (Math.Abs(result[index][index]) < 1.0E-20)
          return null;
        for (int i = index + 1; i < MaxLength; ++i)
        {
          result[i][index] /= result[index][index];
          for (int k = index + 1; k < MaxLength; ++k)
            result[i][k] -= result[i][index] * result[index][k];
        }
      }
      return result;
    }

    static public double MatrixDeterminant(double[][] matrix)
    {
      int[] perm;
      int toggle;
      double[][] lum = MatrixDecompose(matrix, out perm, out toggle);
      if (lum == null)
        throw new Exception("Unable to compute MatrixDeterminant");
      double result = toggle;
      for (int index = 0; index < lum.Length; ++index)
        result *= lum[index][index];
      return result;
    }

  }
}
