namespace Problem2379
{

  /// <summary>
  /// 2379. Minimum Recolors to Get K Consecutive Black Blocks
  /// https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks
  /// 
  /// Difficulty Easy
  /// Acceptance 63.2%
  /// 
  /// String
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int MinimumRecolors(string blocks, int k)
    {
      var result = k;
      var count = 0;

      for (var i = 0; i < k - 1; i++)
        count += blocks[i] == 'W' ? 1 : 0;

      for (var i = k - 1; i < blocks.Length && result > 0; i++)
      {
        count += blocks[i] == 'W' ? 1 : 0;

        if (result > count)
          result = count;

        count -= blocks[i - k + 1] == 'W' ? 1 : 0;
      }

      return result;
    }
  }
}
