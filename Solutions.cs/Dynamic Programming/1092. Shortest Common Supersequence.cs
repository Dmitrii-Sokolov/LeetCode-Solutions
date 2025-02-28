namespace Problem1092
{

  /// <summary>
  /// 1092. Shortest Common Supersequence
  /// https://leetcode.com/problems/shortest-common-supersequence
  /// 
  /// Difficulty Hard
  /// Acceptance 60.3%
  /// 
  /// String
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public string ShortestCommonSupersequence(string str0, string str1)
    {
      var xMax = str0.Length;
      var yMax = str1.Length;
      Span<int> path = stackalloc int[(xMax + 1) * (yMax + 1)];

      var x = xMax;
      var y = yMax;
      while (--x >= 0)
      {
        y = yMax;
        while (--y >= 0)
        {
          path[x * (yMax + 1) + y] = str0[x] == str1[y]
            ? path[(x + 1) * (yMax + 1) + y + 1] + 1
            : Math.Max(path[(x + 1) * (yMax + 1) + y], path[x * (yMax + 1) + y + 1]);
        }
      }

      var result = new System.Text.StringBuilder();
      x = 0;
      y = 0;
      while (x < xMax && y < yMax)
      {
        if (str0[x] == str1[y])
        {
          result.Append(str0[x]);
          x++;
          y++;
        }
        else if (path[(x + 1) * (yMax + 1) + y] > path[x * (yMax + 1) + y + 1])
        {
          result.Append(str0[x]);
          x++;
        }
        else
        {
          result.Append(str1[y]);
          y++;
        }
      }

      while (x < xMax)
        result.Append(str0[x++]);

      while (y < yMax)
        result.Append(str1[y++]);

      return result.ToString();
    }
  }
}
