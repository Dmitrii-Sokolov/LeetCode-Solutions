namespace Problem1442
{

  /// <summary>
  /// 1442. Count Triplets That Can Form Two Arrays of Equal XOR
  /// https://leetcode.com/problems/count-triplets-that-can-form-two-arrays-of-equal-xor
  /// 
  /// Difficulty Medium
  /// Acceptance 85.0%
  /// 
  /// Array
  /// Hash Table
  /// Math
  /// Bit Manipulation
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int CountTriplets(int[] arr)
    {
      var result = 0;
      for (var i = 0; i < arr.Length - 1; i++)
      {
        var sub = arr[i];
        for (var k = i + 1; k < arr.Length; k++)
        {
          sub ^= arr[k];
          if (sub == 0)
            result += k - i;
        }
      }

      return result;
    }
  }
}
