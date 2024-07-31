namespace Problem1992
{

  /// <summary>
  /// 1992. Find All Groups of Farmland
  /// https://leetcode.com/problems/find-all-groups-of-farmland
  /// 
  /// Difficulty Medium
  /// Acceptance 75.8%
  /// 
  /// Array
  /// Depth-First Search
  /// Breadth-First Search
  /// Matrix
  /// </summary>
  public class Solution
  {
    public int[][] FindFarmland(int[][] land)
    {
      var result = new List<int[]>();

      for (var i = 0; i < land.Length; i++)
      {
        for (var n = 0; n < land[0].Length; n++)
        {
          if (land[i][n] == 1)
            result.Add(Check(land, i, n));
        }
      }

      return [.. result];
    }

    private int[] Check(int[][] land, int x, int y)
    {
      var result = new int[4];
      result[0] = x;
      result[1] = y;

      while (x < land.Length - 1 && land[x + 1][y] == 1)
        x++;

      while (y < land[0].Length - 1 && land[x][y + 1] == 1)
        y++;

      result[2] = x;
      result[3] = y;

      for (; x >= result[0]; x--)
      {
        for (y = result[3]; y >= result[1]; y--)
          land[x][y] = 0;
      }

      return result;
    }
  }
}
