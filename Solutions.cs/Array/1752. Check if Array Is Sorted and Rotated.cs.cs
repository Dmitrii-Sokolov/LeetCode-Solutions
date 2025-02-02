namespace Problem1752
{

  /// <summary>
  /// 1752. Check if Array Is Sorted and Rotated
  /// https://leetcode.com/problems/check-if-array-is-sorted-and-rotated
  /// 
  /// Difficulty Easy
  /// Acceptance 52.7%
  /// 
  /// 
  /// </summary>
  public class Solution
  {
    public bool Check(int[] numbers)
    {
      var previous = numbers[^1];
      var step = false;
      foreach (var number in numbers)
      {
        if (previous > number)
        {
          if (step)
            return false;

          step = true;
        }

        previous = number;
      }

      return true;
    }
  }
}
