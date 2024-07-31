namespace Problem1502
{

  /// <summary>
  /// 1502. Can Make Arithmetic Progression From Sequence
  /// https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence
  /// 
  /// Difficulty Easy
  /// Acceptance 69.6%
  /// 
  /// Array
  /// Sorting
  /// </summary>
  public class Solution
  {
    public bool CanMakeArithmeticProgression(int[] arr)
    {
      if (arr.Length == 1)
        return true;

      Array.Sort(arr);
      var step = arr[1] - arr[0];
      for (var i = 1; i < arr.Length; i++)
      {
        if (arr[i] - arr[i - 1] != step)
          return false;
      }

      return true;
    }
  }
}
