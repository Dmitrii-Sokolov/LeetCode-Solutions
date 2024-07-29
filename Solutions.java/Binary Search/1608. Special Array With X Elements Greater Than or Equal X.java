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
class Solution
{
  public int specialArray(int[] nums)
  {
    var max = nums.length;
    var min = 1;

    while (min <= max)
    {
      var middle = (max + min) / 2;
      var count = 0;

      for (var n : nums)
      {
        if (n >= middle)
        {
          count++;
        }
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

    // var freq = new int[1001];
    // for (var n : nums) {
    //     freq[n]++;
    // }

    // var count = 0;
    // for (var index = 1000; index >= 0; index--) {
    //     count += freq[index];
    //     if (count > index) {
    //         return -1;
    //     } else if (count == index) {
    //         return count;
    //     }
    // }

    // return -2;
  }
}
