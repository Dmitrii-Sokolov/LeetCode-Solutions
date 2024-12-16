namespace Problem962
{

  /// <summary>
  /// 962. Maximum Width Ramp
  /// https://leetcode.com/problems/maximum-width-ramp
  /// 
  /// Difficulty Medium
  /// Acceptance 52.4%
  /// 
  /// Array
  /// Stack
  /// Monotonic Stack
  /// </summary>
  public class Solution
  {
    public int MaxWidthRamp(int[] numbers)
    {
      var lastIndex = 0;
      Span<int> monotonicTail = stackalloc int[numbers.Length];
      monotonicTail[lastIndex++] = 0;
      var result = 0;
      for (var i = 1; i < numbers.Length; i++)
      {
        if (numbers[monotonicTail[lastIndex - 1]] > numbers[i])
        {
          monotonicTail[lastIndex++] = i;
        }
        else
        {
          var min = 0;
          var max = lastIndex - 1;
          while (max > min)
          {
            var middle = max + min >> 1;
            if (numbers[monotonicTail[middle]] <= numbers[i])
            {
              max = middle;
            }
            else
            {
              min = middle + 1;
            }
          }

          if (result < i - monotonicTail[min])
            result = i - monotonicTail[min];
        }
      }

      return result;
    }
  }
}
