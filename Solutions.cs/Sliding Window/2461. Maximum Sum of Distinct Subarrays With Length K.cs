namespace Problem2461
{

  /// <summary>
  /// 2461. Maximum Sum of Distinct Subarrays With Length K
  /// https://leetcode.com/problems/maximum-sum-of-distinct-subarrays-with-length-k
  /// 
  /// Difficulty Medium
  /// Acceptance 40.3%
  /// 
  /// Array
  /// Hash Table
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    public long MaximumSubarraySum(int[] numbers, int k)
    {
      Span<int> counts = stackalloc int[100_001];
      var duplicates = 0;
      var sum = 0L;
      var result = 0L;
      var left = 0;
      var right = -1;
      var number = 0;
      while (right < k - 1)
      {
        number = numbers[++right];
        sum += number;
        if (++counts[number] > 1)
          duplicates++;
      }

      if (duplicates == 0)
        result = sum;

      while (right < numbers.Length - 1)
      {
        number = numbers[left++];
        sum -= number;
        if (--counts[number] > 0)
          duplicates--;

        number = numbers[++right];
        sum += number;
        if (++counts[number] > 1)
          duplicates++;

        if (duplicates == 0 && result < sum)
          result = sum;
      }

      return result;
    }

    //public long MaximumSubarraySum(int[] numbers, int k)
    //{
    //  var lastOccurrence = new int[100_001];
    //  var sum = 0L;
    //  var result = 0L;
    //  var left = 0;
    //  var right = -1;
    //  while (CouldMoveRight())
    //  {
    //    MoveRight();

    //    if (IsGoodWindow())
    //    {
    //      RecordResult();
    //      MoveLeft();
    //    }
    //  }

    //  return result;

    //  bool CouldMoveRight() => right < numbers.Length - 1;

    //  void MoveRight()
    //  {
    //    ++right;
    //    var number = numbers[right];
    //    sum += number;

    //    var last = lastOccurrence[number] - 1;
    //    lastOccurrence[number] = right + 1;

    //    while (left <= last)
    //      MoveLeft();
    //  }

    //  bool IsGoodWindow() => right - left + 1 == k;

    //  void RecordResult()
    //  {
    //    if (result < sum)
    //      result = sum;
    //  }

    //  void MoveLeft()
    //  {
    //    sum -= numbers[left];
    //    ++left;
    //  }
    //}
  }
}
