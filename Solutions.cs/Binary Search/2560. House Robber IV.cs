namespace Problem2560
{

  /// <summary>
  /// 2560. House Robber IV
  /// https://leetcode.com/problems/house-robber-iv
  /// 
  /// Difficulty Medium
  /// Acceptance 53.9%
  /// 
  /// Array
  /// Binary Search
  /// </summary>
  public class Solution
  {
    public int MinCapability(int[] numbers, int k)
    {
      var min = int.MaxValue;
      var max = int.MinValue;
      for (var i = 0; i < numbers.Length; i++)
      {
        if (min > numbers[i])
          min = numbers[i];

        if (max < numbers[i])
          max = numbers[i];
      }

      while (max > min)
      {
        var middle = max + min >> 1;
        var count = 0;
        for (var i = 0; i < numbers.Length; i++)
        {
          if (numbers[i] <= middle)
          {
            if (++count == k)
              break;

            i++;
          }
        }

        if (count == k)
        {
          max = middle;
        }
        else
        {
          min = middle + 1;
        }
      }

      return min;
    }
  }
}
