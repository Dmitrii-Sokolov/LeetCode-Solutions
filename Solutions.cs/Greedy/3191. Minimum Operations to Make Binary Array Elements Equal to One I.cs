namespace Problem3191
{

  /// <summary>
  /// 3191. Minimum Operations to Make Binary Array Elements Equal to One I
  /// https://leetcode.com/problems/minimum-operations-to-make-binary-array-elements-equal-to-one-i
  /// 
  /// Difficulty Medium
  /// Acceptance 75.9%
  /// 
  /// Array
  /// Bit Manipulation
  /// Queue
  /// Sliding Window
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int MinOperations(int[] numbers)
    {
      var result = 0;
      for (var i = 0; i < numbers.Length - 2; i++)
      {
        if (numbers[i] == 0)
        {
          numbers[i + 1] = 1 - numbers[i + 1];
          numbers[i + 2] = 1 - numbers[i + 2];
          result++;
        }
      }

      return numbers[^1] == 1 && numbers[^2] == 1 ? result : -1;
    }
  }
}
