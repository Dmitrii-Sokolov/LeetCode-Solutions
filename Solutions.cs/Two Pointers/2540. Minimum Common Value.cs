namespace Problem2540
{

  /// <summary>
  /// 2540. Minimum Common Value
  /// https://leetcode.com/problems/minimum-common-value
  /// 
  /// Difficulty Easy
  /// Acceptance 58.9%
  /// 
  /// Array
  /// Hash Table
  /// Two Pointers
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public int GetCommon(int[] nums1, int[] nums2)
    {
      var n1 = 0;
      var n2 = 0;
      while (n1 < nums1.Length && n2 < nums2.Length)
      {
        var number1 = nums1[n1];
        var number2 = nums2[n2];

        if (number1 == number2)
          return number1;
        else if (number1 < number2)
          n1++;
        else if (number1 > number2)
          n2++;
      }

      return -1;
    }
  }
}
