namespace Problem2554
{

  /// <summary>
  /// 2554. Maximum Number of Integers to Choose From a Range I
  /// https://leetcode.com/problems/maximum-number-of-integers-to-choose-from-a-range-i
  /// 
  /// Difficulty Medium
  /// Acceptance 63.6%
  /// 
  /// Array
  /// Hash Table
  /// Binary Search
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int MaxCount(int[] bannedRaw, int n, int maxSum)
    {
      var banned = bannedRaw.ToHashSet();
      var count = 0;
      var number = 1;
      while (number <= n && number <= maxSum)
      {
        if (!banned.Contains(number))
        {
          count++;
          maxSum -= number;
        }

        number++;
      }

      return count;
    }
  }
}
