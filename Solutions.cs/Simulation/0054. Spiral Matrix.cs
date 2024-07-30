namespace Problem54
{

  /// <summary>
  /// 54. Spiral Matrix
  /// https://leetcode.com/problems/spiral-matrix
  /// 
  /// Difficulty Medium
  /// Acceptance 50.5%
  /// 
  /// Array
  /// Matrix
  /// Simulation
  /// </summary>
  public class Solution
  {
    public List<int> SpiralOrder(int[][] matrix)
    {
      var m = matrix.Length;
      var n = matrix[0].Length;
      var result = new List<int>(m * n);
      var i = 0;
      var x = 0;
      var y = 0;
      var stepX = 1;
      var stepY = 0;
      while (i < m * n)
      {
        i++;
        result.Add(matrix[y][x]);
        matrix[y][x] = -200;
        var nextX = x + stepX;
        var nextY = y + stepY;
        if (nextX < 0 || nextX >= n ||
            nextY < 0 || nextY >= m ||
            matrix[nextY][nextX] == -200)
        {
          var temp = stepY;
          stepY = stepX;
          stepX = -temp;
        }

        x += stepX;
        y += stepY;
      }

      return result;
    }
  }
}
