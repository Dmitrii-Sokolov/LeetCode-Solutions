namespace Problem334
{

  /// <summary>
  /// 334. Increasing Triplet Subsequence
  /// https://leetcode.com/problems/increasing-triplet-subsequence
  /// 
  /// Difficulty Medium
  /// Acceptance 39.2%
  /// 
  /// Array
  /// Greedy
  /// </summary>
  public class Solution
  {
    public bool IncreasingTriplet(int[] numbers)
    {
      var first = int.MaxValue;
      var second = int.MaxValue;
      foreach (var number in numbers)
      {
        if (number > second)
        {
          return true;
        }
        else
        {
          if (number > first)
          {
            second = number;
          }
          else
          {
            first = number;
          }
        }
      }

      return false;
    }
  }
}
