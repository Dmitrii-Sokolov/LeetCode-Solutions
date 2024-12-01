namespace Problem1346
{

  /// <summary>
  /// 1346. Check If N and Its Double Exist
  /// https://leetcode.com/problems/check-if-n-and-its-double-exist
  /// 
  /// Difficulty Easy
  /// Acceptance 38.3%
  /// 
  /// Array
  /// Hash Table
  /// Two Pointers
  /// Binary Search
  /// Sorting
  /// </summary>
  public class Solution
  {
    public bool CheckIfExist(int[] numbers)
    {
      var counts = new int[2001];
      for (var i = 0; i < numbers.Length; i++)
      {
        var number = numbers[i];

        if (number % 2 == 0)
        {
          var halfNumberIndex = number / 2 + 1000;
          if (counts[halfNumberIndex] > 0)
            return true;
        }

        var doubleNumberIndex = number * 2 + 1000;
        if (0 <= doubleNumberIndex && doubleNumberIndex <= 2000)
        {
          if (counts[doubleNumberIndex] > 0)
            return true;
        }

        counts[number + 1000]++;
      }

      return false;
    }
  }
}
