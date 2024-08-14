namespace Problem719
{

  /// <summary>
  /// 719. Find K-th Smallest Pair Distance
  /// https://leetcode.com/problems/find-k-th-smallest-pair-distance/description/?envType=daily-question&envId=2024-08-14
  /// 
  /// Difficulty Hard
  /// Acceptance 39.4%
  /// 
  /// Array
  /// Two Pointers
  /// Binary Search
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int SmallestDistancePair(int[] numbers, int targetCount)
    {
      Array.Sort(numbers);
      var minNumber = numbers.Min();
      var maxNumber = numbers.Max();
      var min = 0;
      var max = maxNumber - minNumber;

      while (min < max)
      {
        var middle = max + min >> 1;
        var (count, sum) = CountLesserSums(numbers, middle);

        if (count < targetCount)
          min = middle + 1;
        else if (count > targetCount)
        {
          max = sum;
        }
        else
        {
          return sum;
        }
      }

      return max;
    }

    private (int Count, int Max) CountLesserSums(int[] numbers, int threshold)
    {
      var result = 0;
      var offset = 0;
      var max = 0;
      for (var i = 0; i < numbers.Length; i++)
      {
        if (offset < i)
          offset = i;

        while (offset < numbers.Length - 1 && numbers[offset + 1] - numbers[i] <= threshold)
          offset++;

        max = Math.Max(max, numbers[offset] - numbers[i]);
        result += offset - i;
      }

      return (result, max);
    }
  }
}
