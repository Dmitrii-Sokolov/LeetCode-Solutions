namespace Problem976
{

  /// <summary>
  /// 976. Largest Perimeter Triangle
  /// https://leetcode.com/problems/largest-perimeter-triangle
  /// 
  /// Difficulty Easy
  /// Acceptance 56.2%
  /// 
  /// Array
  /// Math
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int LargestPerimeter(int[] nums)
    {
      for (var i = 0; i < nums.Length; i++)
      {
        var max = i;
        for (var k = i; k < nums.Length; k++)
        {
          if (nums[k] > nums[max])
            max = k;
        }

        (nums[max], nums[i]) = (nums[i], nums[max]);

        if (i > 1)
        {
          if (nums[i] + nums[i - 1] > nums[i - 2])
            return nums[i] + nums[i - 1] + nums[i - 2];
        }
      }

      return 0;
    }
  }
}
