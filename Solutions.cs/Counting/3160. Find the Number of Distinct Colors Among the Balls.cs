namespace Problem3160
{

  /// <summary>
  /// 3160. Find the Number of Distinct Colors Among the Balls
  /// https://leetcode.com/problems/find-the-number-of-distinct-colors-among-the-balls
  /// 
  /// Difficulty Medium
  /// Acceptance 54.3%
  /// 
  /// Array
  /// Hash Table
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[] QueryResults(int _, int[][] queries)
    {
      var result = new int[queries.Length];
      var colors = new Dictionary<int, int>(queries.Length);
      var colorsCount = new Dictionary<int, int>(queries.Length);
      var currentColorsCount = 0;
      for (var i = 0; i < queries.Length; i++)
      {
        var query = queries[i];
        var ballIndex = query[0];
        var newColor = query[1];

        if (colors.TryGetValue(ballIndex, out var oldColor))
        {
          colorsCount[oldColor]--;
          if (colorsCount[oldColor] == 0)
            currentColorsCount--;
        }

        colorsCount[newColor] = colorsCount.GetValueOrDefault(newColor) + 1;
        if (colorsCount[newColor] == 1)
          currentColorsCount++;

        colors[ballIndex] = newColor;

        result[i] = currentColorsCount;
      }

      return result;
    }
  }
}
