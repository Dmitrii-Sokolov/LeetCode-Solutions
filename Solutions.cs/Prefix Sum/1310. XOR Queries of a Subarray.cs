namespace Problem1310
{

  /// <summary>
  /// 1310. XOR Queries of a Subarray
  /// https://leetcode.com/problems/xor-queries-of-a-subarray
  /// 
  /// Difficulty Medium
  /// Acceptance 76.7%
  /// 
  /// Array
  /// Bit Manipulation
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int[] XorQueries(int[] numbers, int[][] queries)
    {
      var prefixes = new int[numbers.Length + 1];
      prefixes[0] = 0;
      for (var i = 0; i < numbers.Length; i++)
        prefixes[i + 1] = prefixes[i] ^ numbers[i];

      var result = new int[queries.Length];
      for (var i = 0; i < queries.Length; i++)
      {
        var left = queries[i][0];
        var right = queries[i][1];
        result[i] = prefixes[right + 1] ^ prefixes[left];
      }

      return result;
    }
  }
}
