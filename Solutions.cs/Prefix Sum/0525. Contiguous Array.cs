namespace Problem525
{

  /// <summary>
  /// 525. Contiguous Array
  /// https://leetcode.com/problems/contiguous-array
  /// 
  /// Difficulty Medium
  /// Acceptance 49.0%
  /// 
  /// Array
  /// Hash Table
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int FindMaxLength(int[] nums)
    {
      var counters = new Dictionary<int, int>();
      counters[0] = -1;
      var result = 0;
      var prefix = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        prefix += nums[i] == 0 ? -1 : 1;

        if (counters.TryGetValue(prefix, out var c))
        {
          result = Math.Max(result, i - c);
        }
        else
        {
          counters[prefix] = i;
        }
      }

      return result;
    }
  }
}
