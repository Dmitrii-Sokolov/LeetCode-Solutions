namespace Problem670
{

  /// <summary>
  /// 670. Maximum Swap
  /// https://leetcode.com/problems/maximum-swap
  /// 
  /// Difficulty Medium
  /// Acceptance 49.6%
  /// 
  /// Math
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int MaximumSwap(int number)
    {
      if (number <= 9)
        return number;

      var digits = new List<int>();
      while (number > 0)
      {
        digits.Add(number % 10);
        number /= 10;
      }

      for (var first = digits.Count - 1; first > 0; first--)
      {
        var index = first;
        for (var i = 0; i < first; i++)
        {
          if (digits[i] > digits[index])
            index = i;
        }

        if (index != first)
        {
          (digits[index], digits[first]) = (digits[first], digits[index]);
          break;
        }
      }

      for (var i = digits.Count - 1; i >= 0; i--)
        number = number * 10 + digits[i];

      return number;
    }
  }
}
