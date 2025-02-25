namespace Problem1524
{

  /// <summary>
  /// 1524. Number of Sub-arrays With Odd Sum
  /// https://leetcode.com/problems/number-of-sub-arrays-with-odd-sum
  /// 
  /// Difficulty Medium
  /// Acceptance 50.7%
  /// 
  /// Array
  /// Math
  /// Dynamic Programming
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    private const uint Modulo = 1000_000_007u;

    public int NumOfSubarrays(int[] numbers)
    {
      var prefix = 0;
      var evenPrefixesCount = 0;

      for (var i = 0; i < numbers.Length; i++)
      {
        prefix += numbers[i];
        evenPrefixesCount += prefix & 1;
      }

      var oddPrefixCount = numbers.Length + 1 - evenPrefixesCount;
      var result = (uint)oddPrefixCount * (uint)evenPrefixesCount % Modulo;

      return (int)result;
    }
  }
}
