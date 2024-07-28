namespace Problem1051
{

  /// <summary>
  /// 1051. Height Checker
  /// https://leetcode.com/problems/height-checker/description/
  /// 
  /// Difficulty Easy 80.8%
  /// 
  /// Array
  /// Sorting
  /// Counting Sort
  /// </summary>
  class Solution
  {
    public int heightChecker(int[] heights)
    {
      var expected = heights.clone();
      Arrays.sort(expected);

      var result = 0;

      for (var i = 0; i < expected.length; i++)
      {
        if (expected[i] != heights[i])
        {
          result++;
        }
      }

      return result;
    }
  }
}
