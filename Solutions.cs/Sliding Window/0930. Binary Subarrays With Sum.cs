namespace Problem930
{

  /// <summary>
  /// 930. Binary Subarrays With Sum
  /// https://leetcode.com/problems/binary-subarrays-with-sum
  /// 
  /// Difficulty Medium
  /// Acceptance 63.3%
  /// 
  /// Array
  /// Hash Table
  /// Sliding Window
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int NumSubarraysWithSum(int[] nums, int goal)
    {
      return goal == 0
          ? CountZeroCombinations(nums)
          : CountNonZeroCombinations(nums, goal);
    }

    private int CountZeroCombinations(int[] nums)
    {
      var options = 0;
      var start = 0;
      var end = 0;

      while (start < nums.Length)
      {
        while (start < nums.Length && nums[start] != 0)
          start++;

        end = start;

        while (end < nums.Length && nums[end] == 0)
          end++;

        var count = end - start;
        options += count * (count + 1) / 2;

        start = end + 1;
      }

      return options;
    }

    private int CountNonZeroCombinations(int[] nums, int goal)
    {
      var options = 0;
      var sum = 0;
      var caretRight = 0;
      var caretLeft = 0;

      while (caretRight < nums.Length)
      {
        var leftZeros = -1;
        var rightZeros = 0;

        while (caretRight < nums.Length && sum < goal)
          sum += nums[caretRight++];

        while (caretRight + rightZeros < nums.Length && nums[caretRight + rightZeros] == 0)
          rightZeros++;

        while (caretLeft < nums.Length && sum == goal)
        {
          leftZeros++;
          sum -= nums[caretLeft++];
        }

        options += (leftZeros + 1) * (rightZeros + 1);
      }

      return options;

      /*var options = 0;

      for(var len = Math.Max(goal, 1); len < nums.Length + 1; len++)
      {
          var sum = 0;
          for(var i = 0; i < len; i++)
              sum += nums[i];

          if (sum == goal)
              options++;

          for(var shift = 0; shift < nums.Length - len; shift++)
          {
              sum = sum - nums[shift] + nums[len + shift];

              if (sum == goal)
                  options++;
          }
      }

      return options;*/
    }
  }
}
