namespace Problem974
{

  /// <summary>
  /// 974. Subarray Sums Divisible by K
  /// https://leetcode.com/problems/subarray-sums-divisible-by-k
  /// 
  /// Difficulty Medium
  /// Acceptance 55.5%
  /// 
  /// Array
  /// Hash Table
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int SubarraysDivByK(int[] nums, int k)
    {
      var set = new int[10000];
      var sum = 0;
      var result = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        set[sum]++;
        sum = Mod(sum + nums[i], k);
        result += set[sum];
      }

      return result;
    }

    private static int Mod(int x, int m) => ((x % m) + m) % m;
  }
}
