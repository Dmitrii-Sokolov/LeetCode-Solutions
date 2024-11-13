namespace Problem1608
{

  /// <summary>
  /// 1608. Special Array With X Elements Greater Than or Equal X
  /// https://leetcode.com/problems/special-array-with-x-elements-greater-than-or-equal-x
  /// 
  /// Difficulty Easy
  /// Acceptance 66.9%
  /// 
  /// Array
  /// Binary Search
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int SpecialArray(int[] nums)
    {
      var max = nums.Length;
      var min = 1;

      while (min <= max)
      {
        var middle = (max + min) / 2;
        var count = 0;

        foreach (var n in nums)
        {
          if (n >= middle)
            count++;
        }

        if (count == middle)
        {
          return count;
        }
        else if (count < middle)
        {
          max = middle - 1;
        }
        else
        {
          min = middle + 1;
        }
      }

      return -1;
    }
  }
}
