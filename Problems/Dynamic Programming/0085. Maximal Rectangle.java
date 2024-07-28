namespace Problem85Java
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
  class Solution
  {
    public int maximalRectangle(char[][] matrix)
    {
      if (matrix == null || matrix.length == 0 || matrix[0].length == 0)
        return 0;

      var rowCount = matrix.length;
      var columnsCount = matrix[0].length;
      var result = 0;
      var heights = new int[columnsCount];

      for (var i = 0; i < rowCount; i++)
      {
        for (var n = 0; n < columnsCount; n++)
        {
          heights[n] = matrix[i][n] == '1' ? heights[n] + 1 : 0;
        }

        result = Math.max(result, GetMaxArea(heights));
      }

      return result;
    }

    private int GetMaxArea(int[] heights)
    {
      var stack = new Stack<Integer>();
      var result = 0;
      var i = 0;

      while (i < heights.length)
      {
        if (stack.size() == 0 || heights[stack.peek()] <= heights[i])
        {
          stack.push(i++);
        }
        else
        {
          int top = stack.pop();
          int area = heights[top] * (stack.size() == 0 ? i : i - stack.peek() - 1);
          result = Math.max(result, area);
        }
      }

      while (stack.size() > 0)
      {
        var top = stack.pop();
        var area = heights[top] * (stack.size() == 0 ? i : i - stack.peek() - 1);
        result = Math.max(result, area);
      }

      return result;
    }
  }
}
