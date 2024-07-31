namespace Problem1051
{

  /// <summary>
  /// 1051. Height Checker
  /// https://leetcode.com/problems/height-checker
  /// 
  /// Difficulty Easy
  /// Acceptance 80.8%
  /// 
  /// Array
  /// Sorting
  /// Counting Sort
  /// </summary>
  public class Solution
  {
    public int HeightChecker(int[] heights)
    {
      var expected = (int[])heights.Clone();
      Array.Sort(expected);

      var result = 0;

      for (var i = 0; i < expected.Length; i++)
      {
        if (expected[i] != heights[i])
          result++;
      }

      return result;
    }
  }
}
