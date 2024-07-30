namespace Problem3005
{

  /// <summary>
  /// 3005. Count Elements With Maximum Frequency
  /// https://leetcode.com/problems/count-elements-with-maximum-frequency
  /// 
  /// Difficulty Easy
  /// Acceptance 78.9%
  /// 
  /// Array
  /// Hash Table
  /// Counting
  /// </summary>
  public class Solution
  {
    public int MaxFrequencyElements(int[] nums)
    {
      var freqs = new int[100];
      for (var i = 0; i < nums.Length; i++)
        freqs[nums[i] - 1] += 1;

      var maxFreq = 0;
      for (var i = 0; i < freqs.Length; i++)
      {
        if (freqs[i] > maxFreq)
          maxFreq = freqs[i];
      }

      var count = 0;
      for (var i = 0; i < freqs.Length; i++)
      {
        if (freqs[i] == maxFreq)
          count++;
      }

      return count * maxFreq;
    }
  }
}
