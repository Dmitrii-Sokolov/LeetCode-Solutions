namespace Problem85
{

  /// <summary>
  /// 85. Maximal Rectangle
  /// https://leetcode.com/problems/maximal-rectangle
  /// 
  /// Difficulty Hard 51.1%
  /// 
  /// Array
  /// Dynamic Programming
  /// Stack
  /// Matrix
  /// Monotonic Stack
  /// </summary>
  public class Solution
  {
    public int MaximalRectangle(char[][] matrix)
    {
      if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
        return 0;

      var rowCount = matrix.Length;
      var columnsCount = matrix[0].Length;
      var result = 0;
      var heights = new int[columnsCount];

      for (var i = 0; i < rowCount; i++)
      {
        for (var n = 0; n < columnsCount; n++)
        {
          heights[n] = matrix[i][n] == '1' ? heights[n] + 1 : 0;
        }

        result = Math.Max(result, GetMaxArea(heights));
      }

      return result;
    }

    private int GetMaxArea(int[] heights)
    {
      var stack = new Stack<int>();
      var result = 0;
      var i = 0;

      while (i < heights.Length)
      {
        if (stack.Count == 0 || heights[stack.Peek()] <= heights[i])
        {
          stack.Push(i++);
        }
        else
        {
          int top = stack.Pop();
          int area = heights[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
          result = Math.Max(result, area);
        }
      }

      while (stack.Count > 0)
      {
        var top = stack.Pop();
        var area = heights[top] * (stack.Count == 0 ? i : i - stack.Peek() - 1);
        result = Math.Max(result, area);
      }

      return result;
    }
  }
}
