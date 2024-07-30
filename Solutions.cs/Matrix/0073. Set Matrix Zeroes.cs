namespace Problem73
{

  /// <summary>
  /// 73. Set Matrix Zeroes
  /// https://leetcode.com/problems/set-matrix-zeroes
  /// 
  /// Difficulty Medium
  /// Acceptance 56.7%
  /// 
  /// Array
  /// Hash Table
  /// Matrix
  /// </summary>
  public class Solution
  {
    public void SetZeroes(int[][] matrix)
    {
      var x = -1;
      var y = -1;

      for (var i = 0; i < matrix.Length; i++)
      {
        for (var k = 0; k < matrix[i].Length; k++)
        {
          if (matrix[i][k] == 0)
          {
            if (x == -1)
            {
              x = i;
              y = k;
            }
            else
            {
              matrix[x][k] = 0;
              matrix[i][y] = 0;
            }
          }
        }
      }

      if (x != -1)
      {
        for (var i = 0; i < matrix.Length; i++)
        {
          if (i != x && matrix[i][y] == 0)
          {
            for (var k = 0; k < matrix[i].Length; k++)
            {
              matrix[i][k] = 0;
            }
          }
        }

        for (var k = 0; k < matrix[0].Length; k++)
        {
          if (matrix[x][k] == 0)
          {
            for (var i = 0; i < matrix.Length; i++)
            {
              matrix[i][k] = 0;
            }
          }
        }

        for (var k = 0; k < matrix[0].Length; k++)
        {
          matrix[x][k] = 0;
        }
      }
    }
  }
}
