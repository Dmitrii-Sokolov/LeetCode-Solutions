namespace Problem330
{

  /// <summary>
  /// 330. Patching Array
  /// https://leetcode.com/problems/patching-array
  /// 
  /// Difficulty Hard
  /// Acceptance 53.1%
  /// 
  /// Array
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int MinPatches(int[] nums, int n)
    {
      long coverage = 0;
      var p = 0;
      var result = 0;

      while (coverage < n)
      {
        if (p < nums.Length && nums[p] <= coverage + 1)
        {
          coverage += nums[p];
          p++;
        }
        else
        {
          coverage += coverage + 1;
          result++;
        }
      }

      return result;
    }
  }
}
