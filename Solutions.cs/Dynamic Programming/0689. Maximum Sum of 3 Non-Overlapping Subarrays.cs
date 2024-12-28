namespace Problem689
{

  /// <summary>
  /// 689. Maximum Sum of 3 Non-Overlapping Subarrays
  /// https://leetcode.com/problems/maximum-sum-of-3-non-overlapping-subarrays
  /// 
  /// Difficulty Hard
  /// Acceptance 52.8%
  /// 
  /// Array
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int[] MaxSumOfThreeSubarrays(int[] numbers, int k)
    {
      var prefixes = new long[numbers.Length + 1];
      for (var i = 0; i < numbers.Length; i++)
        prefixes[i + 1] = prefixes[i] + numbers[i];

      var sums = new long[numbers.Length + 1 - k];
      for (var i = 0; i < numbers.Length + 1 - k; i++)
        sums[i] = prefixes[i + k] - prefixes[i];

      var maxs1 = new int[sums.Length - 2 * k];
      maxs1[^1] = sums.Length - 1;
      for (var i = maxs1.Length - 2; i >= 0; i--)
        maxs1[i] = sums[i + 2 * k] >= sums[maxs1[i + 1]]
          ? i + 2 * k
          : maxs1[i + 1];

      var maxs2 = new int[sums.Length - 2 * k];
      maxs2[^1] = sums.Length - 1 - k;
      for (var i = maxs2.Length - 2; i >= 0; i--)
        maxs2[i] = sums[i + k] + sums[maxs1[i]] >= sums[maxs2[i + 1]] + sums[maxs1[maxs2[i + 1] - k]]
          ? i + k
          : maxs2[i + 1];

      int[] bestTriple = [sums.Length - 2 * k - 1, sums.Length - 1 * k - 1, sums.Length - 0 * k - 1];
      for (var i = sums.Length - 2 * k - 2; i >= 0; i--)
      {
        if (sums[i] + sums[maxs2[i]] + sums[maxs1[maxs2[i] - k]] >=
          sums[bestTriple[0]] + sums[bestTriple[1]] + sums[bestTriple[2]])
        {
          bestTriple = [i, maxs2[i], maxs1[maxs2[i] - k]];
        }
      }

      return bestTriple;
    }
  }
}
