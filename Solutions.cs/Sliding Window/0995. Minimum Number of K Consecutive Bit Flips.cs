namespace Problem995
{

  /// <summary>
  /// 995. Minimum Number of K Consecutive Bit Flips
  /// https://leetcode.com/problems/minimum-number-of-k-consecutive-bit-flips
  /// 
  /// Difficulty Hard
  /// Acceptance 62.7%
  /// 
  /// Array
  /// Bit Manipulation
  /// Queue
  /// Sliding Window
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int MinKBitFlips(int[] nums, int k)
    {
      var result = 0;
      var flip = 0;

      for (var i = 0; i < nums.Length; i++)
      {
        if (nums[i] == 0)
        {
          if (flip > 0)
            flip--;
          else
          {
            if (i + k > nums.Length)
              return -1;

            result++;
            flip = k - 1;
          }
        }
        else if (flip > 0)
        {
          if (i + k > nums.Length)
            return -1;

          for (var n = i + flip; n < i + k; n++)
            nums[n] = 1 - nums[n];
          result++;
          flip = 0;
        }
      }

      return result;
    }
  }
}
