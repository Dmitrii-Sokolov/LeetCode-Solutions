namespace Problem1248
{

  /// <summary>
  /// 1248. Count Number of Nice Subarrays
  /// https://leetcode.com/problems/count-number-of-nice-subarrays
  /// 
  /// Difficulty Medium
  /// Acceptance 71.2%
  /// 
  /// Array
  /// Hash Table
  /// Math
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public int NumberOfSubarrays(int[] nums, int k)
    {
      var queue = new Queue<int>();
      var last = -1;
      var i = 0;
      while (k > 0 && i < nums.Length)
      {
        if (nums[i] % 2 > 0)
        {
          queue.Enqueue(i - last);
          last = i;
          k--;
        }

        i++;
      }

      if (k > 0)
        return 0;

      var result = 0;
      while (i <= nums.Length)
      {
        while (i < nums.Length && nums[i] % 2 == 0)
          i++;

        result += queue.Dequeue() * (i - last);
        queue.Enqueue(i - last);

        last = i;
        i++;
      }

      return result;
    }
  }
}
