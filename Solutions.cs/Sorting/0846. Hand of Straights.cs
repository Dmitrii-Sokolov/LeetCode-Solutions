namespace Problem846
{

  /// <summary>
  /// 846. Hand of Straights
  /// https://leetcode.com/problems/hand-of-straights
  /// 
  /// Difficulty Medium
  /// Acceptance 56.7%
  /// 
  /// Array
  /// Hash Table
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public bool IsNStraightHand(int[] nums, int groupSize)
    {
      if (nums.Length % groupSize > 0)
        return false;
      else if (groupSize == 1)
      {
        return true;
      }

      Array.Sort(nums);
      var i = 0;
      while (i < nums.Length)
      {
        while (i < nums.Length && nums[i] == -1)
        {
          i++;
        }

        if (i == nums.Length)
          return true;

        var start = nums[i];
        var shift = i;
        for (var n = 0; n < groupSize; n++)
        {
          while (shift < nums.Length && nums[shift] != start + n)
          {
            shift++;
          }

          if (shift == nums.Length)
            return false;

          nums[shift] = -1;
        }
      }

      return true;
    }
  }
}
