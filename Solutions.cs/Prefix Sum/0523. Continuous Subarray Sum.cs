namespace Problem523
{

  /// <summary>
  /// 523. Continuous Subarray Sum
  /// https://leetcode.com/problems/continuous-subarray-sum
  /// 
  /// Difficulty Medium
  /// Acceptance 30.3%
  /// 
  /// Array
  /// Hash Table
  /// Math
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public bool CheckSubarraySum(int[] nums, int k)
    {
      if (nums.Length < 2)
        return false;

      var set = new HashSet<int>();
      var sum = 0;
      var prevSum = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        prevSum = sum;
        sum = ((sum % k) + (nums[i] % k)) % k;
        if (set.Contains(sum))
          return true;
        set.Add(prevSum);
      }

      return false;
    }
  }
}
