namespace Problem3208
{

  /// <summary>
  /// 3208. Alternating Groups II
  /// https://leetcode.com/problems/alternating-groups-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 49.5%
  /// 
  /// Array
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int NumberOfAlternatingGroups(int[] colors, int k)
    {
      var n = colors.Length;
      var result = 0;
      var start = 0;
      for (var i = 0; i < n + k - 2; i++)
      {
        if (colors[i % n] == colors[(i + 1) % n])
          start = i + 1;

        if (i - start + 2 >= k)
          result++;
      }

      return result;
    }
  }
}
