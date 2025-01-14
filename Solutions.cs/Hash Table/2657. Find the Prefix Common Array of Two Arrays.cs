namespace Problem2657
{

  /// <summary>
  /// 2657. Find the Prefix Common Array of Two Arrays
  /// https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays
  /// 
  /// Difficulty Medium
  /// Acceptance 84.2%
  /// 
  /// Array
  /// Hash Table
  /// Bit Manipulation
  /// </summary>
  public class Solution
  {
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
      var n = A.Length;
      var counts = new int[n];
      var result = new int[n];
      var count = 0;
      for (var i = 0; i < n; i++)
      {
        if (++counts[A[i] - 1] == 2)
          count++;

        if (++counts[B[i] - 1] == 2)
          count++;

        result[i] = count;
      }

      return result;
    }
  }
}
