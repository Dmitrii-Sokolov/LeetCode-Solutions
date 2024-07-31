namespace Problem552
{

  /// <summary>
  /// 552. Student Attendance Record II
  /// https://leetcode.com/problems/student-attendance-record-ii
  /// 
  /// Difficulty Hard
  /// Acceptance 55.2%
  /// 
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int CheckRecord(int n)
    {
      long[,] matrix = {
          {1, 1, 1, 0, 0, 0},
          {1, 0, 0, 0, 0, 0},
          {0, 1, 0, 0, 0, 0},
          {1, 1, 1, 1, 1, 1},
          {0, 0, 0, 1, 0, 0},
          {0, 0, 0, 0, 1, 0}};

      long[] v = { 1, 1, 0, 1, 0, 0 };

      v = Multiply(Pow(matrix, n), v);

      return (int)v[3];
    }

    private int Size = 6;
    private long Modulo = 1000000007;

    private long[,] Pow(long[,] matrix, int power)
    {
      long[,] result = {
          {1, 0, 0, 0, 0, 0},
          {0, 1, 0, 0, 0, 0},
          {0, 0, 1, 0, 0, 0},
          {0, 0, 0, 1, 0, 0},
          {0, 0, 0, 0, 1, 0},
          {0, 0, 0, 0, 0, 1}};

      while (power > 0)
      {
        // result = multiply(result, matrix);
        // power--;

        if (power % 2 > 0)
          result = Multiply(result, matrix);

        power /= 2;
        matrix = Multiply(matrix, matrix);
      }

      return result;
    }

    private long[,] Multiply(long[,] a, long[,] b)
    {
      var result = new long[Size, Size];

      for (var i = 0; i < Size; i++)
      {
        for (var x = 0; x < Size; x++)
        {
          for (var y = 0; y < Size; y++)
          {
            result[x, y] = (result[x, y] + (a[x, i] * b[i, y])) % Modulo;
          }
        }
      }

      return result;
    }

    private long[] Multiply(long[,] matrix, long[] column)
    {
      var result = new long[Size];

      for (var x = 0; x < Size; x++)
      {
        for (var y = 0; y < Size; y++)
        {
          result[x] = (result[x] + (column[y] * matrix[x, y])) % Modulo;
        }
      }

      return result;
    }
  }
}
