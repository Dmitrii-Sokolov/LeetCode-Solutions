namespace Problem552
{

  /// <summary>
  /// 552. Student Attendance Record II
  /// https://leetcode.com/problems/student-attendance-record-ii
  /// 
  /// Difficulty Hard 55.2%
  /// 
  /// Dynamic Programming
  /// </summary>
  class Solution
  {
    public int checkRecord(int n)
    {
      long[][] matrix = {
            {1, 1, 1, 0, 0, 0},
            {1, 0, 0, 0, 0, 0},
            {0, 1, 0, 0, 0, 0},
            {1, 1, 1, 1, 1, 1},
            {0, 0, 0, 1, 0, 0},
            {0, 0, 0, 0, 1, 0}};

      long[] v = { 1, 1, 0, 1, 0, 0 };

      v = multiply(pow(matrix, n), v);

      return Math.toIntExact(v[3]);
    }

    private int size = 6;
    private long modulo = 1000000007;

    private long[][] pow(long[][] matrix, int power)
    {
      long[][] result = {
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
        {
          result = multiply(result, matrix);
        }

        power /= 2;
        matrix = multiply(matrix, matrix);
      }

      return result;
    }

    private long[][] multiply(long[][] a, long[][] b)
    {
      var result = new long[size][size];

      for (var i = 0; i < size; i++)
      {
        for (var x = 0; x < size; x++)
        {
          for (var y = 0; y < size; y++)
          {
            result[x][y] = (result[x][y] + a[x][i] * b[i][y]) % modulo;
          }
        }
      }

      return result;
    }

    private long[] multiply(long[][] matrix, long[] column)
    {
      var result = new long[size];

      for (var x = 0; x < size; x++)
      {
        for (var y = 0; y < size; y++)
        {
          result[x] = (result[x] + column[y] * matrix[x][y]) % modulo;
        }
      }

      return result;
    }
  }
}
