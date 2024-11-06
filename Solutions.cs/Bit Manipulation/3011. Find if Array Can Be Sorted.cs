namespace Problem3011
{

  /// <summary>
  /// 3011. Find if Array Can Be Sorted
  /// https://leetcode.com/problems/find-if-array-can-be-sorted
  /// 
  /// Difficulty Medium
  /// Acceptance 60.9%
  /// 
  /// Array
  /// Bit Manipulation
  /// Sorting
  /// </summary>
  public class Solution
  {
    public bool CanSortArray(int[] numbers)
    {
      var currentBitsNumber = 0;
      var currentMax = 0;
      var previousMax = 0;
      for (var i = 0; i < numbers.Length; i++)
      {
        var number = numbers[i];
        var bitsNumber = CountNumberOfSetBits(number);
        if (currentBitsNumber == bitsNumber)
        {
          if (number > currentMax)
            currentMax = number;
        }
        else
        {
          previousMax = currentMax;
          currentMax = number;
          currentBitsNumber = bitsNumber;
        }

        if (number < previousMax)
          return false;
      }

      return true;
    }

    public static int CountNumberOfSetBits(int number)
    {
      var result = 0;
      while (number > 0)
      {
        result += number % 2;
        number >>= 1;
      }

      return result;
    }
  }
}
